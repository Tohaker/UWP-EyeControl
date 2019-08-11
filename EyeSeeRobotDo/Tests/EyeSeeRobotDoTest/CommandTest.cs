
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EyeSeeRobotDoTest
{
    [TestClass]
    public class CommandTest
    {
        [TestMethod]
        public void ConstructWirelessStatusCheckTest()
        {
            Command command = new Command(Communication.Wireless, "hand.dev");
            String expected = "hand.dev/";

            String actual = command.StatusCheck();

            Assert.AreEqual(expected, actual);
        }
    }
}
