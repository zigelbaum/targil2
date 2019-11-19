using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tar1
{
    class GuestRequest
    {
        
        public DateTime EntryDate;
        public DateTime RealesedDate;
        public bool IsApproved;

        public GuestRequest(DateTime entryDate, DateTime realesedDate, bool isApproved)
        {
            EntryDate = entryDate;
            RealesedDate = realesedDate;
            IsApproved = isApproved;
        }

        public override string ToString()
        {
            string s = "entry Date: " + EntryDate + " realesed Date: " + RealesedDate;
            if (IsApproved == true)
                s += " the request is approved";
            else
                s += " the request has not been approved";
            return s;
        }
    }
}
