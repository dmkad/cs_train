using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace addressbook_wt.tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            double total = 1500;
            bool vipclient = false;

            if (total > 1000 && vipclient)
            {
                total = total * 0.9;
                System.Console.Out.Write("Скидка 10%, общая сумма " + total);
            }
            else
            {
                System.Console.Out.Write("Скидки нет, общая сумма " + total);

            }
        }
    }
}
