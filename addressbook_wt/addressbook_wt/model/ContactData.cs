using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    public class ContactData
    {
        public ContactData(string firstname, string lastname)
        {
            this.firstname = firstname;
            this.lastname = lastname;
        }

        public string firstname { get; set; }
        public string middlename { get; set; } = "";
        public string lastname { get; set; }
        public string title { get; set; } = "";
        public string company { get; set; } = "";
        public string address { get; set; } = "";
        public string home { get; set; } = "";
        public string mobile { get; set; } = "";
        public string work { get; set; } = "";
        public string fax { get; set; } = "";
        public string email { get; set; } = "";
        public string email2 { get; set; } = "";
        public string email3 { get; set; } = "";
        public string homepage { get; set; } = "";
        public string bday { get; set; } = "";
        public string bmonth { get; set; } = "-";
        public string byear { get; set; } = "";
        public string aday { get; set; } = "";
        public string amonth { get; set; } = "-";
        public string ayear { get; set; } = "";
        public string address2 { get; set; } = "";
        public string phone2 { get; set; } = "";
        public string notes { get; set; } = "";
    }
}
