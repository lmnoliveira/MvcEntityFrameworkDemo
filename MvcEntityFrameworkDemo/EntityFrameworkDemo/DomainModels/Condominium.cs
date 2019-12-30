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
    }
}