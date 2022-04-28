using System;
using System.Collections.Generic;


namespace Student {

    public class Student
    {
        string ime;
        string prezime;
        double prosek;
        int trenutnaGodinaStudija;
        DateTime datumUpisa;
        BrojIndeksa brojIndeksa;
        Smer smer;

        public string Ime { get => ime; set => ime = value; }
        public string Prezime { get => prezime; set => prezime = value; }
        public double Prosek { get => prosek; set => prosek = value; }
        public int TrenutnaGodinaStudija { get => trenutnaGodinaStudija; set => trenutnaGodinaStudija = value; }
        public DateTime DatumUpisa { get => datumUpisa; set => datumUpisa = value; }
        private BrojIndeksa BrojIndeksa1 { get => brojIndeksa; set => brojIndeksa = value; }
        private Smer Smer1 { get => smer; set => smer = value; }

        struct BrojIndeksa
        {
            int godina;
            int broj;
        }

        enum Smer
        {
            ISIT,
            ME,
            OM,
            OK
        }

    }

    class Program
    {
        public static void Kreiranje(List<Student> studenti)
        {
            studenti.Add(new Student());
        }
        void PrikazJednogStudenta()
        {

        }
        void PrikazSvihStudenata()
        {

        }

        void Azuriranje()
        {

        }

        void Brisanje()
        {

        }
        static void Main()
        {
            List<Student> studenti = new List<Student>();
            string odgovorKorisnika;
            string meni = "\n1 - Kreiranje\n" +
                          "2 - Prikaz jednog studenta\n" +
                          "3 - Prikaz svih studenata\n" +
                          "4 - Azuriranje\n" +
                          "5 - Brisanje\n"+
                          "0 - Izlazak";


            while (true)
            {
                Console.WriteLine(meni);
                odgovorKorisnika = Console.ReadLine();
                switch (odgovorKorisnika)
                {
                    case "1":
                        Console.WriteLine("Kreiranje");
                        Kreiranje(studenti);
                        break;
                    case "2":
                        Console.WriteLine("Prikaz jednog studenta");
                        break;
                    case "3":
                        Console.WriteLine("Prikaz vise studenata");
                        break;
                    case "4":
                        Console.WriteLine("Azuriranje");
                        break;
                    case "5":
                        Console.WriteLine("Brisanje");
                        break;
                    case "0":
                        Console.WriteLine("\n*** Dovidjenja ***\n");
                        return;
                    default:
                        Console.WriteLine("Pogresna operacija!\nPokusajte ponovo: ");
                        break;
                }
                
            }
      
                              

        }
    }
}
