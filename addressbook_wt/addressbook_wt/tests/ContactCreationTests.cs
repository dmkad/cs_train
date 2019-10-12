using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreationTests : AuthTestBase
    {
        
        [Test]
        public void ContactCreationTest()
        {
            ContactData contact = new ContactData("Joe", "Wilson");
            contact.middlename = "Second";
            contact.company = "IBM";
            contact.email = "superjoe@joe.com";

            app.Contacts.Create(contact);
        }

        [Test]
        public void EmptyContactCreationTest()
        {
            ContactData contact = new ContactData("", "");
            contact.middlename = "";
            contact.company = "";
            contact.email = "";

            app.Contacts.Create(contact);
        }
    }
}
