using System.Text.Json.Serialization;

namespace Anastasia_Erileeva_kt_42_21.Models
{
    public class Student
    {
        [JsonIgnore]
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Middlename { get; set; }
        public int GroupID { get; set; }
        [JsonIgnore]
        public Group? Group { get; set; }
        public bool DeletionStatus { get; set; }
    }
}