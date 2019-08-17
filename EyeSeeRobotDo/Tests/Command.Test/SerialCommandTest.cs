using Command;
using Command.Communication;
using Moq;
using System;
using Xunit;

namespace Command.Test
{
    public class SerialCommandTest
    {
        private Mock<ISerialPort> mock;
        public SerialCommandTest()
        {
            mock = new Mock<ISerialPort>();
        }

        [Fact]
        public void ConstructStatusCheckTest()
        {
            ISerialPort port = mock.Object;

            SerialCommand command = new SerialCommand(port);
            string expected = "0";

            string actual = command.StatusCheck();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SendSuccessfulStatusCheckTest()
        {
            string expected = "0";
            mock.Setup(sp => sp.Send(It.Is<string>(s => s.Equals("0")))).Returns(true);
            mock.Setup(sp => sp.Read()).Returns(expected);
            ISerialPort port = mock.Object;

            SerialCommand command = new SerialCommand(port);
            string response = "";

            if(command.SerialPort.Send(command.StatusCheck()))
                response = command.SerialPort.Read();

            Assert.True(command.ValidateResponse(expected, response));
        }

        [Fact]
        public void HandleExceptionOnSendTimeoutTest()
        {
            mock.Setup(sp => sp.Send(It.Is<string>(s => s.Equals("0")))).Returns(true);
            mock.Setup(sp => sp.Read()).Throws(new TimeoutException());
            ISerialPort port = mock.Object;

            SerialCommand command = new SerialCommand(port);
            string response = "";

            if (command.SerialPort.Send(command.StatusCheck()))
                response = command.SerialPort.Read();
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
            ISerialPort port = mock.Object;

            SerialCommand command = new SerialCommand(port);

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
            ISerialPort port = mock.Object;

            SerialCommand command = new SerialCommand(port);

            string actual = command.MoveFingers(selectedFingers, true);

            Assert.Equal(expected, actual);
        }
    }
}
