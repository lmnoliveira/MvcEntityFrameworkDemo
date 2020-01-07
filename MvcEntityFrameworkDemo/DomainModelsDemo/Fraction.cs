namespace DomainModelsDemo
{
    public class Fraction
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Complement { get; set; }
        public decimal PerThousand { get; set; }
        public Zone Zone { get; set; }
    }
}
