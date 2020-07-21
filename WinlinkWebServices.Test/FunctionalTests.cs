using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WinlinkWebServices.Test
{
    [TestClass]
    public class FunctionalTests
    {
        [TestInitialize]
        public void TextFixtureSetUp()
        {
            //TODO: Enter a valid access key enabled for the below service requests before running the tests
            var config = new WinlinkWebServiceConfiguration { WebServiceAccessKey = "4242", WebServicesHost = "http://cms-z.winlink.org" };
            WinlinkWebServices.SetConfiguration(config);
        }

        [TestMethod]
        public void AccountExistsTest()
        {
            var response = WinlinkWebServices.AccountExists("ZZ0TST");
            Console.WriteLine($"Response: {response}");
        }

        [TestMethod]
        public async Task AccountExistsAsyncTest()
        {
            var response = await WinlinkWebServices.AccountExistsAsync("ZZ0TST");
            Console.WriteLine($"Response: {response}");
        }

        [TestMethod]
        public void AccountTacticalExistsTest()
        {
            var response = WinlinkWebServices.AccountTacticalExists("TACTICAL");
            Console.WriteLine($"Response: {response}");
        }

        [TestMethod]
        public async Task AccountTacticalExistsAsyncTest()
        {
            var response = await WinlinkWebServices.AccountTacticalExistsAsync("TACTICAL");
            Console.WriteLine($"Response: {response}");
        }

        [TestMethod]
        public void AddGatewayChannelTest()
        {
            WinlinkWebServices.AddGatewayChannel("ZZ0TST-10", "ZZ0TST", "DM78QX", 145000, 0, 1200, 50, 25, 3, 0, "24-7", "PUBLIC");
        }

        [TestMethod]
        public async Task AddGatewayChannelAsyncTest()
        {
            await WinlinkWebServices.AddGatewayChannelAsync("ZZ0TST-10", "ZZ0TST", "DM78QX", 145000, 0, 1200, 50, 25, 3, 0, "24-7", "PUBLIC");
        }

        //AddMultipleGatewayChannels
        //!!!

        [TestMethod]
        public void AddProgramVersionTest()
        {
            WinlinkWebServices.AddProgramVersion("ZZ0TST", "RMS Relay", "1.0.0");
        }

        [TestMethod]
        public async Task AddProgramVersionAsyncTest()
        {
            await WinlinkWebServices.AddProgramVersionAsync("ZZ0TST", "RMS Relay", "1.0.0");
        }

        //AddSysop
        //AddSessionRecord
        //AddTacticalAddress
        //!!!

        [TestMethod]
        public void GetChannelListingTest()
        {
            var response = WinlinkWebServices.GetChannelListing(new List<int> { 0 });
            Console.WriteLine($"Record Count: {response.Count}");
        }

        [TestMethod]
        public async Task GetChannelListingAsyncTest()
        {
            var response = await WinlinkWebServices.GetChannelListingAsync(new List<int> { 50, 51 });
            Console.WriteLine($"Record Count: {response.Count}");
        }

        //GetChannelRecords
        //LookupLicense
        //SendAccountPassword
        //!!!

    }
}
