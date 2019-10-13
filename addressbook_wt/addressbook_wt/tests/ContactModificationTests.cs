using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactModificationTests : AuthTestBase
    {
        [Test]
        public void ContactModificationTest()
        {
            ContactData newData = new ContactData("John", "Wood");
            newData.middlename = null;
            newData.company = "vvvvvvvvvvvvvo";
            newData.email = null;

            app.Contacts.TestContactPresent();

            List<ContactData> oldContacts = app.Contacts.GetContactList();

            app.Contacts.Modify(0, newData);

            List<ContactData> newContacts = app.Contacts.GetContactList();
            oldContacts[0].firstname = newData.firstname;
            oldContacts[0].lastname = newData.lastname;
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}
