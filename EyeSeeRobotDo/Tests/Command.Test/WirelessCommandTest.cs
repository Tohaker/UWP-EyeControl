using System;
using System.Collections.Generic;
using Communication;
using Xunit;

namespace Command.Test
{
    public class WirelessCommandTest
    {
        [Fact]
        public void ConstructStatusCheckTest()
        {
            WirelessCommand command = new WirelessCommand("hand.dev");
            string expected = "hand.dev/";

            string actual = command.StatusCheck();

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(new int[] { 0, 0, 0, 0 }, "0")]
        [InlineData(new int[] { 1, 0, 0, 0 }, "1")]
        [InlineData(new int[] { 0, 1, 0, 0 }, "2")]
        [InlineData(new int[] { 0, 0, 1, 0 }, "4")]
        [InlineData(new int[] { 0, 0, 0, 1 }, "8")]
        [InlineData(new int[] { 1, 1, 1, 1 }, "15")]
        [InlineData(new int[] { 1, 0, 0, 1 }, "9")]
        public void ConstructReleaseFingersTest(int[] selectedFingers, string expectedFingers)
        {
            WirelessCommand command = new WirelessCommand("hand.dev");
            string expected = String.Format("hand.dev/move?fingers={0}&hold=false", expectedFingers);

            string actual = command.MoveFingers(selectedFingers, false);

            Assert.Equal(expected, actual);
        }
    }
}
