namespace WinlinkWebServices
{
    /// <summary>
    /// Configuration settings 
    /// </summary>
    public class WinlinkWebServiceConfiguration
    {
        /// <summary>
        /// The winlink web service host (URI)
        /// </summary>
        public string WebServicesHost { get; set; } = "https://api.winlink.org";

        /// <summary>
        /// The web service access key grants access to one or more API's. A winlink administrator will
        /// create the access key and determine which API are appropriate to assign to your project.
        /// </summary>
        public string WebServiceAccessKey { get; set; }
    }
}
