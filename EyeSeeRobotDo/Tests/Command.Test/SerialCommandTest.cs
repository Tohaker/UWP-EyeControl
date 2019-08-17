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

        [Theory]
        [InlineData(new int[] { 0, 0, 0, 0 }, "0")]
        [InlineData(new int[] { 1, 0, 0, 0 }, "1")]
        [InlineData(new int[] { 0, 1, 0, 0 }, "2")]
        [InlineData(new int[] { 0, 0, 1, 0 }, "4")]
        [InlineData(new int[] { 0, 0, 0, 1 }, "8")]
        [InlineData(new int[] { 1, 1, 1, 1 }, "15")]
        [InlineData(new int[] { 1, 0, 0, 1 }, "9")]
        public void ConstructReleaseFingersTest(int[] selectedFingers, string expected)
        {
            SerialCommand command = new SerialCommand("COM1");

            string actual = command.MoveFingers(selectedFingers, false);

            Assert.Equal(expected, actual);
        }

        // We only need to test a couple of the finger sets as the main bulk are tested 
        // in the previous test.
        [Theory]
        [InlineData(new int[] { 0, 0, 0, 0 }, "16")]
        [InlineData(new int[] { 1, 0, 0, 0 }, "17")]
        [InlineData(new int[] { 0, 1, 0, 0 }, "18")]
        [InlineData(new int[] { 0, 0, 1, 0 }, "20")]
        [InlineData(new int[] { 0, 0, 0, 1 }, "24")]
        [InlineData(new int[] { 1, 1, 1, 1 }, "31")]
        [InlineData(new int[] { 1, 0, 0, 1 }, "25")]
        public void ConstructHoldFingersTest(int[] selectedFingers, string expected)
        {
            SerialCommand command = new SerialCommand("COM1");

            string actual = command.MoveFingers(selectedFingers, true);

            Assert.Equal(expected, actual);
        }
    }
}
