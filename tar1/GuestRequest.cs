using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tar1
{
    class GuestRequest
    {

        private DateTime entryDate;
        private DateTime realesedDate;
        private bool isApproved;

        public DateTime EntryDate { get => entryDate; set => entryDate = value; }
        public DateTime RealesedDate { get => realesedDate; set => realesedDate = value; }
        public bool IsApproved { get => isApproved; set => isApproved = value; }

        public GuestRequest(DateTime entryDate, DateTime realesedDate)
        {
            EntryDate = entryDate;
            RealesedDate = realesedDate;
            isApproved = false;
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
