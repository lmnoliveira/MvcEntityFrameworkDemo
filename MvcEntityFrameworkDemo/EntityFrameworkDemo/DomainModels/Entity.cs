using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EntityFrameworkDemo.DomainModels
{
    public class Entity
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        //public List<EntitiesFractions> EntitiesFractions { get; set; }
    }
}
