using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        private string allPhones;

        public ContactData(string firstname, string lastname)
        {
            Firstname = firstname;
            Lastname = lastname;
        }

        public bool Equals(ContactData other)
        {
            if (object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (object.ReferenceEquals(this, other))
            {
                return true;
            }
            return Firstname == other.Firstname && Lastname == other.Lastname;
        }
        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }

        public override string ToString()
        {
            return string.Concat(Firstname, " ", Lastname);
        }

        public int CompareTo(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            if (Lastname.CompareTo(other.Lastname) == 0)
            {
                return Firstname.CompareTo(other.Firstname);
            }
            return Lastname.CompareTo(other.Lastname);
        }
        //public int CompareTo(ContactData other)
        //{
        //    if (Object.ReferenceEquals(other, null))
        //    {
        //        return 1;
        //    }
        //    return ToString().CompareTo(other.ToString());
        //}



        public string Id { get; set; }
        public string Firstname { get; set; }
        public string Middlename { get; set; } = "";
        public string Lastname { get; set; } = "";
        public string title { get; set; } = "";
        public string Company { get; set; } = "";
        public string Address { get; set; } = "";
        public string HomePhone { get; set; } = "";
        public string MobilePhone { get; set; } = "";
        public string WorkPhone { get; set; } = "";
        public string AllPhones 
        { 
            get { 
                if (allPhones != null)
                {
                    return allPhones;
                }
                else
                {
                    return (CleanUp(HomePhone) + CleanUp(MobilePhone) + CleanUp(WorkPhone)).Trim();
                }

            } 
            set {
                allPhones = value;

            } 
        }

        private string CleanUp(string phone)
        {
            if (phone == null || phone == "")
            {
                return "";
            }
            return phone.Replace(" ", "").Replace("-", "").Replace("(", "").Replace(")", "") + "\r\n";
        }

        public string Fax { get; set; } = "";
        public string email { get; set; } = "";
        public string email2 { get; set; } = "";
        public string email3 { get; set; } = "";
        public string HomePage { get; set; } = "";
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
