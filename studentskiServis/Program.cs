using System;
using System.Collections.Generic;


namespace Student {

    public class Student
    {
        string ime; // ne znam zasto mi trazi da bude nullable
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
    public static class Extension
    {
        public static string Ispis (this Smer s)
        {

            switch (s)
            {
                case Smer.ISIT:
                    return "Informacione tehnologije";
                    
                case Smer.ME:
                    return "Menadzment";
                    
                case Smer.OM:
                    return "Operacioni menadzment";
                    
                case Smer.OK:
                    return "Upravljanje kvalitetom";
                    
                default:
                    return "";
            }
        }
        public static string IspisStudentaUTabeli(this Student student)
        {

            return 
                "Ime\t" +"Prezime\t\t" + "Broj Indeksa\t" + "Prosek\t" + "Trenutna Godina\t" + "Smer\t" + "Datum Upisa\t\n"+
                student.Ime + "\t" + student.Prezime + "\t" + student.BrojIndeksa.godina+ $"/" + student.BrojIndeksa.broj + "\t" + student.Prosek + "\t\t" + student.TrenutnaGodinaStudija + "\t" + student.FaxSmer+ "\t" + student.DatumUpisa.ToShortDateString() + "\t\n";

        }
    }

    class Program
    {
        public static void Kreiranje(List<Student> studenti)
        {
            Student s = new Student();      

            Console.WriteLine("Ime studenta:");
            s.Ime = Console.ReadLine()??"";

            Console.WriteLine("Prezime studenta:");
            s.Prezime = Console.ReadLine()??"";

            Console.WriteLine("Prosek studenta:");
            string? prosekPom;
            double prosekVred;
            bool okParse = false;

            do
            {

                prosekPom = Console.ReadLine();
                okParse = Double.TryParse(prosekPom, out prosekVred);
                if (okParse == true && prosekVred>=6d && prosekVred<=10d)
                {
                    s.Prosek = (double)Math.Round(prosekVred, 2);

                }
                else
                {
                    Console.WriteLine("Prosek studenta pogesno unesen! Pokusajte ponovo:"); //ovde nesto nije dobro, ne znam sta se desava ali radi
                    okParse = false;
                }

            }
            while (!okParse);
            okParse = false;
            int godVred;
            do
            {
                Console.WriteLine("Trenutna godina studija:");
                string? trenGodStud = Console.ReadLine();

                okParse = int.TryParse(trenGodStud, out godVred);
                if (okParse == true)
                {
                    s.TrenutnaGodinaStudija = godVred;
                }
                else
                {
                    Console.WriteLine("Niste uneli adekvatan broj");
                }

            } while (!okParse || (godVred< 1 || godVred>4));
            
              

            Console.WriteLine("Datum upisa: dd/MM/yyyy");
            bool isValidDate = DateTime.TryParse(Console.ReadLine(), out s.datumUpisa);
            while (!isValidDate)
            {
                isValidDate = DateTime.TryParse(Console.ReadLine(), out s.datumUpisa);
            }

            bool godParse = false;
            bool indParse = false;
            int godInd =0;
            int brInd = 0;

            while (!godParse)
            {
                Console.WriteLine("Godina indeksa:");
                godParse = int.TryParse(Console.ReadLine(), out godInd);
                
            }
            while (!indParse)
            {
                Console.WriteLine("Broj indeksa");
                indParse = int.TryParse(Console.ReadLine(), out brInd);
            }
       
            //provera da li postoji student 
            foreach (Student st in studenti)
            {
                if (st.BrojIndeksa.broj == brInd && st.BrojIndeksa.godina == godInd)
                {
                    Console.WriteLine("Student sa tim brojem indeksa vec postoji u sistemu\n");
                    return;
                }
                
            }
            s.BrojIndeksa = new BrojIndeksa(godInd, brInd);
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
            studenti.Add(s); //ubaci studenta u listu
        }
        public static void PrikazJednogStudenta(List<Student> studenti)
        {
            bool godParse = false;
            bool indParse = false;
            int godInd = 0;
            int brInd = 0;

            while (!godParse)
            {
                Console.WriteLine("Godina indeksa:");
                godParse = int.TryParse(Console.ReadLine(), out godInd);

            }
            while (!indParse)
            {
                Console.WriteLine("Broj indeksa");
                indParse = int.TryParse(Console.ReadLine(), out brInd);
            }
            foreach (Student s in studenti)
            {
                if (s.BrojIndeksa.godina==godInd && s.BrojIndeksa.broj==brInd)
                {
                    Console.WriteLine(s.IspisStudentaUTabeli());                    
                    return;
                }
                
            }
            Console.WriteLine("Trazeni student ne postoji!");
            return;
        }
        public static void PrikazSvihStudenata(List<Student> studenti)
        {
            foreach (Student s in studenti)
            {
                Console.Write(s.IspisStudentaUTabeli());
            }
            return;
        }

        public static void Azuriranje(List<Student> studenti)
        {
            bool godParse = false;
            bool indParse = false;
            int godInd = 0;
            int brInd = 0;

            while (!godParse)
            {
                Console.WriteLine("Godina indeksa:");
                godParse = int.TryParse(Console.ReadLine(), out godInd);

            }
            while (!indParse)
            {
                Console.WriteLine("Broj indeksa");
                indParse = int.TryParse(Console.ReadLine(), out brInd);
            }
            BrojIndeksa b = new(godInd,brInd);         

            foreach (Student s in studenti)
            {
                if (s.BrojIndeksa.Equals(b))
                {
                    Console.WriteLine("Ime studenta:");
                    s.Ime = Console.ReadLine()??"N.";

                    Console.WriteLine("Prezime studenta:");
                    s.Prezime = Console.ReadLine()??"N.";

                    Console.WriteLine("Prosek studenta:");
                    string? prosekPom;
                    double prosekVred;
                    bool okParse = false;

                    do
                    {

                        prosekPom = Console.ReadLine();
                        okParse = Double.TryParse(prosekPom, out prosekVred);
                        Console.WriteLine(prosekVred);
                        if (okParse == true && prosekVred >= 6d && prosekVred <= 10d)
                        {
                            s.Prosek = (double)Math.Round(prosekVred, 2);

                        }
                        else
                        {
                            Console.WriteLine("Prosek studenta pogesno unesen! Pokusajte ponovo:"); //ovde nesto nije dobro, ne znam sta se desava
                            okParse = false;
                        }

                    }
                    while (!okParse);
                    okParse = false;
                    int godVred;
                    do
                    {
                        Console.WriteLine("Trenutna godina studija:");
                        string? trenGodStud = Console.ReadLine();

                        okParse = int.TryParse(trenGodStud, out godVred);
                        if (okParse == true)
                        {
                            s.TrenutnaGodinaStudija = godVred;
                        }
                        else
                        {
                            Console.WriteLine("Niste uneli adekvatan broj");
                        }

                    } while (!okParse || (godVred < 1 || godVred > 4));



                    Console.WriteLine("Datum upisa: dd/MM/yyyy");
                    bool isValidDate = DateTime.TryParse(Console.ReadLine(), out s.datumUpisa);
                    while (!isValidDate)
                    {
                        isValidDate = DateTime.TryParse(Console.ReadLine(), out s.datumUpisa);
                    }
                    
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
                }
                else
                {
                    Console.WriteLine("Ne postoji student sa tim brojem indeksa!");
                    return;
                }

            }

        }

        public static void  Brisanje(List<Student> studenti)
        {

            bool godParse = false;
            bool indParse = false;
            int godInd = 0;
            int brInd = 0;

            while (!godParse)
            {
                Console.WriteLine("Godina indeksa:");
                godParse = int.TryParse(Console.ReadLine(), out godInd);

            }
            while (!indParse)
            {
                Console.WriteLine("Broj indeksa");
                indParse = int.TryParse(Console.ReadLine(), out brInd);
            }
            BrojIndeksa b = new(godInd, brInd);

            foreach (Student s in studenti)
            {
                if (s.BrojIndeksa.Equals(b))
                {
                    studenti.Remove(s);
                    Console.WriteLine("***Brisanje studenta***" + b.godina + $"/" + b.broj);
                    return;
                }
            }
            Console.WriteLine("Student sa unetim brojem indeksa ne postoji");
            return;
        }

        public static void PoslednjiIndeks(List<Student> studenti)
        {

        }
        public static void Popularnost(List<Student> studenti,int god1, int god2)
        {
            int countGod1=0, countGod2 = 0;
            foreach (Student student in studenti)
            {
                if (student.datumUpisa.Year==god1)
                {
                    countGod1++;
                }
                if (student.datumUpisa.Year == god2)
                {
                    countGod2++;
                }
            }
            if (countGod1 > countGod2)
                Console.WriteLine("Vise studenata je bilo " + god1);
            else if (countGod2 > countGod1)
                Console.WriteLine("Vise studenata je bilo " + god2);
            else
                Console.WriteLine("Bilo je isto studenata obe godine");
        }
        public static void SmerSaNajvecimBrojemStudenata(List<Student> studenti)
        {
            int isit = 0, me = 0, om = 0, ok = 0;
            foreach (Student student in studenti)
            {
                if (student.smer==Smer.ISIT)
                {
                    isit++;
                }
                if (student.smer==Smer.ME)
                {
                    me++;
                }
                if (student.smer==Smer.OM)
                {
                    om++;
                }
                if (student.smer==Smer.OK)
                {
                    ok++;
                }
            }
            if (isit>me && isit>om && isit>ok)
            {
                Console.WriteLine("Najvise ima ljudi na ISIT");
                return;
            }
            if (me>isit && me>ok && me>om)
            {
                Console.WriteLine("Najvise je ljudi na ME");
                return;
            }
            if (om>isit && om>ok && om > me)
            {
                Console.WriteLine("Najvise je ljudi na OM");
                return;
            }
            else
            {
                Console.WriteLine("Najvise je ljudi na OK");
                return;
            }


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
                          "6 - Dodatno\n" +
                          "0 - Izlazak";
            string meniDodatno = "\n1 - Kreiranje\n" +
                          "2 - Popularnost fakulteta odredjenih godina\n" +
                          "3 - Prikaz svih studenata\n" +
                          "4 - Azuriranje\n" +
                          "5 - Brisanje\n" +
                          "6 - Dodatno\n" +
                          "7 - Dodatno\n" +
                          "8 - Nazad\n" +
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
                        PrikazJednogStudenta(studenti);
                        break;
                    case "3":
                        PrikazSvihStudenata(studenti);
                        break;
                    case "4":
                        Azuriranje(studenti);
                        break;
                    case "5":
                        Brisanje(studenti);
                        break;
                    case "6":
                        Console.WriteLine("Dodatno");
                        Console.WriteLine(meniDodatno);
                        odgovorKorisnika = Console.ReadLine();
                        switch (odgovorKorisnika)
                        {
                            case "1":
                                Console.WriteLine("Poslednji indeks");
                                break;
                            case "2":
                                Console.WriteLine("Unesite dve godine:");
                                int god1 = 2017;
                                int god2 = 2018;
                                Popularnost(studenti,god1,god2);
                                break;
                            case "3":
                                Console.WriteLine("Ponovni upis");
                                break;
                            case "4":
                                Console.WriteLine("Prosek po godinama studija");
                                break;
                            case "5":
                                Console.WriteLine("Prosek po smeru");
                                break;
                            case "6":
                                Console.WriteLine("Pregled svih studenata upisanih odredjene godine");
                                break;
                            case "7":
                                Console.WriteLine("Smer sa najvecim brojem studenata");
                                break;
                            case "8":
                                Console.WriteLine("Nazad");
                                break;
                            case "0":
                                Console.WriteLine("\n*** Dovidjenja ***\n");
                                return;
                            default:
                                Console.WriteLine("Pogresna operacija!\nPokusajte ponovo: ");
                                break;
                        }
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
