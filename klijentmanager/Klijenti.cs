namespace klijentmanager
{
    public class Klijenti
    {
        public int ID { get; }
        public string Ime { get; }
        public string Prezime { get; }
        public string Kontakt { get; }
        public string Adresa { get; }

        public Klijenti(int id, string ime, string prezime, string kontakt, string adresa)
        {
            ID = id;
            Ime = ime;
            Prezime = prezime;
            Kontakt = kontakt;
            Adresa = adresa;
        }
    }
}
