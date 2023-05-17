/* Options:
Date: 2023-05-17 04:06:47
Version: 5.140
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
        WoAD,
        RadioMail,
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
    ///Returns a collection of details about the user's account
    ///</summary>
    [Route("/about/user", "POST,GET")]
    [Api(Description="Returns a collection of details about the user's account")]
    public partial class AboutUser
        : WebServiceRequest, IReturn<AboutUserResponse>
    {
        ///<summary>
        ///Account callsign (no SSID)
        ///</summary>
        [ApiMember(Description="Account callsign (no SSID)", IsRequired=true)]
        public virtual string Callsign { get; set; }
    }

    public partial class AboutUserResponse
        : WebServiceResponse
    {
        public AboutUserResponse()
        {
            Activity = new List<ActivityRecord>{};
            Donations = new List<DonationRecord>{};
            EmailAliasList = new List<EmailAliasRecord>{};
            GatewayChannels = new List<ChannelRecord>{};
            IPAddresses = new List<IPAddressRecord>{};
            MpsList = new List<MessagePickupStationRecord>{};
            PositionReports = new List<PositionReportRecord>{};
            SessionRecords = new List<SessionRecord>{};
            TrafficLogs = new List<TrafficRecord>{};
            VersionList = new List<VersionRecord>{};
            WhiteList = new List<WhitelistRecord>{};
        }

        public virtual string Callsign { get; set; }
        public virtual string Password { get; set; }
        public virtual string CallsignPrefix { get; set; }
        public virtual string CallsignSuffix { get; set; }
        public virtual bool IsTactical { get; set; }
        public virtual string AlternateEmailAddress { get; set; }
        public virtual string PasswordRecoveryAddress { get; set; }
        public virtual bool NoPurge { get; set; }
        public virtual bool GatewayAccess { get; set; }
        public virtual bool LockedOut { get; set; }
        public virtual string LockedOutReason { get; set; }
        public virtual int MaxMessageSize { get; set; }
        public virtual int PendingMessages { get; set; }
        public virtual DateTime LastAccess { get; set; }
        public virtual List<ActivityRecord> Activity { get; set; }
        public virtual List<DonationRecord> Donations { get; set; }
        public virtual List<EmailAliasRecord> EmailAliasList { get; set; }
        public virtual List<ChannelRecord> GatewayChannels { get; set; }
        public virtual List<IPAddressRecord> IPAddresses { get; set; }
        public virtual List<MessagePickupStationRecord> MpsList { get; set; }
        public virtual List<PositionReportRecord> PositionReports { get; set; }
        public virtual List<SessionRecord> SessionRecords { get; set; }
        public virtual SysopRecord SysopData { get; set; }
        public virtual List<TrafficRecord> TrafficLogs { get; set; }
        public virtual List<VersionRecord> VersionList { get; set; }
        public virtual List<WhitelistRecord> WhiteList { get; set; }
    }

    ///<summary>
    ///Adds a new callsign or tactical account. Password can be no less than 6 and no more than 12 characters long. Password can be blank for tactical accounts only.
    ///</summary>
    [Route("/account/add", "POST")]
    [Api(Description="Adds a new callsign or tactical account. Password can be no less than 6 and no more than 12 characters long. Password can be blank for tactical accounts only.")]
    public partial class AccountAdd
        : WebServiceRequest, IReturn<AccountAddResponse>
    {
        ///<summary>
        ///Account callsign or tactical address
        ///</summary>
        [ApiMember(Description="Account callsign or tactical address", IsRequired=true, Name="Callsign")]
        public virtual string Callsign { get; set; }

        ///<summary>
        ///Account password
        ///</summary>
        [ApiMember(Description="Account password", IsRequired=true, Name="Password")]
        public virtual string Password { get; set; }
    }

    public partial class AccountAddResponse
        : WebServiceResponse
    {
    }

    ///<summary>
    ///Gets the alternate email associated with this callsign. This is the forwarding email address.
    ///</summary>
    [Route("/account/alternateEmail/get", "POST,GET")]
    [Api(Description="Gets the alternate email associated with this callsign. This is the forwarding email address.")]
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
    ///Sets the alternate email address for this callsign. This is the forwarding email address.
    ///</summary>
    [Route("/account/alternateEmail/set", "POST,GET")]
    [Api(Description="Sets the alternate email address for this callsign. This is the forwarding email address.")]
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
    ///Gets the callsign prefix for this callsign.
    ///</summary>
    [Route("/account/callsignPrefix/get", "POST,GET")]
    [Api(Description="Gets the callsign prefix for this callsign.")]
    public partial class AccountCallsignPrefixGet
        : WebServiceRequest, IReturn<AccountCallsignPrefixGetResponse>
    {
        ///<summary>
        ///Account callsign
        ///</summary>
        [ApiMember(Description="Account callsign", IsRequired=true, Name="Callsign")]
        public virtual string Callsign { get; set; }
    }

    public partial class AccountCallsignPrefixGetResponse
        : WebServiceResponse
    {
        public virtual string CallsignPrefix { get; set; }
    }

    ///<summary>
    ///Sets the callsign prefix for this callsign.
    ///</summary>
    [Route("/account/callsignPrefix/set", "POST,GET")]
    [Api(Description="Sets the callsign prefix for this callsign.")]
    public partial class AccountCallsignPrefixSet
        : WebServiceRequest, IReturn<AccountCallsignPrefixSetResponse>
    {
        ///<summary>
        ///Account callsign
        ///</summary>
        [ApiMember(Description="Account callsign", IsRequired=true, Name="Callsign")]
        public virtual string Callsign { get; set; }

        ///<summary>
        ///Callsign prefix
        ///</summary>
        [ApiMember(Description="Callsign prefix", IsRequired=true, Name="CallsignPrefix")]
        public virtual string CallsignPrefix { get; set; }
    }

    public partial class AccountCallsignPrefixSetResponse
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
    ///Gets the callsign suffix for this callsign.
    ///</summary>
    [Route("/account/callsignSuffix/get", "POST,GET")]
    [Api(Description="Gets the callsign suffix for this callsign.")]
    public partial class AccountCallsignSuffixGet
        : WebServiceRequest, IReturn<AccountCallsignSuffixGetResponse>
    {
        ///<summary>
        ///Account callsign
        ///</summary>
        [ApiMember(Description="Account callsign", IsRequired=true, Name="Callsign")]
        public virtual string Callsign { get; set; }
    }

    public partial class AccountCallsignSuffixGetResponse
        : WebServiceResponse
    {
        public virtual string CallsignSuffix { get; set; }
    }

    ///<summary>
    ///Sets the callsign suffix for this callsign.
    ///</summary>
    [Route("/account/callsignSuffix/set", "POST,GET")]
    [Api(Description="Sets the callsign suffix for this callsign.")]
    public partial class AccountCallsignSuffixSet
        : WebServiceRequest, IReturn<AccountCallsignSuffixSetResponse>
    {
        ///<summary>
        ///Account callsign
        ///</summary>
        [ApiMember(Description="Account callsign", IsRequired=true, Name="Callsign")]
        public virtual string Callsign { get; set; }

        ///<summary>
        ///Callsign suffix
        ///</summary>
        [ApiMember(Description="Callsign suffix", IsRequired=true, Name="CallsignSuffix")]
        public virtual string CallsignSuffix { get; set; }
    }

    public partial class AccountCallsignSuffixSetResponse
        : WebServiceResponse
    {
    }

    ///<summary>
    ///Determines if the specified callsign or tactical account exists in the Winlink system. Request frequency: no more than once a day.
    ///</summary>
    [Route("/account/exists", "POST,GET")]
    [Api(Description="Determines if the specified callsign or tactical account exists in the Winlink system. Request frequency: no more than once a day.")]
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
    ///Gets the state of the gateway access setting. This setting indicates if the callsign has been approved to operate as a gateway.
    ///</summary>
    [Route("/account/gatewayAccess/get", "POST,GET")]
    [Api(Description="Gets the state of the gateway access setting. This setting indicates if the callsign has been approved to operate as a gateway.")]
    public partial class AccountGatewayAccessGet
        : WebServiceRequest, IReturn<AccountGatewayAccessGetResponse>
    {
        ///<summary>
        ///Account callsign
        ///</summary>
        [ApiMember(Description="Account callsign", IsRequired=true, Name="Callsign")]
        public virtual string Callsign { get; set; }
    }

    public partial class AccountGatewayAccessGetResponse
        : WebServiceResponse
    {
        public virtual bool GatewayAccess { get; set; }
    }

    ///<summary>
    ///Gets a list of all gateway authorized callsigns.
    ///</summary>
    [Route("/account/gatewayAccess/list", "POST,GET")]
    [Api(Description="Gets a list of all gateway authorized callsigns.")]
    public partial class AccountGatewayAccessList
        : WebServiceRequest, IReturn<AccountGatewayAccessListResponse>
    {
    }

    public partial class AccountGatewayAccessListResponse
        : WebServiceResponse
    {
        public AccountGatewayAccessListResponse()
        {
            GatewayAuthorized = new List<string>{};
        }

        public virtual List<string> GatewayAuthorized { get; set; }
    }

    ///<summary>
    ///Sets the state of the gateway access setting.
    ///</summary>
    [Route("/account/gatewayAccess/set", "POST,GET")]
    [Api(Description="Sets the state of the gateway access setting.")]
    public partial class AccountGatewayAccessSet
        : WebServiceRequest, IReturn<AccountGatewayAccessSetResponse>
    {
        ///<summary>
        ///Account callsign
        ///</summary>
        [ApiMember(Description="Account callsign", IsRequired=true, Name="Callsign")]
        public virtual string Callsign { get; set; }

        ///<summary>
        ///Controls who can act as a Winlink gateway
        ///</summary>
        [ApiMember(Description="Controls who can act as a Winlink gateway", IsRequired=true, Name="GatewayAccess")]
        public virtual bool? GatewayAccess { get; set; }
    }

    public partial class AccountGatewayAccessSetResponse
        : WebServiceResponse
    {
    }

    ///<summary>
    ///Determines if the specified callsign or tactical account is a group address account.
    ///</summary>
    [Route("/account/isGroupAddress", "POST,GET")]
    [Api(Description="Determines if the specified callsign or tactical account is a group address account.")]
    public partial class AccountIsGroupAddress
        : WebServiceRequest, IReturn<AccountIsGroupAddressResponse>
    {
        ///<summary>
        ///Account callsign or tactical
        ///</summary>
        [ApiMember(Description="Account callsign or tactical", IsRequired=true, Name="Callsign")]
        public virtual string Callsign { get; set; }
    }

    public partial class AccountIsGroupAddressResponse
        : WebServiceResponse
    {
        public virtual bool IsGroupAddress { get; set; }
    }

    ///<summary>
    ///Returns last time the callsign account was used.
    ///</summary>
    [Route("/account/lastAccess/get", "POST,GET")]
    [Api(Description="Returns last time the callsign account was used.")]
    public partial class AccountLastAccessGet
        : WebServiceRequest, IReturn<AccountLastAccessGetResponse>
    {
        ///<summary>
        ///Account callsign
        ///</summary>
        [ApiMember(Description="Account callsign", IsRequired=true, Name="Callsign")]
        public virtual string Callsign { get; set; }
    }

    public partial class AccountLastAccessGetResponse
        : WebServiceResponse
    {
        public virtual DateTime LastAccess { get; set; }
    }

    ///<summary>
    ///Unlocks a callsign account - allowing access.
    ///</summary>
    [Route("/account/lockedOut/clear", "POST,GET")]
    [Api(Description="Unlocks a callsign account - allowing access.")]
    public partial class AccountLockedOutClear
        : WebServiceRequest, IReturn<AccountLockedOutClearResponse>
    {
        ///<summary>
        ///Account callsign
        ///</summary>
        [ApiMember(Description="Account callsign", IsRequired=true)]
        public virtual string Callsign { get; set; }
    }

    public partial class AccountLockedOutClearResponse
        : WebServiceResponse
    {
    }

    ///<summary>
    ///Gets the state of the locked out setting for the specified account.
    ///</summary>
    [Route("/account/lockedOut/get", "POST,GET")]
    [Api(Description="Gets the state of the locked out setting for the specified account.")]
    public partial class AccountLockedOutGet
        : WebServiceRequest, IReturn<AccountLockedOutGetResponse>
    {
        ///<summary>
        ///Account callsign
        ///</summary>
        [ApiMember(Description="Account callsign", IsRequired=true, Name="Callsign")]
        public virtual string Callsign { get; set; }
    }

    public partial class AccountLockedOutGetResponse
        : WebServiceResponse
    {
        public virtual bool LockedOut { get; set; }
    }

    ///<summary>
    ///Returns a list of locked out accounts.
    ///</summary>
    [Route("/account/lockedOut/list", "POST,GET")]
    [Api(Description="Returns a list of locked out accounts.")]
    public partial class AccountLockedOutList
        : WebServiceRequest, IReturn<AccountLockedOutListResponse>
    {
    }

    public partial class AccountLockedOutListResponse
        : WebServiceResponse
    {
        public AccountLockedOutListResponse()
        {
            LockedOutList = new List<LockedOutRecord>{};
        }

        public virtual List<LockedOutRecord> LockedOutList { get; set; }
    }

    ///<summary>
    ///Locks a callsign account - preventing system access.
    ///</summary>
    [Route("/account/lockedOut/set", "POST,GET")]
    [Api(Description="Locks a callsign account - preventing system access.")]
    public partial class AccountLockedOutSet
        : WebServiceRequest, IReturn<AccountLockedOutSetResponse>
    {
        ///<summary>
        ///Account callsign
        ///</summary>
        [ApiMember(Description="Account callsign", IsRequired=true)]
        public virtual string Callsign { get; set; }

        ///<summary>
        ///Callsign of administrator performing this action
        ///</summary>
        [ApiMember(Description="Callsign of administrator performing this action", IsRequired=true)]
        public virtual string AdminCallsign { get; set; }

        ///<summary>
        ///Reason for lockout
        ///</summary>
        [ApiMember(Description="Reason for lockout", IsRequired=true)]
        public virtual string Reason { get; set; }
    }

    public partial class AccountLockedOutSetResponse
        : WebServiceResponse
    {
    }

    ///<summary>
    ///Gets the maximum message size for this callsign.
    ///</summary>
    [Route("/account/maxMessageSize/get", "POST,GET")]
    [Api(Description="Gets the maximum message size for this callsign.")]
    public partial class AccountMaxMessageSizeGet
        : WebServiceRequest, IReturn<AccountMaxMessageSizeGetResponse>
    {
        ///<summary>
        ///Account callsign
        ///</summary>
        [ApiMember(Description="Account callsign", IsRequired=true, Name="Callsign")]
        public virtual string Callsign { get; set; }
    }

    public partial class AccountMaxMessageSizeGetResponse
        : WebServiceResponse
    {
        public virtual int MaxMessageSize { get; set; }
    }

    ///<summary>
    ///Sets the maximum message size for this callsign.
    ///</summary>
    [Route("/account/maxMessageSize/set", "POST,GET")]
    [Api(Description="Sets the maximum message size for this callsign.")]
    public partial class AccountMaxMessageSizeSet
        : WebServiceRequest, IReturn<AccountMaxMessageSizeSetResponse>
    {
        ///<summary>
        ///Account callsign
        ///</summary>
        [ApiMember(Description="Account callsign", IsRequired=true, Name="Callsign")]
        public virtual string Callsign { get; set; }

        ///<summary>
        ///Maximum messages size (default: 120000)
        ///</summary>
        [ApiMember(Description="Maximum messages size (default: 120000)", Name="MaxMessageSize")]
        public virtual int MaxMessageSize { get; set; }
    }

    public partial class AccountMaxMessageSizeSetResponse
        : WebServiceResponse
    {
    }

    ///<summary>
    ///Gets the state of the no purge setting.
    ///</summary>
    [Route("/account/noPurge/get", "POST,GET")]
    [Api(Description="Gets the state of the no purge setting.")]
    public partial class AccountNoPurgeGet
        : WebServiceRequest, IReturn<AccountNoPurgeGetResponse>
    {
        ///<summary>
        ///Account callsign
        ///</summary>
        [ApiMember(Description="Account callsign", IsRequired=true, Name="Callsign")]
        public virtual string Callsign { get; set; }
    }

    public partial class AccountNoPurgeGetResponse
        : WebServiceResponse
    {
        public virtual bool NoPurge { get; set; }
    }

    ///<summary>
    ///Sets the state of the no purge setting.
    ///</summary>
    [Route("/account/noPurge/set", "POST,GET")]
    [Api(Description="Sets the state of the no purge setting.")]
    public partial class AccountNoPurgeSet
        : WebServiceRequest, IReturn<AccountNoPurgeSetResponse>
    {
        ///<summary>
        ///Account callsign
        ///</summary>
        [ApiMember(Description="Account callsign", IsRequired=true, Name="Callsign")]
        public virtual string Callsign { get; set; }

        ///<summary>
        ///No purge flag
        ///</summary>
        [ApiMember(Description="No purge flag", IsRequired=true, Name="NoPurge")]
        public virtual bool? NoPurge { get; set; }
    }

    public partial class AccountNoPurgeSetResponse
        : WebServiceResponse
    {
    }

    ///<summary>
    ///Changes the password for an existing callsign or tactical account. Password can be no less than 6 and no more than 12 characters long. Password can be blank for tactical accounts only. Triggers message to user informing then of password change.
    ///</summary>
    [Route("/account/password/change", "POST,GET")]
    [Api(Description="Changes the password for an existing callsign or tactical account. Password can be no less than 6 and no more than 12 characters long. Password can be blank for tactical accounts only. Triggers message to user informing then of password change.")]
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
    ///Gets the recovery email address.
    ///</summary>
    [Route("/account/password/recovery/email/get", "POST,GET")]
    [Api(Description="Gets the recovery email address.")]
    public partial class AccountPasswordRecoveryEmailGet
        : WebServiceRequest, IReturn<AccountPasswordRecoveryEmailGetResponse>
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

    public partial class AccountPasswordRecoveryEmailGetResponse
        : WebServiceResponse
    {
        public virtual string RecoveryEmail { get; set; }
    }

    ///<summary>
    ///Sets the recovery email address.
    ///</summary>
    [Route("/account/password/recovery/email/set", "POST,GET")]
    [Api(Description="Sets the recovery email address.")]
    public partial class AccountPasswordRecoveryEmailSet
        : WebServiceRequest, IReturn<AccountPasswordRecoveryEmailSetResponse>
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

        ///<summary>
        ///Email address to use for password recovery
        ///</summary>
        [ApiMember(Description="Email address to use for password recovery", IsRequired=true, Name="RecoveryEmail")]
        public virtual string RecoveryEmail { get; set; }
    }

    public partial class AccountPasswordRecoveryEmailSetResponse
        : WebServiceResponse
    {
    }

    ///<summary>
    ///Causes the password to be emailed to the recovery address. If no recovery address is found an error is returned.
    ///</summary>
    [Route("/account/password/send", "POST,GET")]
    [Api(Description="Causes the password to be emailed to the recovery address. If no recovery address is found an error is returned.")]
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
    ///Sets the password for Callsign. This API does not trigger a message to the user.
    ///</summary>
    [Route("/account/password/set", "POST,GET")]
    [Api(Description="Sets the password for Callsign. This API does not trigger a message to the user.")]
    public partial class AccountPasswordSet
        : WebServiceRequest, IReturn<AccountPasswordSetResponse>
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

    public partial class AccountPasswordSetResponse
        : WebServiceResponse
    {
    }

    ///<summary>
    ///Verifies Password is correct for the callsign or tactical account.
    ///</summary>
    [Route("/account/password/validate", "POST")]
    [Api(Description="Verifies Password is correct for the callsign or tactical account.")]
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
    ///Removes a callsign or tactical account and all references to it. If the tactical account has a password, it must be included.
    ///</summary>
    [Route("/account/remove", "POST,GET")]
    [Api(Description="Removes a callsign or tactical account and all references to it. If the tactical account has a password, it must be included.")]
    public partial class AccountRemove
        : WebServiceRequest, IReturn<AccountRemoveResponse>
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

    public partial class AccountRemoveResponse
        : WebServiceResponse
    {
    }

    ///<summary>
    ///Gets multiple properties for this callsign.
    ///</summary>
    [Route("/account/settings/get", "POST,GET")]
    [Api(Description="Gets multiple properties for this callsign.")]
    public partial class AccountSettingsGet
        : WebServiceRequest, IReturn<AccountSettingsGetResponse>
    {
        ///<summary>
        ///Account callsign
        ///</summary>
        [ApiMember(Description="Account callsign", IsRequired=true, Name="Callsign")]
        public virtual string Callsign { get; set; }
    }

    public partial class AccountSettingsGetResponse
        : WebServiceResponse
    {
        public virtual AccountSettingsRecord AccountSettings { get; set; }
        public virtual string Callsign { get; set; }
        public virtual DateTime LastAccess { get; set; }
        public virtual string Password { get; set; }
        public virtual string RecoveryEmail { get; set; }
        public virtual string CallsignPrefix { get; set; }
        public virtual string CallsignSuffix { get; set; }
        public virtual int MaxMessageSize { get; set; }
        public virtual bool NoPurge { get; set; }
        public virtual bool GatewayAccess { get; set; }
        public virtual bool LockedOut { get; set; }
        public virtual string LockOutReason { get; set; }
        public virtual string LockedOutBy { get; set; }
        public virtual string AlternateEmail { get; set; }
        public virtual bool Tactical { get; set; }
    }

    public partial class AccountSettingsRecord
    {
        public virtual string Callsign { get; set; }
        public virtual DateTime LastAccess { get; set; }
        public virtual string Password { get; set; }
        public virtual string RecoveryEmail { get; set; }
        public virtual string CallsignPrefix { get; set; }
        public virtual string CallsignSuffix { get; set; }
        public virtual int MaxMessageSize { get; set; }
        public virtual bool NoPurge { get; set; }
        public virtual bool GatewayAccess { get; set; }
        public virtual bool LockedOut { get; set; }
        public virtual string LockOutReason { get; set; }
        public virtual string LockedOutBy { get; set; }
        public virtual string AlternateEmail { get; set; }
        public virtual bool Tactical { get; set; }
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
    ///Removes an existing tactical account and all references to it. If a password was used it must be provided.
    ///</summary>
    [Route("/account/tactical/remove", "POST,GET")]
    [Api(Description="Removes an existing tactical account and all references to it. If a password was used it must be provided.")]
    public partial class AccountTacticalRemove
        : WebServiceRequest, IReturn<AccountTacticalRemoveResponse>
    {
        ///<summary>
        ///Tactical account name
        ///</summary>
        [ApiMember(Description="Tactical account name", IsRequired=true, Name="TacticalAccount")]
        public virtual string TacticalAccount { get; set; }

        ///<summary>
        ///Account password
        ///</summary>
        [ApiMember(Description="Account password", Name="Password")]
        public virtual string Password { get; set; }
    }

    public partial class AccountTacticalRemoveResponse
        : WebServiceResponse
    {
    }

    ///<summary>
    ///Returns a list of activity records for the specified callsign.
    ///</summary>
    [Route("/activity/get", "POST,GET")]
    [Api(Description="Returns a list of activity records for the specified callsign.")]
    public partial class ActivityGet
        : WebServiceRequest, IReturn<ActivityGetResponse>
    {
        ///<summary>
        ///Account callsign (no SSID)
        ///</summary>
        [ApiMember(Description="Account callsign (no SSID)", IsRequired=true)]
        public virtual string Callsign { get; set; }
    }

    public partial class ActivityGetResponse
        : WebServiceResponse
    {
        public ActivityGetResponse()
        {
            Activity = new List<ActivityRecord>{};
        }

        public virtual List<ActivityRecord> Activity { get; set; }
    }

    ///<summary>
    ///Returns a list of the latest activity for each callsign over the number of hours requested.
    ///</summary>
    [Route("/activity/latest", "POST,GET")]
    [Api(Description="Returns a list of the latest activity for each callsign over the number of hours requested.")]
    public partial class ActivityLatest
        : WebServiceRequest, IReturn<ActivityLatestResponse>
    {
        ///<summary>
        ///Number of hours of history to include
        ///</summary>
        [ApiMember(Description="Number of hours of history to include")]
        public virtual int HistoryHours { get; set; }
    }

    public partial class ActivityLatestResponse
        : WebServiceResponse
    {
        public ActivityLatestResponse()
        {
            Activity = new List<LatestActivity>{};
        }

        public virtual List<LatestActivity> Activity { get; set; }
    }

    [DataContract]
    public partial class ActivityRecord
    {
        [DataMember]
        public virtual DateTime Timestamp { get; set; }

        [DataMember]
        public virtual string Callsign { get; set; }

        [DataMember]
        public virtual string Source { get; set; }

        [DataMember]
        public virtual string Channel { get; set; }

        [DataMember]
        public virtual int ClientType { get; set; }

        [DataMember]
        public virtual int LinkType { get; set; }

        [DataMember]
        public virtual int Protocol { get; set; }

        [DataMember]
        public virtual int MessagesInbound { get; set; }

        [DataMember]
        public virtual int MessagesOutbound { get; set; }

        [DataMember]
        public virtual int BytesInbound { get; set; }

        [DataMember]
        public virtual int BytesOutbound { get; set; }

        [DataMember]
        public virtual int ConnectTime { get; set; }
    }

    ///<summary>
    ///Returns one of several activity reports for the specified period and callsign.
    ///</summary>
    [Route("/activity/report", "POST,GET")]
    [Api(Description="Returns one of several activity reports for the specified period and callsign.")]
    public partial class ActivityReport
        : WebServiceRequest, IReturn<ActivityReportResponse>
    {
        ///<summary>
        ///Report Type:  SystemSummary - requires HistoryDays > 0 and no more than 365.  GatewaySummary - requires Callsign, HistoryDays > 0 and no more than 365.  SystemActivity - requires HistoryDays > 0 and no more than 21.  GatewayActivity - requires Callsign, HistoryDays > 0 and no more than 21.  GatewayFrequency - requires ServiceCodes.  UserActivity - requires Callsign, HistoryDays > 0 and no more than 21.
        ///</summary>
        [ApiMember(Description="Report Type:\r\n  SystemSummary - requires HistoryDays > 0 and no more than 365.\r\n  GatewaySummary - requires Callsign, HistoryDays > 0 and no more than 365.\r\n  SystemActivity - requires HistoryDays > 0 and no more than 21.\r\n  GatewayActivity - requires Callsign, HistoryDays > 0 and no more than 21.\r\n  GatewayFrequency - requires ServiceCodes.\r\n  UserActivity - requires Callsign, HistoryDays > 0 and no more than 21.", IsRequired=true, Name="ReportType")]
        public virtual ActivityReportType ReportType { get; set; }

        ///<summary>
        ///Number of days of history to include (default: 1)
        ///</summary>
        [ApiMember(Description="Number of days of history to include (default: 1)", Name="HistoryDays")]
        public virtual int HistoryDays { get; set; }

        ///<summary>
        ///Number of hours of history to include (default: 0)
        ///</summary>
        [ApiMember(Description="Number of hours of history to include (default: 0)", Name="HistoryHours")]
        public virtual int HistoryHours { get; set; }

        ///<summary>
        ///Station Callsign (required sometimes)
        ///</summary>
        [ApiMember(Description="Station Callsign (required sometimes)", IsRequired=true, Name="Callsign")]
        public virtual string Callsign { get; set; }

        ///<summary>
        ///One or more service codes (default: PUBLIC)
        ///</summary>
        [ApiMember(Description="One or more service codes (default: PUBLIC)", Name="ServiceCodes")]
        public virtual string ServiceCodes { get; set; }
    }

    public partial class ActivityReportResponse
        : WebServiceResponse
    {
        public virtual string Report { get; set; }
    }

    [DataContract]
    public enum ActivityReportType
    {
        SystemSummary,
        GatewaySummary,
        SystemActivity,
        GatewayActivity,
        GatewayFrequency,
        UserActivity,
    }

    ///<summary>
    ///Returns the system activity summary for the specified period.
    ///</summary>
    [Route("/activitySummary/get", "POST,GET")]
    [Route("/activity/summary", "POST,GET")]
    [Api(Description="Returns the system activity summary for the specified period.")]
    public partial class ActivitySummaryGet
        : WebServiceRequest, IReturn<ActivitySummaryGetResponse>
    {
        ///<summary>
        ///Specific period (YYYYMM)  default: Current year/month
        ///</summary>
        [ApiMember(Description="Specific period (YYYYMM)  default: Current year/month", Name="Period")]
        public virtual string Period { get; set; }
    }

    public partial class ActivitySummaryGetResponse
        : WebServiceResponse
    {
        public virtual string Period { get; set; }
        public virtual int TotalReceivedPacket { get; set; }
        public virtual int TotalSentPacket { get; set; }
        public virtual int TotalReceivedAprs { get; set; }
        public virtual int TotalSentAprs { get; set; }
        public virtual int TotalReceivedWeb { get; set; }
        public virtual int TotalSentWeb { get; set; }
        public virtual int P1Connections { get; set; }
        public virtual int P2Connections { get; set; }
        public virtual int P3Connections { get; set; }
        public virtual int P4Connections { get; set; }
        public virtual int Winmor500Connections { get; set; }
        public virtual int Winmor1600Connections { get; set; }
        public virtual int RobustPacketConnections { get; set; }
        public virtual int Ardop200Connections { get; set; }
        public virtual int Ardop500Connections { get; set; }
        public virtual int Ardop1000Connections { get; set; }
        public virtual int Ardop2000Connections { get; set; }
        public virtual int Ardop2000FMConnections { get; set; }
        public virtual int VaraConnections { get; set; }
        public virtual int Vara500Connections { get; set; }
        public virtual int Vara2750Connections { get; set; }
        public virtual int Vara1200FmConnections { get; set; }
        public virtual int Vara9600FmConnections { get; set; }
        public virtual int HfMessagesReceived { get; set; }
        public virtual int HfMessagesSent { get; set; }
        public virtual int HfBytesReceived { get; set; }
        public virtual int HfBytesSent { get; set; }
    }

    ///<summary>
    ///Adds an ARSFi donation record.
    ///</summary>
    [Route("/arsfi/registration/add", "POST")]
    [Route("/arsfi/donation/add", "POST")]
    [Api(Description="Adds an ARSFi donation record.")]
    public partial class ArsfiDonationAdd
        : WebServiceRequest, IReturn<ArsfiDonationAddResponse>
    {
        ///<summary>
        ///Callsign of person
        ///</summary>
        [ApiMember(Description="Callsign of person", Name="Callsign")]
        public virtual string Callsign { get; set; }

        ///<summary>
        ///Name of person
        ///</summary>
        [ApiMember(Description="Name of person", IsRequired=true, Name="Name")]
        public virtual string Name { get; set; }

        ///<summary>
        ///Email address
        ///</summary>
        [ApiMember(Description="Email address", IsRequired=true, Name="EmailAddress")]
        public virtual string EmailAddress { get; set; }

        ///<summary>
        ///Dollar amount
        ///</summary>
        [ApiMember(Description="Dollar amount", IsRequired=true, Name="Amount")]
        public virtual double Amount { get; set; }

        ///<summary>
        ///Type of transaction (Winmor, V4, Donation, etc.)
        ///</summary>
        [ApiMember(Description="Type of transaction (Winmor, V4, Donation, etc.)", IsRequired=true, Name="TransactionType")]
        public virtual string TransactionType { get; set; }

        ///<summary>
        ///Registration key
        ///</summary>
        [ApiMember(Description="Registration key", Name="RegistrationKey")]
        public virtual string RegistrationKey { get; set; }

        ///<summary>
        ///True if record has been voided
        ///</summary>
        [ApiMember(Description="True if record has been voided", Name="Voided")]
        public virtual bool Voided { get; set; }

        ///<summary>
        ///Notes
        ///</summary>
        [ApiMember(Description="Notes", Name="Notes")]
        public virtual string Notes { get; set; }
    }

    public partial class ArsfiDonationAddResponse
        : WebServiceResponse
    {
    }

    ///<summary>
    ///Deletes a specific ARSFi donation record.
    ///</summary>
    [Route("/arsfi/donation/delete", "POST,GET")]
    [Api(Description="Deletes a specific ARSFi donation record.")]
    public partial class ArsfiDonationDelete
        : WebServiceRequest, IReturn<ArsfiDonationDeleteResponse>
    {
        ///<summary>
        ///The unique transaction ID
        ///</summary>
        [ApiMember(Description="The unique transaction ID", IsRequired=true, Name="TransactionId")]
        public virtual string TransactionId { get; set; }
    }

    public partial class ArsfiDonationDeleteResponse
        : WebServiceResponse
    {
    }

    ///<summary>
    ///Returns zero or more records that partially match the specified filter.
    ///</summary>
    [Route("/arsfi/donation/filter", "POST,GET")]
    [Api(Description="Returns zero or more records that partially match the specified filter.")]
    public partial class ArsfiDonationFilter
        : WebServiceRequest, IReturn<ArsfiDonationFilterResponse>
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

    public partial class ArsfiDonationFilterResponse
        : WebServiceResponse
    {
        public ArsfiDonationFilterResponse()
        {
            Donations = new List<DonationRecord>{};
        }

        public virtual List<DonationRecord> Donations { get; set; }
    }

    ///<summary>
    ///Returns a specific ARSFi donation record.
    ///</summary>
    [Route("/arsfi/donation/get", "POST,GET")]
    [Api(Description="Returns a specific ARSFi donation record.")]
    public partial class ArsfiDonationGet
        : WebServiceRequest, IReturn<ArsfiDonationGetResponse>
    {
        ///<summary>
        ///The unique transaction ID
        ///</summary>
        [ApiMember(Description="The unique transaction ID", IsRequired=true, Name="TransactionId")]
        public virtual string TransactionId { get; set; }
    }

    public partial class ArsfiDonationGetResponse
        : WebServiceResponse
    {
        public virtual DonationRecord Donation { get; set; }
    }

    ///<summary>
    ///Returns a list of ARSFi donation records (optionally, based on filter settings).
    ///</summary>
    [Route("/arsfi/donation/list", "POST,GET")]
    [Api(Description="Returns a list of ARSFi donation records (optionally, based on filter settings).")]
    public partial class ArsfiDonationList
        : WebServiceRequest, IReturn<ArsfiDonationListResponse>
    {
        ///<summary>
        ///Full or partial callsign
        ///</summary>
        [ApiMember(Description="Full or partial callsign", Name="CallsignFilter")]
        public virtual string CallsignFilter { get; set; }

        ///<summary>
        ///Full or partial name
        ///</summary>
        [ApiMember(Description="Full or partial name", Name="NameFilter")]
        public virtual string NameFilter { get; set; }

        ///<summary>
        ///Number of days to look back
        ///</summary>
        [ApiMember(Description="Number of days to look back", Name="AgeFilter")]
        public virtual string AgeFilter { get; set; }

        ///<summary>
        ///Limit number of records returned (default: 100)
        ///</summary>
        [ApiMember(Description="Limit number of records returned (default: 100)")]
        public virtual int RecordLimit { get; set; }
    }

    public partial class ArsfiDonationListResponse
        : WebServiceResponse
    {
        public ArsfiDonationListResponse()
        {
            Donations = new List<DonationRecord>{};
        }

        public virtual List<DonationRecord> Donations { get; set; }
    }

    ///<summary>
    ///Returns zero or more ARSFi donation records.
    ///</summary>
    [Route("/arsfi/donation/search", "POST,GET")]
    [Api(Description="Returns zero or more ARSFi donation records.")]
    public partial class ArsfiDonationSearch
        : WebServiceRequest, IReturn<ArsfiDonationSearchResponse>
    {
        ///<summary>
        ///Callsign of person making donation
        ///</summary>
        [ApiMember(Description="Callsign of person making donation", Name="Callsign")]
        public virtual string Callsign { get; set; }

        ///<summary>
        ///Name of person making donation
        ///</summary>
        [ApiMember(Description="Name of person making donation", Name="Name")]
        public virtual string Name { get; set; }

        ///<summary>
        ///Email address
        ///</summary>
        [ApiMember(Description="Email address", Name="EmailAddress")]
        public virtual string EmailAddress { get; set; }

        ///<summary>
        ///Type of transaction (Winmor, V4, Donation, etc.)
        ///</summary>
        [ApiMember(Description="Type of transaction (Winmor, V4, Donation, etc.)", Name="TransactionType")]
        public virtual string TransactionType { get; set; }

        ///<summary>
        ///Registration key
        ///</summary>
        [ApiMember(Description="Registration key", Name="RegistrationKey")]
        public virtual string RegistrationKey { get; set; }

        ///<summary>
        ///True to search for voided records (default: false)
        ///</summary>
        [ApiMember(Description="True to search for voided records (default: false)", Name="Voided")]
        public virtual bool Voided { get; set; }

        ///<summary>
        ///Limit number of records returned (default: 100)
        ///</summary>
        [ApiMember(Description="Limit number of records returned (default: 100)")]
        public virtual int RecordLimit { get; set; }
    }

    public partial class ArsfiDonationSearchResponse
        : WebServiceResponse
    {
        public ArsfiDonationSearchResponse()
        {
            Donations = new List<DonationRecord>{};
        }

        public virtual List<DonationRecord> Donations { get; set; }
    }

    ///<summary>
    ///Updates a ARSFi donation record. Omitted parameters are left unchanged.
    ///</summary>
    [Route("/arsfi/donation/update", "POST,GET")]
    [Api(Description="Updates a ARSFi donation record. Omitted parameters are left unchanged.")]
    public partial class ArsfiDonationUpdate
        : WebServiceRequest, IReturn<ArsfiDonationUpdateResponse>
    {
        ///<summary>
        ///The unique transaction ID
        ///</summary>
        [ApiMember(Description="The unique transaction ID", IsRequired=true, Name="TransactionId")]
        public virtual string TransactionId { get; set; }

        ///<summary>
        ///Callsign of person making donation
        ///</summary>
        [ApiMember(Description="Callsign of person making donation", Name="Callsign")]
        public virtual string Callsign { get; set; }

        ///<summary>
        ///Name of person making donation
        ///</summary>
        [ApiMember(Description="Name of person making donation", Name="Name")]
        public virtual string Name { get; set; }

        ///<summary>
        ///Email address
        ///</summary>
        [ApiMember(Description="Email address", Name="EmailAddress")]
        public virtual string EmailAddress { get; set; }

        ///<summary>
        ///Dollar amount of donation
        ///</summary>
        [ApiMember(Description="Dollar amount of donation", Name="Amount")]
        public virtual double Amount { get; set; }

        ///<summary>
        ///Type of transaction (Winmor, V4, Donation, etc.)
        ///</summary>
        [ApiMember(Description="Type of transaction (Winmor, V4, Donation, etc.)", Name="TransactionType")]
        public virtual string TransactionType { get; set; }

        ///<summary>
        ///Registration key
        ///</summary>
        [ApiMember(Description="Registration key", Name="RegistrationKey")]
        public virtual string RegistrationKey { get; set; }

        ///<summary>
        ///Notes
        ///</summary>
        [ApiMember(Description="Notes", Name="Notes")]
        public virtual string Notes { get; set; }

        ///<summary>
        ///True to void the registration record
        ///</summary>
        [ApiMember(Description="True to void the registration record", Name="Void")]
        public virtual bool Void { get; set; }
    }

    public partial class ArsfiDonationUpdateResponse
        : WebServiceResponse
    {
    }

    ///<summary>
    ///Returns a registration key for the specified callsign.
    ///</summary>
    [Route("/arsfi/registration/key", "POST,GET")]
    [Api(Description="Returns a registration key for the specified callsign.")]
    public partial class ArsfiRegistrationKey
        : WebServiceRequest, IReturn<ArsfiRegistrationKeyResponse>
    {
        ///<summary>
        ///Account callsign (no SSID)
        ///</summary>
        [ApiMember(Description="Account callsign (no SSID)", IsRequired=true)]
        public virtual string Callsign { get; set; }

        ///<summary>
        ///Type of registration key to create (Winmor, V4, Express, etc.)
        ///</summary>
        [ApiMember(Description="Type of registration key to create (Winmor, V4, Express, etc.)", IsRequired=true)]
        public virtual string KeyType { get; set; }
    }

    public partial class ArsfiRegistrationKeyResponse
        : WebServiceResponse
    {
        public virtual string Callsign { get; set; }
        public virtual string RegistrationKey { get; set; }
        public virtual string KeyType { get; set; }
    }

    ///<summary>
    ///Returns a list of valid registration records for the specified callsign.
    ///</summary>
    [Route("/arsfi/registration/list", "POST,GET")]
    [Api(Description="Returns a list of valid registration records for the specified callsign.")]
    public partial class ArsfiRegistrationList
        : WebServiceRequest, IReturn<ArsfiRegistrationListResponse>
    {
        ///<summary>
        ///Callsign  of person (no SID)
        ///</summary>
        [ApiMember(Description="Callsign  of person (no SID)", IsRequired=true, Name="Callsign")]
        public virtual string Callsign { get; set; }
    }

    public partial class ArsfiRegistrationListResponse
        : WebServiceResponse
    {
        public ArsfiRegistrationListResponse()
        {
            Registrations = new List<RegistrationRecord>{};
        }

        public virtual List<RegistrationRecord> Registrations { get; set; }
    }

    ///<summary>
    ///Returns the registration key for the specified callsign and registration type if it exists and has not been voided.
    ///</summary>
    [Route("/arsfi/registration/lookup", "POST,GET")]
    [Api(Description="Returns the registration key for the specified callsign and registration type if it exists and has not been voided.")]
    public partial class ArsfiRegistrationLookup
        : WebServiceRequest, IReturn<ArsfiRegistrationLookupResponse>
    {
        ///<summary>
        ///Callsign of person
        ///</summary>
        [ApiMember(Description="Callsign of person", IsRequired=true, Name="Callsign")]
        public virtual string Callsign { get; set; }

        ///<summary>
        ///Type of registration (Winmor, V4, etc.)
        ///</summary>
        [ApiMember(Description="Type of registration (Winmor, V4, etc.)", IsRequired=true, Name="RegistrationType")]
        public virtual string RegistrationType { get; set; }
    }

    public partial class ArsfiRegistrationLookupResponse
        : WebServiceResponse
    {
        public virtual string RegistrationKey { get; set; }
    }

    ///<summary>
    ///Returns true if the specified registration exists and has not been voided.
    ///</summary>
    [Route("/arsfi/registration/valid", "POST,GET")]
    [Api(Description="Returns true if the specified registration exists and has not been voided.")]
    public partial class ArsfiRegistrationValid
        : WebServiceRequest, IReturn<ArsfiRegistrationValidResponse>
    {
        ///<summary>
        ///Callsign of person (no SID)
        ///</summary>
        [ApiMember(Description="Callsign of person (no SID)", IsRequired=true, Name="Callsign")]
        public virtual string Callsign { get; set; }

        ///<summary>
        ///Registration key
        ///</summary>
        [ApiMember(Description="Registration key", IsRequired=true, Name="RegistrationKey")]
        public virtual string RegistrationKey { get; set; }
    }

    public partial class ArsfiRegistrationValidResponse
        : WebServiceResponse
    {
        public virtual bool Valid { get; set; }
    }

    ///<summary>
    ///Voids or un-voids the specified registration record.
    ///</summary>
    [Route("/arsfi/registration/void", "POST,GET")]
    [Api(Description="Voids or un-voids the specified registration record.")]
    public partial class ArsfiRegistrationVoid
        : WebServiceRequest, IReturn<ArsfiRegistrationVoidResponse>
    {
        ///<summary>
        ///Callsign  of person (no SID)
        ///</summary>
        [ApiMember(Description="Callsign  of person (no SID)", IsRequired=true, Name="Callsign")]
        public virtual string Callsign { get; set; }

        ///<summary>
        ///Registration key
        ///</summary>
        [ApiMember(Description="Registration key", IsRequired=true, Name="RegistrationKey")]
        public virtual string RegistrationKey { get; set; }

        ///<summary>
        ///True to void the registration record
        ///</summary>
        [ApiMember(Description="True to void the registration record", Name="Void")]
        public virtual bool Void { get; set; }
    }

    public partial class ArsfiRegistrationVoidResponse
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
    ///Returns a number 0-x indicating if the submitted IP address (v4 only) is blacklisted by zero, one or more DNSBL services. Also returned are the names of the DNSBL services returning a positive result (if any). This service uses a number of popular DNS spam blacklist'ing services (currently: Barracuda, Spamcop, and Spamhaus).
    ///</summary>
    [Route("/blacklist/query", "POST,GET")]
    [Api(Description="Returns a number 0-x indicating if the submitted IP address (v4 only) is blacklisted by zero, one or more DNSBL services. Also returned are the names of the DNSBL services returning a positive result (if any). This service uses a number of popular DNS spam blacklist'ing services (currently: Barracuda, Spamcop, and Spamhaus).")]
    public partial class Blacklist
        : WebServiceRequest, IReturn<BlacklistResponse>
    {
        ///<summary>
        ///A single version 4 IP address (dotted notation in string format)
        ///</summary>
        [ApiMember(Description="A single version 4 IP address (dotted notation in string format)", IsRequired=true, Name="IP")]
        public virtual string IP { get; set; }
    }

    public partial class BlacklistResponse
        : WebServiceResponse
    {
        public virtual int BlacklistCount { get; set; }
        public virtual string BlacklistSources { get; set; }
    }

    ///<summary>
    ///Sets multiple properties for this callsign.
    ///</summary>
    [Route("/callsign/properties/set", "POST,GET")]
    [Api(Description="Sets multiple properties for this callsign.")]
    public partial class CallsignPropertiesSet
        : WebServiceRequest, IReturn<CallsignPropertiesSetResponse>
    {
        ///<summary>
        ///Account callsign
        ///</summary>
        [ApiMember(Description="Account callsign", IsRequired=true, Name="Callsign")]
        public virtual string Callsign { get; set; }

        ///<summary>
        ///Callsign prefix (default: blank)
        ///</summary>
        [ApiMember(Description="Callsign prefix (default: blank)", Name="CallsignPrefix")]
        public virtual string CallsignPrefix { get; set; }

        ///<summary>
        ///Callsign suffix (default: blank)
        ///</summary>
        [ApiMember(Description="Callsign suffix (default: blank)", Name="CallsignSuffix")]
        public virtual string CallsignSuffix { get; set; }

        ///<summary>
        ///Maximum messages size (default: 120000)
        ///</summary>
        [ApiMember(Description="Maximum messages size (default: 120000)", Name="MaxMessageSize")]
        public virtual int MaxMessageSize { get; set; }

        ///<summary>
        ///Controls who can act as a Winlink gateway (default: false)
        ///</summary>
        [ApiMember(Description="Controls who can act as a Winlink gateway (default: false)", Name="GatewayAccess")]
        public virtual bool GatewayAccess { get; set; }

        ///<summary>
        ///No purge flag (default: false)
        ///</summary>
        [ApiMember(Description="No purge flag (default: false)", Name="NoPurge")]
        public virtual bool NoPurge { get; set; }
    }

    public partial class CallsignPropertiesSetResponse
        : WebServiceResponse
    {
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
    ///Adds multiple channel records replacing any previously defined.
    ///</summary>
    [Route("/channel/add/multiple", "POST")]
    [Api(Description="Adds multiple channel records replacing any previously defined.")]
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

    [DataContract]
    public partial class CmsApplication
    {
        [DataMember]
        public virtual DateTime Timestamp { get; set; }

        [DataMember]
        public virtual string Name { get; set; }

        [DataMember]
        public virtual string Version { get; set; }
    }

    ///<summary>
    ///Adds an application status record to the cmsstatus table.
    ///</summary>
    [Route("/cms/applicationStatus/add", "POST,GET")]
    [Api(Description="Adds an application status record to the cmsstatus table.")]
    public partial class CmsApplicationStatusAdd
        : WebServiceRequest, IReturn<CmsApplicationStatusAddResponse>
    {
        ///<summary>
        ///The datetime value to be recorded with this application status
        ///</summary>
        [ApiMember(Description="The datetime value to be recorded with this application status", Name="Timestamp")]
        public virtual DateTime Timestamp { get; set; }

        ///<summary>
        ///The CMS name (e.g., 'Perth')
        ///</summary>
        [ApiMember(Description="The CMS name (e.g., 'Perth')", IsRequired=true, Name="CmsName")]
        public virtual string CmsName { get; set; }

        ///<summary>
        ///The name of the applicaiton (e.g., 'CMS Telnet Server')
        ///</summary>
        [ApiMember(Description="The name of the applicaiton (e.g., 'CMS Telnet Server')", IsRequired=true, Name="Application")]
        public virtual string Application { get; set; }

        ///<summary>
        ///The name of the property (e.g., 'Running')
        ///</summary>
        [ApiMember(Description="The name of the property (e.g., 'Running')", IsRequired=true, Name="Property")]
        public virtual string Property { get; set; }

        ///<summary>
        ///The value for this property (e.g., 'True')
        ///</summary>
        [ApiMember(Description="The value for this property (e.g., 'True')", Name="Value")]
        public virtual string Value { get; set; }
    }

    public partial class CmsApplicationStatusAddResponse
        : WebServiceResponse
    {
    }

    ///<summary>
    ///Deletes an application status record from the cmsstatus table.
    ///</summary>
    [Route("/cms/applicationStatus/delete", "POST,GET")]
    [Api(Description="Deletes an application status record from the cmsstatus table.")]
    public partial class CmsApplicationStatusDelete
        : WebServiceRequest, IReturn<CmsApplicationStatusDeleteResponse>
    {
        ///<summary>
        ///The CMS name (e.g., 'Perth')
        ///</summary>
        [ApiMember(Description="The CMS name (e.g., 'Perth')", IsRequired=true, Name="CmsName")]
        public virtual string CmsName { get; set; }

        ///<summary>
        ///The name of the application (e.g., 'CMS Telnet Server')
        ///</summary>
        [ApiMember(Description="The name of the application (e.g., 'CMS Telnet Server')", IsRequired=true, Name="Application")]
        public virtual string Application { get; set; }

        ///<summary>
        ///The name of the property (e.g., 'Running')
        ///</summary>
        [ApiMember(Description="The name of the property (e.g., 'Running')", IsRequired=true, Name="Property")]
        public virtual string Property { get; set; }
    }

    public partial class CmsApplicationStatusDeleteResponse
        : WebServiceResponse
    {
    }

    ///<summary>
    ///Returns a list showing the status of all applications running on the specified server.
    ///</summary>
    [Route("/cms/applicationStatus", "POST,GET")]
    [Route("/cms/applicationStatus/get", "POST,GET")]
    [Api(Description="Returns a list showing the status of all applications running on the specified server.")]
    public partial class CmsApplicationStatusGet
        : WebServiceRequest, IReturn<CmsApplicationStatusGetResponse>
    {
        ///<summary>
        ///The CMS name (e.g., 'Perth')
        ///</summary>
        [ApiMember(Description="The CMS name (e.g., 'Perth')", IsRequired=true, Name="CmsName")]
        public virtual string CmsName { get; set; }
    }

    public partial class CmsApplicationStatusGetResponse
        : WebServiceResponse
    {
        public CmsApplicationStatusGetResponse()
        {
            Applications = new List<CmsApplication>{};
        }

        public virtual DateTime Timestamp { get; set; }
        public virtual string CmsName { get; set; }
        public virtual bool Online { get; set; }
        public virtual List<CmsApplication> Applications { get; set; }
    }

    [DataContract]
    public partial class DeliveryListRecord
    {
        [DataMember]
        public virtual string Address { get; set; }

        [DataMember]
        public virtual bool Forwarded { get; set; }
    }

    [DataContract]
    public partial class DonationRecord
    {
        [DataMember]
        public virtual string TransactionId { get; set; }

        [DataMember]
        public virtual DateTime Timestamp { get; set; }

        [DataMember]
        public virtual string Callsign { get; set; }

        [DataMember]
        public virtual string Name { get; set; }

        [DataMember]
        public virtual string EmailAddress { get; set; }

        [DataMember]
        public virtual double Amount { get; set; }

        [DataMember]
        public virtual string TransactionType { get; set; }

        [DataMember]
        public virtual string RegistrationKey { get; set; }

        [DataMember]
        public virtual bool Void { get; set; }

        [DataMember]
        public virtual string Notes { get; set; }
    }

    ///<summary>
    ///Echos the sent data back to the requestor.
    ///</summary>
    [Route("/echo", "POST,GET")]
    [Api(Description="Echos the sent data back to the requestor.")]
    public partial class Echo
        : WebServiceRequest, IReturn<EchoResponse>
    {
        public virtual string Data { get; set; }
    }

    public partial class EchoResponse
        : WebServiceResponse
    {
        public virtual string Data { get; set; }
    }

    ///<summary>
    ///Adds an email alias record.
    ///</summary>
    [Route("/emailAlias/add", "POST,GET")]
    [Api(Description="Adds an email alias record.")]
    public partial class EmailAliasAdd
        : WebServiceRequest, IReturn<EmailAliasAddResponse>
    {
        ///<summary>
        ///Account callsign
        ///</summary>
        [ApiMember(Description="Account callsign", IsRequired=true, Name="Callsign")]
        public virtual string Callsign { get; set; }

        ///<summary>
        ///Alias name
        ///</summary>
        [ApiMember(Description="Alias name", IsRequired=true, Name="Alias")]
        public virtual string Alias { get; set; }

        ///<summary>
        ///Email address for alias
        ///</summary>
        [ApiMember(Description="Email address for alias", IsRequired=true, Name="Address")]
        public virtual string Address { get; set; }
    }

    public partial class EmailAliasAddResponse
        : WebServiceResponse
    {
    }

    ///<summary>
    ///Deletes the specified email alias record.
    ///</summary>
    [Route("/emailAlias/delete", "POST,GET")]
    [Api(Description="Deletes the specified email alias record.")]
    public partial class EmailAliasDelete
        : WebServiceRequest, IReturn<EmailAliasDeleteResponse>
    {
        ///<summary>
        ///Account callsign
        ///</summary>
        [ApiMember(Description="Account callsign", IsRequired=true, Name="Callsign")]
        public virtual string Callsign { get; set; }

        ///<summary>
        ///Alias name
        ///</summary>
        [ApiMember(Description="Alias name", IsRequired=true, Name="Alias")]
        public virtual string Alias { get; set; }
    }

    public partial class EmailAliasDeleteResponse
        : WebServiceResponse
    {
    }

    ///<summary>
    ///Returns the email address for the specified alias.
    ///</summary>
    [Route("/emailAlias/get", "POST,GET")]
    [Api(Description="Returns the email address for the specified alias.")]
    public partial class EmailAliasGet
        : WebServiceRequest, IReturn<EmailAliasGetResponse>
    {
        ///<summary>
        ///Account callsign
        ///</summary>
        [ApiMember(Description="Account callsign", IsRequired=true, Name="Callsign")]
        public virtual string Callsign { get; set; }

        ///<summary>
        ///Alias name
        ///</summary>
        [ApiMember(Description="Alias name", IsRequired=true, Name="Alias")]
        public virtual string Alias { get; set; }
    }

    public partial class EmailAliasGetResponse
        : WebServiceResponse
    {
        public virtual string Address { get; set; }
    }

    ///<summary>
    ///Returns a list of all email aliases.
    ///</summary>
    [Route("/emailAlias/list", "POST,GET")]
    [Api(Description="Returns a list of all email aliases.")]
    public partial class EmailAliasList
        : WebServiceRequest, IReturn<EmailAliasListResponse>
    {
    }

    public partial class EmailAliasListResponse
        : WebServiceResponse
    {
        public EmailAliasListResponse()
        {
            AliasList = new List<EmailAliasRecord>{};
        }

        public virtual List<EmailAliasRecord> AliasList { get; set; }
    }

    [DataContract]
    public partial class EmailAliasRecord
    {
        [DataMember]
        public virtual string Callsign { get; set; }

        [DataMember]
        public virtual string Alias { get; set; }

        [DataMember]
        public virtual string Address { get; set; }
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
    ///Returns an array of data structures showing connection statistics of the gateway.
    ///</summary>
    [Route("/gatewayStats", "POST,GET")]
    [Route("/gateway/stats", "POST,GET")]
    [Api(Description="Returns an array of data structures showing connection statistics of the gateway.")]
    public partial class GatewayStats
        : WebServiceRequest, IReturn<GatewayStatsResponse>
    {
        ///<summary>
        ///Gateway callsign (may include SSID)
        ///</summary>
        [ApiMember(Description="Gateway callsign (may include SSID)", IsRequired=true, Name="Callsign")]
        public virtual string Callsign { get; set; }

        ///<summary>
        ///One or more service codes (default: PUBLIC)
        ///</summary>
        [ApiMember(Description="One or more service codes (default: PUBLIC)", Name="ServiceCodes")]
        public virtual string ServiceCodes { get; set; }

        ///<summary>
        ///Year and month - YYYYMM (default: current year and month)
        ///</summary>
        [ApiMember(Description="Year and month - YYYYMM (default: current year and month)", Name="Period")]
        public virtual string Period { get; set; }
    }

    [DataContract]
    public partial class GatewayStatsRecord
    {
        [DataMember]
        public virtual DateTime Timestamp { get; set; }

        [DataMember]
        public virtual string Callsign { get; set; }

        [DataMember]
        public virtual string Period { get; set; }

        [DataMember]
        public virtual string Channel { get; set; }

        [DataMember]
        public virtual int TcpIp { get; set; }

        [DataMember]
        public virtual int Packet { get; set; }

        [DataMember]
        public virtual int Pactor1 { get; set; }

        [DataMember]
        public virtual int Pactor2 { get; set; }

        [DataMember]
        public virtual int Pactor3 { get; set; }

        [DataMember]
        public virtual int Pactor4 { get; set; }

        [DataMember]
        public virtual int Winmor500 { get; set; }

        [DataMember]
        public virtual int Winmor1600 { get; set; }

        [DataMember]
        public virtual int RobustPacket { get; set; }

        [DataMember]
        public virtual int Ardop200 { get; set; }

        [DataMember]
        public virtual int Ardop500 { get; set; }

        [DataMember]
        public virtual int Ardop1000 { get; set; }

        [DataMember]
        public virtual int Ardop2000 { get; set; }

        [DataMember]
        public virtual int Ardop2000Fm { get; set; }

        [DataMember]
        public virtual int Vara { get; set; }

        [DataMember]
        public virtual int Vara1200Fm { get; set; }

        [DataMember]
        public virtual int Vara9600Fm { get; set; }

        [DataMember]
        public virtual int Vara500 { get; set; }

        [DataMember]
        public virtual int Vara2750 { get; set; }

        [DataMember]
        public virtual int MessagesIn { get; set; }

        [DataMember]
        public virtual int MessagesOut { get; set; }

        [DataMember]
        public virtual string ServiceCode { get; set; }
    }

    public partial class GatewayStatsResponse
        : WebServiceResponse
    {
        public GatewayStatsResponse()
        {
            GatewayStats = new List<GatewayStatsRecord>{};
        }

        public virtual List<GatewayStatsRecord> GatewayStats { get; set; }
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
    ///Adds a new group. A group name is used to send mail to all members of the group
    ///</summary>
    [Route("/group/add", "POST,GET")]
    [Api(Description="Adds a new group. A group name is used to send mail to all members of the group")]
    public partial class GroupAdd
        : WebServiceRequest, IReturn<GroupAddResponse>
    {
        ///<summary>
        ///Name of the group
        ///</summary>
        [ApiMember(Description="Name of the group", IsRequired=true)]
        public virtual string GroupName { get; set; }

        ///<summary>
        ///Description of the group
        ///</summary>
        [ApiMember(Description="Description of the group")]
        public virtual string Description { get; set; }

        ///<summary>
        ///SQL query or name and parameters for pre-defined query
        ///</summary>
        [ApiMember(Description="SQL query or name and parameters for pre-defined query")]
        public virtual string Query { get; set; }

        ///<summary>
        ///True to send messages to the email address associated with each callsign
        ///</summary>
        [ApiMember(Description="True to send messages to the email address associated with each callsign")]
        public virtual bool CcEmailAddress { get; set; }

        ///<summary>
        ///True to send messages to internet email address associated with each callsign ONLY
        ///</summary>
        [ApiMember(Description="True to send messages to internet email address associated with each callsign ONLY")]
        public virtual bool InternetAddressesOnly { get; set; }
    }

    public partial class GroupAddResponse
        : WebServiceResponse
    {
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

    ///<summary>
    ///Deletes an existing group.
    ///</summary>
    [Route("/group/delete", "POST,GET")]
    [Api(Description="Deletes an existing group.")]
    public partial class GroupDelete
        : WebServiceRequest, IReturn<GroupDeleteResponse>
    {
        ///<summary>
        ///Name of the group
        ///</summary>
        [ApiMember(Description="Name of the group", IsRequired=true)]
        public virtual string GroupName { get; set; }
    }

    public partial class GroupDeleteResponse
        : WebServiceResponse
    {
    }

    ///<summary>
    ///Returns true is the group already exists
    ///</summary>
    [Route("/group/exists", "POST,GET")]
    [Api(Description="Returns true is the group already exists")]
    public partial class GroupExists
        : WebServiceRequest, IReturn<GroupExistsResponse>
    {
        ///<summary>
        ///Name of the group
        ///</summary>
        [ApiMember(Description="Name of the group", IsRequired=true)]
        public virtual string GroupName { get; set; }
    }

    public partial class GroupExistsResponse
        : WebServiceResponse
    {
        public virtual bool Exists { get; set; }
    }

    ///<summary>
    ///Returns details of the specified group.
    ///</summary>
    [Route("/group/get", "POST,GET")]
    [Api(Description="Returns details of the specified group.")]
    public partial class GroupGet
        : WebServiceRequest, IReturn<GroupGetResponse>
    {
        ///<summary>
        ///Name of the group
        ///</summary>
        [ApiMember(Description="Name of the group", IsRequired=true)]
        public virtual string GroupName { get; set; }
    }

    public partial class GroupGetResponse
        : WebServiceResponse
    {
        public virtual GroupRecord Group { get; set; }
    }

    ///<summary>
    ///Returns a list of defined groups
    ///</summary>
    [Route("/group/list", "POST,GET")]
    [Api(Description="Returns a list of defined groups")]
    public partial class GroupList
        : WebServiceRequest, IReturn<GroupListResponse>
    {
        ///<summary>
        ///Callsign of group manager or admin (omit for all)
        ///</summary>
        [ApiMember(Description="Callsign of group manager or admin (omit for all)")]
        public virtual string Manager { get; set; }

        ///<summary>
        ///If true return only names for groups that are locked
        ///</summary>
        [ApiMember(Description="If true return only names for groups that are locked")]
        public virtual bool LockedOnly { get; set; }
    }

    public partial class GroupListResponse
        : WebServiceResponse
    {
        public GroupListResponse()
        {
            Groups = new List<string>{};
        }

        public virtual List<string> Groups { get; set; }
    }

    ///<summary>
    ///Adds a manager to an existing group
    ///</summary>
    [Route("/group/manager/add", "POST,GET")]
    [Api(Description="Adds a manager to an existing group")]
    public partial class GroupManagerAdd
        : WebServiceRequest, IReturn<GroupManagerAddResponse>
    {
        ///<summary>
        ///Callsign of the group manager
        ///</summary>
        [ApiMember(Description="Callsign of the group manager", IsRequired=true)]
        public virtual string Callsign { get; set; }

        ///<summary>
        ///Name of the group
        ///</summary>
        [ApiMember(Description="Name of the group", IsRequired=true)]
        public virtual string GroupName { get; set; }
    }

    public partial class GroupManagerAddResponse
        : WebServiceResponse
    {
    }

    ///<summary>
    ///Returns a list of group address for which the user is a manager of
    ///</summary>
    [Route("/group/manager/address/list", "POST,GET")]
    [Api(Description="Returns a list of group address for which the user is a manager of")]
    public partial class GroupManagerAddressList
        : WebServiceRequest, IReturn<GroupManagerAddressListResponse>
    {
        ///<summary>
        ///Callsign of the manager
        ///</summary>
        [ApiMember(Description="Callsign of the manager", IsRequired=true)]
        public virtual string Callsign { get; set; }

        ///<summary>
        ///Account password
        ///</summary>
        [ApiMember(Description="Account password", IsRequired=true, Name="Password")]
        public virtual string Password { get; set; }
    }

    public partial class GroupManagerAddressListResponse
        : WebServiceResponse
    {
        public GroupManagerAddressListResponse()
        {
            GroupAddresses = new List<GroupManagerAddressRecord>{};
        }

        public virtual List<GroupManagerAddressRecord> GroupAddresses { get; set; }
    }

    [DataContract]
    public partial class GroupManagerAddressRecord
    {
        [DataMember]
        public virtual string GroupName { get; set; }

        [DataMember]
        public virtual string Description { get; set; }
    }

    ///<summary>
    ///Returns true if callsign is a manager (or admin) of any group
    ///</summary>
    [Route("/group/manager/any", "POST,GET")]
    [Api(Description="Returns true if callsign is a manager (or admin) of any group")]
    public partial class GroupManagerAny
        : WebServiceRequest, IReturn<GroupManagerAnyResponse>
    {
        ///<summary>
        ///Callsign of the manager
        ///</summary>
        [ApiMember(Description="Callsign of the manager", IsRequired=true)]
        public virtual string Callsign { get; set; }
    }

    public partial class GroupManagerAnyResponse
        : WebServiceResponse
    {
        public virtual bool IsValid { get; set; }
    }

    ///<summary>
    ///Removes a manager from an existing group
    ///</summary>
    [Route("/group/manager/delete", "POST,GET")]
    [Api(Description="Removes a manager from an existing group")]
    public partial class GroupManagerDelete
        : WebServiceRequest, IReturn<GroupManagerDeleteResponse>
    {
        ///<summary>
        ///Callsign of the group manager
        ///</summary>
        [ApiMember(Description="Callsign of the group manager", IsRequired=true)]
        public virtual string Callsign { get; set; }

        ///<summary>
        ///Name of the group
        ///</summary>
        [ApiMember(Description="Name of the group", IsRequired=true)]
        public virtual string GroupName { get; set; }
    }

    public partial class GroupManagerDeleteResponse
        : WebServiceResponse
    {
    }

    ///<summary>
    ///Returns a list of managers for the specified group
    ///</summary>
    [Route("/group/manager/list", "POST,GET")]
    [Api(Description="Returns a list of managers for the specified group")]
    public partial class GroupManagerList
        : WebServiceRequest, IReturn<GroupManagerListResponse>
    {
        ///<summary>
        ///Name of the group
        ///</summary>
        [ApiMember(Description="Name of the group", IsRequired=true)]
        public virtual string GroupName { get; set; }
    }

    public partial class GroupManagerListResponse
        : WebServiceResponse
    {
        public GroupManagerListResponse()
        {
            Managers = new List<string>{};
        }

        public virtual List<string> Managers { get; set; }
    }

    ///<summary>
    ///Adds a member address to an existing group
    ///</summary>
    [Route("/group/member/add", "POST,GET")]
    [Api(Description="Adds a member address to an existing group")]
    public partial class GroupMemberAdd
        : WebServiceRequest, IReturn<GroupMemberAddResponse>
    {
        ///<summary>
        ///Address (callsign or email)
        ///</summary>
        [ApiMember(Description="Address (callsign or email)", IsRequired=true)]
        public virtual string Address { get; set; }

        ///<summary>
        ///Name of the group
        ///</summary>
        [ApiMember(Description="Name of the group", IsRequired=true)]
        public virtual string GroupName { get; set; }
    }

    public partial class GroupMemberAddResponse
        : WebServiceResponse
    {
    }

    ///<summary>
    ///Removes a member address from an existing group
    ///</summary>
    [Route("/group/member/delete", "POST,GET")]
    [Api(Description="Removes a member address from an existing group")]
    public partial class GroupMemberDelete
        : WebServiceRequest, IReturn<GroupMemberDeleteResponse>
    {
        ///<summary>
        ///Address (callsign or email)
        ///</summary>
        [ApiMember(Description="Address (callsign or email)", IsRequired=true)]
        public virtual string Address { get; set; }

        ///<summary>
        ///Name of the group
        ///</summary>
        [ApiMember(Description="Name of the group", IsRequired=true)]
        public virtual string GroupName { get; set; }
    }

    ///<summary>
    ///Removes all member addresses from an existing group
    ///</summary>
    [Route("/group/member/delete/all", "POST,GET")]
    [Api(Description="Removes all member addresses from an existing group")]
    public partial class GroupMemberDeleteAll
        : WebServiceRequest, IReturn<GroupMemberDeleteAllResponse>
    {
        ///<summary>
        ///Name of the group
        ///</summary>
        [ApiMember(Description="Name of the group", IsRequired=true)]
        public virtual string GroupName { get; set; }
    }

    public partial class GroupMemberDeleteAllResponse
        : WebServiceResponse
    {
    }

    public partial class GroupMemberDeleteResponse
        : WebServiceResponse
    {
    }

    ///<summary>
    ///Imports a list of member addresses into an existing group
    ///</summary>
    [Route("/group/member/import", "POST,GET")]
    [Api(Description="Imports a list of member addresses into an existing group")]
    public partial class GroupMemberImport
        : WebServiceRequest, IReturn<GroupMemberImportResponse>
    {
        public GroupMemberImport()
        {
            ImportList = new List<string>{};
        }

        ///<summary>
        ///Name of the group
        ///</summary>
        [ApiMember(Description="Name of the group", IsRequired=true)]
        public virtual string GroupName { get; set; }

        ///<summary>
        ///List of callsigns and email addresses to import (txt or csv format, one item per line)
        ///</summary>
        [ApiMember(Description="List of callsigns and email addresses to import (txt or csv format, one item per line)", IsRequired=true)]
        public virtual List<string> ImportList { get; set; }
    }

    public partial class GroupMemberImportResponse
        : WebServiceResponse
    {
        public GroupMemberImportResponse()
        {
            ErrorList = new List<string>{};
        }

        public virtual List<string> ErrorList { get; set; }
    }

    ///<summary>
    ///Return a list of member addresses from the specified group
    ///</summary>
    [Route("/group/member/list", "POST,GET")]
    [Api(Description="Return a list of member addresses from the specified group")]
    public partial class GroupMemberList
        : WebServiceRequest, IReturn<GroupMemberListResponse>
    {
        ///<summary>
        ///Name of the group
        ///</summary>
        [ApiMember(Description="Name of the group", IsRequired=true)]
        public virtual string GroupName { get; set; }

        ///<summary>
        ///Include members added because of a dynamic group query (default: true)
        ///</summary>
        [ApiMember(Description="Include members added because of a dynamic group query (default: true)")]
        public virtual bool IncludeDynamic { get; set; }

        ///<summary>
        ///Flag dynamic members with asterisk (default: false)
        ///</summary>
        [ApiMember(Description="Flag dynamic members with asterisk (default: false)")]
        public virtual bool FlagDynamic { get; set; }

        ///<summary>
        ///Limit the number of member addresses returned to this value (0 = no limit)
        ///</summary>
        [ApiMember(Description="Limit the number of member addresses returned to this value (0 = no limit)")]
        public virtual int DynamicResultLimit { get; set; }
    }

    public partial class GroupMemberListResponse
        : WebServiceResponse
    {
        public GroupMemberListResponse()
        {
            Members = new List<string>{};
        }

        public virtual List<string> Members { get; set; }
    }

    ///<summary>
    ///Return a list of groups this addresses is a member of
    ///</summary>
    [Route("/group/membership", "POST,GET")]
    [Api(Description="Return a list of groups this addresses is a member of")]
    public partial class GroupMembership
        : WebServiceRequest, IReturn<GroupMembershipResponse>
    {
        ///<summary>
        ///Address (callsign or email)
        ///</summary>
        [ApiMember(Description="Address (callsign or email)", IsRequired=true)]
        public virtual string Address { get; set; }
    }

    public partial class GroupMembershipResponse
        : WebServiceResponse
    {
        public GroupMembershipResponse()
        {
            Addresses = new List<string>{};
        }

        public virtual List<string> Addresses { get; set; }
    }

    [DataContract]
    public partial class GroupRecord
    {
        [DataMember]
        public virtual string GroupName { get; set; }

        [DataMember]
        public virtual string Description { get; set; }

        [DataMember]
        public virtual string Query { get; set; }

        [DataMember]
        public virtual bool CcEmailAddress { get; set; }

        [DataMember]
        public virtual bool InternetAddressesOnly { get; set; }

        [DataMember]
        public virtual bool Locked { get; set; }
    }

    ///<summary>
    ///Changes the name of an existing group to a new unused name
    ///</summary>
    [Route("/group/rename", "POST,GET")]
    [Api(Description="Changes the name of an existing group to a new unused name")]
    public partial class GroupRename
        : WebServiceRequest, IReturn<GroupRenameResponse>
    {
        ///<summary>
        ///Name of the group
        ///</summary>
        [ApiMember(Description="Name of the group", IsRequired=true)]
        public virtual string GroupName { get; set; }

        ///<summary>
        ///New name for the group
        ///</summary>
        [ApiMember(Description="New name for the group", IsRequired=true)]
        public virtual string NewGroupName { get; set; }
    }

    public partial class GroupRenameResponse
        : WebServiceResponse
    {
    }

    ///<summary>
    ///Updates an existing group record.
    ///</summary>
    [Route("/group/update", "POST,GET")]
    [Api(Description="Updates an existing group record.")]
    public partial class GroupUpdate
        : WebServiceRequest, IReturn<GroupUpdateResponse>
    {
        ///<summary>
        ///Name of the group
        ///</summary>
        [ApiMember(Description="Name of the group", IsRequired=true)]
        public virtual string GroupName { get; set; }

        ///<summary>
        ///Description of the group
        ///</summary>
        [ApiMember(Description="Description of the group")]
        public virtual string Description { get; set; }

        ///<summary>
        ///SQL query or name and parameters for pre-defined query
        ///</summary>
        [ApiMember(Description="SQL query or name and parameters for pre-defined query")]
        public virtual string Query { get; set; }

        ///<summary>
        ///True to send messages to the email address associated with each callsign
        ///</summary>
        [ApiMember(Description="True to send messages to the email address associated with each callsign")]
        public virtual bool CcEmailAddress { get; set; }

        ///<summary>
        ///True to send messages to internet email address associated with each callsign ONLY
        ///</summary>
        [ApiMember(Description="True to send messages to internet email address associated with each callsign ONLY")]
        public virtual bool InternetAddressesOnly { get; set; }
    }

    public partial class GroupUpdateResponse
        : WebServiceResponse
    {
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
    ///Returns a list of inquiry records for use in updating the Winlink catalog.
    ///</summary>
    [Route("/inquiries/catalog", "POST,GET")]
    [Api(Description="Returns a list of inquiry records for use in updating the Winlink catalog.")]
    public partial class InquiriesCatalog
        : WebServiceRequest, IReturn<InquiriesCatalogResponse>
    {
    }

    public partial class InquiriesCatalogResponse
        : WebServiceResponse
    {
        public InquiriesCatalogResponse()
        {
            Inquiries = new List<InquiryRecord>{};
        }

        public virtual List<InquiryRecord> Inquiries { get; set; }
    }

    ///<summary>
    ///Returns a list of inquiries
    ///</summary>
    [Route("/inquiries/list", "POST,GET")]
    [Api(Description="Returns a list of inquiries")]
    public partial class InquiriesList
        : WebServiceRequest, IReturn<InquiriesListResponse>
    {
    }

    ///<summary>
    ///Returns a list of disabled inquiry records.
    ///</summary>
    [Route("/inquiries/list/disabled", "POST,GET")]
    [Api(Description="Returns a list of disabled inquiry records.")]
    public partial class InquiriesListDisabled
        : WebServiceRequest, IReturn<InquiriesListDisabledResponse>
    {
    }

    public partial class InquiriesListDisabledResponse
        : WebServiceResponse
    {
        public InquiriesListDisabledResponse()
        {
            Inquiries = new List<InquiryRecord>{};
        }

        public virtual List<InquiryRecord> Inquiries { get; set; }
    }

    public partial class InquiriesListResponse
        : WebServiceResponse
    {
        public InquiriesListResponse()
        {
            List = new List<InquiryRecord>{};
        }

        public virtual List<InquiryRecord> List { get; set; }
    }

    ///<summary>
    ///Adds or updates an inquiry returns.
    ///</summary>
    [Route("/inquiry/add", "POST,GET")]
    [Route("/inquiry/update", "POST,GET")]
    [Api(Description="Adds or updates an inquiry returns.")]
    public partial class InquiryAddUpdate
        : WebServiceRequest, IReturn<InquiryAddUpdateResponse>
    {
        ///<summary>
        ///The ID of the inquiry record
        ///</summary>
        [ApiMember(Description="The ID of the inquiry record", IsRequired=true)]
        public virtual string InquiryId { get; set; }

        public virtual string Category { get; set; }
        public virtual string Subject { get; set; }
        public virtual string Process { get; set; }
        public virtual string Url { get; set; }
        public virtual int Lifetime { get; set; }
        public virtual int SizeEstimate { get; set; }
        public virtual bool Enabled { get; set; }
        public virtual int DownloadCount { get; set; }
        public virtual int ImageQuality { get; set; }
    }

    public partial class InquiryAddUpdateResponse
        : WebServiceResponse
    {
    }

    ///<summary>
    ///Deletes the specified inquiry record
    ///</summary>
    [Route("/inquiry/delete", "POST,GET")]
    [Api(Description="Deletes the specified inquiry record")]
    public partial class InquiryDelete
        : WebServiceRequest, IReturn<InquiryDeleteResponse>
    {
        ///<summary>
        ///The ID of the inquiry record
        ///</summary>
        [ApiMember(Description="The ID of the inquiry record", IsRequired=true)]
        public virtual string InquiryId { get; set; }
    }

    public partial class InquiryDeleteResponse
        : WebServiceResponse
    {
    }

    ///<summary>
    ///Returns the specified inquiry record.
    ///</summary>
    [Route("/inquiry/get", "POST,GET")]
    [Api(Description="Returns the specified inquiry record.")]
    public partial class InquiryGet
        : WebServiceRequest, IReturn<InquiryGetResponse>
    {
        ///<summary>
        ///The ID of the inquiry record
        ///</summary>
        [ApiMember(Description="The ID of the inquiry record", IsRequired=true)]
        public virtual string InquiryId { get; set; }
    }

    public partial class InquiryGetResponse
        : WebServiceResponse
    {
        public virtual InquiryRecord Inquiry { get; set; }
    }

    [DataContract]
    public partial class InquiryRecord
    {
        [DataMember]
        public virtual DateTime Timestamp { get; set; }

        [DataMember]
        public virtual string InquiryId { get; set; }

        [DataMember]
        public virtual string Category { get; set; }

        [DataMember]
        public virtual string Subject { get; set; }

        [DataMember]
        public virtual string Process { get; set; }

        [DataMember]
        public virtual string Url { get; set; }

        [DataMember]
        public virtual int Lifetime { get; set; }

        [DataMember]
        public virtual int SizeEstimate { get; set; }

        [DataMember]
        public virtual bool Enabled { get; set; }

        [DataMember]
        public virtual int DownloadCount { get; set; }

        [DataMember]
        public virtual int ImageQuality { get; set; }
    }

    ///<summary>
    ///Returns a list of inquiry records using the specified filter.
    ///</summary>
    [Route("/inquiry/search", "POST,GET")]
    [Api(Description="Returns a list of inquiry records using the specified filter.")]
    public partial class InquirySearch
        : WebServiceRequest, IReturn<InquirySearchResponse>
    {
        ///<summary>
        ///Filter text -- applied to multiple columns
        ///</summary>
        [ApiMember(Description="Filter text -- applied to multiple columns")]
        public virtual string Filter { get; set; }
    }

    public partial class InquirySearchResponse
        : WebServiceResponse
    {
        public InquirySearchResponse()
        {
            Inquiries = new List<InquiryRecord>{};
        }

        public virtual List<InquiryRecord> Inquiries { get; set; }
    }

    ///<summary>
    ///Submits an inquiry request for processing
    ///</summary>
    [Route("/inquiry/submit", "POST,GET")]
    [Api(Description="Submits an inquiry request for processing")]
    public partial class InquirySubmit
        : WebServiceRequest, IReturn<InquirySubmitResponse>
    {
        ///<summary>
        ///The ID of the inquiry record or a URL
        ///</summary>
        [ApiMember(Description="The ID of the inquiry record or a URL", IsRequired=true)]
        public virtual string InquiryId { get; set; }

        ///<summary>
        ///Callsign account
        ///</summary>
        [ApiMember(Description="Callsign account", IsRequired=true, Name="Callsign")]
        public virtual string Callsign { get; set; }
    }

    public partial class InquirySubmitResponse
        : WebServiceResponse
    {
    }

    ///<summary>
    ///Updates the record timestamp to the current date
    ///</summary>
    [Route("/inquiry/touch", "POST,GET")]
    [Api(Description="Updates the record timestamp to the current date")]
    public partial class InquiryTouch
        : WebServiceRequest, IReturn<InquiryTouchResponse>
    {
        ///<summary>
        ///The ID of the inquiry record
        ///</summary>
        [ApiMember(Description="The ID of the inquiry record", IsRequired=true)]
        public virtual string InquiryId { get; set; }
    }

    public partial class InquiryTouchResponse
        : WebServiceResponse
    {
    }

    ///<summary>
    ///Returns a list of winlink admin accounts
    ///</summary>
    [Route("/internal/admin/accounts/get", "POST,GET")]
    [Api(Description="Returns a list of winlink admin accounts")]
    public partial class InternalAdminAccountsGet
        : WebServiceRequest, IReturn<InternalAdminAccountsGetResponse>
    {
    }

    public partial class InternalAdminAccountsGetResponse
        : WebServiceResponse
    {
        public InternalAdminAccountsGetResponse()
        {
            AdminAccounts = new List<string>{};
        }

        public virtual List<string> AdminAccounts { get; set; }
    }

    ///<summary>
    ///Returns a list of group admin accounts
    ///</summary>
    [Route("/internal/group/admin/accounts/get", "POST,GET")]
    [Api(Description="Returns a list of group admin accounts")]
    public partial class InternalGroupAdminAccountsGet
        : WebServiceRequest, IReturn<InternalGroupAdminAccountsGetResponse>
    {
    }

    public partial class InternalGroupAdminAccountsGetResponse
        : WebServiceResponse
    {
        public InternalGroupAdminAccountsGetResponse()
        {
            GroupAdminAccounts = new List<string>{};
        }

        public virtual List<string> GroupAdminAccounts { get; set; }
    }

    [DataContract]
    public partial class IPAddressRecord
    {
        [DataMember]
        public virtual DateTime Timestamp { get; set; }

        [DataMember]
        public virtual string Callsign { get; set; }

        [DataMember]
        public virtual string IPAddress { get; set; }
    }

    ///<summary>
    ///Returns a list of callsigns know to have used the provided IP address to access Winlink systems
    ///</summary>
    [Route("/ipAddressUsers/get", "POST,GET")]
    [Api(Description="Returns a list of callsigns know to have used the provided IP address to access Winlink systems")]
    public partial class IPAddressUsers
        : WebServiceRequest, IReturn<IPAddressUsersResponse>
    {
        ///<summary>
        ///IP address
        ///</summary>
        [ApiMember(Description="IP address", IsRequired=true, Name="IPAddress")]
        public virtual string IPAddress { get; set; }
    }

    public partial class IPAddressUsersResponse
        : WebServiceResponse
    {
        public IPAddressUsersResponse()
        {
            IPAddressUsers = new List<IPAddressRecord>{};
        }

        public virtual List<IPAddressRecord> IPAddressUsers { get; set; }
    }

    public partial class LatestActivity
    {
        [DataMember]
        public virtual DateTime Timestamp { get; set; }

        [DataMember]
        public virtual string Callsign { get; set; }
    }

    [DataContract]
    public partial class LatestProgramVersionRecord
    {
        [DataMember]
        public virtual string Program { get; set; }

        [DataMember]
        public virtual string Version { get; set; }

        [DataMember]
        public virtual UserType UserType { get; set; }
    }

    ///<summary>
    ///Deletes a license record.
    ///</summary>
    [Route("/license/delete", "POST,GET")]
    [Api(Description="Deletes a license record.")]
    public partial class LicenseDelete
        : WebServiceRequest, IReturn<LicenseDeleteResponse>
    {
        ///<summary>
        ///Callsign
        ///</summary>
        [ApiMember(Description="Callsign", IsRequired=true)]
        public virtual string Callsign { get; set; }
    }

    public partial class LicenseDeleteResponse
        : WebServiceResponse
    {
    }

    ///<summary>
    ///Retrieves a specific license record from the database.
    ///</summary>
    [Route("/license/get", "POST,GET")]
    [Api(Description="Retrieves a specific license record from the database.")]
    public partial class LicenseGet
        : WebServiceRequest, IReturn<LicenseGetResponse>
    {
        ///<summary>
        ///Callsign
        ///</summary>
        [ApiMember(Description="Callsign", IsRequired=true)]
        public virtual string Callsign { get; set; }
    }

    public partial class LicenseGetResponse
        : WebServiceResponse
    {
        public virtual LicenseRecord LicenseRecord { get; set; }
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
    ///Adds a license record to the database. If the record already exists, it is replaced
    ///</summary>
    [Route("/license/put", "POST,GET")]
    [Api(Description="Adds a license record to the database. If the record already exists, it is replaced")]
    public partial class LicensePut
        : WebServiceRequest, IReturn<LicensePutResponse>
    {
        [ApiMember(IsRequired=true)]
        public virtual string Callsign { get; set; }

        public virtual string LicenseName { get; set; }
        public virtual string Country { get; set; }
        public virtual LicenseStatus Status { get; set; }
        public virtual string StatusDescription { get; set; }
        public virtual string ServiceUsed { get; set; }
        public virtual DateTime RecheckDate { get; set; }
        public virtual string Comments { get; set; }
    }

    public partial class LicensePutResponse
        : WebServiceResponse
    {
    }

    ///<summary>
    ///Returns list of license records where one or more of the callsign, name or comments fields contain the supplied search text.
    ///</summary>
    [Route("/license/search", "POST,GET")]
    [Api(Description="Returns list of license records where one or more of the callsign, name or comments fields contain the supplied search text.")]
    public partial class LicenseSearch
        : WebServiceRequest, IReturn<LicenseSearchResponse>
    {
        ///<summary>
        ///Text to filter results by
        ///</summary>
        [ApiMember(Description="Text to filter results by", IsRequired=true)]
        public virtual string SearchText { get; set; }
    }

    public partial class LicenseSearchResponse
        : WebServiceResponse
    {
        public LicenseSearchResponse()
        {
            LicenseRecords = new List<LicenseRecord>{};
        }

        public virtual List<LicenseRecord> LicenseRecords { get; set; }
    }

    ///<summary>
    ///Adds or updates a license record. If the record already exists only the provided elements are replaced - others remain unaltered.
    ///</summary>
    [Route("/license/update", "POST,GET")]
    [Api(Description="Adds or updates a license record. If the record already exists only the provided elements are replaced - others remain unaltered.")]
    public partial class LicenseUpdate
        : WebServiceRequest, IReturn<LicenseUpdateResponse>
    {
        [ApiMember(IsRequired=true)]
        public virtual string Callsign { get; set; }

        public virtual string LicenseName { get; set; }
        public virtual string Country { get; set; }
        public virtual LicenseStatus Status { get; set; }
        public virtual string StatusDescription { get; set; }
        public virtual string ServiceUsed { get; set; }
        public virtual DateTime RecheckDate { get; set; }
        public virtual string Comments { get; set; }
    }

    public partial class LicenseUpdateResponse
        : WebServiceResponse
    {
    }

    ///<summary>
    ///Returns information regarding the validity of the amateur radio license.
    ///</summary>
    [Route("/license/validate", "POST,GET")]
    [Api(Description="Returns information regarding the validity of the amateur radio license.")]
    public partial class LicenseValidate
        : WebServiceRequest, IReturn<LicenseValidateResponse>
    {
        ///<summary>
        ///Callsign to test
        ///</summary>
        [ApiMember(Description="Callsign to test", IsRequired=true)]
        public virtual string Callsign { get; set; }
    }

    public partial class LicenseValidateResponse
        : WebServiceResponse
    {
        public virtual LicenseRecord ValidationRecord { get; set; }
    }

    [DataContract]
    public partial class LockedOutRecord
    {
        [DataMember]
        public virtual DateTime Timestamp { get; set; }

        [DataMember]
        public virtual string Callsign { get; set; }

        [DataMember]
        public virtual string AdminCallsign { get; set; }

        [DataMember]
        public virtual string Reason { get; set; }
    }

    ///<summary>
    ///Deletes (marks as forwarded) a specific email message identified by MessageId.
    ///</summary>
    [Route("/message/delete", "POST,GET")]
    [Route("/message/kill", "POST,GET")]
    [Api(Description="Deletes (marks as forwarded) a specific email message identified by MessageId.")]
    public partial class MessageDelete
        : WebServiceRequest, IReturn<MessageDeleteResponse>
    {
        ///<summary>
        ///The ID of the message
        ///</summary>
        [ApiMember(Description="The ID of the message", IsRequired=true)]
        public virtual string MessageId { get; set; }

        ///<summary>
        ///Completely remove all traces of the message from the database (default: false)
        ///</summary>
        [ApiMember(Description="Completely remove all traces of the message from the database (default: false)")]
        public virtual bool CompleteDeletion { get; set; }
    }

    public partial class MessageDeleteResponse
        : WebServiceResponse
    {
    }

    ///<summary>
    ///Returns a list of addressees for this message and their delivery status
    ///</summary>
    [Route("/message/delivery/list", "POST,GET")]
    [Api(Description="Returns a list of addressees for this message and their delivery status")]
    public partial class MessageDeliveryList
        : WebServiceRequest, IReturn<MessageDeliveryListResponse>
    {
        ///<summary>
        ///The ID of the message
        ///</summary>
        [ApiMember(Description="The ID of the message", IsRequired=true, Name="MessageId")]
        public virtual string MessageId { get; set; }
    }

    public partial class MessageDeliveryListResponse
        : WebServiceResponse
    {
        public MessageDeliveryListResponse()
        {
            DeliveryList = new List<DeliveryListRecord>{};
        }

        public virtual List<DeliveryListRecord> DeliveryList { get; set; }
    }

    ///<summary>
    ///Returns if the message with MessageId exists.
    ///</summary>
    [Route("/message/exists", "POST,GET")]
    [Api(Description="Returns if the message with MessageId exists.")]
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
    ///Gets a specific email message identified by MessageId. Returns the mime encoded message.
    ///</summary>
    [Route("/message/get/byid", "POST,GET")]
    [Api(Description="Gets a specific email message identified by MessageId. Returns the mime encoded message.")]
    public partial class MessageGetById
        : WebServiceRequest, IReturn<MessageGetByIdResponse>
    {
        ///<summary>
        ///The ID of the message
        ///</summary>
        [ApiMember(Description="The ID of the message", IsRequired=true)]
        public virtual string MessageId { get; set; }
    }

    public partial class MessageGetByIdResponse
        : WebServiceResponse
    {
        public virtual string MessageId { get; set; }
        public virtual string Mime { get; set; }
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

    ///<summary>
    ///Gets a specific email message identified by MessageId. Returns the decoded message.
    ///</summary>
    [Route("/message/get/decoded/internal", "POST,GET")]
    [Api(Description="Gets a specific email message identified by MessageId. Returns the decoded message.")]
    public partial class MessageGetDecodedInternal
        : WebServiceRequest, IReturn<MessageGetDecodedResponse>
    {
        ///<summary>
        ///The ID of the message
        ///</summary>
        [ApiMember(Description="The ID of the message", IsRequired=true, Name="MessageId")]
        public virtual string MessageId { get; set; }
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

    ///<summary>
    ///Returns a list of messages and message details based on the query parameters (Default: Messages seen in the last 24 hours)
    ///</summary>
    [Route("/message/list/query", "POST,GET")]
    [Api(Description="Returns a list of messages and message details based on the query parameters (Default: Messages seen in the last 24 hours)")]
    public partial class MessageListQuery
        : WebServiceRequest, IReturn<MessageListQueryResponse>
    {
        ///<summary>
        ///Type of query (one of: Action,Addressee,Cms,Gateway,MessageId,Sender,Source,Subject)
        ///</summary>
        [ApiMember(Description="Type of query (one of: Action,Addressee,Cms,Gateway,MessageId,Sender,Source,Subject)")]
        public virtual MessageQueryType QueryType { get; set; }

        ///<summary>
        ///Parameter value for selected query type (required when query type specified)
        ///</summary>
        [ApiMember(Description="Parameter value for selected query type (required when query type specified)")]
        public virtual string QueryArgument { get; set; }

        ///<summary>
        ///Number of hours of history to include (default: 24)
        ///</summary>
        [ApiMember(Description="Number of hours of history to include (default: 24)")]
        public virtual int HistoryHours { get; set; }

        ///<summary>
        ///Limit number of records returned (default: 1000)
        ///</summary>
        [ApiMember(Description="Limit number of records returned (default: 1000)")]
        public virtual int RecordLimit { get; set; }

        ///<summary>
        ///True to include messages that were hidden
        ///</summary>
        [ApiMember(Description="True to include messages that were hidden")]
        public virtual bool IncludeHidden { get; set; }

        ///<summary>
        ///Specify specific status (Accepted, Proposed, Rejected, Forwarded, etc.
        ///</summary>
        [ApiMember(Description="Specify specific status (Accepted, Proposed, Rejected, Forwarded, etc.")]
        public virtual string Status { get; set; }
    }

    public partial class MessageListQueryRecord
    {
        [DataMember]
        public virtual DateTime Timestamp { get; set; }

        [DataMember]
        public virtual string MessageId { get; set; }

        [DataMember]
        public virtual int Size { get; set; }

        [DataMember]
        public virtual int Attachments { get; set; }

        [DataMember]
        public virtual string Action { get; set; }

        [DataMember]
        public virtual string Source { get; set; }

        [DataMember]
        public virtual string Cms { get; set; }

        [DataMember]
        public virtual string Gateway { get; set; }

        [DataMember]
        public virtual string Sender { get; set; }

        [DataMember]
        public virtual string Subject { get; set; }
    }

    public partial class MessageListQueryResponse
        : WebServiceResponse
    {
        public MessageListQueryResponse()
        {
            MessageList = new List<MessageListQueryRecord>{};
        }

        public virtual List<MessageListQueryRecord> MessageList { get; set; }
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

    [DataContract]
    public enum MessageQueryType
    {
        None,
        Action,
        Addressee,
        Cms,
        Gateway,
        MessageId,
        Sender,
        Source,
        Subject,
        FullText,
    }

    ///<summary>
    ///Reprocesses the specified message. This may cause duplicates.
    ///</summary>
    [Route("/message/reprocess", "POST,GET")]
    [Api(Description="Reprocesses the specified message. This may cause duplicates.")]
    public partial class MessageReprocess
        : WebServiceRequest, IReturn<MessageReprocessResponse>
    {
        ///<summary>
        ///The ID of the message
        ///</summary>
        [ApiMember(Description="The ID of the message", IsRequired=true, Name="MessageId")]
        public virtual string MessageId { get; set; }
    }

    public partial class MessageReprocessResponse
        : WebServiceResponse
    {
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
        ///Callsign of message sender
        ///</summary>
        [ApiMember(Description="Callsign of message sender", IsRequired=true)]
        public virtual string Callsign { get; set; }

        ///<summary>
        ///Password for callsign account
        ///</summary>
        [ApiMember(Description="Password for callsign account", IsRequired=true)]
        public virtual string Password { get; set; }

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
        [ApiMember(Description="Sender's callsign or email address", IsRequired=true, Name="From")]
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

    ///<summary>
    ///Returns a list of tracked actions for the specified message ID
    ///</summary>
    [Route("/message/track", "POST,GET")]
    [Api(Description="Returns a list of tracked actions for the specified message ID")]
    public partial class MessageTrack
        : WebServiceRequest, IReturn<MessageTrackResponse>
    {
        ///<summary>
        ///The ID of the message
        ///</summary>
        [ApiMember(Description="The ID of the message", IsRequired=true, Name="MessageId")]
        public virtual string MessageId { get; set; }
    }

    [DataContract]
    public partial class MessageTrackRecord
    {
        [DataMember]
        public virtual DateTime Timestamp { get; set; }

        [DataMember]
        public virtual string Site { get; set; }

        [DataMember]
        public virtual string MessageId { get; set; }

        [DataMember]
        public virtual string Event { get; set; }

        [DataMember]
        public virtual string Status { get; set; }

        [DataMember]
        public virtual string Sender { get; set; }

        [DataMember]
        public virtual string Address { get; set; }

        [DataMember]
        public virtual string Detail { get; set; }
    }

    public partial class MessageTrackResponse
        : WebServiceResponse
    {
        public MessageTrackResponse()
        {
            TrackList = new List<MessageTrackRecord>{};
        }

        public virtual List<MessageTrackRecord> TrackList { get; set; }
    }

    ///<summary>
    ///Removes a record from the message view table
    ///</summary>
    [Route("/message/view/delete", "POST,GET")]
    [Api(Description="Removes a record from the message view table")]
    public partial class MessageViewDelete
        : WebServiceRequest, IReturn<MessageViewDeleteResponse>
    {
        ///<summary>
        ///The ID of the message
        ///</summary>
        [ApiMember(Description="The ID of the message", IsRequired=true, Name="MessageId")]
        public virtual string MessageId { get; set; }
    }

    public partial class MessageViewDeleteResponse
        : WebServiceResponse
    {
    }

    ///<summary>
    ///Returns a list of messages and message details based on the query parameters
    ///</summary>
    [Route("/message/view/query", "POST,GET")]
    [Api(Description="Returns a list of messages and message details based on the query parameters")]
    public partial class MessageViewQuery
        : WebServiceRequest, IReturn<MessageViewQueryResponse>
    {
        ///<summary>
        ///Type of query (one of: MessageId,Gateway,Source,Sender,Subject,Addressee,FullText)
        ///</summary>
        [ApiMember(Description="Type of query (one of: MessageId,Gateway,Source,Sender,Subject,Addressee,FullText)")]
        public virtual MessageQueryType QueryType { get; set; }

        ///<summary>
        ///Parameter value for selected query type (required when query type specified)
        ///</summary>
        [ApiMember(Description="Parameter value for selected query type (required when query type specified)")]
        public virtual string QueryArgument { get; set; }

        ///<summary>
        ///Number of hours of history to include (default: 24)
        ///</summary>
        [ApiMember(Description="Number of hours of history to include (default: 24)")]
        public virtual int HistoryHours { get; set; }

        ///<summary>
        ///Limit number of records returned (default: 1000)
        ///</summary>
        [ApiMember(Description="Limit number of records returned (default: 1000)")]
        public virtual int RecordLimit { get; set; }

        ///<summary>
        ///The minimum full text search match score (default: 5)
        ///</summary>
        [ApiMember(Description="The minimum full text search match score (default: 5)")]
        public virtual double MinimumScore { get; set; }
    }

    public partial class MessageViewQueryRecord
    {
        [DataMember]
        public virtual DateTime Timestamp { get; set; }

        [DataMember]
        public virtual string MessageId { get; set; }

        [DataMember]
        public virtual string Callsign { get; set; }

        [DataMember]
        public virtual string Gateway { get; set; }

        [DataMember]
        public virtual string Cms { get; set; }

        [DataMember]
        public virtual string Sender { get; set; }

        [DataMember]
        public virtual string Source { get; set; }

        [DataMember]
        public virtual string Subject { get; set; }

        [DataMember]
        public virtual int Frequency { get; set; }

        [DataMember]
        public virtual int Attachments { get; set; }

        [DataMember]
        public virtual int Size { get; set; }

        [DataMember]
        public virtual string ClientType { get; set; }
    }

    public partial class MessageViewQueryResponse
        : WebServiceResponse
    {
        public MessageViewQueryResponse()
        {
            MessageList = new List<MessageViewQueryRecord>{};
        }

        public virtual List<MessageViewQueryRecord> MessageList { get; set; }
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
        VARA2750 = 54,
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
    public partial class PasswordHashRecord
    {
        [DataMember]
        public virtual string Callsign { get; set; }

        [DataMember]
        public virtual string PasswordHash { get; set; }
    }

    ///<summary>
    ///Returns a list of password hashes for use in validating client passwords off-air. Maximum request frequency - 5 minutes.
    ///</summary>
    [Route("/passwords/list", "POST,GET")]
    [Api(Description="Returns a list of password hashes for use in validating client passwords off-air. Maximum request frequency - 5 minutes.")]
    public partial class PasswordsList
        : WebServiceRequest, IReturn<PasswordsListResponse>
    {
        ///<summary>
        ///Challenge phrase
        ///</summary>
        [ApiMember(Description="Challenge phrase", IsRequired=true, Name="Challenge")]
        public virtual string Challenge { get; set; }
    }

    public partial class PasswordsListResponse
        : WebServiceResponse
    {
        public PasswordsListResponse()
        {
            PasswordHash = new List<PasswordHashRecord>{};
        }

        public virtual List<PasswordHashRecord> PasswordHash { get; set; }
    }

    ///<summary>
    ///Tests CMS web services connectivity. Request frequency: no more than once an hour.
    ///</summary>
    [Route("/ping", "POST,GET")]
    [Api(Description="Tests CMS web services connectivity. Request frequency: no more than once an hour.")]
    public partial class Ping
        : IReturn<PingResponse>
    {
    }

    ///<summary>
    ///Tests telnet, web services, and web application interfaces. Returns HTTP 200 if all pass, otherwise 4xx indicating an error.
    ///</summary>
    [Route("/ping/health", "POST,GET")]
    [Api(Description="Tests telnet, web services, and web application interfaces. Returns HTTP 200 if all pass, otherwise 4xx indicating an error.")]
    public partial class PingHealth
        : WebServiceRequest, IReturn<PingHealthResponse>
    {
    }

    public partial class PingHealthResponse
        : WebServiceResponse
    {
    }

    public partial class PingResponse
        : WebServiceResponse
    {
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
    ///Delete an existing position report.
    ///</summary>
    [Route("/position/reports/delete", "POST,GET")]
    [Api(Description="Delete an existing position report.")]
    public partial class PositionReportsDelete
        : WebServiceRequest, IReturn<PositionReportsDeleteResponse>
    {
        ///<summary>
        ///Callsign
        ///</summary>
        [ApiMember(Description="Callsign", IsRequired=true, Name="Callsign")]
        public virtual string Callsign { get; set; }

        ///<summary>
        ///Date and time of the position report
        ///</summary>
        [ApiMember(Description="Date and time of the position report", IsRequired=true, Name="Timestamp")]
        public virtual DateTime Timestamp { get; set; }
    }

    public partial class PositionReportsDeleteResponse
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
    ///Returns a data structure containing version information for all version reporting programs.
    ///</summary>
    [Route("/program/versions", "POST,GET")]
    [Api(Description="Returns a data structure containing version information for all version reporting programs.")]
    public partial class ProgramVersions
        : WebServiceRequest, IReturn<ProgramVersionsResponse>
    {
        ///<summary>
        ///One of Client, Sysop, or AnyAll (default: AnyAll)
        ///</summary>
        [ApiMember(Description="One of Client, Sysop, or AnyAll (default: AnyAll)", Name="UserType")]
        public virtual UserType UserType { get; set; }
    }

    [DataContract]
    public partial class ProgramVersionsCountRecord
    {
        [DataMember]
        public virtual string Program { get; set; }

        [DataMember]
        public virtual string Version { get; set; }

        [DataMember]
        public virtual int Count { get; set; }
    }

    ///<summary>
    ///Returns a data structure containing the name and counts of all programs reporting version within the past 30 days.
    ///</summary>
    [Route("/program/version/counts", "POST,GET")]
    [Api(Description="Returns a data structure containing the name and counts of all programs reporting version within the past 30 days.")]
    public partial class ProgramVersionsCounts
        : WebServiceRequest, IReturn<ProgramVersionsCountsResponse>
    {
    }

    public partial class ProgramVersionsCountsResponse
        : WebServiceResponse
    {
        public ProgramVersionsCountsResponse()
        {
            ProgramVersionCounts = new List<ProgramVersionsCountRecord>{};
        }

        public virtual List<ProgramVersionsCountRecord> ProgramVersionCounts { get; set; }
    }

    ///<summary>
    ///Returns a data structure containing the most recent version for each program.
    ///</summary>
    [Route("/program/versions/latest", "POST,GET")]
    [Api(Description="Returns a data structure containing the most recent version for each program.")]
    public partial class ProgramVersionsLatest
        : WebServiceRequest, IReturn<ProgramVersionsLatestResponse>
    {
        ///<summary>
        ///One of Client, Sysop, or AnyAll (default: AnyAll)
        ///</summary>
        [ApiMember(Description="One of Client, Sysop, or AnyAll (default: AnyAll)", Name="UserType")]
        public virtual UserType UserType { get; set; }
    }

    public partial class ProgramVersionsLatestResponse
        : WebServiceResponse
    {
        public ProgramVersionsLatestResponse()
        {
            ProgramVersionList = new List<LatestProgramVersionRecord>{};
        }

        public virtual List<LatestProgramVersionRecord> ProgramVersionList { get; set; }
    }

    [DataContract]
    public partial class ProgramVersionsRecord
    {
        [DataMember]
        public virtual string Callsign { get; set; }

        [DataMember]
        public virtual string Program { get; set; }

        [DataMember]
        public virtual string Version { get; set; }

        [DataMember]
        public virtual string CurrentVersion { get; set; }

        [DataMember]
        public virtual UserType UserType { get; set; }

        [DataMember]
        public virtual bool UpdateNeeded { get; set; }
    }

    public partial class ProgramVersionsResponse
        : WebServiceResponse
    {
        public ProgramVersionsResponse()
        {
            ProgramVersionList = new List<ProgramVersionsRecord>{};
        }

        public virtual List<ProgramVersionsRecord> ProgramVersionList { get; set; }
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

    [DataContract]
    public partial class QueueCounts
    {
        [DataMember]
        public virtual int RmsInboundCount { get; set; }

        [DataMember]
        public virtual int SmtpInboundCount { get; set; }

        [DataMember]
        public virtual int ActivityCount { get; set; }

        [DataMember]
        public virtual int SmtpQueueCount { get; set; }

        [DataMember]
        public virtual int RpQueueCount { get; set; }

        [DataMember]
        public virtual int PrQueueCount { get; set; }

        [DataMember]
        public virtual int MessagesPendingDelivery { get; set; }
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

    [DataContract]
    public partial class RegistrationRecord
    {
        [DataMember]
        public virtual string RegistrationType { get; set; }

        [DataMember]
        public virtual string RegistrationKey { get; set; }
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
        ///Callsign of server (SSID optional)
        ///</summary>
        [ApiMember(Description="Callsign of server (SSID optional)", IsRequired=true)]
        public virtual string Server { get; set; }

        ///<summary>
        ///Server grid locator
        ///</summary>
        [ApiMember(Description="Server grid locator", IsRequired=true)]
        public virtual string ServerGrid { get; set; }

        ///<summary>
        ///Callsign of client (SSID optional)
        ///</summary>
        [ApiMember(Description="Callsign of client (SSID optional)", IsRequired=true)]
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
    ///Returns a list of session records matching the request parameters
    ///</summary>
    [Route("/session/list", "POST,GET")]
    [Api(Description="Returns a list of session records matching the request parameters")]
    public partial class SessionList
        : WebServiceRequest, IReturn<SessionListResponse>
    {
        ///<summary>
        ///Number of hours of history to include (default: 24)
        ///</summary>
        [ApiMember(Description="Number of hours of history to include (default: 24)")]
        public virtual int HistoryHours { get; set; }

        ///<summary>
        ///Name of application (gateway)
        ///</summary>
        [ApiMember(Description="Name of application (gateway)")]
        public virtual string Application { get; set; }

        ///<summary>
        ///Specific server (gateway) callsign
        ///</summary>
        [ApiMember(Description="Specific server (gateway) callsign")]
        public virtual string Server { get; set; }

        ///<summary>
        ///Connection mode (default: all modes)
        ///</summary>
        [ApiMember(Description="Connection mode (default: all modes)")]
        public virtual string Mode { get; set; }

        ///<summary>
        ///Filter records based on the service code used by the gateway
        ///</summary>
        [ApiMember(Description="Filter records based on the service code used by the gateway")]
        public virtual string ServiceCodeFilter { get; set; }
    }

    public partial class SessionListResponse
        : WebServiceResponse
    {
        public SessionListResponse()
        {
            Sessions = new List<SessionRecord>{};
        }

        public virtual List<SessionRecord> Sessions { get; set; }
    }

    [DataContract]
    public partial class SessionRecord
    {
        [DataMember]
        public virtual DateTime Timestamp { get; set; }

        [DataMember]
        public virtual string Application { get; set; }

        [DataMember]
        public virtual string Version { get; set; }

        [DataMember]
        public virtual string Cms { get; set; }

        [DataMember]
        public virtual string Server { get; set; }

        [DataMember]
        public virtual string ServerGrid { get; set; }

        [DataMember]
        public virtual string Client { get; set; }

        [DataMember]
        public virtual string ClientGrid { get; set; }

        [DataMember]
        public virtual string Sid { get; set; }

        [DataMember]
        public virtual string Mode { get; set; }

        [DataMember]
        public virtual int Frequency { get; set; }

        [DataMember]
        public virtual int Kilometers { get; set; }

        [DataMember]
        public virtual int Degrees { get; set; }

        [DataMember]
        public virtual string LastCommand { get; set; }

        [DataMember]
        public virtual int MessagesSent { get; set; }

        [DataMember]
        public virtual int MessagesReceived { get; set; }

        [DataMember]
        public virtual int BytesSent { get; set; }

        [DataMember]
        public virtual int BytesReceived { get; set; }

        [DataMember]
        public virtual int HoldingSeconds { get; set; }

        [DataMember]
        public virtual string IdTag { get; set; }
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
    ///Deletes an existing sysop record.
    ///</summary>
    [Route("/sysop/delete", "POST,GET")]
    [Api(Description="Deletes an existing sysop record.")]
    public partial class SysopDelete
        : WebServiceRequest, IReturn<SysopDeleteResponse>
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

    public partial class SysopDeleteResponse
        : WebServiceResponse
    {
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
    ///Returns a sysop record.
    ///</summary>
    [Route("/sysop/get", "POST,GET")]
    [Api(Description="Returns a sysop record.")]
    public partial class SysopGet
        : WebServiceRequest, IReturn<SysopGetResponse>
    {
        ///<summary>
        ///Sysop callsign (no SSID)
        ///</summary>
        [ApiMember(Description="Sysop callsign (no SSID)", IsRequired=true, Name="Callsign")]
        public virtual string Callsign { get; set; }
    }

    public partial class SysopGetResponse
        : WebServiceResponse
    {
        public virtual SysopRecord Sysop { get; set; }
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
    ///Returns assorted system statistics.
    ///</summary>
    [Route("/system/stats")]
    [Api(Description="Returns assorted system statistics.")]
    public partial class SystemStats
        : WebServiceRequest, IReturn<SystemStatusResponse>
    {
    }

    ///<summary>
    ///Returns status of several CMS queues.
    ///</summary>
    [Route("/systemStatus", "POST,GET")]
    [Route("/queue/status", "POST,GET")]
    [Api(Description="Returns status of several CMS queues.")]
    public partial class SystemStatus
        : WebServiceRequest, IReturn<SystemStatusResponse>
    {
    }

    public partial class SystemStatusResponse
        : WebServiceResponse
    {
        public virtual DateTime Timestamp { get; set; }
        public virtual string AvailableRam { get; set; }
        public virtual QueueCounts QueueCounts { get; set; }
        public virtual string WebServiceVersion { get; set; }
    }

    [DataContract]
    public partial class TableInfo
    {
        [DataMember]
        public virtual string TableName { get; set; }

        [DataMember]
        public virtual int RowCount { get; set; }

        [DataMember]
        public virtual int DataLength { get; set; }
    }

    ///<summary>
    ///Returns statistics about most CMSMaster tables.
    ///</summary>
    [Route("/table/stats", "POST,GET")]
    [Route("/table/stats/get", "POST,GET")]
    [Api(Description="Returns statistics about most CMSMaster tables.")]
    public partial class TableStatsGet
        : WebServiceRequest, IReturn<TableStatsGetResponse>
    {
    }

    public partial class TableStatsGetResponse
        : WebServiceResponse
    {
        public TableStatsGetResponse()
        {
            Tables = new List<TableInfo>{};
        }

        public virtual List<TableInfo> Tables { get; set; }
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
    ///Returns a list of records showing details of traffic that passed through the specified gateway.
    ///</summary>
    [Route("/traffic/logs/callsign/get", "POST,GET")]
    [Api(Description="Returns a list of records showing details of traffic that passed through the specified gateway.")]
    public partial class TrafficLogsCallsignGet
        : WebServiceRequest, IReturn<TrafficLogsCallsignGetResponse>
    {
        ///<summary>
        ///Gateway Callsign (no SSID) or other gateway identifier such as TELNET, WEBMAIL, SERVICE, etc.
        ///</summary>
        [ApiMember(Description="Gateway Callsign (no SSID) or other gateway identifier such as TELNET, WEBMAIL, SERVICE, etc.", IsRequired=true, Name="Callsign")]
        public virtual string Callsign { get; set; }
    }

    public partial class TrafficLogsCallsignGetResponse
        : WebServiceResponse
    {
        public TrafficLogsCallsignGetResponse()
        {
            TrafficList = new List<TrafficRecord>{};
        }

        public virtual List<TrafficRecord> TrafficList { get; set; }
    }

    ///<summary>
    ///Hides a record in the traffic logs table
    ///</summary>
    [Route("/traffic/logs/hide", "POST,GET")]
    [Api(Description="Hides a record in the traffic logs table")]
    public partial class TrafficLogsHide
        : WebServiceRequest, IReturn<TrafficLogsHideResponse>
    {
        ///<summary>
        ///The ID of the message
        ///</summary>
        [ApiMember(Description="The ID of the message", IsRequired=true)]
        public virtual string MessageId { get; set; }

        ///<summary>
        ///True to hide traffic log records for this message ID
        ///</summary>
        [ApiMember(Description="True to hide traffic log records for this message ID")]
        public virtual bool Hide { get; set; }
    }

    public partial class TrafficLogsHideResponse
        : WebServiceResponse
    {
    }

    ///<summary>
    ///Returns a list of records showing details of traffic sent by the specified sender.
    ///</summary>
    [Route("/traffic/logs/sender/get", "POST,GET")]
    [Api(Description="Returns a list of records showing details of traffic sent by the specified sender.")]
    public partial class TrafficLogsSenderGet
        : WebServiceRequest, IReturn<TrafficLogsSenderGetResponse>
    {
        ///<summary>
        ///Callsign or SMTP email address.
        ///</summary>
        [ApiMember(Description="Callsign or SMTP email address.", IsRequired=true, Name="Sender")]
        public virtual string Sender { get; set; }
    }

    public partial class TrafficLogsSenderGetResponse
        : WebServiceResponse
    {
        public TrafficLogsSenderGetResponse()
        {
            TrafficList = new List<TrafficRecord>{};
        }

        public virtual List<TrafficRecord> TrafficList { get; set; }
    }

    ///<summary>
    ///Returns a list of records showing details of traffic sent by the specified source.
    ///</summary>
    [Route("/traffic/logs/source/get", "POST,GET")]
    [Api(Description="Returns a list of records showing details of traffic sent by the specified source.")]
    public partial class TrafficLogsSourceGet
        : WebServiceRequest, IReturn<TrafficLogsSourceGetResponse>
    {
        ///<summary>
        ///Callsign or other source identifier such as WEBMAIL, SMTP, SERVICE, etc.
        ///</summary>
        [ApiMember(Description="Callsign or other source identifier such as WEBMAIL, SMTP, SERVICE, etc.", IsRequired=true, Name="Source")]
        public virtual string Source { get; set; }
    }

    public partial class TrafficLogsSourceGetResponse
        : WebServiceResponse
    {
        public TrafficLogsSourceGetResponse()
        {
            TrafficList = new List<TrafficRecord>{};
        }

        public virtual List<TrafficRecord> TrafficList { get; set; }
    }

    [DataContract]
    public partial class TrafficRecord
    {
        [DataMember]
        public virtual DateTime Timestamp { get; set; }

        [DataMember]
        public virtual string Site { get; set; }

        [DataMember]
        public virtual string Event { get; set; }

        [DataMember]
        public virtual string MessageId { get; set; }

        [DataMember]
        public virtual int ClientType { get; set; }

        [DataMember]
        public virtual string Callsign { get; set; }

        [DataMember]
        public virtual string Gateway { get; set; }

        [DataMember]
        public virtual string Source { get; set; }

        [DataMember]
        public virtual string Sender { get; set; }

        [DataMember]
        public virtual string Subject { get; set; }

        [DataMember]
        public virtual int Size { get; set; }

        [DataMember]
        public virtual int Attachments { get; set; }

        [DataMember]
        public virtual int Frequency { get; set; }
    }

    [DataContract]
    public enum UserType
    {
        AnyAll,
        Client,
        Sysop,
    }

    ///<summary>
    ///Add/update a program version record. Version records should be sent at application startup and then no more often than once every 24 hours. Only programs monitored by the CMS are accepted.
    ///</summary>
    [Route("/version/add", "POST,GET")]
    [Api(Description="Add/update a program version record. Version records should be sent at application startup and then no more often than once every 24 hours. Only programs monitored by the CMS are accepted.")]
    public partial class VersionAdd
        : WebServiceRequest, IReturn<VersionAddResponse>
    {
        ///<summary>
        ///Station callsign
        ///</summary>
        [ApiMember(Description="Station callsign", IsRequired=true, Name="Callsign")]
        public virtual string Callsign { get; set; }

        ///<summary>
        ///Name of program (e.g., Winlink Express)
        ///</summary>
        [ApiMember(Description="Name of program (e.g., Winlink Express)", IsRequired=true, Name="Program")]
        public virtual string Program { get; set; }

        ///<summary>
        ///Dotted version of the program (e.g., 1.2.3)
        ///</summary>
        [ApiMember(Description="Dotted version of the program (e.g., 1.2.3)", IsRequired=true, Name="Version")]
        public virtual string Version { get; set; }

        ///<summary>
        ///
        ///</summary>
        [ApiMember(Description="", Name="Comments")]
        public virtual string Comments { get; set; }
    }

    public partial class VersionAddResponse
        : WebServiceResponse
    {
    }

    ///<summary>
    ///Deletes an existing program version record for a specific callsign.
    ///</summary>
    [Route("/version/delete", "POST,GET")]
    [Api(Description="Deletes an existing program version record for a specific callsign.")]
    public partial class VersionDelete
        : WebServiceRequest, IReturn<VersionDeleteResponse>
    {
        ///<summary>
        ///Station callsign
        ///</summary>
        [ApiMember(Description="Station callsign", IsRequired=true, Name="Callsign")]
        public virtual string Callsign { get; set; }

        ///<summary>
        ///Name of program (e.g., Winlink Express)
        ///</summary>
        [ApiMember(Description="Name of program (e.g., Winlink Express)", IsRequired=true, Name="Program")]
        public virtual string Program { get; set; }
    }

    public partial class VersionDeleteResponse
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
    ///Returns a list of watch notification records showing the number of notices sent for each watch (callsign+program) over the past 30 days
    ///</summary>
    [Route("/watch/notices", "POST,GET")]
    [Api(Description="Returns a list of watch notification records showing the number of notices sent for each watch (callsign+program) over the past 30 days")]
    public partial class WatchNotices
        : WebServiceRequest, IReturn<WatchNoticesResponse>
    {
        ///<summary>
        ///A single service code, if applicable
        ///</summary>
        [ApiMember(Description="A single service code, if applicable")]
        public virtual string ServiceCode { get; set; }
    }

    [DataContract]
    public partial class WatchNoticesRecord
    {
        [DataMember]
        public virtual string Callsign { get; set; }

        [DataMember]
        public virtual string Program { get; set; }

        [DataMember]
        public virtual int Count { get; set; }
    }

    public partial class WatchNoticesResponse
        : WebServiceResponse
    {
        public WatchNoticesResponse()
        {
            Notices = new List<WatchNoticesRecord>{};
        }

        public virtual List<WatchNoticesRecord> Notices { get; set; }
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
        ///Account callsign
        ///</summary>
        [ApiMember(Description="Account callsign", IsRequired=true)]
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

    ///<summary>
    ///Add or update a whitelist item.
    ///</summary>
    [Route("/whitelist/add", "POST,GET")]
    [Api(Description="Add or update a whitelist item.")]
    public partial class WhitelistAdd
        : WebServiceRequest, IReturn<WhitelistAddResponse>
    {
        ///<summary>
        ///Account callsign (no SSID)
        ///</summary>
        [ApiMember(Description="Account callsign (no SSID)", IsRequired=true)]
        public virtual string Callsign { get; set; }

        ///<summary>
        ///Email address or domain to add
        ///</summary>
        [ApiMember(Description="Email address or domain to add", IsRequired=true)]
        public virtual string Address { get; set; }

        ///<summary>
        ///Allow or disallow an address or domain
        ///</summary>
        [ApiMember(Description="Allow or disallow an address or domain", IsRequired=true)]
        public virtual bool? Allow { get; set; }
    }

    public partial class WhitelistAddResponse
        : WebServiceResponse
    {
    }

    ///<summary>
    ///Deletes a whitelist entry.
    ///</summary>
    [Route("/whitelist/delete", "POST,GET")]
    [Api(Description="Deletes a whitelist entry.")]
    public partial class WhitelistDelete
        : WebServiceRequest, IReturn<WhitelistDeleteResponse>
    {
        ///<summary>
        ///Account callsign (no SSID)
        ///</summary>
        [ApiMember(Description="Account callsign (no SSID)", IsRequired=true)]
        public virtual string Callsign { get; set; }

        ///<summary>
        ///Email address or domain to delete
        ///</summary>
        [ApiMember(Description="Email address or domain to delete", IsRequired=true)]
        public virtual string Address { get; set; }
    }

    public partial class WhitelistDeleteResponse
        : WebServiceResponse
    {
    }

    ///<summary>
    ///Returns a list of allowed and disallowed addresses for the specified callsign. Maximum request frequency - 30 minutes.
    ///</summary>
    [Route("/whitelist/get", "POST,GET")]
    [Route("/whitelist/list", "POST,GET")]
    [Api(Description="Returns a list of allowed and disallowed addresses for the specified callsign. Maximum request frequency - 30 minutes.")]
    public partial class WhitelistGet
        : WebServiceRequest, IReturn<WhitelistGetResponse>
    {
        ///<summary>
        ///Account callsign (no SSID)
        ///</summary>
        [ApiMember(Description="Account callsign (no SSID)", IsRequired=true)]
        public virtual string Callsign { get; set; }
    }

    public partial class WhitelistGetResponse
        : WebServiceResponse
    {
        public WhitelistGetResponse()
        {
            AccessList = new List<WhitelistRecord>{};
        }

        public virtual List<WhitelistRecord> AccessList { get; set; }
    }

    [DataContract]
    public partial class WhitelistRecord
    {
        [DataMember]
        public virtual DateTime Timestamp { get; set; }

        [DataMember]
        public virtual string Address { get; set; }

        [DataMember]
        public virtual bool Allow { get; set; }
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

