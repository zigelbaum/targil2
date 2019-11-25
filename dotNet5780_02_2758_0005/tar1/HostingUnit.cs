using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tar1
{
    class HostingUnit: IComparable
    {
        private static Int32 _stSerialKey = 10000000;
        private readonly Int32 _HostingUnitKey;
        private bool[,] _Diary;





        /*  public bool[,] Diary { get => _Diary;}  !!!!!!!11!  */

        public int HostingUnitKey => _HostingUnitKey;

        public HostingUnit()
        {
            _HostingUnitKey = _stSerialKey;
            _stSerialKey++;
            _Diary = new bool[12, 31];

            for (Int32 i = 0; i < 12; i++)
                for (Int32 j = 0; j < 31; j++)
                    _Diary[i, j] = false;
        }//constructor

        private DateTime Occupied(DateTime d)
        {
            DateTime end;
            for (int i = d.Month - 1; i < 12; i++)
            {
                int j;
                if (i == d.Month)
                    j = d.Day;
                else
                    j = 0;
                for (; j < 31; j++)
                {
                    if (!_Diary[i, j])
                    {
                        if (j != 0)
                            end = new DateTime(d.Year, i, j);
                        else
                            end = new DateTime(d.Year, i - 1, 31);
                        return end;
                    }
                }
            }
            end = new DateTime(d.Year, 12, 31);
            return end;
        }

        public override string ToString()
        {
            DateTime d;
            string s = "Hosting Unit Key: " + HostingUnitKey + "\n";
            s += "days occupied: ";
            for (int k = 0; k < 12; k++)
                for (int j = 0; j < 31; j++)
                {
                    if (_Diary[k, j])
                    {
                        d = new DateTime(2019, k + 1, j + 1);
                        s += d.ToString();
                        d = Occupied(d);
                        s += "-" + d.ToString();
                        k = d.Month - 1;
                        j = d.Day - 1;
                    }


                }
            return s;
        }

        public int GetAnnualBusyDays()//returns number of occupied days during the year
        {
            int i = 0;
            for (int k = 0; k < 12; k++)
                for (int j = 0; j < 31; j++)
                {
                    if (_Diary[k, j] == true)
                        i++;
                }
            return i;
        }

        public float GetAnnualBusyPercentage()
        {
            float percetage;
            percetage = (float)GetAnnualBusyDays() * 100 / (12 * 31);
            return percetage;
        }

        public bool ApproveRequest(GuestRequest guestReq)
        {
            TimeSpan d = guestReq.RealesedDate- guestReq.EntryDate;
            Int32 i = guestReq.EntryDate.Month - 1;
            Int32 j = guestReq.EntryDate.Day - 1;
            for (int k = 0; k < d.Days; k++)
            {
                if (j > 30)
                {
                    j = 0;
                    i++;
                }
                if (_Diary[i, j] == true)
                {
                    guestReq.IsApproved = false;
                    return false;
                }
                j++;
            }
            guestReq.IsApproved = true;

            i = guestReq.EntryDate.Month - 1;
            j = guestReq.EntryDate.Day - 1;

            for (int k = 0; k < d.Days; k++)
            {
                if (j > 30)
                {
                    j = 0;
                    i++;
                }
                _Diary[i, j] = true;
                j++;
            }
            return true;
        }

        public int CompareTo(object obj)
        {
            return this.GetAnnualBusyDays().CompareTo((obj as HostingUnit).GetAnnualBusyDays());
        }

    }
}
