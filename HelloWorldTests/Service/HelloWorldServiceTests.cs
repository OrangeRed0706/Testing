using HelloWorld.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HelloWorldTests.Service
{
    [TestClass()]
    public class HelloWorldServiceTests
    {
        private readonly HelloWorldService _helloWorldService;

        public HelloWorldServiceTests()
        {
            _helloWorldService = new HelloWorldService();
        }

        [TestMethod()]
        public void GetHelloWorldTest()
        {
            var result = _helloWorldService.GetHelloWorld();
            Assert.AreEqual("Hello World!", result);
        }
    }
}
