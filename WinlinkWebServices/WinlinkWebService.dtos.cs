/* Options:
Date: 2020-07-19 13:32:56
Version: 5.40
Tip: To override a DTO option, remove "//" prefix before updating
BaseUrl: https://api.winlink.org

//GlobalNamespace: 
//MakePartial: True
//MakeVirtual: True
//MakeInternal: False
//MakeDataContractsExtensible: False
//AddReturnMarker: True
//AddDescriptionAsComments: True
//AddDataContractAttributes: False
//AddIndexesToDataMembers: False
//AddGeneratedCodeAttributes: False
//AddResponseStatus: False
//AddImplicitVersion: 
//InitializeCollections: True
//ExportValueTypes: False
//IncludeTypes: 
//ExcludeTypes: 
//AddNamespaces: 
//AddDefaultXmlNamespace: http://schemas.servicestack.net/types
*/

using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using ServiceStack;
using ServiceStack.DataAnnotations;
using winlink.cms.webservices;
using winlink.util;
using winlink.cms;


namespace winlink.cms
{

    public enum ClientType
    {
        Unknown,
        Webmail,
        Simple,
        Airmail,
        Paclink,
        FBB,
        Browser,
        Outpost,
        Relay,
        Express,
        SNOS,
        BPQ,
        JNOS,
        DRATS,
        UnixLINK,
        Pat,
    }

    public enum EventType
    {
        Unknown,
        Accepted,
        Forwarded,
        Received,
        Rejected,
        Proposed,
        Processed,
        Posted,
    }

    public enum TrafficType
    {
        Unknown,
        P2P,
        RadioOnly,
    }
}

namespace winlink.cms.webservices
{

    ///<summary>
    ///Gets the alternate email associated with this callsign.
    ///</summary>
    [Route("/account/alternateEmail/get", "POST,GET")]
    [Api(Description="Gets the alternate email associated with this callsign.")]
    public partial class AccountAlternateEmailGet
        : WebServiceRequest, IReturn<AccountAlternateEmailGetResponse>
    {
        ///<summary>
        ///Account callsign
        ///</summary>
        [ApiMember(Description="Account callsign", IsRequired=true, Name="Callsign")]
        public virtual string Callsign { get; set; }
    }

    public partial class AccountAlternateEmailGetResponse
        : WebServiceResponse
    {
        public virtual string AlternateEmail { get; set; }
    }

    ///<summary>
    ///Sets the alternate email address for this callsign.
    ///</summary>
    [Route("/account/alternateEmail/set", "POST,GET")]
    [Api(Description="Sets the alternate email address for this callsign.")]
    public partial class AccountAlternateEmailSet
        : WebServiceRequest, IReturn<AccountAlternateEmailSetResponse>
    {
        ///<summary>
        ///Account callsign
        ///</summary>
        [ApiMember(Description="Account callsign", IsRequired=true, Name="Callsign")]
        public virtual string Callsign { get; set; }

        ///<summary>
        ///Alternate email address to use for forwarding messages
        ///</summary>
        [ApiMember(Description="Alternate email address to use for forwarding messages", IsRequired=true, Name="AlternateEmail")]
        public virtual string AlternateEmail { get; set; }
    }

    public partial class AccountAlternateEmailSetResponse
        : WebServiceResponse
    {
    }

    ///<summary>
    ///Searches for matching callsigns. All callsigns containing the search text are returned.
    ///</summary>
    [Route("/account/callsign/search", "POST,GET")]
    [Api(Description="Searches for matching callsigns. All callsigns containing the search text are returned.")]
    public partial class AccountCallsignSearch
        : WebServiceRequest, IReturn<AccountCallsignSearchResponse>
    {
        ///<summary>
        ///Search text
        ///</summary>
        [ApiMember(Description="Search text", IsRequired=true)]
        public virtual string SearchText { get; set; }

        ///<summary>
        ///Limits number of returned records (default: 100)
        ///</summary>
        [ApiMember(Description="Limits number of returned records (default: 100)")]
        public virtual int RecordLimit { get; set; }
    }

    public partial class AccountCallsignSearchResponse
        : WebServiceResponse
    {
        public AccountCallsignSearchResponse()
        {
            Callsigns = new List<string>{};
        }

        public virtual List<string> Callsigns { get; set; }
    }

    ///<summary>
    ///Determines if the specified callsign or tactical account exists in the Winlink system.
    ///</summary>
    [Route("/account/exists", "POST,GET")]
    [Api(Description="Determines if the specified callsign or tactical account exists in the Winlink system.")]
    public partial class AccountExists
        : WebServiceRequest, IReturn<AccountExistsResponse>
    {
        ///<summary>
        ///Account callsign or tactical
        ///</summary>
        [ApiMember(Description="Account callsign or tactical", IsRequired=true, Name="Callsign")]
        public virtual string Callsign { get; set; }

        public virtual bool AllowBlocked { get; set; }
    }

    public partial class AccountExistsResponse
        : WebServiceResponse
    {
        public virtual bool CallsignExists { get; set; }
    }

    ///<summary>
    ///Changes the password for an existing callsign or tactical account. Password can be no less than 6 and no more than 12 characters long. Password can be blank for tactical accounts only.
    ///</summary>
    [Route("/account/password/change", "POST,GET")]
    [Api(Description="Changes the password for an existing callsign or tactical account. Password can be no less than 6 and no more than 12 characters long. Password can be blank for tactical accounts only.")]
    public partial class AccountPasswordChange
        : WebServiceRequest, IReturn<AccountPasswordChangeResponse>
    {
        ///<summary>
        ///Account callsign or tactical address
        ///</summary>
        [ApiMember(Description="Account callsign or tactical address", IsRequired=true, Name="Callsign")]
        public virtual string Callsign { get; set; }

        ///<summary>
        ///Current account password
        ///</summary>
        [ApiMember(Description="Current account password", IsRequired=true, Name="OldPassword")]
        public virtual string OldPassword { get; set; }

        ///<summary>
        ///New account password
        ///</summary>
        [ApiMember(Description="New account password", IsRequired=true, Name="NewPassword")]
        public virtual string NewPassword { get; set; }
    }

    public partial class AccountPasswordChangeResponse
        : WebServiceResponse
    {
    }

    ///<summary>
    ///Causes the password to be emailed to the recovery address.
    ///</summary>
    [Route("/account/password/send", "POST,GET")]
    [Api(Description="Causes the password to be emailed to the recovery address.")]
    public partial class AccountPasswordSend
        : WebServiceRequest, IReturn<AccountPasswordSendResponse>
    {
        ///<summary>
        ///Account callsign
        ///</summary>
        [ApiMember(Description="Account callsign", IsRequired=true, Name="Callsign")]
        public virtual string Callsign { get; set; }
    }

    public partial class AccountPasswordSendResponse
        : WebServiceResponse
    {
        public virtual string ResponseMessage { get; set; }
    }

    ///<summary>
    ///Verifies Password is correct for Callsign.
    ///</summary>
    [Route("/account/password/validate", "POST")]
    [Api(Description="Verifies Password is correct for Callsign.")]
    public partial class AccountPasswordValidate
        : WebServiceRequest, IReturn<AccountPasswordValidateResponse>
    {
        ///<summary>
        ///Account callsign
        ///</summary>
        [ApiMember(Description="Account callsign", IsRequired=true, Name="Callsign")]
        public virtual string Callsign { get; set; }

        ///<summary>
        ///Account password
        ///</summary>
        [ApiMember(Description="Account password", IsRequired=true, Name="Password")]
        public virtual string Password { get; set; }
    }

    public partial class AccountPasswordValidateResponse
        : WebServiceResponse
    {
        public virtual bool IsValid { get; set; }
    }

    ///<summary>
    ///Adds a new tactical account.
    ///</summary>
    [Route("/account/tactical/add", "POST,GET")]
    [Api(Description="Adds a new tactical account.")]
    public partial class AccountTacticalAdd
        : WebServiceRequest, IReturn<AccountTacticalAddResponse>
    {
        ///<summary>
        ///Account name
        ///</summary>
        [ApiMember(Description="Account name", IsRequired=true)]
        public virtual string TacticalAccount { get; set; }

        ///<summary>
        ///Optional account password
        ///</summary>
        [ApiMember(Description="Optional account password")]
        public virtual string Password { get; set; }
    }

    public partial class AccountTacticalAddResponse
        : WebServiceResponse
    {
    }

    ///<summary>
    ///Returns true if this account exists and is a tactical account.
    ///</summary>
    [Route("/account/tactical/exists", "POST,GET")]
    [Api(Description="Returns true if this account exists and is a tactical account.")]
    public partial class AccountTacticalExists
        : WebServiceRequest, IReturn<AccountTacticalExistsResponse>
    {
        ///<summary>
        ///Account callsign
        ///</summary>
        [ApiMember(Description="Account callsign", IsRequired=true, Name="TacticalAccount")]
        public virtual string TacticalAccount { get; set; }
    }

    public partial class AccountTacticalExistsResponse
        : WebServiceResponse
    {
        public virtual bool Tactical { get; set; }
    }

    ///<summary>
    ///Removes an existing tactical account and all references to it.
    ///</summary>
    [Route("/account/tactical/remove", "POST,GET")]
    [Api(Description="Removes an existing tactical account and all references to it.")]
    public partial class AccountTacticalRemove
        : WebServiceRequest, IReturn<AccountTacticalRemoveResponse>
    {
        ///<summary>
        ///Tactical account name
        ///</summary>
        [ApiMember(Description="Tactical account name", IsRequired=true, Name="TacticalAccount")]
        public virtual string TacticalAccount { get; set; }
    }

    public partial class AccountTacticalRemoveResponse
        : WebServiceResponse
    {
    }

    [DataContract]
    public partial class Attachment
    {
        public Attachment()
        {
            Image = new byte[]{};
        }

        [DataMember]
        public virtual string FileName { get; set; }

        [DataMember]
        public virtual byte[] Image { get; set; }
    }

    ///<summary>
    ///Adds a (or updates an existing) channel record.
    ///</summary>
    [Route("/channel/add", "POST,GET")]
    [Api(Description="Adds a (or updates an existing) channel record.")]
    public partial class ChannelAdd
        : WebServiceRequest, IReturn<ChannelAddResponse>
    {
        ///<summary>
        ///Channel/Gateway callsign (may include SSID)
        ///</summary>
        [ApiMember(Description="Channel/Gateway callsign (may include SSID)", IsRequired=true)]
        public virtual string Callsign { get; set; }

        ///<summary>
        ///Sysop base callsign (no SSID)
        ///</summary>
        [ApiMember(Description="Sysop base callsign (no SSID)", IsRequired=true)]
        public virtual string BaseCallsign { get; set; }

        ///<summary>
        ///6 digit grid locator
        ///</summary>
        [ApiMember(Description="6 digit grid locator", IsRequired=true)]
        public virtual string GridSquare { get; set; }

        ///<summary>
        ///channel frequency in hertz
        ///</summary>
        [ApiMember(Description="channel frequency in hertz", IsRequired=true)]
        public virtual int Frequency { get; set; }

        ///<summary>
        ///Number indicating mode(s) the channel supports
        ///</summary>
        [ApiMember(Description="Number indicating mode(s) the channel supports", IsRequired=true)]
        public virtual int Mode { get; set; }

        ///<summary>
        ///Typically 1200 or 9600 for packet, 200 for P1, 600 for P2 and 3200 for P3
        ///</summary>
        [ApiMember(Description="Typically 1200 or 9600 for packet, 200 for P1, 600 for P2 and 3200 for P3")]
        public virtual int Baud { get; set; }

        ///<summary>
        ///Radiated power in watts
        ///</summary>
        [ApiMember(Description="Radiated power in watts")]
        public virtual int Power { get; set; }

        ///<summary>
        ///Antenna height above average terrain
        ///</summary>
        [ApiMember(Description="Antenna height above average terrain")]
        public virtual int Height { get; set; }

        ///<summary>
        ///Antenna gain in db
        ///</summary>
        [ApiMember(Description="Antenna gain in db")]
        public virtual int Gain { get; set; }

        ///<summary>
        ///360 for North, 0 for omnidirectional
        ///</summary>
        [ApiMember(Description="360 for North, 0 for omnidirectional")]
        public virtual int Direction { get; set; }

        ///<summary>
        ///Hours of operation (e.g., 00-23 for 24/7 operation)
        ///</summary>
        [ApiMember(Description="Hours of operation (e.g., 00-23 for 24/7 operation)")]
        public virtual string Hours { get; set; }

        ///<summary>
        ///Service code indicating the intended audience for this channel (default: PUBLIC)
        ///</summary>
        [ApiMember(Description="Service code indicating the intended audience for this channel (default: PUBLIC)")]
        public virtual string ServiceCode { get; set; }
    }

    ///<summary>
    ///Adds multiple channel records replacing any previously defined
    ///</summary>
    [Route("/channel/add/multiple", "POST")]
    [Api(Description="Adds multiple channel records replacing any previously defined")]
    public partial class ChannelAddMultiple
        : WebServiceRequest, IReturn<ChannelAddMultipleResponse>
    {
        public ChannelAddMultiple()
        {
            PartialChannelRecords = new List<PartialChannelRecord>{};
        }

        ///<summary>
        ///Channel/Gateway callsign (may include SSID)
        ///</summary>
        [ApiMember(Description="Channel/Gateway callsign (may include SSID)", IsRequired=true)]
        public virtual string Callsign { get; set; }

        ///<summary>
        ///Sysop base callsign (no SSID)
        ///</summary>
        [ApiMember(Description="Sysop base callsign (no SSID)", IsRequired=true)]
        public virtual string BaseCallsign { get; set; }

        ///<summary>
        ///6 digit grid locator
        ///</summary>
        [ApiMember(Description="6 digit grid locator", IsRequired=true)]
        public virtual string GridSquare { get; set; }

        ///<summary>
        ///Service code indicating the intended audience for this channel (default: PUBLIC)
        ///</summary>
        [ApiMember(Description="Service code indicating the intended audience for this channel (default: PUBLIC)")]
        public virtual string ServiceCode { get; set; }

        ///<summary>
        ///Hours of operation (e.g., 00-23 for 24/7 operation)
        ///</summary>
        [ApiMember(Description="Hours of operation (e.g., 00-23 for 24/7 operation)")]
        public virtual string OperatingHours { get; set; }

        ///<summary>
        ///One or more channel records
        ///</summary>
        [ApiMember(Description="One or more channel records", IsRequired=true)]
        public virtual List<PartialChannelRecord> PartialChannelRecords { get; set; }
    }

    public partial class ChannelAddMultipleResponse
        : WebServiceResponse
    {
    }

    public partial class ChannelAddResponse
        : WebServiceResponse
    {
    }

    ///<summary>
    ///Deletes an existing channel record.
    ///</summary>
    [Route("/channel/delete", "POST,GET")]
    [Api(Description="Deletes an existing channel record.")]
    public partial class ChannelDelete
        : WebServiceRequest, IReturn<ChannelDeleteResponse>
    {
        ///<summary>
        ///Channel/Gateway callsign (may include SSID)
        ///</summary>
        [ApiMember(Description="Channel/Gateway callsign (may include SSID)", IsRequired=true)]
        public virtual string Callsign { get; set; }

        ///<summary>
        ///channel frequency in hertz
        ///</summary>
        [ApiMember(Description="channel frequency in hertz", IsRequired=true)]
        public virtual int Frequency { get; set; }

        ///<summary>
        ///Number indicating mode the channel supports
        ///</summary>
        [ApiMember(Description="Number indicating mode the channel supports", IsRequired=true)]
        public virtual int Mode { get; set; }
    }

    ///<summary>
    ///Deletes all channel records for the specified callsign.
    ///</summary>
    [Route("/channel/delete/all", "POST,GET")]
    [Api(Description="Deletes all channel records for the specified callsign.")]
    public partial class ChannelDeleteAll
        : WebServiceRequest, IReturn<ChannelDeleteAllResponse>
    {
        ///<summary>
        ///Channel/Gateway callsign (may include SSID)
        ///</summary>
        [ApiMember(Description="Channel/Gateway callsign (may include SSID)", IsRequired=true)]
        public virtual string Callsign { get; set; }
    }

    public partial class ChannelDeleteAllResponse
        : WebServiceResponse
    {
    }

    public partial class ChannelDeleteResponse
        : WebServiceResponse
    {
    }

    ///<summary>
    ///Returns a list of all channel records for the specified callsign (most recent first).
    ///</summary>
    [Route("/channel/get", "POST,GET")]
    [Api(Description="Returns a list of all channel records for the specified callsign (most recent first).")]
    public partial class ChannelGet
        : WebServiceRequest, IReturn<ChannelGetResponse>
    {
        ///<summary>
        ///Channel/Gateway callsign (may include SSID)
        ///</summary>
        [ApiMember(Description="Channel/Gateway callsign (may include SSID)", IsRequired=true)]
        public virtual string Callsign { get; set; }
    }

    public partial class ChannelGetResponse
        : WebServiceResponse
    {
        public ChannelGetResponse()
        {
            Channels = new List<ChannelRecord>{};
        }

        public virtual List<ChannelRecord> Channels { get; set; }
    }

    ///<summary>
    ///Returns a list of channel records matching the request criteria.
    ///</summary>
    [Route("/channel/list", "POST,GET")]
    [Api(Description="Returns a list of channel records matching the request criteria.")]
    public partial class ChannelList
        : WebServiceRequest, IReturn<ChannelListResponse>
    {
        public ChannelList()
        {
            Modes = new List<int>{};
        }

        ///<summary>
        ///One or more operating modes (default: all)
        ///</summary>
        [ApiMember(Description="One or more operating modes (default: all)")]
        public virtual List<int> Modes { get; set; }

        ///<summary>
        ///Number of hours of history to include (default: 6)
        ///</summary>
        [ApiMember(Description="Number of hours of history to include (default: 6)")]
        public virtual int HistoryHours { get; set; }

        ///<summary>
        ///One or more service codes (default: PUBLIC)
        ///</summary>
        [ApiMember(Description="One or more service codes (default: PUBLIC)")]
        public virtual string ServiceCodes { get; set; }
    }

    public partial class ChannelListResponse
        : WebServiceResponse
    {
        public ChannelListResponse()
        {
            Channels = new List<ChannelRecord>{};
        }

        public virtual List<ChannelRecord> Channels { get; set; }
    }

    [DataContract]
    public partial class ChannelRecord
    {
        [DataMember]
        public virtual DateTime Timestamp { get; set; }

        [DataMember]
        public virtual string Callsign { get; set; }

        [DataMember]
        public virtual string BaseCallsign { get; set; }

        [DataMember]
        public virtual string GridSquare { get; set; }

        [DataMember]
        public virtual int Frequency { get; set; }

        [DataMember]
        public virtual int Mode { get; set; }

        [DataMember]
        public virtual int Baud { get; set; }

        [DataMember]
        public virtual int Power { get; set; }

        [DataMember]
        public virtual int Height { get; set; }

        [DataMember]
        public virtual int Gain { get; set; }

        [DataMember]
        public virtual int Direction { get; set; }

        [DataMember]
        public virtual string OperatingHours { get; set; }

        [DataMember]
        public virtual string ServiceCode { get; set; }
    }

    ///<summary>
    ///Returns the number of active gateway channels for the specified period.
    ///</summary>
    [Route("/gateway/channel/count", "POST,GET")]
    [Api(Description="Returns the number of active gateway channels for the specified period.")]
    public partial class GatewayChannelCount
        : WebServiceRequest, IReturn<GatewayChannelCountResponse>
    {
        ///<summary>
        ///Number of hours of history to include (default: 6)
        ///</summary>
        [ApiMember(Description="Number of hours of history to include (default: 6)", Name="HistoryHours")]
        public virtual int HistoryHours { get; set; }
    }

    public partial class GatewayChannelCountResponse
        : WebServiceResponse
    {
        public virtual int GatewayCount { get; set; }
    }

    [DataContract]
    public partial class GatewayChannelRecord
    {
        [DataMember]
        public virtual DateTime Timestamp { get; set; }

        [DataMember]
        public virtual string SupportedModes { get; set; }

        [DataMember]
        public virtual int Mode { get; set; }

        [DataMember]
        public virtual string Gridsquare { get; set; }

        [DataMember]
        public virtual int Frequency { get; set; }

        [DataMember]
        public virtual string OperatingHours { get; set; }

        [DataMember]
        public virtual string Baud { get; set; }

        [DataMember]
        public virtual string RadioRange { get; set; }

        [DataMember]
        public virtual string Antenna { get; set; }

        [DataMember]
        public virtual string ServiceCode { get; set; }
    }

    ///<summary>
    ///Returns a list of channel records based on the supplied parameters.
    ///</summary>
    [Route("/gateway/channel/report", "POST,GET")]
    [Api(Description="Returns a list of channel records based on the supplied parameters.")]
    public partial class GatewayChannelReport
        : WebServiceRequest, IReturn<GatewayChannelReportResponse>
    {
        public GatewayChannelReport()
        {
            Modes = new List<int>{};
        }

        ///<summary>
        ///The minimum frequency (default: 0)
        ///</summary>
        [ApiMember(Description="The minimum frequency (default: 0)")]
        public virtual int FrequencyMinimum { get; set; }

        ///<summary>
        ///The maximum frequency (default: max int)
        ///</summary>
        [ApiMember(Description="The maximum frequency (default: max int)")]
        public virtual int FrequencyMaximum { get; set; }

        ///<summary>
        ///One or more service codes --  to filter the response to just those service codes (default: PUBLIC)
        ///</summary>
        [ApiMember(Description="One or more service codes --  to filter the response to just those service codes (default: PUBLIC)")]
        public virtual string ServiceCodes { get; set; }

        ///<summary>
        ///Zero or more modes -- to filter the response for just those modes. (default: empty (all modes))
        ///</summary>
        [ApiMember(Description="Zero or more modes -- to filter the response for just those modes. (default: empty (all modes))")]
        public virtual List<int> Modes { get; set; }
    }

    public partial class GatewayChannelReportRecord
    {
        public virtual string Callsign { get; set; }
        public virtual string Gridsquare { get; set; }
        public virtual int Frequency { get; set; }
        public virtual int Mode { get; set; }
        public virtual string Hours { get; set; }
        public virtual string ServiceCode { get; set; }
    }

    public partial class GatewayChannelReportResponse
        : WebServiceResponse
    {
        public GatewayChannelReportResponse()
        {
            Channels = new List<GatewayChannelReportRecord>{};
        }

        public virtual List<GatewayChannelReportRecord> Channels { get; set; }
    }

    ///<summary>
    ///Returns a formatted gateway listing (to be saved as a text file)
    ///</summary>
    [Route("/gatewayListing", "POST,GET")]
    [Route("/gateway/listing", "POST,GET")]
    [Api(Description="Returns a formatted gateway listing (to be saved as a text file)")]
    public partial class GatewayListing
        : WebServiceRequest, IReturn<GatewayListingResponse>
    {
        ///<summary>
        ///One or more service codes (default: PUBLIC)
        ///</summary>
        [ApiMember(Description="One or more service codes (default: PUBLIC)", Name="ServiceCodes")]
        public virtual string ServiceCodes { get; set; }

        ///<summary>
        ///Number of hours of history to include (default: 6)
        ///</summary>
        [ApiMember(Description="Number of hours of history to include (default: 6)", Name="HistoryHours")]
        public virtual int HistoryHours { get; set; }

        ///<summary>
        ///The type of listing (default: Pactor)
        ///</summary>
        [ApiMember(Description="The type of listing (default: Pactor)", Name="ListingType")]
        public virtual GatewayListingType ListingType { get; set; }
    }

    public partial class GatewayListingResponse
        : WebServiceResponse
    {
        public virtual string Listing { get; set; }
    }

    [DataContract]
    public enum GatewayListingType
    {
        Packet,
        Pactor,
        Winmor,
        RobustPacket,
        Airmail,
        ARDOP,
        VARA,
    }

    [DataContract]
    public enum GatewayOperatingMode
    {
        AnyAll,
        Packet,
        Pactor,
        Winmor,
        RobustPacket,
        AllHf,
        ARDOP,
        VARA,
        VARAFM,
    }

    [DataContract]
    public partial class GatewayPositionsRecord
    {
        [DataMember]
        public virtual string Callsign { get; set; }

        [DataMember]
        public virtual string Gridsquare { get; set; }

        [DataMember]
        public virtual int Frequency { get; set; }

        [DataMember]
        public virtual int Mode { get; set; }

        [DataMember]
        public virtual string Baud { get; set; }

        [DataMember]
        public virtual string ServiceCode { get; set; }

        [DataMember]
        public virtual int Distance { get; set; }

        [DataMember]
        public virtual int Heading { get; set; }
    }

    ///<summary>
    ///Returns a list of gateways corresponding to the request parameters. The list is sorted by distance from the supplied grid square.
    ///</summary>
    [Route("/gatewayProximity", "POST,GET")]
    [Route("/gateway/proximity", "POST,GET")]
    [Api(Description="Returns a list of gateways corresponding to the request parameters. The list is sorted by distance from the supplied grid square.")]
    public partial class GatewayProximity
        : WebServiceRequest, IReturn<GatewayProximityResponse>
    {
        ///<summary>
        ///Grid location
        ///</summary>
        [ApiMember(Description="Grid location", IsRequired=true, Name="GridSquare")]
        public virtual string GridSquare { get; set; }

        ///<summary>
        ///One or more service codes (default: PUBLIC)
        ///</summary>
        [ApiMember(Description="One or more service codes (default: PUBLIC)", Name="ServiceCodes")]
        public virtual string ServiceCodes { get; set; }

        ///<summary>
        ///Number of hours of history to include (default: 6)
        ///</summary>
        [ApiMember(Description="Number of hours of history to include (default: 6)", Name="HistoryHours")]
        public virtual int HistoryHours { get; set; }

        ///<summary>
        ///Distance in miles to search (default: 0 - all)
        ///</summary>
        [ApiMember(Description="Distance in miles to search (default: 0 - all)", Name="MaxDistance")]
        public virtual int MaxDistance { get; set; }

        ///<summary>
        ///One of Packet, Pactor, Winmor, RobustPacket, or AnyAll (default: AnyAll)
        ///</summary>
        [ApiMember(Description="One of Packet, Pactor, Winmor, RobustPacket, or AnyAll (default: AnyAll)", Name="OperatingMode")]
        public virtual GatewayOperatingMode OperatingMode { get; set; }
    }

    public partial class GatewayProximityResponse
        : WebServiceResponse
    {
        public GatewayProximityResponse()
        {
            GatewayList = new List<GatewayPositionsRecord>{};
        }

        public virtual List<GatewayPositionsRecord> GatewayList { get; set; }
    }

    ///<summary>
    ///Returns an array of data structures showing the status of Winlink gateways.
    ///</summary>
    [Route("/gatewayStatus", "POST,GET")]
    [Route("/gateway/status", "POST,GET")]
    [Api(Description="Returns an array of data structures showing the status of Winlink gateways.")]
    public partial class GatewayStatus
        : WebServiceRequest, IReturn<GatewayStatusResponse>
    {
        ///<summary>
        ///Number of hours of history to include (default: 6)
        ///</summary>
        [ApiMember(Description="Number of hours of history to include (default: 6)")]
        public virtual int HistoryHours { get; set; }

        ///<summary>
        ///One or more service codes (default: PUBLIC)
        ///</summary>
        [ApiMember(Description="One or more service codes (default: PUBLIC)")]
        public virtual string ServiceCodes { get; set; }

        ///<summary>
        ///One of Packet, Pactor, Winmor, RobustPacket, ARDOP, VARA, VARAFM, AllHf, or AnyAll (default: AnyAll)
        ///</summary>
        [ApiMember(Description="One of Packet, Pactor, Winmor, RobustPacket, ARDOP, VARA, VARAFM, AllHf, or AnyAll (default: AnyAll)")]
        public virtual GatewayOperatingMode Mode { get; set; }
    }

    [DataContract]
    public partial class GatewayStatusRecord
    {
        public GatewayStatusRecord()
        {
            GatewayChannels = new List<GatewayChannelRecord>{};
        }

        [DataMember]
        public virtual DateTime Timestamp { get; set; }

        [DataMember]
        public virtual string Callsign { get; set; }

        [DataMember]
        public virtual string BaseCallsign { get; set; }

        [DataMember]
        public virtual double Latitude { get; set; }

        [DataMember]
        public virtual double Longitude { get; set; }

        [DataMember]
        public virtual int HoursSinceStatus { get; set; }

        [DataMember]
        public virtual string LastStatus { get; set; }

        [DataMember]
        public virtual string Comments { get; set; }

        [DataMember]
        public virtual GatewayOperatingMode RequestedMode { get; set; }

        [DataMember]
        public virtual List<GatewayChannelRecord> GatewayChannels { get; set; }
    }

    public partial class GatewayStatusResponse
        : WebServiceResponse
    {
        public GatewayStatusResponse()
        {
            Gateways = new List<GatewayStatusRecord>{};
        }

        public virtual List<GatewayStatusRecord> Gateways { get; set; }
    }

    ///<summary>
    ///Returns a list groups and addresses that are managed by the supplied account
    ///</summary>
    [Route("/group/address/list", "POST,GET")]
    [Api(Description="Returns a list groups and addresses that are managed by the supplied account")]
    public partial class GroupAddressList
        : WebServiceRequest, IReturn<GroupAddressListResponse>
    {
        ///<summary>
        ///Callsign of group manager
        ///</summary>
        [ApiMember(Description="Callsign of group manager", IsRequired=true)]
        public virtual string Callsign { get; set; }

        ///<summary>
        ///Account password
        ///</summary>
        [ApiMember(Description="Account password", IsRequired=true, Name="Password")]
        public virtual string Password { get; set; }

        ///<summary>
        ///Include members added because of a dynamic group query (default: false)
        ///</summary>
        [ApiMember(Description="Include members added because of a dynamic group query (default: false)")]
        public virtual bool IncludeDynamic { get; set; }
    }

    public partial class GroupAddressListResponse
        : WebServiceResponse
    {
        public GroupAddressListResponse()
        {
            GroupAddresses = new List<GroupAddressRecord>{};
        }

        public virtual List<GroupAddressRecord> GroupAddresses { get; set; }
    }

    public partial class GroupAddressRecord
    {
        public GroupAddressRecord()
        {
            AddressList = new List<string>{};
        }

        [DataMember]
        public virtual string GroupName { get; set; }

        [DataMember]
        public virtual List<string> AddressList { get; set; }
    }

    [DataContract]
    public partial class HybridRecord
    {
        [DataMember]
        public virtual string Callsign { get; set; }

        [DataMember]
        public virtual bool AutomaticForwarding { get; set; }

        [DataMember]
        public virtual bool ManualForwarding { get; set; }
    }

    ///<summary>
    ///Returns a list of radio network hybrid stations.
    ///</summary>
    [Route("/hybirdStation/list", "POST,GET")]
    [Route("/hybridStation/list", "POST,GET")]
    [Api(Description="Returns a list of radio network hybrid stations.")]
    public partial class HybridStationList
        : WebServiceRequest, IReturn<HybridStationListResponse>
    {
    }

    public partial class HybridStationListResponse
        : WebServiceResponse
    {
        public HybridStationListResponse()
        {
            HybridList = new List<HybridRecord>{};
        }

        public virtual List<HybridRecord> HybridList { get; set; }
    }

    ///<summary>
    ///Returns information regarding the the amateur radio license.
    ///</summary>
    [Route("/license/lookup", "POST,GET")]
    [Api(Description="Returns information regarding the the amateur radio license.")]
    public partial class LicenseLookup
        : WebServiceRequest, IReturn<LicenseLookupResponse>
    {
        ///<summary>
        ///Callsign to look up
        ///</summary>
        [ApiMember(Description="Callsign to look up", IsRequired=true)]
        public virtual string Callsign { get; set; }
    }

    public partial class LicenseLookupResponse
        : WebServiceResponse
    {
        public virtual LicenseRecord ValidationRecord { get; set; }
    }

    ///<summary>
    ///Returns a list of all messages pending for this account.
    ///</summary>
    [Route("/message/exists", "POST,GET")]
    [Api(Description="Returns a list of all messages pending for this account.")]
    public partial class MessageExists
        : WebServiceRequest, IReturn<MessageExistsResponse>
    {
        ///<summary>
        ///The ID of the message
        ///</summary>
        [ApiMember(Description="The ID of the message", IsRequired=true, Name="MessageId")]
        public virtual string MessageId { get; set; }
    }

    public partial class MessageExistsResponse
        : WebServiceResponse
    {
        public virtual bool Exists { get; set; }
    }

    ///<summary>
    ///Gets a specific email message identified by MessageId. Returns the mime encoded message.
    ///</summary>
    [Route("/message/get", "POST,GET")]
    [Api(Description="Gets a specific email message identified by MessageId. Returns the mime encoded message.")]
    public partial class MessageGet
        : WebServiceRequest, IReturn<MessageGetResponse>
    {
        ///<summary>
        ///Account callsign or callsign of requester
        ///</summary>
        [ApiMember(Description="Account callsign or callsign of requester", IsRequired=true)]
        public virtual string AccountName { get; set; }

        ///<summary>
        ///Password for account
        ///</summary>
        [ApiMember(Description="Password for account", IsRequired=true)]
        public virtual string Password { get; set; }

        ///<summary>
        ///The ID of the message
        ///</summary>
        [ApiMember(Description="The ID of the message", IsRequired=true)]
        public virtual string MessageId { get; set; }

        ///<summary>
        ///Message is marked as forwarded (delivered)
        ///</summary>
        [ApiMember(Description="Message is marked as forwarded (delivered)")]
        public virtual bool MarkAsForwarded { get; set; }
    }

    ///<summary>
    ///Gets a specific email message identified by MessageId. Returns the decoded message.
    ///</summary>
    [Route("/message/get/decoded", "POST,GET")]
    [Api(Description="Gets a specific email message identified by MessageId. Returns the decoded message.")]
    public partial class MessageGetDecoded
        : WebServiceRequest, IReturn<MessageGetDecodedResponse>
    {
        ///<summary>
        ///Account callsign or callsign of requester
        ///</summary>
        [ApiMember(Description="Account callsign or callsign of requester", IsRequired=true)]
        public virtual string AccountName { get; set; }

        ///<summary>
        ///Password for account
        ///</summary>
        [ApiMember(Description="Password for account", IsRequired=true)]
        public virtual string Password { get; set; }

        ///<summary>
        ///The ID of the message
        ///</summary>
        [ApiMember(Description="The ID of the message", IsRequired=true, Name="MessageId")]
        public virtual string MessageId { get; set; }

        ///<summary>
        ///Message is marked as forwarded (delivered)
        ///</summary>
        [ApiMember(Description="Message is marked as forwarded (delivered)")]
        public virtual bool MarkAsForwarded { get; set; }
    }

    public partial class MessageGetDecodedResponse
        : WebServiceResponse
    {
        public MessageGetDecodedResponse()
        {
            ToAddresses = new List<string>{};
            CcAddresses = new List<string>{};
            Attachments = new List<Attachment>{};
        }

        public virtual string MessageId { get; set; }
        public virtual string Header { get; set; }
        public virtual string Sender { get; set; }
        public virtual string Source { get; set; }
        public virtual string Subject { get; set; }
        public virtual List<string> ToAddresses { get; set; }
        public virtual List<string> CcAddresses { get; set; }
        public virtual string Body { get; set; }
        public virtual List<Attachment> Attachments { get; set; }
        public virtual bool Forwarded { get; set; }
        public virtual string Mime { get; set; }
    }

    public partial class MessageGetResponse
        : WebServiceResponse
    {
        public virtual string MessageId { get; set; }
        public virtual string Mime { get; set; }
    }

    ///<summary>
    ///Returns a list of all messages pending for this account.
    ///</summary>
    [Route("/message/list", "POST,GET")]
    [Api(Description="Returns a list of all messages pending for this account.")]
    public partial class MessageList
        : WebServiceRequest, IReturn<MessageListResponse>
    {
        ///<summary>
        ///The Winlink account name. Usually a callsign or tactical address.
        ///</summary>
        [ApiMember(Description="The Winlink account name. Usually a callsign or tactical address.", IsRequired=true)]
        public virtual string AccountName { get; set; }

        ///<summary>
        ///Password for account (tactical address may not have a password)
        ///</summary>
        [ApiMember(Description="Password for account (tactical address may not have a password)", IsRequired=true)]
        public virtual string Password { get; set; }
    }

    [DataContract]
    public partial class MessageListRecord
    {
        [DataMember]
        public virtual DateTime Timestamp { get; set; }

        [DataMember]
        public virtual string MessageId { get; set; }

        [DataMember]
        public virtual string Sender { get; set; }

        [DataMember]
        public virtual string Subject { get; set; }

        [DataMember]
        public virtual int Size { get; set; }

        [DataMember]
        public virtual int Attachments { get; set; }
    }

    public partial class MessageListResponse
        : WebServiceResponse
    {
        public MessageListResponse()
        {
            Messages = new List<MessageListRecord>{};
        }

        public virtual List<MessageListRecord> Messages { get; set; }
    }

    ///<summary>
    ///Adds an entry to the MPS table. If the combination of callsign and mpsCallsign already exist only the timestamp is updated.
    ///</summary>
    [Route("/mps/add", "POST,GET")]
    [Api(Description="Adds an entry to the MPS table. If the combination of callsign and mpsCallsign already exist only the timestamp is updated.")]
    public partial class MessagePickupStationAdd
        : WebServiceRequest, IReturn<MessagePickupStationAddResponse>
    {
        ///<summary>
        ///Callsign of requestor
        ///</summary>
        [ApiMember(Description="Callsign of requestor", IsRequired=true, Name="Requester")]
        public virtual string Requester { get; set; }

        ///<summary>
        ///Station callsign
        ///</summary>
        [ApiMember(Description="Station callsign", IsRequired=true, Name="Callsign")]
        public virtual string Callsign { get; set; }

        ///<summary>
        ///Account password
        ///</summary>
        [ApiMember(Description="Account password", IsRequired=true, Name="Password")]
        public virtual string Password { get; set; }

        ///<summary>
        ///MPS callsign
        ///</summary>
        [ApiMember(Description="MPS callsign", IsRequired=true, Name="MpsCallsign")]
        public virtual string MpsCallsign { get; set; }
    }

    public partial class MessagePickupStationAddResponse
        : WebServiceResponse
    {
    }

    ///<summary>
    ///Deletes all MPS records for this callsign.
    ///</summary>
    [Route("/mps/delete", "POST,GET")]
    [Api(Description="Deletes all MPS records for this callsign.")]
    public partial class MessagePickupStationDelete
        : WebServiceRequest, IReturn<MessagePickupStationDeleteResponse>
    {
        ///<summary>
        ///Callsign of requestor
        ///</summary>
        [ApiMember(Description="Callsign of requestor", IsRequired=true, Name="Requester")]
        public virtual string Requester { get; set; }

        ///<summary>
        ///Station callsign
        ///</summary>
        [ApiMember(Description="Station callsign", IsRequired=true, Name="Callsign")]
        public virtual string Callsign { get; set; }

        ///<summary>
        ///Account password
        ///</summary>
        [ApiMember(Description="Account password", IsRequired=true, Name="Password")]
        public virtual string Password { get; set; }
    }

    public partial class MessagePickupStationDeleteResponse
        : WebServiceResponse
    {
    }

    ///<summary>
    ///Returns all MPS records for this callsign.
    ///</summary>
    [Route("/mps/get", "POST,GET")]
    [Api(Description="Returns all MPS records for this callsign.")]
    public partial class MessagePickupStationGet
        : WebServiceRequest, IReturn<MessagePickupStationGetResponse>
    {
        ///<summary>
        ///Callsign of requestor
        ///</summary>
        [ApiMember(Description="Callsign of requestor", IsRequired=true, Name="Requester")]
        public virtual string Requester { get; set; }

        ///<summary>
        ///Station callsign
        ///</summary>
        [ApiMember(Description="Station callsign", IsRequired=true, Name="Callsign")]
        public virtual string Callsign { get; set; }
    }

    public partial class MessagePickupStationGetResponse
        : WebServiceResponse
    {
        public MessagePickupStationGetResponse()
        {
            MpsList = new List<MessagePickupStationRecord>{};
        }

        public virtual List<MessagePickupStationRecord> MpsList { get; set; }
    }

    ///<summary>
    ///Returns all MPS records. Maximum request frequency - 30 minutes.
    ///</summary>
    [Route("/mps/list", "POST,GET")]
    [Api(Description="Returns all MPS records. Maximum request frequency - 30 minutes.")]
    public partial class MessagePickupStationList
        : WebServiceRequest, IReturn<MessagePickupStationListResponse>
    {
        ///<summary>
        ///Callsign of requestor
        ///</summary>
        [ApiMember(Description="Callsign of requestor", IsRequired=true, Name="Requester")]
        public virtual string Requester { get; set; }
    }

    public partial class MessagePickupStationListResponse
        : WebServiceResponse
    {
        public MessagePickupStationListResponse()
        {
            MpsList = new List<MessagePickupStationRecord>{};
        }

        public virtual List<MessagePickupStationRecord> MpsList { get; set; }
    }

    [DataContract]
    public partial class MessagePickupStationRecord
    {
        [DataMember]
        public virtual DateTime Timestamp { get; set; }

        [DataMember]
        public virtual string Callsign { get; set; }

        [DataMember]
        public virtual string MpsCallsign { get; set; }
    }

    ///<summary>
    ///Sends a message. If successfully posted the message ID is returned with the response.
    ///</summary>
    [Route("/message/send", "POST,GET")]
    [Api(Description="Sends a message. If successfully posted the message ID is returned with the response.")]
    public partial class MessageSend
        : WebServiceRequest, IReturn<MessageSendResponse>
    {
        ///<summary>
        ///The ID of the message. One will be created if not provided
        ///</summary>
        [ApiMember(Description="The ID of the message. One will be created if not provided")]
        public virtual string MessageId { get; set; }

        ///<summary>
        ///The full email message in mime format (headers and body)
        ///</summary>
        [ApiMember(Description="The full email message in mime format (headers and body)", IsRequired=true)]
        public virtual string Mime { get; set; }

        ///<summary>
        ///True to hide message in traffic logs
        ///</summary>
        [ApiMember(Description="True to hide message in traffic logs")]
        public virtual bool Hidden { get; set; }
    }

    public partial class MessageSendResponse
        : WebServiceResponse
    {
        public virtual string MessageId { get; set; }
    }

    ///<summary>
    ///Sends a plain text message to a single recipient. If successfully posted the message ID is returned in the response.
    ///</summary>
    [Route("/message/send/simple", "POST,GET")]
    [Api(Description="Sends a plain text message to a single recipient. If successfully posted the message ID is returned in the response.")]
    public partial class MessageSendSimple
        : WebServiceRequest, IReturn<MessageSendSimpleResponse>
    {
        ///<summary>
        ///The ID of the message. One will be created if not provided
        ///</summary>
        [ApiMember(Description="The ID of the message. One will be created if not provided", Name="MessageId")]
        public virtual string MessageId { get; set; }

        ///<summary>
        ///Sender's callsign or email address
        ///</summary>
        [ApiMember(Description="Sender\'s callsign or email address", IsRequired=true, Name="From")]
        public virtual string From { get; set; }

        ///<summary>
        ///Subject of the message
        ///</summary>
        [ApiMember(Description="Subject of the message", IsRequired=true, Name="Subject")]
        public virtual string Subject { get; set; }

        ///<summary>
        ///Email address (or callsign) of recipient
        ///</summary>
        [ApiMember(Description="Email address (or callsign) of recipient", IsRequired=true, Name="To")]
        public virtual string To { get; set; }

        ///<summary>
        ///Body of message
        ///</summary>
        [ApiMember(Description="Body of message", IsRequired=true, Name="Body")]
        public virtual string Body { get; set; }

        ///<summary>
        ///True to hide message in traffic logs
        ///</summary>
        [ApiMember(Description="True to hide message in traffic logs")]
        public virtual bool Hidden { get; set; }
    }

    public partial class MessageSendSimpleResponse
        : WebServiceResponse
    {
        public virtual string MessageId { get; set; }
    }

    ///<summary>
    ///Sends a simple text message (attachments possible). If successfully posted the message ID is returned in the response.
    ///</summary>
    [Route("/message/send/text", "POST,GET")]
    [Api(Description="Sends a simple text message (attachments possible). If successfully posted the message ID is returned in the response.")]
    public partial class MessageSendText
        : WebServiceRequest, IReturn<MessageSendTextResponse>
    {
        public MessageSendText()
        {
            ToAddresses = new List<string>{};
            CcAddresses = new List<string>{};
            Attachments = new List<Attachment>{};
        }

        ///<summary>
        ///The ID of the message. One will be created if not provided
        ///</summary>
        [ApiMember(Description="The ID of the message. One will be created if not provided", Name="MessageId")]
        public virtual string MessageId { get; set; }

        ///<summary>
        ///Email address of sender
        ///</summary>
        [ApiMember(Description="Email address of sender", IsRequired=true, Name="Sender")]
        public virtual string Sender { get; set; }

        ///<summary>
        ///Message subject
        ///</summary>
        [ApiMember(Description="Message subject", IsRequired=true, Name="Subject")]
        public virtual string Subject { get; set; }

        ///<summary>
        ///One or more recipient email addresses
        ///</summary>
        [ApiMember(Description="One or more recipient email addresses", IsRequired=true, Name="ToAddresses")]
        public virtual List<string> ToAddresses { get; set; }

        ///<summary>
        ///Zero or more recipient cc email addresses
        ///</summary>
        [ApiMember(Description="Zero or more recipient cc email addresses", Name="CcAddresses")]
        public virtual List<string> CcAddresses { get; set; }

        ///<summary>
        ///Body of the message
        ///</summary>
        [ApiMember(Description="Body of the message", Name="Body")]
        public virtual string Body { get; set; }

        ///<summary>
        ///Zero of more attachment records
        ///</summary>
        [ApiMember(Description="Zero of more attachment records", Name="Attachments")]
        public virtual List<Attachment> Attachments { get; set; }

        ///<summary>
        ///True to hide message in traffic logs
        ///</summary>
        [ApiMember(Description="True to hide message in traffic logs")]
        public virtual bool Hidden { get; set; }
    }

    public partial class MessageSendTextResponse
        : WebServiceResponse
    {
        public virtual string MessageId { get; set; }
    }

    [DataContract]
    public enum ModeMappings
    {
        Packet1200 = 0,
        Packet2400 = 1,
        Packet4800 = 2,
        Packet9600 = 3,
        Packet19200 = 4,
        Packet38400 = 5,
        Pactor1 = 11,
        Pactor12 = 12,
        Pactor123 = 13,
        Pactor2 = 14,
        Pactor23 = 15,
        Pactor3 = 16,
        Pactor1234 = 17,
        Pactor234 = 18,
        Pactor34 = 19,
        Pactor4 = 20,
        WINMOR500 = 21,
        WINMOR1600 = 22,
        ROBUSTPACKET = 30,
        ARDOP200 = 40,
        ARDOP500 = 41,
        ARDOP1000 = 42,
        ARDOP2000 = 43,
        ARDOP2000FM = 44,
        VARA = 50,
        VARAFM = 51,
        VARAFMWide = 52,
        VARA500 = 53,
    }

    [DataContract]
    public partial class ParamRecord
    {
        [DataMember]
        public virtual DateTime Timestamp { get; set; }

        [DataMember]
        public virtual string Callsign { get; set; }

        [DataMember]
        public virtual string Param { get; set; }

        [DataMember]
        public virtual string Value { get; set; }
    }

    [DataContract]
    public partial class PartialChannelRecord
    {
        [DataMember]
        public virtual int Frequency { get; set; }

        [DataMember]
        public virtual ModeMappings ProtocolMode { get; set; }

        [DataMember]
        public virtual int Baud { get; set; }

        [DataMember]
        public virtual int Power { get; set; }

        [DataMember]
        public virtual int Height { get; set; }

        [DataMember]
        public virtual int Gain { get; set; }

        [DataMember]
        public virtual int Direction { get; set; }
    }

    [DataContract]
    public partial class PositionReportRecord
    {
        [DataMember]
        public virtual DateTime Timestamp { get; set; }

        [DataMember]
        public virtual string Callsign { get; set; }

        [DataMember]
        public virtual string ReportedBy { get; set; }

        [DataMember]
        public virtual double Latitude { get; set; }

        [DataMember]
        public virtual double Longitude { get; set; }

        [DataMember]
        public virtual string Heading { get; set; }

        [DataMember]
        public virtual string Speed { get; set; }

        [DataMember]
        public virtual string Comment { get; set; }

        [DataMember]
        public virtual bool Marine { get; set; }

        [DataMember]
        public virtual bool Yotreps { get; set; }

        [DataMember]
        public virtual string LatitudeNMEA { get; set; }

        [DataMember]
        public virtual string LongitudeNMEA { get; set; }
    }

    ///<summary>
    ///Submit a new position report.
    ///</summary>
    [Route("/position/reports/add", "POST")]
    [Api(Description="Submit a new position report.")]
    public partial class PositionReportsAdd
        : WebServiceRequest, IReturn<PositionReportsAddResponse>
    {
        ///<summary>
        ///Date and time of the position report
        ///</summary>
        [ApiMember(Description="Date and time of the position report", IsRequired=true)]
        public virtual DateTime Timestamp { get; set; }

        ///<summary>
        ///Callsign of the person the report is for (no SSID)
        ///</summary>
        [ApiMember(Description="Callsign of the person the report is for (no SSID)", IsRequired=true)]
        public virtual string Callsign { get; set; }

        [ApiMember]
        public virtual string ReportedBy { get; set; }

        [ApiMember]
        public virtual double Latitude { get; set; }

        [ApiMember]
        public virtual double Longitude { get; set; }

        [ApiMember]
        public virtual string Heading { get; set; }

        [ApiMember]
        public virtual string Speed { get; set; }

        [ApiMember]
        public virtual string Comment { get; set; }

        [ApiMember]
        public virtual bool Marine { get; set; }

        [ApiMember]
        public virtual bool Yotreps { get; set; }

        [ApiMember]
        [ApiMember(Description="True to have the position sent to APRS servers")]
        public virtual bool EchoToAprs { get; set; }
    }

    public partial class PositionReportsAddResponse
        : WebServiceResponse
    {
    }

    ///<summary>
    ///Returns a list of all position reports for a specific callsign.
    ///</summary>
    [Route("/position/reports/get", "POST,GET")]
    [Api(Description="Returns a list of all position reports for a specific callsign.")]
    public partial class PositionReportsGet
        : WebServiceRequest, IReturn<PositionReportsGetResponse>
    {
        ///<summary>
        ///Station callsign
        ///</summary>
        [ApiMember(Description="Station callsign", IsRequired=true, Name="Callsign")]
        public virtual string Callsign { get; set; }
    }

    public partial class PositionReportsGetResponse
        : WebServiceResponse
    {
        public PositionReportsGetResponse()
        {
            PositionReports = new List<PositionReportRecord>{};
        }

        public virtual List<PositionReportRecord> PositionReports { get; set; }
    }

    ///<summary>
    ///Returns a list of position reports near the last reported position of the specificed callsign.
    ///</summary>
    [Route("/position/reports/nearby", "POST,GET")]
    [Api(Description="Returns a list of position reports near the last reported position of the specificed callsign.")]
    public partial class PositionReportsNearby
        : WebServiceRequest, IReturn<PositionReportsNearbyResponse>
    {
        ///<summary>
        ///Station callsign
        ///</summary>
        [ApiMember(Description="Station callsign", IsRequired=true)]
        public virtual string Callsign { get; set; }

        ///<summary>
        ///Distance from source in nautical miles (default: 100)
        ///</summary>
        [ApiMember(Description="Distance from source in nautical miles (default: 100)")]
        public virtual int DistanceLimitNm { get; set; }

        ///<summary>
        ///Maximum age (in days) of position reports to include (default: 14)
        ///</summary>
        [ApiMember(Description="Maximum age (in days) of position reports to include (default: 14)")]
        public virtual int ReportAgeLimitDays { get; set; }
    }

    public partial class PositionReportsNearbyResponse
        : WebServiceResponse
    {
        public PositionReportsNearbyResponse()
        {
            PositionReports = new List<PositionReportRecord>{};
        }

        public virtual List<PositionReportRecord> PositionReports { get; set; }
    }

    ///<summary>
    ///Returns a list the most recent position reports. Maximum request frequency - 30 minutes.
    ///</summary>
    [Route("/position/reports/recent", "POST,GET")]
    [Api(Description="Returns a list the most recent position reports. Maximum request frequency - 30 minutes.")]
    public partial class PositionReportsRecent
        : WebServiceRequest, IReturn<PositionReportsRecentResponse>
    {
        ///<summary>
        ///Number of hours of history to include (default: 2 weeks)
        ///</summary>
        [ApiMember(Description="Number of hours of history to include (default: 2 weeks)")]
        public virtual int HistoryHours { get; set; }

        ///<summary>
        ///True to include only the latest report from each callsign
        ///</summary>
        [ApiMember(Description="True to include only the latest report from each callsign")]
        public virtual bool OnePerCallsign { get; set; }
    }

    public partial class PositionReportsRecentResponse
        : WebServiceResponse
    {
        public PositionReportsRecentResponse()
        {
            PositionReports = new List<PositionReportRecord>{};
        }

        public virtual int HistoryHours { get; set; }
        public virtual List<PositionReportRecord> PositionReports { get; set; }
    }

    ///<summary>
    ///Returns a list of all position reports for or reported by a specific callsign.
    ///</summary>
    [Route("/position/reports/search", "POST,GET")]
    [Api(Description="Returns a list of all position reports for or reported by a specific callsign.")]
    public partial class PositionReportsSearch
        : WebServiceRequest, IReturn<PositionReportsSearchResponse>
    {
        ///<summary>
        ///Callsign
        ///</summary>
        [ApiMember(Description="Callsign", IsRequired=true, Name="Callsign")]
        public virtual string Callsign { get; set; }
    }

    public partial class PositionReportsSearchResponse
        : WebServiceResponse
    {
        public PositionReportsSearchResponse()
        {
            PositionReports = new List<PositionReportRecord>{};
        }

        public virtual List<PositionReportRecord> PositionReports { get; set; }
    }

    ///<summary>
    ///Update an existing position report.
    ///</summary>
    [Route("/position/reports/update", "POST,GET")]
    [Api(Description="Update an existing position report.")]
    public partial class PositionReportsUpdate
        : WebServiceRequest, IReturn<PositionReportsUpdateResponse>
    {
        ///<summary>
        ///Date and time of the position report
        ///</summary>
        [ApiMember(Description="Date and time of the position report", IsRequired=true)]
        public virtual DateTime Timestamp { get; set; }

        ///<summary>
        ///Callsign of person submitting report
        ///</summary>
        [ApiMember(Description="Callsign of person submitting report", IsRequired=true)]
        public virtual string Callsign { get; set; }

        [ApiMember]
        public virtual string ReportedBy { get; set; }

        [ApiMember]
        public virtual double Latitude { get; set; }

        [ApiMember]
        public virtual double Longitude { get; set; }

        [ApiMember]
        public virtual string Heading { get; set; }

        [ApiMember]
        public virtual string Speed { get; set; }

        [ApiMember]
        public virtual string Comment { get; set; }

        [ApiMember]
        public virtual bool Marine { get; set; }

        [ApiMember]
        public virtual bool Yotreps { get; set; }

        [ApiMember]
        public virtual string LatitudeNMEA { get; set; }

        [ApiMember]
        public virtual string LongitudeNMEA { get; set; }
    }

    public partial class PositionReportsUpdateResponse
        : WebServiceResponse
    {
    }

    ///<summary>
    ///Returns a list of propagation records within the specified sliding time window specified by the parameters
    ///</summary>
    [Route("/propagation/list", "POST,GET")]
    [Api(Description="Returns a list of propagation records within the specified sliding time window specified by the parameters")]
    public partial class PropagationList
        : WebServiceRequest, IReturn<PropagationListResponse>
    {
        ///<summary>
        ///Number of hours back in time to start history (default: 6 hours ago).
        ///</summary>
        [ApiMember(Description="Number of hours back in time to start history (default: 6 hours ago).")]
        public virtual int WindowStart { get; set; }

        ///<summary>
        ///How many hours of history to return (default: 6, max: 24)
        ///</summary>
        [ApiMember(Description="How many hours of history to return (default: 6, max: 24)")]
        public virtual int WindowLength { get; set; }
    }

    public partial class PropagationListResponse
        : WebServiceResponse
    {
        public PropagationListResponse()
        {
            PropagationRecords = new List<PropagationRecord>{};
        }

        public virtual List<PropagationRecord> PropagationRecords { get; set; }
    }

    [DataContract]
    public partial class PropagationRecord
    {
        [DataMember]
        public virtual DateTime Timestamp { get; set; }

        [DataMember]
        public virtual string Server { get; set; }

        [DataMember]
        public virtual string ServerGrid { get; set; }

        [DataMember]
        public virtual double ServerLat { get; set; }

        [DataMember]
        public virtual double ServerLon { get; set; }

        [DataMember]
        public virtual string Client { get; set; }

        [DataMember]
        public virtual string ClientGrid { get; set; }

        [DataMember]
        public virtual double ClientLat { get; set; }

        [DataMember]
        public virtual double ClientLon { get; set; }

        [DataMember]
        public virtual string Mode { get; set; }

        [DataMember]
        public virtual int Frequency { get; set; }

        [DataMember]
        public virtual int HoldingSeconds { get; set; }
    }

    ///<summary>
    ///Adds or replaces a parameter and value for the specified callsign.
    ///</summary>
    [Route("/radioNetwork/params/add", "POST,GET")]
    [Route("/radioNetwork/params/replace", "POST,GET")]
    [Route("/radioNetwork/params/update", "POST,GET")]
    [Api(Description="Adds or replaces a parameter and value for the specified callsign.")]
    public partial class RadioNetworkParamsAdd
        : WebServiceRequest, IReturn<RadioNetworkParamsAddResponse>
    {
        ///<summary>
        ///Station callsign
        ///</summary>
        [ApiMember(Description="Station callsign", IsRequired=true, Name="Callsign")]
        public virtual string Callsign { get; set; }

        ///<summary>
        ///Account password
        ///</summary>
        [ApiMember(Description="Account password", IsRequired=true, Name="Password")]
        public virtual string Password { get; set; }

        ///<summary>
        ///Parameter name
        ///</summary>
        [ApiMember(Description="Parameter name", IsRequired=true, Name="Param")]
        public virtual string Param { get; set; }

        ///<summary>
        ///Parameter value
        ///</summary>
        [ApiMember(Description="Parameter value", Name="Param")]
        public virtual string Value { get; set; }
    }

    public partial class RadioNetworkParamsAddResponse
        : WebServiceResponse
    {
    }

    ///<summary>
    ///Returns the requested parameter record or all records for the specified callsign if no parameter name specified.
    ///</summary>
    [Route("/radioNetwork/params/get", "POST,GET")]
    [Api(Description="Returns the requested parameter record or all records for the specified callsign if no parameter name specified.")]
    public partial class RadioNetworkParamsGet
        : WebServiceRequest, IReturn<RadioNetworkParamsGetResponse>
    {
        ///<summary>
        ///Station callsign
        ///</summary>
        [ApiMember(Description="Station callsign", IsRequired=true, Name="Callsign")]
        public virtual string Callsign { get; set; }

        ///<summary>
        ///Parameter name
        ///</summary>
        [ApiMember(Description="Parameter name", Name="Param")]
        public virtual string Param { get; set; }
    }

    public partial class RadioNetworkParamsGetResponse
        : WebServiceResponse
    {
        public RadioNetworkParamsGetResponse()
        {
            ParamList = new List<ParamRecord>{};
        }

        public virtual List<ParamRecord> ParamList { get; set; }
    }

    ///<summary>
    ///Returns a list of all parameter records for all callsigns. Maximum request frequency - 30 minutes.
    ///</summary>
    [Route("/radioNetwork/params", "POST,GET")]
    [Route("/radioNetwork/params/list", "POST,GET")]
    [Api(Description="Returns a list of all parameter records for all callsigns. Maximum request frequency - 30 minutes.")]
    public partial class RadioNetworkParamsList
        : WebServiceRequest, IReturn<RadioNetworkParamsListResponse>
    {
    }

    public partial class RadioNetworkParamsListResponse
        : WebServiceResponse
    {
        public RadioNetworkParamsListResponse()
        {
            ParamList = new List<ParamRecord>{};
        }

        public virtual List<ParamRecord> ParamList { get; set; }
    }

    ///<summary>
    ///Adds a gateway session record to the database.
    ///</summary>
    [Route("/session/add", "POST,GET")]
    [Api(Description="Adds a gateway session record to the database.")]
    public partial class SessionAdd
        : WebServiceRequest, IReturn<SessionAddResponse>
    {
        ///<summary>
        ///Name of the application
        ///</summary>
        [ApiMember(Description="Name of the application", IsRequired=true)]
        public virtual string Application { get; set; }

        public virtual string Version { get; set; }
        public virtual string Cms { get; set; }
        ///<summary>
        ///Callsign of server (gateway)
        ///</summary>
        [ApiMember(Description="Callsign of server (gateway)", IsRequired=true)]
        public virtual string Server { get; set; }

        ///<summary>
        ///Server grid locator
        ///</summary>
        [ApiMember(Description="Server grid locator", IsRequired=true)]
        public virtual string ServerGrid { get; set; }

        ///<summary>
        ///Callsign of client
        ///</summary>
        [ApiMember(Description="Callsign of client", IsRequired=true)]
        public virtual string Client { get; set; }

        ///<summary>
        ///Client grid locator
        ///</summary>
        [ApiMember(Description="Client grid locator", IsRequired=true)]
        public virtual string ClientGrid { get; set; }

        public virtual string Sid { get; set; }
        public virtual string Mode { get; set; }
        public virtual int Frequency { get; set; }
        public virtual int Kilometers { get; set; }
        public virtual int Degrees { get; set; }
        public virtual string LastCommand { get; set; }
        public virtual int MessagesSent { get; set; }
        public virtual int MessagesReceived { get; set; }
        public virtual int BytesSent { get; set; }
        public virtual int BytesReceived { get; set; }
        public virtual int HoldingSeconds { get; set; }
        public virtual string IdTag { get; set; }
    }

    public partial class SessionAddResponse
        : WebServiceResponse
    {
    }

    ///<summary>
    ///Returns a sysop record. Requires account password.
    ///</summary>
    [Route("/sysop2/get", "POST,GET")]
    [Api(Description="Returns a sysop record. Requires account password.")]
    public partial class Sysop2Get
        : WebServiceRequest, IReturn<Sysop2GetResponse>
    {
        ///<summary>
        ///Sysop callsign (no SSID)
        ///</summary>
        [ApiMember(Description="Sysop callsign (no SSID)", IsRequired=true, Name="Callsign")]
        public virtual string Callsign { get; set; }

        ///<summary>
        ///Account password
        ///</summary>
        [ApiMember(Description="Account password", IsRequired=true, Name="Password")]
        public virtual string Password { get; set; }
    }

    public partial class Sysop2GetResponse
        : WebServiceResponse
    {
        public virtual SysopRecord Sysop { get; set; }
    }

    ///<summary>
    ///Add/update a sysop record.
    ///</summary>
    [Route("/sysop/add", "POST,GET")]
    [Api(Description="Add/update a sysop record.")]
    public partial class SysopAdd
        : WebServiceRequest, IReturn<SysopAddResponse>
    {
        ///<summary>
        ///Sysop callsign (no SSID)
        ///</summary>
        [ApiMember(Description="Sysop callsign (no SSID)", IsRequired=true, Name="Callsign")]
        public virtual string Callsign { get; set; }

        ///<summary>
        ///Account password
        ///</summary>
        [ApiMember(Description="Account password", IsRequired=true, Name="Password")]
        public virtual string Password { get; set; }

        ///<summary>
        ///6 digit grid locator
        ///</summary>
        [ApiMember(Description="6 digit grid locator", IsRequired=true, Name="GridSquare")]
        public virtual string GridSquare { get; set; }

        ///<summary>
        ///
        ///</summary>
        [ApiMember(Description="", IsRequired=true, Name="SysopName")]
        public virtual string SysopName { get; set; }

        ///<summary>
        ///
        ///</summary>
        [ApiMember(Description="", Name="StreetAddress1")]
        public virtual string StreetAddress1 { get; set; }

        ///<summary>
        ///
        ///</summary>
        [ApiMember(Description="", Name="StreetAddress2")]
        public virtual string StreetAddress2 { get; set; }

        ///<summary>
        ///
        ///</summary>
        [ApiMember(Description="", Name="City")]
        public virtual string City { get; set; }

        ///<summary>
        ///
        ///</summary>
        [ApiMember(Description="", Name="State")]
        public virtual string State { get; set; }

        ///<summary>
        ///
        ///</summary>
        [ApiMember(Description="", Name="Country")]
        public virtual string Country { get; set; }

        ///<summary>
        ///
        ///</summary>
        [ApiMember(Description="", Name="PostalCode")]
        public virtual string PostalCode { get; set; }

        ///<summary>
        ///
        ///</summary>
        [ApiMember(Description="", IsRequired=true, Name="Email")]
        public virtual string Email { get; set; }

        ///<summary>
        ///
        ///</summary>
        [ApiMember(Description="", Name="Phones")]
        public virtual string Phones { get; set; }

        ///<summary>
        ///
        ///</summary>
        [ApiMember(Description="", Name="Website")]
        public virtual string Website { get; set; }

        ///<summary>
        ///
        ///</summary>
        [ApiMember(Description="", Name="Comments")]
        public virtual string Comments { get; set; }
    }

    public partial class SysopAddResponse
        : WebServiceResponse
    {
    }

    ///<summary>
    ///Returns an array of data structures containing combined channel and sysop information.
    ///</summary>
    [Route("/sysopChannels", "POST,GET")]
    [Route("/sysop/channels", "POST,GET")]
    [Api(Description="Returns an array of data structures containing combined channel and sysop information.")]
    public partial class SysopChannelsList
        : WebServiceRequest, IReturn<SysopChannelsListResponse>
    {
        ///<summary>
        ///Number of hours of history to include (default: 6)
        ///</summary>
        [ApiMember(Description="Number of hours of history to include (default: 6)", Name="HistoryHours")]
        public virtual int HistoryHours { get; set; }

        ///<summary>
        ///One of Packet, Pactor, Winmor, RobustPacket, or AnyAll (default: AnyAll)
        ///</summary>
        [ApiMember(Description="One of Packet, Pactor, Winmor, RobustPacket, or AnyAll (default: AnyAll)", Name="Mode")]
        public virtual GatewayOperatingMode OperatingMode { get; set; }

        ///<summary>
        ///One or more service codes (default: PUBLIC)
        ///</summary>
        [ApiMember(Description="One or more service codes (default: PUBLIC)", Name="ServiceCodes")]
        public virtual string ServiceCodes { get; set; }

        ///<summary>
        ///Include information for unauthorized gateways
        ///</summary>
        [ApiMember(Description="Include information for unauthorized gateways", Name="IncludeUnauthorized")]
        public virtual bool IncludeUnauthorized { get; set; }
    }

    public partial class SysopChannelsListResponse
        : WebServiceResponse
    {
        public SysopChannelsListResponse()
        {
            ChannelList = new List<SysopChannelsRecord>{};
        }

        public virtual List<SysopChannelsRecord> ChannelList { get; set; }
    }

    [DataContract]
    public partial class SysopChannelsRecord
    {
        [DataMember]
        public virtual DateTime Timestamp { get; set; }

        [DataMember]
        public virtual string Callsign { get; set; }

        [DataMember]
        public virtual string BaseCallsign { get; set; }

        [DataMember]
        public virtual string SysopName { get; set; }

        [DataMember]
        public virtual string StreetAddress1 { get; set; }

        [DataMember]
        public virtual string StreetAddress2 { get; set; }

        [DataMember]
        public virtual string City { get; set; }

        [DataMember]
        public virtual string State { get; set; }

        [DataMember]
        public virtual string Country { get; set; }

        [DataMember]
        public virtual string PostalCode { get; set; }

        [DataMember]
        public virtual string EMail { get; set; }

        [DataMember]
        public virtual string WebSite { get; set; }

        [DataMember]
        public virtual string Gridsquare { get; set; }

        [DataMember]
        public virtual int Frequency { get; set; }

        [DataMember]
        public virtual int Mode { get; set; }

        [DataMember]
        public virtual int Baud { get; set; }

        [DataMember]
        public virtual string OperatingHours { get; set; }

        [DataMember]
        public virtual string ServiceCode { get; set; }

        [DataMember]
        public virtual bool GatewayAuthorized { get; set; }

        [DataMember]
        public virtual string Phones { get; set; }
    }

    ///<summary>
    ///Returns zero or more records that partially match the specified filter.
    ///</summary>
    [Route("/sysop/filter", "POST,GET")]
    [Api(Description="Returns zero or more records that partially match the specified filter.")]
    public partial class SysopFilter
        : WebServiceRequest, IReturn<SysopFilterResponse>
    {
        ///<summary>
        ///Filter text applied to multiple fields
        ///</summary>
        [ApiMember(Description="Filter text applied to multiple fields")]
        public virtual string Filter { get; set; }

        ///<summary>
        ///Limit number of returned records (default: 100)
        ///</summary>
        [ApiMember(Description="Limit number of returned records (default: 100)")]
        public virtual int RecordLimit { get; set; }
    }

    public partial class SysopFilterResponse
        : WebServiceResponse
    {
        public SysopFilterResponse()
        {
            SysopList = new List<SysopRecord>{};
        }

        public virtual List<SysopRecord> SysopList { get; set; }
    }

    ///<summary>
    ///Returns a list of all sysop records.
    ///</summary>
    [Route("/sysop/list", "POST,GET")]
    [Api(Description="Returns a list of all sysop records.")]
    public partial class SysopList
        : WebServiceRequest, IReturn<SysopListResponse>
    {
    }

    public partial class SysopListResponse
        : WebServiceResponse
    {
        public SysopListResponse()
        {
            SysopList = new List<SysopRecord>{};
        }

        public virtual List<SysopRecord> SysopList { get; set; }
    }

    [DataContract]
    public partial class SysopRecord
    {
        [DataMember]
        public virtual DateTime Timestamp { get; set; }

        [DataMember]
        public virtual string Callsign { get; set; }

        [DataMember]
        public virtual string GridSquare { get; set; }

        [DataMember]
        public virtual string SysopName { get; set; }

        [DataMember]
        public virtual string StreetAddress1 { get; set; }

        [DataMember]
        public virtual string StreetAddress2 { get; set; }

        [DataMember]
        public virtual string City { get; set; }

        [DataMember]
        public virtual string State { get; set; }

        [DataMember]
        public virtual string Country { get; set; }

        [DataMember]
        public virtual string PostalCode { get; set; }

        [DataMember]
        public virtual string Email { get; set; }

        [DataMember]
        public virtual string Phones { get; set; }

        [DataMember]
        public virtual string Website { get; set; }

        [DataMember]
        public virtual string Comments { get; set; }
    }

    ///<summary>
    ///Add P2P traffic information to the CMS for audit purposes
    ///</summary>
    [Route("/traffic/add", "POST,GET")]
    [Api(Description="Add P2P traffic information to the CMS for audit purposes")]
    public partial class TrafficAdd
        : WebServiceRequest, IReturn<TrafficAddResponse>
    {
        ///<summary>
        ///The date/time value when the message was sent or received
        ///</summary>
        [ApiMember(Description="The date/time value when the message was sent or received", IsRequired=true)]
        public virtual DateTime Timestamp { get; set; }

        ///<summary>
        ///The ID of the message
        ///</summary>
        [ApiMember(Description="The ID of the message", IsRequired=true)]
        public virtual string MessageId { get; set; }

        ///<summary>
        ///Station base callsign
        ///</summary>
        [ApiMember(Description="Station base callsign", IsRequired=true)]
        public virtual string Callsign { get; set; }

        ///<summary>
        ///Frequency of the connection in Hz
        ///</summary>
        [ApiMember(Description="Frequency of the connection in Hz", IsRequired=true)]
        public virtual int Frequency { get; set; }

        ///<summary>
        ///Name of client program
        ///</summary>
        [ApiMember(Description="Name of client program", IsRequired=true)]
        public virtual ClientType Client { get; set; }

        ///<summary>
        ///Message event - forwarded, received, rejected, etc.
        ///</summary>
        [ApiMember(Description="Message event - forwarded, received, rejected, etc.", IsRequired=true)]
        public virtual EventType Event { get; set; }

        ///<summary>
        ///Type of message traffic - via gateway, telnet, p2p, radio only, etc.
        ///</summary>
        [ApiMember(Description="Type of message traffic - via gateway, telnet, p2p, radio only, etc.", IsRequired=true)]
        public virtual TrafficType TrafficType { get; set; }

        ///<summary>
        ///Valid mime message
        ///</summary>
        [ApiMember(Description="Valid mime message", IsRequired=true)]
        public virtual string Mime { get; set; }
    }

    public partial class TrafficAddResponse
        : WebServiceResponse
    {
    }

    ///<summary>
    ///Returns a list of programs used by clients and their versions. If Program is specified the results will be for that particular program only. Maximum request frequency - 10 minutes.
    ///</summary>
    [Route("/version/list", "POST,GET")]
    [Api(Description="Returns a list of programs used by clients and their versions. If Program is specified the results will be for that particular program only. Maximum request frequency - 10 minutes.")]
    public partial class VersionList
        : WebServiceRequest, IReturn<VersionListResponse>
    {
        ///<summary>
        ///Name of program (e.g., RMS Packet)
        ///</summary>
        [ApiMember(Description="Name of program (e.g., RMS Packet)", Name="Program")]
        public virtual string Program { get; set; }

        ///<summary>
        ///Number of hours of history to include (default: 24)
        ///</summary>
        [ApiMember(Description="Number of hours of history to include (default: 24)", Name="HistoryHours")]
        public virtual int HistoryHours { get; set; }
    }

    public partial class VersionListResponse
        : WebServiceResponse
    {
        public VersionListResponse()
        {
            VersionList = new List<VersionRecord>{};
        }

        public virtual List<VersionRecord> VersionList { get; set; }
    }

    [DataContract]
    public partial class VersionRecord
    {
        [DataMember]
        public virtual DateTime Timestamp { get; set; }

        [DataMember]
        public virtual string Callsign { get; set; }

        [DataMember]
        public virtual string Program { get; set; }

        [DataMember]
        public virtual string Version { get; set; }

        [DataMember]
        public virtual string Comments { get; set; }
    }

    ///<summary>
    ///Deletes the specified watch
    ///</summary>
    [Route("/watch/delete", "POST,GET")]
    [Api(Description="Deletes the specified watch")]
    public partial class WatchDelete
        : WebServiceRequest, IReturn<WatchDeleteResponse>
    {
        ///<summary>
        ///Callsign associated with the watch
        ///</summary>
        [ApiMember(Description="Callsign associated with the watch", IsRequired=true)]
        public virtual string Callsign { get; set; }

        ///<summary>
        ///Callsign account password
        ///</summary>
        [ApiMember(Description="Callsign account password", IsRequired=true)]
        public virtual string Password { get; set; }

        ///<summary>
        ///Program name
        ///</summary>
        [ApiMember(Description="Program name", IsRequired=true)]
        public virtual string Program { get; set; }
    }

    public partial class WatchDeleteResponse
        : WebServiceResponse
    {
    }

    ///<summary>
    ///Returns a watch record for the specified callsign and program
    ///</summary>
    [Route("/watch/get", "POST,GET")]
    [Api(Description="Returns a watch record for the specified callsign and program")]
    public partial class WatchGet
        : WebServiceRequest, IReturn<WatchGetResponse>
    {
        ///<summary>
        ///Callsign associated with the watch
        ///</summary>
        [ApiMember(Description="Callsign associated with the watch", IsRequired=true)]
        public virtual string Callsign { get; set; }

        ///<summary>
        ///Callsign account password
        ///</summary>
        [ApiMember(Description="Callsign account password", IsRequired=true)]
        public virtual string Password { get; set; }

        ///<summary>
        ///Program name
        ///</summary>
        [ApiMember(Description="Program name", IsRequired=true)]
        public virtual string Program { get; set; }
    }

    public partial class WatchGetResponse
        : WebServiceResponse
    {
        public virtual DateTime Timestamp { get; set; }
        public virtual string Callsign { get; set; }
        public virtual string Program { get; set; }
        public virtual int AllowedTardyHours { get; set; }
        public virtual string NotificationEmails { get; set; }
    }

    ///<summary>
    ///Returns a list of watch records for the specified callsign
    ///</summary>
    [Route("/watch/list", "POST,GET")]
    [Api(Description="Returns a list of watch records for the specified callsign")]
    public partial class WatchList
        : WebServiceRequest, IReturn<WatchListResponse>
    {
        ///<summary>
        ///Callsign associated with the watch
        ///</summary>
        [ApiMember(Description="Callsign associated with the watch", IsRequired=true)]
        public virtual string Callsign { get; set; }

        ///<summary>
        ///Callsign account password
        ///</summary>
        [ApiMember(Description="Callsign account password", IsRequired=true)]
        public virtual string Password { get; set; }
    }

    public partial class WatchListResponse
        : WebServiceResponse
    {
        public WatchListResponse()
        {
            List = new List<WatchRecord>{};
        }

        public virtual List<WatchRecord> List { get; set; }
    }

    ///<summary>
    ///Updates status of the watched program. Ping frequency no more than once every hour. The watch will be disabled automatically for programs that ping too frequently.
    ///</summary>
    [Route("/watch/ping", "POST,GET")]
    [Api(Description="Updates status of the watched program. Ping frequency no more than once every hour. The watch will be disabled automatically for programs that ping too frequently.")]
    public partial class WatchPing
        : WebServiceRequest, IReturn<WatchPingResponse>
    {
        ///<summary>
        ///Callsign
        ///</summary>
        [ApiMember(Description="Callsign", IsRequired=true)]
        public virtual string Callsign { get; set; }

        ///<summary>
        ///Program name
        ///</summary>
        [ApiMember(Description="Program name", IsRequired=true)]
        public virtual string Program { get; set; }
    }

    public partial class WatchPingResponse
        : WebServiceResponse
    {
    }

    [DataContract]
    public partial class WatchRecord
    {
        [DataMember]
        public virtual DateTime Timestamp { get; set; }

        [DataMember]
        public virtual string Callsign { get; set; }

        [DataMember]
        public virtual string Program { get; set; }

        [DataMember]
        public virtual int AllowedTardyHours { get; set; }

        [DataMember]
        public virtual string NotificationEmails { get; set; }
    }

    ///<summary>
    ///Establishes a watch for a program
    ///</summary>
    [Route("/watch/set", "POST,GET")]
    [Api(Description="Establishes a watch for a program")]
    public partial class WatchSet
        : WebServiceRequest, IReturn<WatchSetResponse>
    {
        ///<summary>
        ///Callsign
        ///</summary>
        [ApiMember(Description="Callsign", IsRequired=true)]
        public virtual string Callsign { get; set; }

        ///<summary>
        ///Callsign account password
        ///</summary>
        [ApiMember(Description="Callsign account password", IsRequired=true)]
        public virtual string Password { get; set; }

        ///<summary>
        ///Program name (additional text could be included to differentiate between multiple programs with the same name)
        ///</summary>
        [ApiMember(Description="Program name (additional text could be included to differentiate between multiple programs with the same name)", IsRequired=true)]
        public virtual string Program { get; set; }

        ///<summary>
        ///Number of hours before the program is considered off-line (0 to disable). Two hours or greater since pings are sent at a maximum rate of once an hour.
        ///</summary>
        [ApiMember(Description="Number of hours before the program is considered off-line (0 to disable). Two hours or greater since pings are sent at a maximum rate of once an hour.", IsRequired=true)]
        public virtual int AllowedTardyHours { get; set; }

        ///<summary>
        ///Email addresses to send notifications to (comma-separated). If blank, notifications are sent to the callsign account.
        ///</summary>
        [ApiMember(Description="Email addresses to send notifications to (comma-separated). If blank, notifications are sent to the callsign account.")]
        public virtual string NotificationEmails { get; set; }
    }

    public partial class WatchSetResponse
        : WebServiceResponse
    {
    }

    ///<summary>
    ///Submit a new weather report.
    ///</summary>
    [Route("/weather/report/add", "POST,GET")]
    [Api(Description="Submit a new weather report.")]
    public partial class WeatherReportAdd
        : WebServiceRequest, IReturn<WeatherReportAddResponse>
    {
        ///<summary>
        ///Date and time of the weather report
        ///</summary>
        [ApiMember(Description="Date and time of the weather report", IsRequired=true)]
        public virtual DateTime Timestamp { get; set; }

        ///<summary>
        ///Callsign of person submitting report
        ///</summary>
        [ApiMember(Description="Callsign of person submitting report", IsRequired=true)]
        public virtual string Callsign { get; set; }

        [ApiMember(IsRequired=true)]
        public virtual double Latitude { get; set; }

        [ApiMember(IsRequired=true)]
        public virtual double Longitude { get; set; }

        [ApiMember]
        public virtual string Barometer { get; set; }

        [ApiMember]
        public virtual string Trend { get; set; }

        [ApiMember]
        public virtual string Visibility { get; set; }

        [ApiMember]
        public virtual string CloudCover { get; set; }

        [ApiMember]
        public virtual string WindSpeed { get; set; }

        [ApiMember]
        public virtual string WindDirection { get; set; }

        [ApiMember]
        public virtual string SwellHeight { get; set; }

        [ApiMember]
        public virtual string SwellDirection { get; set; }

        [ApiMember]
        public virtual string SwellPeriod { get; set; }

        [ApiMember]
        public virtual string WaveHeight { get; set; }

        [ApiMember]
        public virtual string WaveDirection { get; set; }

        [ApiMember]
        public virtual string WavePeriod { get; set; }

        [ApiMember]
        public virtual string AirTemperature { get; set; }

        [ApiMember]
        public virtual string SeaTemperature { get; set; }
    }

    public partial class WeatherReportAddResponse
        : WebServiceResponse
    {
    }

    public partial class WebServiceRequest
    {
        ///<summary>
        ///Web service access key -- allows use of Winlink web services
        ///</summary>
        [ApiMember(Description="Web service access key -- allows use of Winlink web services", IsRequired=true, Name="Key")]
        public virtual string Key { get; set; }
    }

    public partial class WebServiceResponse
    {
        public virtual ResponseStatus ResponseStatus { get; set; }
    }
}

namespace winlink.util
{

    [DataContract]
    public partial class LicenseRecord
    {
        [DataMember]
        public virtual DateTime Timestamp { get; set; }

        [DataMember]
        public virtual string Callsign { get; set; }

        [DataMember]
        public virtual string StatusDescription { get; set; }

        [DataMember]
        public virtual string LicenseName { get; set; }

        [DataMember]
        public virtual DateTime RecheckDate { get; set; }

        [DataMember]
        public virtual string Country { get; set; }

        [DataMember]
        public virtual LicenseStatus Status { get; set; }

        [DataMember]
        public virtual string ServiceUsed { get; set; }

        [DataMember]
        public virtual string Comments { get; set; }
    }

    [DataContract]
    public enum LicenseStatus
    {
        Unknown,
        Valid,
        Invalid,
        Exempt,
        Expired,
    }
}

