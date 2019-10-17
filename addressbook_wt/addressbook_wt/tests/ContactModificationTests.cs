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
            ContactData newContact = new ContactData("John", "SuperJohn");
            newContact.Middlename = "Middle";
           // newContact.Lastname = "Lastname";
            newContact.Company = "vvvvvvvvvvvvvo";
            newContact.email = null;

            app.Contacts.TestContactPresent();

            List<ContactData> oldContacts = app.Contacts.GetContactList();
            ContactData oldData = oldContacts[0];

            app.Contacts.Modify(0, newContact);

            List<ContactData> newContacts = app.Contacts.GetContactList();
            oldContacts[0].Firstname = newContact.Firstname;
            oldContacts[0].Lastname = newContact.Lastname;
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);

            foreach (ContactData contact in newContacts)
            {
                if (contact.Id == newContact.Id)
                {
                    Assert.AreEqual(newContact.Lastname, contact.Lastname);
                    Assert.AreEqual(newContact.Firstname, contact.Firstname);
                }
            }
        }
    }
}
