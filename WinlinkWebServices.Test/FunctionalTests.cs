using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ServiceStack.Text;
using winlink;
using winlink.cms.webservices;

namespace WinlinkWebServices.Test
{
    [TestClass]
    public class FunctionalTests
    {
        IConfiguration ConfigSecrets { get; set; }
        private string _testCallsign;
        private string _testPassword;
        private string _testEmail;
        private string _testGrid;
        private string _testZip;
        private string _testTactical;
        private string _testEmailAddress;
        private string _testProgramName;

        [TestInitialize]
        public void TextFixtureSetUp()
        {
            //setup access to secrets.json file
            var builder = new ConfigurationBuilder().AddUserSecrets<FunctionalTests>();
            ConfigSecrets = builder.Build();

            var config = new WinlinkWebServiceConfiguration { WebServiceAccessKey = ConfigSecrets["WebserviceAccessKey"], WebServicesHost = "https://cms-z.winlink.org" };
            winlink.WinlinkWebServices.SetConfiguration(config);

            _testCallsign = ConfigSecrets["TestCallsign"];
            _testPassword = ConfigSecrets["TestPassword"];
            _testEmail = ConfigSecrets["TestEmail"];
            _testGrid = ConfigSecrets["TestGrid"];
            _testZip = ConfigSecrets["TestZip"];
            _testTactical = ConfigSecrets["TestTactical"];
            _testEmailAddress = ConfigSecrets["TestEmailAddress"];
            _testProgramName = ConfigSecrets["TestProgramName"];
        }

        [TestMethod]
        public void AccountExistsTest()
        {
            var response = winlink.WinlinkWebServices.AccountExists(_testCallsign);
            Console.WriteLine(response.Dump());
        }

        [TestMethod]
        public async Task AccountExistsAsyncTest()
        {
            var response = await winlink.WinlinkWebServices.AccountExistsAsync(_testCallsign);
            Console.WriteLine(response.Dump());
        }

        [TestMethod]
        public void AccountTacticalExistsTest()
        {
            var response = winlink.WinlinkWebServices.AccountTacticalExists(_testTactical);
            Console.WriteLine(response.Dump());
        }

        [TestMethod]
        public async Task AccountTacticalExistsAsyncTest()
        {
            var response = await winlink.WinlinkWebServices.AccountTacticalExistsAsync(_testTactical);
            Console.WriteLine(response.Dump());
        }

        [TestMethod]
        public void AddGatewayChannelTest()
        {
            winlink.WinlinkWebServices.AddGatewayChannel(_testCallsign + "-10", _testCallsign, _testGrid, 145000, 0, 1200, 50, 25, 3, 0, "24-7", "PUBLIC");
        }

        [TestMethod]
        public async Task AddGatewayChannelAsyncTest()
        {
            await winlink.WinlinkWebServices.AddGatewayChannelAsync(_testCallsign + "-10", _testCallsign, _testGrid, 145000, 0, 1200, 50, 25, 3, 0, "24-7", "PUBLIC");
        }

        [TestMethod]
        public void AddMultipleGatewayChannelsTest()
        {
            var records = new List<PartialChannelRecord>();
            records.Add(new PartialChannelRecord { Frequency = 145000, ProtocolMode = 0, Baud = 1200, Power = 50, Height = 25, Gain = 3, Direction = 0 });
            records.Add(new PartialChannelRecord { Frequency = 147000, ProtocolMode = 0, Baud = 1200, Power = 50, Height = 25, Gain = 3, Direction = 0 });
            winlink.WinlinkWebServices.AddMultipleGatewayChannels(_testCallsign + "-10", _testCallsign, _testGrid, "PUBLIC", "24-7", records);
        }

        [TestMethod]
        public async Task AddMultipleGatewayChannelsAsyncTest()
        {
            var records = new List<PartialChannelRecord>();
            records.Add(new PartialChannelRecord { Frequency = 145000, ProtocolMode = 0, Baud = 1200, Power = 50, Height = 25, Gain = 3, Direction = 0 });
            records.Add(new PartialChannelRecord { Frequency = 147000, ProtocolMode = 0, Baud = 1200, Power = 50, Height = 25, Gain = 3, Direction = 0 });
            await winlink.WinlinkWebServices.AddMultipleGatewayChannelsAsync(_testCallsign + "-10", _testCallsign, _testGrid, "PUBLIC", "24-7", records);
        }

        [TestMethod]
        public void AddProgramVersionTest()
        {
            winlink.WinlinkWebServices.AddProgramVersion(_testCallsign, _testProgramName, "1.0.0", "");
        }

        [TestMethod]
        public async Task AddProgramVersionAsyncTest()
        {
            await winlink.WinlinkWebServices.AddProgramVersionAsync(_testCallsign, _testProgramName, "1.0.0", "");
        }

        [TestMethod]
        public void AddSessionRecordTest()
        {
            winlink.WinlinkWebServices.AddSessionRecord("BPQ32", "6.0.20.1", "K2WVC", "DN30XQ", "K2WVC-1", "", "[BPQ-6.0.20.1-B2FIHJM$]", "PKT12", 0, "", 1, 0, 499, 0, 2, "00006A97187");
        }

        [TestMethod]
        public async Task AddSessionRecordAsyncTest()
        {
            await winlink.WinlinkWebServices.AddSessionRecordAsync("BPQ32", "6.0.20.1", "K2WVC", "DN30XQ", "K2WVC-1", "", "[BPQ-6.0.20.1-B2FIHJM$]", "PKT12", 0, "", 1, 0, 499, 0, 2, "00006A97187");
        }

        [TestMethod]
        public void AddSysopTest()
        {
            winlink.WinlinkWebServices.AddSysop(_testCallsign, _testPassword, _testGrid, "Sam Iam", "A Street", "", "Some City", "CO", "USA", _testZip, _testEmail, "", "www.winlink.org", "comments");
        }

        [TestMethod]
        public async Task AddSysopAsyncTest()
        {
            await winlink.WinlinkWebServices.AddSysopAsync(_testCallsign, _testPassword, _testGrid, "Sam Iam", "A Street", "", "Some City", "CO", "USA", _testZip, _testEmail, "", "www.winlink.org", "comments");
        }

        [TestMethod]
        public void AddTacticalAddressTest()
        {
            winlink.WinlinkWebServices.AddTacticalAddress(_testTactical);
        }

        [TestMethod]
        public async Task AddTacticalAddressAsyncTest()
        {
            await winlink.WinlinkWebServices.AddTacticalAddressAsync(_testTactical);
        }

        [TestMethod]
        public void ChangePasswordTest()
        {
            winlink.WinlinkWebServices.ChangePassword(_testCallsign, _testPassword, _testPassword + "1");
            winlink.WinlinkWebServices.ChangePassword(_testCallsign, _testPassword + "1", _testPassword);
        }

        [TestMethod]
        public async Task ChangePasswordAsyncTest()
        {
            await winlink.WinlinkWebServices.ChangePasswordAsync(_testCallsign, _testPassword, _testPassword + "1");
            await winlink.WinlinkWebServices.ChangePasswordAsync(_testCallsign, _testPassword + "1", _testPassword);
        }

        [TestMethod]
        public void DeleteWatchTest()
        {
            winlink.WinlinkWebServices.SetWatch(_testCallsign, _testPassword, _testProgramName, 4, _testEmailAddress);
            winlink.WinlinkWebServices.DeleteWatch(_testCallsign, _testPassword, _testProgramName);
        }

        [TestMethod]
        public async Task DeleteWatchAsyncTest()
        {
            await winlink.WinlinkWebServices.SetWatchAsync(_testCallsign, _testPassword, _testProgramName, 4, _testEmailAddress);
            await winlink.WinlinkWebServices.DeleteWatchAsync(_testCallsign, _testPassword, _testProgramName);
        }

        [TestMethod]
        public void GetChannelListingTest()
        {
            var response = winlink.WinlinkWebServices.GetChannelListing(new List<int> { 0 });
            Console.WriteLine(response.Dump());
        }

        [TestMethod]
        public async Task GetChannelListingAsyncTest()
        {
            var response = await winlink.WinlinkWebServices.GetChannelListingAsync(new List<int> { 50, 51 });
            Console.WriteLine(response.Dump());
        }

        [TestMethod]
        public void GetChannelRecordsTest()
        {
            var response = winlink.WinlinkWebServices.GetChannelRecords(_testCallsign);
            Console.WriteLine(response.Dump());
        }

        [TestMethod]
        public async Task GetChannelRecordsAsyncTest()
        {
            var response = await winlink.WinlinkWebServices.GetChannelRecordsAsync(_testCallsign);
            Console.WriteLine(response.Dump());
        }

        [TestMethod]
        public void GetGatewayStatusRecordsTest()
        {
            var response = winlink.WinlinkWebServices.GetGatewayStatusRecords(GatewayOperatingMode.VARAFM, 24, "PUBLIC");
            Console.WriteLine(response.Dump());
        }

        [TestMethod]
        public async Task GetGatewayStatusRecordsAsyncTest()
        {
            var response = await winlink.WinlinkWebServices.GetGatewayStatusRecordsAsync(GatewayOperatingMode.VARAFM, 24, "PUBLIC");
            Console.WriteLine(response.Dump());
        }

        [TestMethod]
        public void GetWatchTest()
        {
            winlink.WinlinkWebServices.SetWatch(_testCallsign, _testPassword, _testProgramName, 4, _testEmailAddress);
            var response = winlink.WinlinkWebServices.GetWatch(_testCallsign, _testPassword, _testProgramName);
            Console.WriteLine(response.Dump());
        }

        [TestMethod]
        public async Task GetWatchAsyncTest()
        {
            await winlink.WinlinkWebServices.SetWatchAsync(_testCallsign, _testPassword, _testProgramName, 4, _testEmailAddress);
            var response = await winlink.WinlinkWebServices.GetWatchAsync(_testCallsign, _testPassword, _testProgramName);
            Console.WriteLine(response.Dump());
        }

        [TestMethod]
        public void GetWatchListTest()
        {
            var response = winlink.WinlinkWebServices.GetWatchList(_testCallsign, _testPassword);
            Console.WriteLine(response.Dump());
        }

        [TestMethod]
        public async Task GetWatchListTaskAsyncTest()
        {
            var response = await winlink.WinlinkWebServices.GetWatchListAsync(_testCallsign, _testPassword);
            Console.WriteLine(response.Dump());
        }

        [TestMethod]
        public void LookupLicenseTest()
        {
            var response = winlink.WinlinkWebServices.LookupLicense(_testCallsign);
            Console.WriteLine(response.Dump());
        }

        [TestMethod]
        public async Task LookupLicenseAsyncTest()
        {
            var response = await winlink.WinlinkWebServices.LookupLicenseAsync(_testCallsign);
            Console.WriteLine(response.Dump());
        }

        [TestMethod]
        public void PingWatchTest()
        {
            winlink.WinlinkWebServices.SetWatch(_testCallsign, _testPassword, _testProgramName, 4, _testEmailAddress);
            winlink.WinlinkWebServices.PingWatch(_testCallsign, _testProgramName);
        }

        [TestMethod]
        public async Task PingWatchAsyncTest()
        {
            await winlink.WinlinkWebServices.SetWatchAsync(_testCallsign, _testPassword, _testProgramName, 4, _testEmailAddress);
            await winlink.WinlinkWebServices.PingWatchAsync(_testCallsign, _testProgramName);
        }

        [TestMethod]
        public void ProtocolModeMappingsTest()
        {
            var response = winlink.WinlinkWebServices.ProtocolModeMappings();
            Console.WriteLine(response.Dump());
        }

        [TestMethod]
        public void SendPasswordTest()
        {
            winlink.WinlinkWebServices.SendPassword(_testCallsign);
        }

        [TestMethod]
        public async Task SendPasswordAsyncTest()
        {
            await winlink.WinlinkWebServices.SendPasswordAsync(_testCallsign);
        }

        [TestMethod]
        public void SetPasswordRecoveryEmailTest()
        {
            winlink.WinlinkWebServices.SetPasswordRecoveryEmail(_testCallsign, _testPassword, _testEmail);
        }

        [TestMethod]
        public async Task SetPasswordRecoveryEmailAsyncTest()
        {
            await winlink.WinlinkWebServices.SetPasswordRecoveryEmailAsync(_testCallsign, _testPassword, _testEmail);
        }

        [TestMethod]
        public void SetWatchTest()
        {
            winlink.WinlinkWebServices.SetWatch(_testCallsign, _testPassword, _testProgramName, 4, _testEmailAddress);
        }

        [TestMethod]
        public async Task SetWatchAsyncTest()
        {
            await winlink.WinlinkWebServices.SetWatchAsync(_testCallsign, _testPassword, _testProgramName, 4, _testEmailAddress);
        }

        [TestMethod]
        public void ValidatePasswordTest()
        {
            var response = winlink.WinlinkWebServices.ValidatePassword(_testCallsign, _testPassword);
            Console.WriteLine(response.Dump());
        }

        [TestMethod]
        public async Task ValidatePasswordAsyncTest()
        {
            var response = await winlink.WinlinkWebServices.ValidatePasswordAsync(_testCallsign, _testPassword);
            Console.WriteLine(response.Dump());
        }
    }
}
