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
            navigator.GoToHomePage();
            loginHelper.Login(new AccountData("admin", "secret"));
            contactHelper.InitContactCreation();
            ContactData contact = new ContactData("Joe", "Wilson");
            contact.middlename = "Second";
            contact.company = "IBM";
            contact.email = "superjoe@joe.com";
            contactHelper.FillContactForm(contact);
            contactHelper.SubmitContactCreation();
            contactHelper.ReturnToHomePage();
        }
    }
}
