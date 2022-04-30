using System;
using System.Collections.Generic;


namespace Student {

    public class Student
    {
        string ime;
        string prezime;
        double prosek;
        int trenutnaGodinaStudija;
        public DateTime datumUpisa;
        BrojIndeksa brojIndeksa;
        public Smer smer;

        public string Ime { get => ime; set => ime = value; }
        public string Prezime { get => prezime; set => prezime = value; }
        public double Prosek { get => prosek; set => prosek = value; }
        public int TrenutnaGodinaStudija { get => trenutnaGodinaStudija; set => trenutnaGodinaStudija = value; }
        public DateTime DatumUpisa { get => datumUpisa; set => datumUpisa = value; }
        public BrojIndeksa BrojIndeksa { get => brojIndeksa; set => brojIndeksa = value; }
        public Smer FaxSmer { get => smer; set => smer = value; }

       



    }

    public struct BrojIndeksa
    {
        public int godina { get; set; }
        public int broj { get; set; }

        public BrojIndeksa(int god, int br)
        {
            godina = god;
            broj = br;
        }
    }
    public enum Smer
    {
        ISIT,
        ME,
        OM,
        OK
    }

    class Program
    {
        public static void Kreiranje(List<Student> studenti)
        {   
            Student s = new Student();
            
            Console.WriteLine("Kreiranje\n");

            Console.WriteLine("Ime studenta:");
            s.Ime = Console.ReadLine();

            Console.WriteLine("Prezime studenta:");
            s.Prezime = Console.ReadLine();

            Console.WriteLine("Prosek studenta:");
            string? prosekPom;
            double prosekVred;
            bool okParse=false;
           ;
            do
            {
                
                prosekPom = Console.ReadLine();
                okParse = Double.TryParse(prosekPom, out prosekVred);
                if (okParse == true)
                {
                    s.Prosek = prosekVred;
                }
                else
                {
                    Console.WriteLine("Prosek studenta pogesno unesen!\nPokusajte ponovo:");
                }
            }
            while (!okParse);


            Console.WriteLine("Trenutna godina studija:");
            s.TrenutnaGodinaStudija = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Datum upisa: dd/MM/yyyy");
            bool isValidDate = DateTime.TryParse(Console.ReadLine(), out s.datumUpisa);
            while (!isValidDate)
            {
                isValidDate = DateTime.TryParse(Console.ReadLine(), out s.datumUpisa);
            }
            Console.WriteLine("Broj indeksa u formatu: godina_studija/broj_indeksa");
            string brojIndeksa = Console.ReadLine();
            string[] godinaBrojIndeksa = brojIndeksa.Split('/');
            Console.WriteLine(godinaBrojIndeksa[0]); // <--------------------- Mora da se hendla exception
            Console.WriteLine(godinaBrojIndeksa[1]);
            s.BrojIndeksa = new BrojIndeksa(Int32.Parse(godinaBrojIndeksa[0]), Int32.Parse(godinaBrojIndeksa[1]));
            bool odgovor = false;
            while (!odgovor)
            {
                Console.WriteLine("Smer: ISIT, ME, OM, OK");
                string smerText = Console.ReadLine().ToUpper();
                switch (smerText)
                {
                    case "ISIT":
                        s.smer = Smer.ISIT;
                        odgovor = true;
                        break;
                    case "ME":
                        s.smer = Smer.ME;
                        odgovor = true;
                        break;
                    case "OM":
                        s.smer = Smer.OM;
                        odgovor = true;
                        break;
                    case "OK":
                        s.smer = Smer.OK;
                        odgovor = true;
                        break;
                    default:
                        Console.WriteLine("Nije dobro uneto ime smera!");
                        break;
                }
            }




            Console.WriteLine(s.FaxSmer + "\n" + s.Ime + "\n" + s.Prezime + "\n" + s.Prosek + "\n" + s.TrenutnaGodinaStudija + "\n" + s.DatumUpisa.Date.ToString("dd-MM-yyyy"));
            studenti.Add(s);
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
                        //Console.WriteLine(studenti[0].FaxSmer + "\n" + studenti[0].Ime + "\n" + studenti[0].Prezime + "\n" + studenti[0].Prosek + "\n" + studenti[0].TrenutnaGodinaStudija + "\n" + studenti[0].DatumUpisa.Date.ToString("dd-MM-yyyy"));


                        Console.WriteLine("Pogresna operacija!\nPokusajte ponovo: ");
                        break;
                }
                
            }



        }
    }
}
