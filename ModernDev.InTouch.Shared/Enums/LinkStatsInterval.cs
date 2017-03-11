using System.Diagnostics;
using System.Runtime.Serialization;

namespace ModernDev.InTouch
{
    /// <summary>
    /// Link stats interval.
    /// </summary>
    [DebuggerDisplay("LinkStatusInterval")]
    public enum LinkStatsInterval
    {
        /// <summary>
        /// Hour
        /// </summary>
        [EnumMember(Value = "hour")]
        Hour,

        /// <summary>
        /// Day
        /// </summary>
        [EnumMember(Value = "day")]
        Day,

        /// <summary>
        /// Week
        /// </summary>
        [EnumMember(Value = "week")]
        Week,

        /// <summary>
        /// Month
        /// </summary>
        [EnumMember(Value = "month")]
        Month
    }
}