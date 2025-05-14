using System.ComponentModel.DataAnnotations;

namespace TestJobSRMD.Models
{
    public class ContactModel
    {
        [MinLength(1)]
        public string Name { get; set; } = string.Empty;

        [Phone]
        public string MobilePhone { get; set; } = string.Empty;

        [MinLength(1)]
        public string JobTitle { get; set; } = string.Empty;

        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
    }
}
