using EntityFrameworkDemo.Repositories;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace EntityFrameworkDemo.DomainModels
{
    public class Zone
    {
        [Key()]
        public int Id { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public Condominium Condominium { get; set; }
        public List<Fraction> Fractions { get; set; }
    }
}
