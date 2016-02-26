using System.Diagnostics;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace ModernDev.InTouch
{
    /// <summary>
    /// Information about user's higher education institution.
    /// </summary>
    [DataContract]
    [DebuggerDisplay("UserEducation {UniversityName} {FacultyName}'{Graduation}")]
    public class UserEducation
    {
        /// <summary>
        /// University ID.
        /// </summary>
        [DataMember]
        [JsonProperty("university")]
        public int UniversityId { get; set; }

        /// <summary>
        /// University name.
        /// </summary>
        [DataMember]
        [JsonProperty("university_name")]
        public string UniversityName { get; set; }

        /// <summary>
        /// Faculty ID.
        /// </summary>
        [DataMember]
        [JsonProperty("faculty")]
        public int FacultyId { get; set; }

        /// <summary>
        /// Faculty name.
        /// </summary>
        [DataMember]
        [JsonProperty("faculty_name")]
        public string FacultyName { get; set; }

        /// <summary>
        /// Graduation year.
        /// </summary>
        [DataMember]
        [JsonProperty("graduation")]
        public int Graduation { get; set; }

    }
}