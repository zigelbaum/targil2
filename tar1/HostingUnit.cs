using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tar1
{
    class HostingUnit
    {
        private static int _stSerialKey=10000000;
        private readonly int _HostingUnitKey;
        private bool[,] _Diary;

        public static int StSerialKey { get => _stSerialKey; set => _stSerialKey = value; }

        public int HostingUnitKey => _HostingUnitKey;

        public bool[,] Diary { get => _Diary; set => _Diary = value; }

        public HostingUnit()
        { 
            _HostingUnitKey = _stSerialKey;
            _stSerialKey++;
            _Diary = new bool[12, 31];

            for (int i = 0; i < 12; i++)
                for (int j = 0; j < 31; j++)
                    _Diary[i, j] = false;
        }

        private DateTime Occupied(DateTime d)
        {
            DateTime end;
            for (int i = d.Month-1; i < 12; i++)
            {
                int j;
                if (i == d.Month)
                    j = d.Day;
                else
                    j = 0;
                for (; j < 31; j++)
                {
                    if (!_Diary[i,j])
                    {
                        if(j!=0)
                            end = new DateTime(d.Year, i, j);
                        else
                            end = new DateTime(d.Year, i-1 , 31);
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
            string s = "Hosting Unit Key: " + _HostingUnitKey;
            for (int k = 0; k < 12; k++)
                for (int j = 0; j < 31; j++)
                {
                    if (_Diary[k,j])
                    {
                        d = new DateTime(2019, k+1, j+1);
                        s += d.ToString();
                        d = Occupied(d);
                        s += "-" + d.ToString();
                        k = d.Month - 1;
                        j = d.Day - 1;
                    }
                    
                   
                }
            return s;
        }

        public int GetAnnualBusyDays()
        {

        }
    }

   
}
