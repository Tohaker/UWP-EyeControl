using System;
using Communication;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CommunicationTest
{
    [TestClass]
    public class CommandTest
    {
        [TestMethod]
        public void ConstructWirelessStatusCheckTest()
        {
            WirelessCommand command = new WirelessCommand("hand.dev");
            String expected = "hand.dev/";

            String actual = command.StatusCheck();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ConstructSerialStatusCheckTest()
        {
            SerialCommand command = new SerialCommand("COM1");
            String expected = "0";

            String actual = command.StatusCheck();

            Assert.AreEqual(expected, actual);
        }
    }
}
