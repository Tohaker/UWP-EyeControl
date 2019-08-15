using Communication;
using System;
using Xunit;

namespace Command.Test
{
    public class SerialCommandTest
    {
        [Fact]
        public void ConstructStatusCheckTest()
        {
            SerialCommand command = new SerialCommand("COM1");
            String expected = "0";

            String actual = command.StatusCheck();

            Assert.Equal(expected, actual);
        }
    }
}
