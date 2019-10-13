using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupRemovalTests : AuthTestBase
    {
        
        [Test]
        public void GroupRemovalTest()
        {
            List<GroupData> oldgroups = app.Groups.GetGroupList();


            app.Groups.TestGroupPresent();
            app.Groups.Remove(0);

            List<GroupData> newGroups = app.Groups.GetGroupList();

            oldgroups.RemoveAt(0);
            Assert.AreEqual(oldgroups, newGroups);
        }
    }
}
 