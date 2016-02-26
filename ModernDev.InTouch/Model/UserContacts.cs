using System.Diagnostics;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace ModernDev.InTouch
{
    /// <summary>
    /// Information about user's phone numbers.
    /// </summary>
    [DataContract]
    [DebuggerDisplay("UserContacts {MobilePhone} {HomePhone}")]
    public class UserContacts
    {
        /// <summary>
        /// User's mobile phone number (only for standalone applications);
        /// </summary>
        [DataMember]
        [JsonProperty("mobile_phone")]
        public string MobilePhone { get; set; }

        /// <summary>
        /// User's additional phone number.
        /// </summary>
        [DataMember]
        [JsonProperty("home_phone")]
        public string HomePhone { get; set; }
    }
}