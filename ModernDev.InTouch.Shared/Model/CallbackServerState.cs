using System.Diagnostics;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace ModernDev.InTouch
{
    /// <summary>
    /// A <see cref="CallbackServerState" /> class describes Callback API server state.
    /// </summary>
    [DebuggerDisplay("CallbackServerState {State}")]
    [DataContract]
    public class CallbackServerState
    {
        /// <summary>
        /// State code.
        /// </summary>
        [JsonProperty("state_code")]
        [DataMember]
        public int StateCode { get; set; }

        /// <summary>
        /// State message.
        /// </summary>
        [JsonProperty("state")]
        [DataMember]
        public string State { get; set; }
    }
}