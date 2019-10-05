using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreationTests : TestBase
    {
        
        [Test]
        public void ContactCreationTest()
        {
            GoToHomePage();
            Login(new AccountData("admin", "secret"));
            InitContactCreation();
            ContactData contact = new ContactData("Joe", "Wilson");
            contact.middlename = "Second";
            contact.company = "IBM";
            contact.email = "superjoe@joe.com";
            FillContactForm(contact);
            SubmitContactCreation();
            ReturnToHomePage();
        }
    }
}
