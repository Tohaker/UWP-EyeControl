using System;
using System.Collections.Generic;
using Xunit;
using WireMock.Server;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;

namespace Command.Test
{
    public class WirelessCommandTest
    {
        public FluentMockServer mockServer { get; private set; }

        private void StartMockServer()
        {
            mockServer = FluentMockServer.Start();
            mockServer
                .Given(Request.Create().WithPath("/").UsingGet())
                .RespondWith(Response.Create()
                    .WithStatusCode(200)
                    .WithHeader("Content-Type", "application/json")
                    .WithBody("{ \"status\": \"success\" }")
                    .WithDelay(TimeSpan.FromSeconds(1)
                    )
                );
        }

        private void StopMockServer()
        {
            mockServer.Stop();
        }

        [Fact]
        public void ConstructStatusCheckTest()
        {
            WirelessCommand command = new WirelessCommand("hand.dev");
            string expected = "http://hand.dev/";

            string actual = command.StatusCheck();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ReceiveSuccessfulStatusCheck()
        {
            StartMockServer();

            WirelessCommand command = new WirelessCommand("localhost:" + mockServer.Ports[0]);
            Dictionary<string, string> actual = new Dictionary<string, string>();
            string expected = "success";

            actual = command.Request(command.StatusCheck()).GetAwaiter().GetResult();

            Assert.Equal(expected, actual["status"]);

            StopMockServer();
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
            string expected = String.Format("http://hand.dev/move?fingers={0}&hold=false", expectedFingers);

            string actual = command.MoveFingers(selectedFingers, false);

            Assert.Equal(expected, actual);
        }

        // We only need to test a couple of the finger sets as the main bulk are tested 
        // in the previous test.
        [Theory]
        [InlineData(new int[] { 0, 0, 0, 0 }, "0")]
        [InlineData(new int[] { 1, 1, 1, 1 }, "15")]
        public void ConstructHoldFingersTest(int[] selectedFingers, string expectedFingers)
        {
            WirelessCommand command = new WirelessCommand("hand.dev");
            string expected = String.Format("http://hand.dev/move?fingers={0}&hold=true", expectedFingers);

            string actual = command.MoveFingers(selectedFingers, true);

            Assert.Equal(expected, actual);
        }
    }
}
