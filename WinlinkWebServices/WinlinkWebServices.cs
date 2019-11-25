using ServiceStack;
using winlink.cms.webservices;


namespace WinlinkWebServices
{
    public static class WinlinkWebServices
    {
        public static string WebServiceAccessKey = "[enter web service key here]";
        private static string WebServicesEndpoint = "https://api.winlink.org/";

        /// <summary>
        /// Checks to see if there is an active winlink account for the specified <paramref name="callsign"/>
        /// </summary>
        /// <param name="callsign"></param>
        /// <returns>True if callsign account exists</returns>
        public static bool AccountExists(string callsign)
        {
            var client = new JsonServiceClient(WebServicesEndpoint);
            var request = new AccountExists { Callsign = callsign, Key = WebServiceAccessKey };
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
            var request = new AccountPasswordSend { Callsign = callsign, Key = WebServiceAccessKey };
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
            var request = new AccountTacticalExists { TacticalAccount = tacticalAddress, Key = WebServiceAccessKey };
            var response = client.Send<AccountTacticalExistsResponse>(request);
            if (string.IsNullOrWhiteSpace(response.ResponseStatus.ErrorCode)) return response.Tactical;
            throw new WebServiceException(response.ResponseStatus.ErrorCode + ": " + response.ResponseStatus.Message);
        }



    }
}
