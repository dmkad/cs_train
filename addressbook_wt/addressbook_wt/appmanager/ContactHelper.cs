using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
    public class ContactHelper : HelperBase
    {
        public ContactHelper(ApplicationManager manager) 
            : base(manager)
        {
        }


        public ContactHelper Create(ContactData contact)
        {
            InitContactCreation();
            FillContactForm(contact);
            SubmitContactCreation();
            ReturnToHomePage();
            return this;
        }

        private List<ContactData> contactCache = null;

        public List<ContactData> GetContactList()
        {
            if (contactCache == null)
            {
                contactCache = new List<ContactData>();
                List<ContactData> contacts = new List<ContactData>();
                ICollection<IWebElement> elements = driver.FindElements(By.XPath("//tr[@name='entry']"));
                foreach (IWebElement element in elements)
                {
                    IList<IWebElement> cells = element.FindElements(By.TagName("td"));
                    var c2 = cells.ElementAt(1).Text;
                    var c3 = cells.ElementAt(2).Text;
                    var contact = new ContactData(c3);
                    contact.lastname = c2;
                    contact.Id = element.FindElement(By.TagName("input")).GetAttribute("value");
                    contactCache.Add(contact);
                }
            }
            return new List<ContactData>(contactCache);
        }

        public int GetContactCount()
        {
            return driver.FindElements(By.XPath("//tr[@name='entry']")).Count;
        }

        public ContactHelper Modify(int p, ContactData newData)
        {
            SelectContact(p);
            InitContactModification();
            FillContactForm(newData);
            SubmitContactModification();
            ReturnToHomePage();
            return this;
        }

        public ContactHelper Remove(int p)
        {
            SelectContact(p);
            RemoveContact();
            driver.SwitchTo().Alert().Accept();
            return this;
        }
        public ContactHelper InitContactCreation()
        {
            driver.FindElement(By.LinkText("add new")).Click();
            return this;
        }
        public ContactHelper FillContactForm(ContactData contact)
        {
            Type(By.Name("firstname"), contact.firstname);
            Type(By.Name("middlename"), contact.middlename);
            Type(By.Name("lastname"), contact.lastname);
            Type(By.Name("title"), contact.title);
            Type(By.Name("company"), contact.company);
            Type(By.Name("address"), contact.address);
            Type(By.Name("home"), contact.home);
            Type(By.Name("mobile"), contact.mobile);
            Type(By.Name("work"), contact.work);
            Type(By.Name("fax"), contact.fax);
            Type(By.Name("email"), contact.email);
            Type(By.Name("email2"), contact.email2);
            Type(By.Name("email3"), contact.email3);
            Type(By.Name("homepage"), contact.homepage);
            Type(By.Name("byear"), contact.byear);
            Type(By.Name("ayear"), contact.ayear);
            Type(By.Name("address2"), contact.address2);
            Type(By.Name("phone2"), contact.phone2);
            Type(By.Name("notes"), contact.notes);
            return this;
        }
        public ContactHelper SubmitContactCreation()
        {
            driver.FindElement(By.XPath("(//input[@name='submit'])[2]")).Click();
            contactCache = null;
            return this;
        }
        public ContactHelper ReturnToHomePage()
        {
            driver.FindElement(By.LinkText("home page")).Click();
            return this;
        }
        public ContactHelper SubmitContactModification()
        {
            driver.FindElement(By.Name("update")).Click();
            contactCache = null;
            return this;
        }

        public ContactHelper InitContactModification()
        {
            driver.FindElement(By.CssSelector("img[alt=\"Edit\"]")).Click();
            return this;
        }
        public ContactHelper SelectContact(int index)
        {
            driver.FindElement(By.CssSelector("#maintable tr[name='entry'] > td:nth-child("+ (index + 1) +")")).Click();
            return this;
        }
        public ContactHelper RemoveContact()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            contactCache = null;
            return this;
        }

        public bool IsContactPresent()
        {
            return IsElementPresent(By.Name("selected[]"))
                && IsElementPresent(By.Id("maintable"));
        }

        public void TestContactPresent()
        {
            if (IsContactPresent() == false)
            {
                ContactData contact = new ContactData("Contact1");
                Create(contact);
            }
        }
    }
}
