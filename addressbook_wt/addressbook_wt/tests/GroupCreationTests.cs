﻿using System;
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

            List<GroupData> oldGroups = app.Groups.GetGroupList();

            app.Groups.Create(group);

            Assert.AreEqual(oldGroups.Count + 1, app.Groups.GetGroupCount());

            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups.Add(group);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }

        [Test]
        public void EmptyGroupCreationTest()
        {
            GroupData group = new GroupData("");
            group.Header = "";
            group.Footer = "";

            List<GroupData> oldGroups = app.Groups.GetGroupList();

            app.Groups.Create(group);

            Assert.AreEqual(oldGroups.Count + 1, app.Groups.GetGroupCount());

            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups.Add(group);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }

        [Test]
        public void BadNameGroupCreationTest()
        {
            GroupData group = new GroupData("a'a");
            group.Header = "";
            group.Footer = "";

            List<GroupData> oldGroups = app.Groups.GetGroupList();

            app.Groups.Create(group);

            Assert.AreEqual(oldGroups.Count + 1, app.Groups.GetGroupCount());

            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups.Add(group);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreNotEqual(oldGroups, newGroups);
        }

        [Test]
        public void TenGroupCreationTest()
        {
            int i = 0;
            while (i != 10)
            {
                GroupData group = new GroupData("aaa");
                group.Header = "bbb";
                group.Footer = "ccc";
                List<GroupData> oldGroups = app.Groups.GetGroupList();

                app.Groups.Create(group);

                Assert.AreEqual(oldGroups.Count + 1, app.Groups.GetGroupCount());

                List<GroupData> newGroups = app.Groups.GetGroupList();
                oldGroups.Add(group);
                oldGroups.Sort();
                newGroups.Sort();
                Assert.AreEqual(oldGroups, newGroups);
                i++;
            }
        }
    }
}
