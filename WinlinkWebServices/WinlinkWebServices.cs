using ServiceStack;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using winlink.cms.webservices;
using winlink.util;

namespace winlink
{
    /// <summary>
    /// Common public Winlink APIs
    /// </summary>
    public static class WinlinkWebServices
    {
        private static string _webServiceAccessKey;
        private static string _webServicesHost;

        /// <summary>
        /// Configures necessary endpoint and access key. This method must be called
        /// with valid config settings prior to using any other of the below methods.
        /// Your access key will determine which of the below services are enabled.
        /// </summary>
        public static void SetConfiguration(WinlinkWebServiceConfiguration config)
        {
            _webServiceAccessKey = config.WebServiceAccessKey;
            _webServicesHost = config.WebServicesHost;
        }

        /// <summary>
        /// Returns true if a connectiion to the winlink server can be made
        /// </summary>
        /// <param name="timeoutMs"></param>
        /// <param name="url"></param>
        /// <returns></returns>
        public static bool CheckForInternetConnection(int timeoutMs = 5000, string url = null)
        {
            try
            {
                if (string.IsNullOrEmpty(url)) { url = _webServicesHost; }
                var request = (HttpWebRequest)WebRequest.Create(url);
                request.KeepAlive = false;
                request.Timeout = timeoutMs;
                using (var response = (HttpWebResponse)request.GetResponse())
                    return true;
            }
            catch
            {
                return false;
            }
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
        /// Adds a new winlink account 
        /// </summary>
        /// <param name="callsign"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static bool CreateAccount(string callsign, string password)
        {
            var client = new JsonServiceClient(_webServicesHost);
            var request = new AccountAdd { Key = _webServiceAccessKey, Callsign = callsign, Password = password };
            var response = client.Send<AccountAddResponse>(request);
            if (string.IsNullOrWhiteSpace(response.ResponseStatus.ErrorCode)) return true;
            throw new WebServiceException(response.ResponseStatus.ErrorCode + ": " + response.ResponseStatus.Message);
        }

        /// <summary>
        /// Adds a new winlink account 
        /// </summary>
        /// <param name="callsign"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static async Task<bool> CreateAccountAsync(string callsign, string password)
        {
            var client = new JsonServiceClient(_webServicesHost);
            var request = new AccountAdd { Key = _webServiceAccessKey, Callsign = callsign, Password = password };
            var response = await client.SendAsync<AccountAddResponse>(request);
            if (string.IsNullOrWhiteSpace(response.ResponseStatus.ErrorCode)) return true;
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
        /// Adds a new tactical account
        /// </summary>
        /// <param name="tacticalAddress"></param>
        /// <param name="password">Password can be blank</param>
        /// <returns>True if account was added</returns>
        public static bool CreateTacticalAccount(string tacticalAddress, string password = "")
        {
            var client = new JsonServiceClient(_webServicesHost);
            var request = new AccountTacticalAdd { Key = _webServiceAccessKey, TacticalAccount = tacticalAddress, Password = password };
            var response = client.Send<AccountTacticalAddResponse>(request);
            if (string.IsNullOrWhiteSpace(response.ResponseStatus.ErrorCode)) return true;
            throw new WebServiceException(response.ResponseStatus.ErrorCode + ": " + response.ResponseStatus.Message);
        }

        /// <summary>
        /// Adds a new tactical account
        /// </summary>
        /// <param name="tacticalAddress"></param>
        /// <param name="password">Password can be blank</param>
        /// <returns>True if account was added</returns>
        public static async Task<bool> CreateTacticalAccountAsync(string tacticalAddress, string password = "")
        {
            var client = new JsonServiceClient(_webServicesHost);
            var request = new AccountTacticalAdd { Key = _webServiceAccessKey, TacticalAccount = tacticalAddress, Password = password };
            var response = await client.SendAsync<AccountTacticalAddResponse>(request);
            if (string.IsNullOrWhiteSpace(response.ResponseStatus.ErrorCode)) return true;
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
        /// Add/update a program version record. Version records should be sent at application startup and
        /// then no more often than once every 24 hours. Only programs monitored by the CMS are accepted.
        /// </summary>
        /// <param name="callsign">Account callsign (no SSID)</param>
        /// <param name="program">Program Name - must be a valid 'monitored' program name</param>
        /// <param name="version">Dotted version of the program (e.g., 1.2.3)</param>
        /// <param name="comments"></param>
        public static void AddProgramVersion(string callsign, string program, string version, string comments)
        {
            var client = new JsonServiceClient(_webServicesHost);
            var request = new VersionAdd
            {
                Key = _webServiceAccessKey,
                Callsign = callsign,
                Program = program,
                Version = version,
                Comments = comments
            };
            var response = client.Send<VersionAddResponse>(request);
            if (string.IsNullOrWhiteSpace(response.ResponseStatus.ErrorCode)) return;
            throw new WebServiceException(response.ResponseStatus.ErrorCode + ": " + response.ResponseStatus.Message);
        }

        /// <summary>
        /// Add/update a program version record. Version records should be sent at application startup and
        /// then no more often than once every 24 hours. Only programs monitored by the CMS are accepted.
        /// </summary>
        /// <param name="callsign">Account callsign (no SSID)</param>
        /// <param name="program">Program Name - must be a valid 'monitored' program name</param>
        /// <param name="version">Dotted version of the program (e.g., 1.2.3)</param>
        /// <param name="comments"></param>
        public static async Task AddProgramVersionAsync(string callsign, string program, string version, string comments)
        {
            var client = new JsonServiceClient(_webServicesHost);
            var request = new VersionAdd
            {
                Key = _webServiceAccessKey,
                Callsign = callsign,
                Program = program,
                Version = version,
                Comments = comments
            };
            var response = await client.SendAsync<VersionAddResponse>(request);
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
        /// Change account (or tactical address) password
        /// </summary>
        /// <param name="callsign"></param>
        /// <param name="oldPassword"></param>
        /// <param name="newPassword"></param>
        /// <exception cref="WebServiceException"></exception>
        public static void ChangePassword(string callsign, string oldPassword, string newPassword)
        {
            var client = new JsonServiceClient(_webServicesHost);
            var request = new AccountPasswordChange()
            {
                Key = _webServiceAccessKey,
                Callsign = callsign,
                OldPassword = oldPassword,
                NewPassword = newPassword
            };
            var response = client.Send<AccountPasswordChangeResponse>(request);
            if (string.IsNullOrWhiteSpace(response.ResponseStatus.ErrorCode)) return;
            throw new WebServiceException(response.ResponseStatus.ErrorCode + ": " + response.ResponseStatus.Message);
        }

        /// <summary>
        /// Change account (or tactical address) password
        /// </summary>
        /// <param name="callsign"></param>
        /// <param name="oldPassword"></param>
        /// <param name="newPassword"></param>
        /// <exception cref="WebServiceException"></exception>
        public static async Task ChangePasswordAsync(string callsign, string oldPassword, string newPassword)
        {
            var client = new JsonServiceClient(_webServicesHost);
            var request = new AccountPasswordChange()
            {
                Key = _webServiceAccessKey,
                Callsign = callsign,
                OldPassword = oldPassword,
                NewPassword = newPassword
            };
            var response = await client.SendAsync<AccountPasswordChangeResponse>(request);
            if (string.IsNullOrWhiteSpace(response.ResponseStatus.ErrorCode)) return;
            throw new WebServiceException(response.ResponseStatus.ErrorCode + ": " + response.ResponseStatus.Message);
        }

        /// <summary>
        /// Deletes the watch for the specified callsign and program
        /// </summary>
        /// <param name="callsign"></param>
        /// <param name="password"></param>
        /// <param name="program"></param>
        /// <exception cref="WebServiceException"></exception>
        public static void DeleteWatch(string callsign, string password, string program)
        {
            var client = new JsonServiceClient(_webServicesHost);
            var request = new WatchDelete() { Key = _webServiceAccessKey, Callsign = callsign, Password = password, Program = program };
            var response = client.Send<WatchDeleteResponse>(request);
            if (string.IsNullOrWhiteSpace(response.ResponseStatus.ErrorCode)) return;
            throw new WebServiceException(response.ResponseStatus.ErrorCode + ": " + response.ResponseStatus.Message);
        }

        /// <summary>
        /// Deletes the watch for the specified callsign and program
        /// </summary>
        /// <param name="callsign"></param>
        /// <param name="password"></param>
        /// <param name="program"></param>
        /// <exception cref="WebServiceException"></exception>
        public static async Task DeleteWatchAsync(string callsign, string password, string program)
        {
            var client = new JsonServiceClient(_webServicesHost);
            var request = new WatchDelete() { Key = _webServiceAccessKey, Callsign = callsign, Password = password, Program = program };
            var response = await client.SendAsync<WatchDeleteResponse>(request);
            if (string.IsNullOrWhiteSpace(response.ResponseStatus.ErrorCode)) return;
            throw new WebServiceException(response.ResponseStatus.ErrorCode + ": " + response.ResponseStatus.Message);
        }

        /// <summary>
        /// Returns a list of gateways status records for the specified operating mode
        /// </summary>
        /// <param name="mode">Mode (pactor, packet, vara, anyall, etc.)</param>
        /// <param name="historyHours">Number of hours since the station last updated their channels</param>
        /// <param name="serviceCodes">One or more service codes</param>
        /// <returns></returns>
        /// <exception cref="WebServiceException"></exception>
        public static List<GatewayStatusRecord> GetGatewayStatusRecords(GatewayOperatingMode mode, int historyHours, string serviceCodes)
        {
            var client = new JsonServiceClient(_webServicesHost);
            var request = new GatewayStatus { Key = _webServiceAccessKey, Mode = mode, HistoryHours = historyHours, ServiceCodes = serviceCodes };
            var response = client.Send<GatewayStatusResponse>(request);
            if (string.IsNullOrWhiteSpace(response.ResponseStatus.ErrorCode)) return response.Gateways;
            throw new WebServiceException(response.ResponseStatus.ErrorCode + ": " + response.ResponseStatus.Message);
        }

        /// <summary>
        /// Returns a list of gateways status records for the specified operating mode
        /// </summary>
        /// <param name="mode">Mode (pactor, packet, vara, anyall, etc.)</param>
        /// <param name="historyHours">Number of hours since the station last updated their channels</param>
        /// <param name="serviceCodes">One or more service codes</param>
        /// <returns></returns>
        /// <exception cref="WebServiceException"></exception>
        public static async Task<List<GatewayStatusRecord>> GetGatewayStatusRecordsAsync(GatewayOperatingMode mode, int historyHours, string serviceCodes)
        {
            var client = new JsonServiceClient(_webServicesHost);
            var request = new GatewayStatus { Key = _webServiceAccessKey, Mode = mode, HistoryHours = historyHours, ServiceCodes = serviceCodes };
            var response = await client.SendAsync<GatewayStatusResponse>(request);
            if (string.IsNullOrWhiteSpace(response.ResponseStatus.ErrorCode)) return response.Gateways;
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
        /// Retrieves the watch record for the specified callsign and program
        /// </summary>
        /// <param name="callsign"></param>
        /// <param name="password"></param>
        /// <param name="program"></param>
        /// <returns></returns>
        /// <exception cref="WebServiceException"></exception>
        public static WatchRecord GetWatch(string callsign, string password, string program)
        {
            var client = new JsonServiceClient(_webServicesHost);
            var request = new WatchGet { Key = _webServiceAccessKey, Callsign = callsign, Password = password, Program = program };
            var response = client.Send<WatchGetResponse>(request);
            if (string.IsNullOrWhiteSpace(response.ResponseStatus.ErrorCode)) return new WatchRecord
            {
                AllowedTardyHours = response.AllowedTardyHours,
                Callsign = response.Callsign,
                Program = response.Program,
                NotificationEmails = response.NotificationEmails,
                Timestamp = response.Timestamp
            };
            throw new WebServiceException(response.ResponseStatus.ErrorCode + ": " + response.ResponseStatus.Message);
        }

        /// <summary>
        /// Retrieves the watch record for the specified callsign and program
        /// </summary>
        /// <param name="callsign"></param>
        /// <param name="password"></param>
        /// <param name="program"></param>
        /// <returns></returns>
        /// <exception cref="WebServiceException"></exception>
        public static async Task<WatchRecord> GetWatchAsync(string callsign, string password, string program)
        {
            var client = new JsonServiceClient(_webServicesHost);
            var request = new WatchGet { Key = _webServiceAccessKey, Callsign = callsign, Password = password, Program = program };
            var response = await client.SendAsync<WatchGetResponse>(request);
            if (string.IsNullOrWhiteSpace(response.ResponseStatus.ErrorCode)) return new WatchRecord
            {
                AllowedTardyHours = response.AllowedTardyHours,
                Callsign = response.Callsign,
                Program = response.Program,
                NotificationEmails = response.NotificationEmails,
                Timestamp = response.Timestamp
            };
            throw new WebServiceException(response.ResponseStatus.ErrorCode + ": " + response.ResponseStatus.Message);
        }

        /// <summary>
        /// Returns a list of watch records for the specified callsign
        /// </summary>
        /// <param name="callsign"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        /// <exception cref="WebServiceException"></exception>
        public static List<WatchRecord> GetWatchList(string callsign, string password)
        {
            var client = new JsonServiceClient(_webServicesHost);
            var request = new WatchList { Key = _webServiceAccessKey, Callsign = callsign, Password = password };
            var response = client.Send<WatchListResponse>(request);
            if (string.IsNullOrWhiteSpace(response.ResponseStatus.ErrorCode)) return response.List;
            throw new WebServiceException(response.ResponseStatus.ErrorCode + ": " + response.ResponseStatus.Message);
        }

        /// <summary>
        /// Returns a list of watch records for the specified callsign
        /// </summary>
        /// <param name="callsign"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        /// <exception cref="WebServiceException"></exception>
        public static async Task<List<WatchRecord>> GetWatchListAsync(string callsign, string password)
        {
            var client = new JsonServiceClient(_webServicesHost);
            var request = new WatchList { Key = _webServiceAccessKey, Callsign = callsign, Password = password };
            var response = await client.SendAsync<WatchListResponse>(request);
            if (string.IsNullOrWhiteSpace(response.ResponseStatus.ErrorCode)) return response.List;
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
        /// Updates status of the watched program
        /// </summary>
        /// <param name="callsign"></param>
        /// <param name="program"></param>
        /// <exception cref="WebServiceException"></exception>
        public static void PingWatch(string callsign, string program)
        {
            var client = new JsonServiceClient(_webServicesHost);
            var request = new WatchPing { Key = _webServiceAccessKey, Callsign = callsign, Program = program };
            var response = client.Send<WatchPingResponse>(request);
            if (string.IsNullOrWhiteSpace(response.ResponseStatus.ErrorCode)) return;
            throw new WebServiceException(response.ResponseStatus.ErrorCode + ": " + response.ResponseStatus.Message);
        }

        /// <summary>
        /// Updates status of the watched program
        /// </summary>
        /// <param name="callsign"></param>
        /// <param name="program"></param>
        /// <exception cref="WebServiceException"></exception>
        public static async Task PingWatchAsync(string callsign, string program)
        {
            var client = new JsonServiceClient(_webServicesHost);
            var request = new WatchPing { Key = _webServiceAccessKey, Callsign = callsign, Program = program };
            var response = await client.SendAsync<WatchPingResponse>(request);
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
                {53, "VARA 500"},
                {54, "VARA 2750"}
            };
            return mappings;
        }

        /// <summary>
        /// Requests that the account password be sent to the recovery email address on record
        /// </summary>
        /// <param name="callsign"></param>
        public static void SendPassword(string callsign)
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
        public static async Task SendPasswordAsync(string callsign)
        {
            var client = new JsonServiceClient(_webServicesHost);
            var request = new AccountPasswordSend { Key = _webServiceAccessKey, Callsign = callsign };
            var response = await client.SendAsync<AccountPasswordSendResponse>(request);
            if (string.IsNullOrWhiteSpace(response.ResponseStatus.ErrorCode)) return;
            throw new WebServiceException(response.ResponseStatus.ErrorCode + ": " + response.ResponseStatus.Message);
        }

        /// <summary>
        /// Adds a recovery email address to the account. Used to send forgotten passwords.
        /// </summary>
        /// <param name="callsign"></param>
        /// <param name="password"></param>
        /// <param name="recoveryEmail"></param>
        /// <exception cref="WebServiceException"></exception>
        public static void SetPasswordRecoveryEmail(string callsign, string password, string recoveryEmail)
        {
            var client = new JsonServiceClient(_webServicesHost);
            var request = new AccountPasswordRecoveryEmailSet
            {
                Key = _webServiceAccessKey,
                Callsign = callsign,
                Password = password,
                RecoveryEmail = recoveryEmail
            };
            var response = client.Send<AccountPasswordRecoveryEmailSetResponse>(request);
            if (string.IsNullOrWhiteSpace(response.ResponseStatus.ErrorCode)) return;
            throw new WebServiceException(response.ResponseStatus.ErrorCode + ": " + response.ResponseStatus.Message);
        }

        /// <summary>
        /// Adds a recovery email address to the account. Used to send forgotten passwords.
        /// </summary>
        /// <param name="callsign"></param>
        /// <param name="password"></param>
        /// <param name="recoveryEmail"></param>
        /// <exception cref="WebServiceException"></exception>
        public static async Task SetPasswordRecoveryEmailAsync(string callsign, string password, string recoveryEmail)
        {
            var client = new JsonServiceClient(_webServicesHost);
            var request = new AccountPasswordRecoveryEmailSet
            {
                Key = _webServiceAccessKey,
                Callsign = callsign,
                Password = password,
                RecoveryEmail = recoveryEmail
            };
            var response = await client.SendAsync<AccountPasswordRecoveryEmailSetResponse>(request);
            if (string.IsNullOrWhiteSpace(response.ResponseStatus.ErrorCode)) return;
            throw new WebServiceException(response.ResponseStatus.ErrorCode + ": " + response.ResponseStatus.Message);
        }

        /// <summary>
        /// Establish a watch for a program.
        /// 
        /// The CMS checks the status of each active watch once an hour. If the time of the last 
        /// watch/ping from the application is older than AllowedTardyHours a notification message 
        /// is sent to the email address(es) configured for the watch.If there are no email address
        /// specified the notification is sent to the callsign account associated with the watch.
        /// Notification messages are sent once a day for three days. The watch is disabled
        /// (AllowedTardyHours set to 0) if a ping has not been received after 3 days.
        /// </summary>
        /// <param name="callsign"></param>
        /// <param name="password"></param>
        /// <param name="program"></param>
        /// <param name="tardyHours"></param>
        /// <param name="emailAddresses"></param>
        /// <exception cref="WebServiceException"></exception>
        public static void SetWatch(string callsign, string password, string program, int tardyHours, string emailAddresses)
        {
            var client = new JsonServiceClient(_webServicesHost);
            var request = new WatchSet
            {
                Key = _webServiceAccessKey,
                Callsign = callsign,
                Password = password,
                Program = program,
                AllowedTardyHours = tardyHours,
                NotificationEmails = emailAddresses
            };
            var response = client.Send<WatchSetResponse>(request);
            if (string.IsNullOrWhiteSpace(response.ResponseStatus.ErrorCode)) return;
            throw new WebServiceException(response.ResponseStatus.ErrorCode + ": " + response.ResponseStatus.Message);
        }

        /// <summary>
        /// Establish a watch for a program.
        /// 
        /// The CMS checks the status of each active watch once an hour. If the time of the last 
        /// watch/ping from the application is older than AllowedTardyHours a notification message 
        /// is sent to the email address(es) configured for the watch.If there are no email address
        /// specified the notification is sent to the callsign account associated with the watch.
        /// Notification messages are sent once a day for three days. The watch is disabled
        /// (AllowedTardyHours set to 0) if a ping has not been received after 3 days.
        /// </summary>
        /// <param name="callsign"></param>
        /// <param name="password"></param>
        /// <param name="program"></param>
        /// <param name="tardyHours"></param>
        /// <param name="emailAddresses"></param>
        /// <exception cref="WebServiceException"></exception>
        public static async Task SetWatchAsync(string callsign, string password, string program, int tardyHours, string emailAddresses)
        {
            var client = new JsonServiceClient(_webServicesHost);
            var request = new WatchSet
            {
                Key = _webServiceAccessKey,
                Callsign = callsign,
                Password = password,
                Program = program,
                AllowedTardyHours = tardyHours,
                NotificationEmails = emailAddresses
            };
            var response = await client.SendAsync<WatchSetResponse>(request);
            if (string.IsNullOrWhiteSpace(response.ResponseStatus.ErrorCode)) return;
            throw new WebServiceException(response.ResponseStatus.ErrorCode + ": " + response.ResponseStatus.Message);
        }

        /// <summary>
        /// Validate callsign (or tactical address) password
        /// </summary>
        /// <param name="account"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        /// <exception cref="WebServiceException"></exception>
        public static bool ValidatePassword(string account, string password)
        {
            var client = new JsonServiceClient(_webServicesHost);
            var request = new AccountPasswordValidate { Key = _webServiceAccessKey, Callsign = account, Password = password };
            var response = client.Send<AccountPasswordValidateResponse>(request);
            if (string.IsNullOrWhiteSpace(response.ResponseStatus.ErrorCode)) return response.IsValid;
            throw new WebServiceException(response.ResponseStatus.ErrorCode + ": " + response.ResponseStatus.Message);
        }

        /// <summary>
        /// Validate callsign (or tactical address) password
        /// </summary>
        /// <param name="account"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        /// <exception cref="WebServiceException"></exception>
        public static async Task<bool> ValidatePasswordAsync(string account, string password)
        {
            var client = new JsonServiceClient(_webServicesHost);
            var request = new AccountPasswordValidate { Key = _webServiceAccessKey, Callsign = account, Password = password };
            var response = await client.SendAsync<AccountPasswordValidateResponse>(request);
            if (string.IsNullOrWhiteSpace(response.ResponseStatus.ErrorCode)) return response.IsValid;
            throw new WebServiceException(response.ResponseStatus.ErrorCode + ": " + response.ResponseStatus.Message);
        }

    }
}
