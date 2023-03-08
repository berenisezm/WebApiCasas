namespace WebApiCasas.Entidades
{
    public class Familia
    {
        public int Id { get; set; }

        public string Apellidos { get; set; }

        public string Telefono { get; set; }

        public int Num_integrantes { get; set; }
        
        public int CasaId { get; set; }

        public Casa Casa { get; set; }
    }
}
