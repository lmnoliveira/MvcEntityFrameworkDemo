using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EntityFrameworkDemo.DomainModels
{
    public class Condominium
    {
        [Key()]
        public int Id { get; set; }

        public long SubsidiaryId { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string Location { get; set; }
        public List<Zone> Zones { get; set; }
    }
}