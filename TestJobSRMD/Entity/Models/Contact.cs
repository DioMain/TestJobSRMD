using System.ComponentModel.DataAnnotations;

namespace TestJobSRMD.Entity.Models
{
    public class Contact
    {
        [Key]
        public Guid Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string MobilePhone { get; set; } = string.Empty;

        public string JobTitle { get; set; } = string.Empty;

        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
    }
}
