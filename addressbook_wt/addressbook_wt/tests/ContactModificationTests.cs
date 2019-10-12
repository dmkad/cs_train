﻿using System;
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

            app.Contacts.Modify(1, newData);
        }
    }
}
