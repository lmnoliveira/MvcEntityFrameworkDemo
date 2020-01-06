using System.ComponentModel.DataAnnotations;

namespace MvcDemo.Models
{
    public class CondominiumViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public long SubsidiaryId { get; set; }

        [Required]
        public string Code { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Address { get; set; }
    }
}