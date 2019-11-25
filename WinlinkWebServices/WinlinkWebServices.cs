using System.Collections.Generic;
using ServiceStack;
using winlink.cms.webservices;


namespace WinlinkWebServices
{
    public static class WinlinkWebServices
    {
        /// <summary>
        /// The web service endpoint URI
        /// </summary>
        private static string WebServicesEndpoint = "https://api.winlink.org/";

        /// <summary>
        /// The web service access key grants access to one or more API's. A winlink CMS administrator
        /// will create the access key and determine which API are appropriate to assign to the project.
        /// </summary>
        public static string WebServiceAccessKey = "[enter web service key here]";

        /// <summary>
        /// Checks to see if there is an active winlink account for the specified <paramref name="callsign"/>
        /// </summary>
        /// <param name="callsign"></param>
        /// <returns>True if callsign account exists</returns>
        public static bool AccountExists(string callsign)
        {
            var client = new JsonServiceClient(WebServicesEndpoint);
            var request = new AccountExists { Key = WebServiceAccessKey, Callsign = callsign };
            var response = client.Send<AccountExistsResponse>(request);
            if (string.IsNullOrWhiteSpace(response.ResponseStatus.ErrorCode)) return response.CallsignExists;
            throw new WebServiceException(response.ResponseStatus.ErrorCode + ": " + response.ResponseStatus.Message);
        }

        /// <summary>
        /// Requests that the account password be sent to the recovery email address on record
        /// </summary>
        /// <param name="callsign"></param>
        public static void SendAccountPassword(string callsign)
        {
            var client = new JsonServiceClient(WebServicesEndpoint);
            var request = new AccountPasswordSend { Key = WebServiceAccessKey, Callsign = callsign };
            var response = client.Send<AccountPasswordSendResponse>(request);
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
            var client = new JsonServiceClient(WebServicesEndpoint);
            var request = new AccountTacticalAdd
            {
                Key = WebServiceAccessKey,
                TacticalAccount = tacticalAddress,
                Password = password
            };
            var response = client.Send<AccountTacticalAddResponse>(request);
            if (string.IsNullOrWhiteSpace(response.ResponseStatus.ErrorCode)) return;
            throw new WebServiceException(response.ResponseStatus.ErrorCode + ": " + response.ResponseStatus.Message);
        }

        /// <summary>
        /// Checks to see if the tactical address exists/>
        /// </summary>
        /// <param name="tacticalAddress"></param>
        /// <returns>True if account exists</returns>
        public static bool AccountTacticalExists(string tacticalAddress)
        {
            var client = new JsonServiceClient(WebServicesEndpoint);
            var request = new AccountTacticalExists { Key = WebServiceAccessKey, TacticalAccount = tacticalAddress };
            var response = client.Send<AccountTacticalExistsResponse>(request);
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
        public static void AddGatewayChannel(string callsign, string baseCallsign, string gridSquare, int frequency, ProtocolMode mode,
            int baud, int power, int height, int gain, int direction, string operatingHours, string serviceCode)
        {
            var client = new JsonServiceClient(WebServicesEndpoint);
            var request = new ChannelAdd
            {
                Key = WebServiceAccessKey,
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
            var client = new JsonServiceClient(WebServicesEndpoint);
            var request = new ChannelAddMultiple
            {
                Key = WebServiceAccessKey,
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



    }
}
