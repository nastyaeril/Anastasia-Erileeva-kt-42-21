using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace Anastasia_Erileeva_kt_42_21.Models
{
    public class Group
    {
        public int GroupId { get; set; }
        public required string GroupName { get; set; }
        [JsonIgnore]
        public List<Subject>? Subject { get; set; }
        public bool IsValidGroupName()
        {
            return Regex.Match(GroupName, @"/\D*-\d*-\d\d/g").Success;
        }
    }
}