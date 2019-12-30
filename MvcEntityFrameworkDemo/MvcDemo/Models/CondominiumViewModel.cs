using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace MvcDemo.Models
{
    public class CondominiumViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Code { get; set; }

        [Required]
        public string Name { get; set; }
    }
}