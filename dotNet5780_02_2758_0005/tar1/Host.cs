using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tar1
{
    class Host:IEnumerable
    {
        private long hosttKey;
        private List<HostingUnit> hostingUnitCollection;


        public Host(Int32 hosttKey, Int32 numUnits)//ctor
        {
            this.hosttKey = hosttKey;
            HostingUnitCollection = new List<HostingUnit>();
            for (int i = 0; i < numUnits; i++)
            {
                HostingUnitCollection.Add(new HostingUnit());
            }
        }

        public long HosttKey { get => hosttKey; set => hosttKey = value; }

        internal List<HostingUnit> HostingUnitCollection { get => hostingUnitCollection; private set => hostingUnitCollection = value; }

        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < HostingUnitCollection.Count; i++)
                yield return HostingUnitCollection[i];
        }

        public override string ToString()
        {
            string str = "";
            foreach (HostingUnit hu in HostingUnitCollection)
            {
                str += hu.ToString();
            }
            return str;
        }

        private long SubmitRequest(GuestRequest guestReq)//return the hostunitkey if avlb else -1
        {

            foreach (HostingUnit item in hostingUnitCollection)
            {
                if (item.ApproveRequest(guestReq))
                    return item.HostingUnitKey;
            }
            return -1;
        }

        public int GetHostAnnualBusyDays()
        {
            int andays = 0;
            foreach (HostingUnit item in hostingUnitCollection)
            {
                andays += item.GetAnnualBusyDays();
            }
            return andays;
        }

        //sort the hosting units according to their annual busy days
        public void SortUnits()
        {
            hostingUnitCollection.Sort();
        }

        //trying to approve list of requests
        public bool AssignRequests(params GuestRequest[] guereq)
        {
            foreach (GuestRequest item in guereq)
            {
                if (SubmitRequest(item) == -1)
                    return false;
            }
            return true;
        }

        //indexer
        public HostingUnit this[Int32 index]
        {
            get
            {
                if (index < 0 || index > hostingUnitCollection.Count)
                    return null;
                return hostingUnitCollection[index];
            }
            //set
            //{
            //    if (index < HostingUnitCollection.Count && index > 0)
            //HostingUnitCollection [index] = value;
            //}
        }

    }
}
