using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFrameworkDemo.DomainModels
{
    public class Supplier : Entity
    {
        public string ServicesDescription { get; set; }
    }
}
