namespace DomainModelsDemo
{
    public class Zone
    {
        public int Id { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public Condominium Condominium { get; set; }
        //public List<Fraction> Fractions { get; set; }
    }
}
