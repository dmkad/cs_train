using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactModificationTests : TestBase
    {
        [Test]
        public void ContactModificationTest()
        {
            ContactData newData = new ContactData("Sam", "Wood");
            newData.middlename = "Third";
            newData.company = "MS";
            newData.email = "supersam@ms.com";

            app.Contacts.Modify(1, newData);
        }
    }
}
