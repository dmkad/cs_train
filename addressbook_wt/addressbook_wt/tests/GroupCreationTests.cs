using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupCreationTests : AuthTestBase
    {
        
        [Test]
        public void GroupCreationTest()
        {
            GroupData group = new GroupData("group1");
            group.Header = "group2";
            group.Footer = "group3";

            List<GroupData> oldgroups = app.Groups.GetGroupList();

            app.Groups.Create(group);

            List<GroupData> newgroups = app.Groups.GetGroupList();
            Assert.AreEqual(oldgroups.Count + 1, newgroups.Count);
        }

        [Test]
        public void EmptyGroupCreationTest()
        {
            GroupData group = new GroupData("");
            group.Header = "";
            group.Footer = "";

            List<GroupData> oldgroups = app.Groups.GetGroupList();

            app.Groups.Create(group);

            List<GroupData> newgroups = app.Groups.GetGroupList();
            Assert.AreEqual(oldgroups.Count + 1, newgroups.Count);
        }

        [Test]
        public void BadNameGroupCreationTest()
        {
            GroupData group = new GroupData("a'a");
            group.Header = "";
            group.Footer = "";

            List<GroupData> oldgroups = app.Groups.GetGroupList();

            app.Groups.Create(group);

            List<GroupData> newgroups = app.Groups.GetGroupList();
            Assert.AreNotEqual(
                oldgroups.Count + 1, newgroups.Count);
        }

        [Test]
        public void TenGroupCreationTest()
        {
            int i = 0;
            while (i != 10)
            {
                GroupData group = new GroupData("tengroup " + i);
                group.Header = "tengroup" + i;
                group.Footer = "tengroup" + i;
                List<GroupData> oldgroups = app.Groups.GetGroupList();

                app.Groups.Create(group);

                List<GroupData> newgroups = app.Groups.GetGroupList();
                Assert.AreEqual(oldgroups.Count + 1, newgroups.Count);
                i++;
            }
        }
    }
}
