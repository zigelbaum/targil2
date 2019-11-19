using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tar1
{
    class Host
    {
        private int hosttKey;
        public List<HostingUnit> HostingUnitCollection;

        public Host(int hosttKey, int numUnits)//ctor
        {
            this.hosttKey = hosttKey;
            for (int i = 0; i < numUnits; i++)
            {
                HostingUnitCollection.Add(new HostingUnit());
            }
        }

        public int HosttKey { get => hosttKey; set => hosttKey = value; }

        public override string ToString()
        {
            string str;
            foreach(HostingUnit hu in HostingUnitCollection)
            {
               str += hu.ToString();
            }
            return str;
        }

        private long SubmitRequest(GuestRequest guestReq)
        {
            while ()
        }
    }
}
