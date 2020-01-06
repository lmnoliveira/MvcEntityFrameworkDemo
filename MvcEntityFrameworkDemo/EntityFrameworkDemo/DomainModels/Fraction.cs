using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EntityFrameworkDemo.DomainModels
{
    public class Fraction
    {
        [Key]
        public int Id { get; set; }
        public string Code { get; set; }
        public string Complement { get; set; }
        public decimal PerThousand { get; set; }
        public Zone Zone { get; set; }
        //public List<EntitiesFractions> EntitiesFractions { get; set; }
    }
}
