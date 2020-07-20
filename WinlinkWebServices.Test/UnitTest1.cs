using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WinlinkWebServices.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestInitialize]
        public void TextFixtureSetUp()
        {
            var config = new WinlinkWebServiceConfiguration { WebServiceAccessKey = "xxx", WebServicesHost = "http://cms-z.winlink.org" };
            WinlinkWebServices.SetConfiguration(config);
        }

        [TestMethod]
        public void ChannelListingTest()
        {
            var response = WinlinkWebServices.GetChannelListing(new List<int> { 0 });
            Console.WriteLine($"Record Count: {response.Count}");
        }


        [TestMethod]
        public async Task ChannelListingAsyncTest()
        {
            var response = await WinlinkWebServices.GetChannelListingAsync(new List<int> { 50, 51 });
            Console.WriteLine($"Record Count: {response.Count}");
        }


    }
}
