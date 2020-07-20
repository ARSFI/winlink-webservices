using ServiceStack;
using System.Collections.Generic;
using System.Threading.Tasks;
using winlink.cms.webservices;
using winlink.util;

namespace WinlinkWebServices
{
    /// <summary>
    /// Common public Winlink API's
    /// </summary>
    public static class WinlinkWebServices
    {
        private static string _webServiceAccessKey;
        private static string _webServicesHost;
        
        /// <summary>
        /// 
        /// </summary>
        public static void SetConfiguration(WinlinkWebServiceConfiguration config)
        {
            _webServiceAccessKey = config.WebServiceAccessKey;
            _webServicesHost = config.WebServicesHost;
        }

        /// <summary>
        /// Checks to see if there is an active winlink account for the specified <paramref name="callsign"/>
        /// </summary>
        /// <param name="callsign"></param>
        /// <returns>True if callsign account exists</returns>
        public static bool AccountExists(string callsign)
        {
            var client = new JsonServiceClient(_webServicesHost);
            var request = new AccountExists { Key = _webServiceAccessKey, Callsign = callsign };
            var response = client.Send<AccountExistsResponse>(request);
            if (string.IsNullOrWhiteSpace(response.ResponseStatus.ErrorCode)) return response.CallsignExists;
            throw new WebServiceException(response.ResponseStatus.ErrorCode + ": " + response.ResponseStatus.Message);
        }

        /// <summary>
        /// Checks to see if there is an active winlink account for the specified <paramref name="callsign"/>
        /// </summary>
        /// <param name="callsign"></param>
        /// <returns>True if callsign account exists</returns>
        public static async Task<bool> AccountExistsAsync(string callsign)
        {
            var client = new JsonServiceClient(_webServicesHost);
            var request = new AccountExists { Key = _webServiceAccessKey, Callsign = callsign };
            var response = await client.SendAsync<AccountExistsResponse>(request);
            if (string.IsNullOrWhiteSpace(response.ResponseStatus.ErrorCode)) return response.CallsignExists;
            throw new WebServiceException(response.ResponseStatus.ErrorCode + ": " + response.ResponseStatus.Message);
        }

        /// <summary>
        /// Checks to see if the tactical address exists/>
        /// </summary>
        /// <param name="tacticalAddress"></param>
        /// <returns>True if account exists</returns>
        public static bool AccountTacticalExists(string tacticalAddress)
        {
            var client = new JsonServiceClient(_webServicesHost);
            var request = new AccountTacticalExists { Key = _webServiceAccessKey, TacticalAccount = tacticalAddress };
            var response = client.Send<AccountTacticalExistsResponse>(request);
            if (string.IsNullOrWhiteSpace(response.ResponseStatus.ErrorCode)) return response.Tactical;
            throw new WebServiceException(response.ResponseStatus.ErrorCode + ": " + response.ResponseStatus.Message);
        }

        /// <summary>
        /// Checks to see if the tactical address exists/>
        /// </summary>
        /// <param name="tacticalAddress"></param>
        /// <returns>True if account exists</returns>
        public static async Task<bool> AccountTacticalExistsAsync(string tacticalAddress)
        {
            var client = new JsonServiceClient(_webServicesHost);
            var request = new AccountTacticalExists { Key = _webServiceAccessKey, TacticalAccount = tacticalAddress };
            var response = await client.SendAsync<AccountTacticalExistsResponse>(request);
            if (string.IsNullOrWhiteSpace(response.ResponseStatus.ErrorCode)) return response.Tactical;
            throw new WebServiceException(response.ResponseStatus.ErrorCode + ": " + response.ResponseStatus.Message);
        }

        /// <summary>
        /// Adds/Updates a single gateway channel record. Channel records should be re-added 
        /// every two hours or so to avoid having them removed from listings and maps.
        /// This is the mechanism that the CMS uses to determine if a gateway is on-line.
        /// </summary>
        /// <param name="callsign">Callsign with optional SSID</param>
        /// <param name="baseCallsign">Account callsign</param>
        /// <param name="gridSquare">Six character maidenhead grid locator</param>
        /// <param name="frequency">Center frequency in hertz</param>
        /// <param name="mode">Mode of operation</param>
        /// <param name="baud">Baud rate - primarily for packet (optional)</param>
        /// <param name="power">Transmit power in watts (optional)</param>
        /// <param name="height">Height of antenna above average terrain (optional)</param>
        /// <param name="gain">Antenna gain in db (optional)</param>
        /// <param name="direction">Antenna direction - 0 for omni, 360 for North (optional)</param>
        /// <param name="operatingHours">Hours of operation, eg. 00-23 (optional)</param>
        /// <param name="serviceCode">Single service code - default is PUBLIC (optional)</param>
        public static void AddGatewayChannel(string callsign, string baseCallsign, string gridSquare, int frequency, ModeMappings mode,
            int baud, int power, int height, int gain, int direction, string operatingHours, string serviceCode)
        {
            var client = new JsonServiceClient(_webServicesHost);
            var request = new ChannelAdd
            {
                Key = _webServiceAccessKey,
                Callsign = callsign,
                BaseCallsign = baseCallsign,
                GridSquare = gridSquare,
                Frequency = frequency,
                Mode = (int)mode,
                Baud = baud,
                Power = power,
                Height = height,
                Gain = gain,
                Direction = direction,
                Hours = operatingHours,
                ServiceCode = serviceCode
            };
            var response = client.Send<ChannelAddResponse>(request);
            if (string.IsNullOrWhiteSpace(response.ResponseStatus.ErrorCode)) return;
            throw new WebServiceException(response.ResponseStatus.ErrorCode + ": " + response.ResponseStatus.Message);
        }

        /// <summary>
        /// Adds/Updates a single gateway channel record. Channel records should be re-added 
        /// every two hours or so to avoid having them removed from listings and maps.
        /// This is the mechanism that the CMS uses to determine if a gateway is on-line.
        /// </summary>
        /// <param name="callsign">Callsign with optional SSID</param>
        /// <param name="baseCallsign">Account callsign</param>
        /// <param name="gridSquare">Six character maidenhead grid locator</param>
        /// <param name="frequency">Center frequency in hertz</param>
        /// <param name="mode">Mode of operation</param>
        /// <param name="baud">Baud rate - primarily for packet (optional)</param>
        /// <param name="power">Transmit power in watts (optional)</param>
        /// <param name="height">Height of antenna above average terrain (optional)</param>
        /// <param name="gain">Antenna gain in db (optional)</param>
        /// <param name="direction">Antenna direction - 0 for omni, 360 for North (optional)</param>
        /// <param name="operatingHours">Hours of operation, eg. 00-23 (optional)</param>
        /// <param name="serviceCode">Single service code - default is PUBLIC (optional)</param>
        public static async Task AddGatewayChannelAsync(string callsign, string baseCallsign, string gridSquare, int frequency, ModeMappings mode,
                    int baud, int power, int height, int gain, int direction, string operatingHours, string serviceCode)
        {
            var client = new JsonServiceClient(_webServicesHost);
            var request = new ChannelAdd
            {
                Key = _webServiceAccessKey,
                Callsign = callsign,
                BaseCallsign = baseCallsign,
                GridSquare = gridSquare,
                Frequency = frequency,
                Mode = (int)mode,
                Baud = baud,
                Power = power,
                Height = height,
                Gain = gain,
                Direction = direction,
                Hours = operatingHours,
                ServiceCode = serviceCode
            };
            var response = await client.SendAsync<ChannelAddResponse>(request);
            if (string.IsNullOrWhiteSpace(response.ResponseStatus.ErrorCode)) return;
            throw new WebServiceException(response.ResponseStatus.ErrorCode + ": " + response.ResponseStatus.Message);
        }

        /// <summary>
        /// Adds/Updates multiple gateway channel records. Channel records should be re-added 
        /// every two hours or so to avoid having them removed from listings and maps.
        /// This is the mechanism that the CMS uses to determine if a gateway is on-line.
        /// </summary>
        /// <param name="callsign">Callsign with optional SSID</param>
        /// <param name="baseCallsign">Account callsign</param>
        /// <param name="gridSquare">Six character maidenhead grid locator</param>
        /// <param name="serviceCode">Single service code - default is PUBLIC (optional)</param>
        /// <param name="operatingHours">Hours of operation, eg. 00-23 (optional)</param>
        /// <param name="partialChannelRecords"></param>
        public static void AddMultipleGatewayChannels(string callsign, string baseCallsign, string gridSquare, string serviceCode,
            string operatingHours, List<PartialChannelRecord> partialChannelRecords)
        {
            var client = new JsonServiceClient(_webServicesHost);
            var request = new ChannelAddMultiple
            {
                Key = _webServiceAccessKey,
                Callsign = callsign,
                BaseCallsign = baseCallsign,
                GridSquare = gridSquare,
                ServiceCode = serviceCode,
                OperatingHours = operatingHours,
                PartialChannelRecords = partialChannelRecords
            };
            var response = client.Send<ChannelAddMultipleResponse>(request);
            if (string.IsNullOrWhiteSpace(response.ResponseStatus.ErrorCode)) return;
            throw new WebServiceException(response.ResponseStatus.ErrorCode + ": " + response.ResponseStatus.Message);
        }

        /// <summary>
        /// Adds/Updates multiple gateway channel records. Channel records should be re-added 
        /// every two hours or so to avoid having them removed from listings and maps.
        /// This is the mechanism that the CMS uses to determine if a gateway is on-line.
        /// </summary>
        /// <param name="callsign">Callsign with optional SSID</param>
        /// <param name="baseCallsign">Account callsign</param>
        /// <param name="gridSquare">Six character maidenhead grid locator</param>
        /// <param name="serviceCode">Single service code - default is PUBLIC (optional)</param>
        /// <param name="operatingHours">Hours of operation, eg. 00-23 (optional)</param>
        /// <param name="partialChannelRecords"></param>
        public static async Task AddMultipleGatewayChannelsAsync(string callsign, string baseCallsign, string gridSquare, string serviceCode,
                    string operatingHours, List<PartialChannelRecord> partialChannelRecords)
        {
            var client = new JsonServiceClient(_webServicesHost);
            var request = new ChannelAddMultiple
            {
                Key = _webServiceAccessKey,
                Callsign = callsign,
                BaseCallsign = baseCallsign,
                GridSquare = gridSquare,
                ServiceCode = serviceCode,
                OperatingHours = operatingHours,
                PartialChannelRecords = partialChannelRecords
            };
            var response = await client.SendAsync<ChannelAddMultipleResponse>(request);
            if (string.IsNullOrWhiteSpace(response.ResponseStatus.ErrorCode)) return;
            throw new WebServiceException(response.ResponseStatus.ErrorCode + ": " + response.ResponseStatus.Message);
        }

        /// <summary>
        /// Adds or updates a sysop record
        /// </summary>
        /// <param name="callsign"></param>
        /// <param name="password"></param>
        /// <param name="gridSquare"></param>
        /// <param name="sysopName"></param>
        /// <param name="streetAddress1"></param>
        /// <param name="streetAddress2"></param>
        /// <param name="city"></param>
        /// <param name="state"></param>
        /// <param name="country"></param>
        /// <param name="postalCode"></param>
        /// <param name="email"></param>
        /// <param name="phones"></param>
        /// <param name="website"></param>
        /// <param name="comments"></param>
        public static void AddSysop(string callsign, string password, string gridSquare, string sysopName, string streetAddress1, string streetAddress2,
            string city, string state, string country, string postalCode, string email, string phones, string website, string comments)
        {
            var client = new JsonServiceClient(_webServicesHost);
            var request = new SysopAdd
            {
                Key = _webServiceAccessKey,
                Callsign = callsign,
                Password = password,
                GridSquare = gridSquare,
                SysopName = sysopName,
                StreetAddress1 = streetAddress1,
                StreetAddress2 = streetAddress2,
                City = city,
                State = state,
                PostalCode = postalCode,
                Country = country,
                Email = email,
                Phones = phones,
                Website = website,
                Comments = comments
            };
            var response = client.Send<SysopAddResponse>(request);
            if (string.IsNullOrWhiteSpace(response.ResponseStatus.ErrorCode)) return;
            throw new WebServiceException(response.ResponseStatus.ErrorCode + ": " + response.ResponseStatus.Message);
        }

        /// <summary>
        /// Adds or updates a sysop record
        /// </summary>
        /// <param name="callsign"></param>
        /// <param name="password"></param>
        /// <param name="gridSquare"></param>
        /// <param name="sysopName"></param>
        /// <param name="streetAddress1"></param>
        /// <param name="streetAddress2"></param>
        /// <param name="city"></param>
        /// <param name="state"></param>
        /// <param name="country"></param>
        /// <param name="postalCode"></param>
        /// <param name="email"></param>
        /// <param name="phones"></param>
        /// <param name="website"></param>
        /// <param name="comments"></param>
        public static async Task AddSysopAsync(string callsign, string password, string gridSquare, string sysopName, string streetAddress1, string streetAddress2,
                    string city, string state, string country, string postalCode, string email, string phones, string website, string comments)
        {
            var client = new JsonServiceClient(_webServicesHost);
            var request = new SysopAdd
            {
                Key = _webServiceAccessKey,
                Callsign = callsign,
                Password = password,
                GridSquare = gridSquare,
                SysopName = sysopName,
                StreetAddress1 = streetAddress1,
                StreetAddress2 = streetAddress2,
                City = city,
                State = state,
                PostalCode = postalCode,
                Country = country,
                Email = email,
                Phones = phones,
                Website = website,
                Comments = comments
            };
            var response = await client.SendAsync<SysopAddResponse>(request);
            if (string.IsNullOrWhiteSpace(response.ResponseStatus.ErrorCode)) return;
            throw new WebServiceException(response.ResponseStatus.ErrorCode + ": " + response.ResponseStatus.Message);
        }

        /// <summary>
        /// Adds a radio session record to the CMS database
        /// </summary>
        /// <param name="application">Program name</param>
        /// <param name="version">Program version</param>
        /// <param name="server">Server callsign</param>
        /// <param name="serverGrid">Server maidenhead grid locator</param>
        /// <param name="client">Client callsign</param>
        /// <param name="clientGrid">Client maidenhead grid locator</param>
        /// <param name="sid">Session identifier</param>
        /// <param name="mode">The mode of the connection</param>
        /// <param name="frequency">Frequency in Hertz</param>
        /// <param name="lastCommand">Last protocol command</param>
        /// <param name="messagesSent">Number of messages sent during this session</param>
        /// <param name="messagesReceived">Number of messages received during this session</param>
        /// <param name="bytesSent">Number of bytes sent during this session</param>
        /// <param name="bytesReceived">Number of bytes received during this session</param>
        /// <param name="holdingSeconds">Duration of the session</param>
        /// <param name="idTag">User defined value - 12 characters max</param>
        public static void AddSessionRecord(string application, string version, string server, string serverGrid, string client, string clientGrid, string sid,
           string mode, int frequency, string lastCommand, int messagesSent, int messagesReceived, int bytesSent, int bytesReceived, int holdingSeconds, string idTag)
        {
            var wsClient = new JsonServiceClient(_webServicesHost);
            var request = new SessionAdd
            {
                Key = _webServiceAccessKey,
                Application = application,
                Version = version,
                Server = server,
                ServerGrid = serverGrid,
                Client = client,
                ClientGrid = clientGrid,
                Sid = sid,
                Mode = mode,
                Frequency = frequency,
                LastCommand = lastCommand,
                MessagesSent = messagesSent,
                MessagesReceived = messagesReceived,
                BytesSent = bytesSent,
                BytesReceived = bytesReceived,
                HoldingSeconds = holdingSeconds,
                IdTag = idTag
            };

            var response = wsClient.Send<SessionAddResponse>(request);
            if (string.IsNullOrWhiteSpace(response.ResponseStatus.ErrorCode)) return;
            throw new WebServiceException(response.ResponseStatus.ErrorCode + ": " + response.ResponseStatus.Message);
        }

        /// <summary>
        /// Adds a radio session record to the CMS database
        /// </summary>
        /// <param name="application">Program name</param>
        /// <param name="version">Program version</param>
        /// <param name="server">Server callsign</param>
        /// <param name="serverGrid">Server maidenhead grid locator</param>
        /// <param name="client">Client callsign</param>
        /// <param name="clientGrid">Client maidenhead grid locator</param>
        /// <param name="sid">Session identifier</param>
        /// <param name="mode">The mode of the connection</param>
        /// <param name="frequency">Frequency in Hertz</param>
        /// <param name="lastCommand">Last protocol command</param>
        /// <param name="messagesSent">Number of messages sent during this session</param>
        /// <param name="messagesReceived">Number of messages received during this session</param>
        /// <param name="bytesSent">Number of bytes sent during this session</param>
        /// <param name="bytesReceived">Number of bytes received during this session</param>
        /// <param name="holdingSeconds">Duration of the session</param>
        /// <param name="idTag">User defined value - 12 characters max</param>
        public static async Task AddSessionRecordAsync(string application, string version, string server, string serverGrid, string client, string clientGrid, string sid,
                    string mode, int frequency, string lastCommand, int messagesSent, int messagesReceived, int bytesSent, int bytesReceived, int holdingSeconds, string idTag)
        {
            var wsClient = new JsonServiceClient(_webServicesHost);
            var request = new SessionAdd
            {
                Key = _webServiceAccessKey,
                Application = application,
                Version = version,
                Server = server,
                ServerGrid = serverGrid,
                Client = client,
                ClientGrid = clientGrid,
                Sid = sid,
                Mode = mode,
                Frequency = frequency,
                LastCommand = lastCommand,
                MessagesSent = messagesSent,
                MessagesReceived = messagesReceived,
                BytesSent = bytesSent,
                BytesReceived = bytesReceived,
                HoldingSeconds = holdingSeconds,
                IdTag = idTag
            };

            var response = await wsClient.SendAsync<SessionAddResponse>(request);
            if (string.IsNullOrWhiteSpace(response.ResponseStatus.ErrorCode)) return;
            throw new WebServiceException(response.ResponseStatus.ErrorCode + ": " + response.ResponseStatus.Message);
        }

        /// <summary>
        /// Creates and adds the specified tactical address using the supplied password (optional)
        /// </summary>
        /// <param name="tacticalAddress">Name of the tactical address</param>
        /// <param name="password">Optional password</param>
        public static void AddTacticalAddress(string tacticalAddress, string password = "")
        {
            var client = new JsonServiceClient(_webServicesHost);
            var request = new AccountTacticalAdd
            {
                Key = _webServiceAccessKey,
                TacticalAccount = tacticalAddress,
                Password = password
            };
            var response = client.Send<AccountTacticalAddResponse>(request);
            if (string.IsNullOrWhiteSpace(response.ResponseStatus.ErrorCode)) return;
            throw new WebServiceException(response.ResponseStatus.ErrorCode + ": " + response.ResponseStatus.Message);
        }

        /// <summary>
        /// Creates and adds the specified tactical address using the supplied password (optional)
        /// </summary>
        /// <param name="tacticalAddress">Name of the tactical address</param>
        /// <param name="password">Optional password</param>
        public static async Task AddTacticalAddressAsync(string tacticalAddress, string password = "")
        {
            var client = new JsonServiceClient(_webServicesHost);
            var request = new AccountTacticalAdd
            {
                Key = _webServiceAccessKey,
                TacticalAccount = tacticalAddress,
                Password = password
            };
            var response = await client.SendAsync<AccountTacticalAddResponse>(request);
            if (string.IsNullOrWhiteSpace(response.ResponseStatus.ErrorCode)) return;
            throw new WebServiceException(response.ResponseStatus.ErrorCode + ": " + response.ResponseStatus.Message);
        }

        /// <summary>
        /// Return a list of all channel records for one or more modes
        /// </summary>
        /// <param name="modes">One or more integers representing the mode (pactor, packet, vara, etc.) of the channel</param>
        /// <param name="historyHours">Number of hours since the station last updated their channels</param>
        /// <param name="serviceCodes">One or more service codes</param>
        /// <returns>Returns a list of channel records for the modes specified</returns>
        public static List<ChannelRecord> GetChannelListing(List<int> modes, int historyHours = 6, string serviceCodes = "PUBLIC")
        {
            var client = new JsonServiceClient(_webServicesHost);
            var request = new ChannelList { Key = _webServiceAccessKey, Modes = modes, HistoryHours = historyHours, ServiceCodes = serviceCodes };
            var response = client.Send<ChannelListResponse>(request);
            if (string.IsNullOrWhiteSpace(response.ResponseStatus.ErrorCode)) return response.Channels;
            throw new WebServiceException(response.ResponseStatus.ErrorCode + ": " + response.ResponseStatus.Message);
        }

        /// <summary>
        /// Return a list of all channel records for one or more modes
        /// </summary>
        /// <param name="modes">One or more integers representing the mode (pactor, packet, vara, etc.) of the channel</param>
        /// <param name="historyHours">Number of hours since the station last updated their channels</param>
        /// <param name="serviceCodes">One or more service codes</param>
        /// <returns>Returns a list of channel records for the modes specified</returns>
        public static async Task<List<ChannelRecord>> GetChannelListingAsync(List<int> modes, int historyHours = 6,
                            string serviceCodes = "PUBLIC")
        {
            var client = new JsonServiceClient(_webServicesHost);
            var request = new ChannelList { Key = _webServiceAccessKey, Modes = modes, HistoryHours = historyHours, ServiceCodes = serviceCodes };
            var response = await client.SendAsync<ChannelListResponse>(request);
            if (string.IsNullOrWhiteSpace(response.ResponseStatus.ErrorCode)) return response.Channels;
            throw new WebServiceException(response.ResponseStatus.ErrorCode + ": " + response.ResponseStatus.Message);
        }

        /// <summary>
        /// Get a list of channel records for the specified callsign
        /// </summary>
        /// <param name="callsign"></param>
        /// <returns>Returns a list of channel records for this callsign</returns>
        public static List<ChannelRecord> GetChannelRecords(string callsign)
        {
            var client = new JsonServiceClient(_webServicesHost);
            var request = new ChannelGet { Key = _webServiceAccessKey, Callsign = callsign };
            var response = client.Send<ChannelGetResponse>(request);
            if (string.IsNullOrWhiteSpace(response.ResponseStatus.ErrorCode)) return response.Channels;
            throw new WebServiceException(response.ResponseStatus.ErrorCode + ": " + response.ResponseStatus.Message);
        }

        /// <summary>
        /// Get a list of channel records for the specified callsign
        /// </summary>
        /// <param name="callsign"></param>
        /// <returns>Returns a list of channel records for this callsign</returns>
        public static async Task<List<ChannelRecord>> GetChannelRecordsAsync(string callsign)
        {
            var client = new JsonServiceClient(_webServicesHost);
            var request = new ChannelGet { Key = _webServiceAccessKey, Callsign = callsign };
            var response = await client.SendAsync<ChannelGetResponse>(request);
            if (string.IsNullOrWhiteSpace(response.ResponseStatus.ErrorCode)) return response.Channels;
            throw new WebServiceException(response.ResponseStatus.ErrorCode + ": " + response.ResponseStatus.Message);
        }

        /// <summary>
        /// Returns information regarding the the amateur radio license. It's
        /// primary use is to determine is the license is valid and to populate
        /// the local database with this information.
        /// </summary>
        /// <param name="callsign"></param>
        public static LicenseRecord LookupLicense(string callsign)
        {
            var client = new JsonServiceClient(_webServicesHost);
            var request = new LicenseLookup
            {
                Key = _webServiceAccessKey,
                Callsign = callsign
            };
            var response = client.Send<LicenseLookupResponse>(request);
            if (string.IsNullOrWhiteSpace(response.ResponseStatus.ErrorCode)) return response.ValidationRecord;
            throw new WebServiceException(response.ResponseStatus.ErrorCode + ": " + response.ResponseStatus.Message);
        }

        /// <summary>
        /// Returns information regarding the the amateur radio license. It's
        /// primary use is to determine is the license is valid and to populate
        /// the local database with this information.
        /// </summary>
        /// <param name="callsign"></param>
        public static async Task<LicenseRecord> LookupLicenseAsync(string callsign)
        {
            var client = new JsonServiceClient(_webServicesHost);
            var request = new LicenseLookup
            {
                Key = _webServiceAccessKey,
                Callsign = callsign
            };
            var response = await client.SendAsync<LicenseLookupResponse>(request);
            if (string.IsNullOrWhiteSpace(response.ResponseStatus.ErrorCode)) return response.ValidationRecord;
            throw new WebServiceException(response.ResponseStatus.ErrorCode + ": " + response.ResponseStatus.Message);
        }

        /// <summary>
        /// Requests that the account password be sent to the recovery email address on record
        /// </summary>
        /// <param name="callsign"></param>
        public static void SendAccountPassword(string callsign)
        {
            var client = new JsonServiceClient(_webServicesHost);
            var request = new AccountPasswordSend { Key = _webServiceAccessKey, Callsign = callsign };
            var response = client.Send<AccountPasswordSendResponse>(request);
            if (string.IsNullOrWhiteSpace(response.ResponseStatus.ErrorCode)) return;
            throw new WebServiceException(response.ResponseStatus.ErrorCode + ": " + response.ResponseStatus.Message);
        }

        /// <summary>
        /// Requests that the account password be sent to the recovery email address on record
        /// </summary>
        /// <param name="callsign"></param>
        public static async Task SendAccountPasswordAsync(string callsign)
        {
            var client = new JsonServiceClient(_webServicesHost);
            var request = new AccountPasswordSend { Key = _webServiceAccessKey, Callsign = callsign };
            var response = await client.SendAsync<AccountPasswordSendResponse>(request);
            if (string.IsNullOrWhiteSpace(response.ResponseStatus.ErrorCode)) return;
            throw new WebServiceException(response.ResponseStatus.ErrorCode + ": " + response.ResponseStatus.Message);
        }

        /// <summary>
        /// Handy reference to mapping of integer mode to protocol name
        /// </summary>
        /// <returns></returns>
        public static Dictionary<int, string> ProtocolModeMappings()
        {
            var mappings = new Dictionary<int, string>
            {
                {0,"Packet 1200"},
                {1,"Packet 2400"},
                {2, "Packet 4800"},
                {3, "Packet 9600"},
                {4, "Packet 19200"},
                {5, "Packet 38400"},
                {11, "Pactor 1"},
                {12, "Pactor 1,2"},
                {13, "Pactor 1,2,3"},
                {14, "Pactor 2"},
                {15, "Pactor 2,3"},
                {16, "Pactor 3"},
                {17, "Pactor 1,2,3,4"},
                {18, "Pactor 2,3,4"},
                {19, "Pactor 3,4"},
                {20, "Pactor 4"},
                {21, "WINMOR 500"},
                {22, "WINMOR 1600"},
                {30, "Robust Packet"},
                {40, "ARDOP 200"},
                {41, "ARDOP 500"},
                {42, "ARDOP 1000"},
                {43, "ARDOP 2000"},
                {44, "ARDOP 2000 FM"},
                {50, "VARA"},
                {51, "VARA FM"},
                {52, "VARA FM WIDE"},
                {53, "VARA 500"}
            };
            return mappings;
        }
    }
}
