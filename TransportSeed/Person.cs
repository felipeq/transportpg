using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace TransportSeed
{
    public class Person :IInsertable
    {

        public struct SurnameWithSex
        {
            public string Surname;
            public string Sex;
        };
        SurnameWithSex[] surnames = new SurnameWithSex[] {
            new SurnameWithSex { Surname="Centkowski", Sex="M" },
            new SurnameWithSex { Surname="Jagus", Sex="M" },
            new SurnameWithSex { Surname="Ciszak", Sex="F" },
            new SurnameWithSex { Surname="Niedźwiecki", Sex="M" },
            new SurnameWithSex { Surname="Tucholska", Sex="F" },
            new SurnameWithSex { Surname="Paziewska", Sex="F" },
            new SurnameWithSex { Surname="Licznerska", Sex="F" }
        };
        string[] MaleNames = new string[] { "Filip", "Pawel", "Dawid", "Karol", "Zbigniew", "Piotr", "Adam", "Krzysztof", "Lukasz" };
        string[] FemaleNames = new string[] { "Marta", "Joanna", "Iga", "Agnieszka", "Paulina", "Karolina", "Anna", "Jadwiga", "Ewelina" };
        public string Plec;
        public int Wiek;
        public string Imie;
        public string Nazwisko;
        public string PESEL;

        public Person()
        {

            Random rnd = new Random();

            Wiek = rnd.Next(23, 84);
            var seed = rnd.Next(0, surnames.Length - 1);
            Nazwisko = surnames[seed].Surname;
            PESEL = ((2020 - Wiek) % 100).ToString();
            var year = rnd.Next(1, 12);
            if (year < 10)
                PESEL += '0' + year;
            else PESEL += year;
            var month = rnd.Next(1, 29);

            if (month < 10)
                PESEL += '0' + month;
            else PESEL += month;
            PESEL += rnd.Next(0, 9);
            PESEL += rnd.Next(0, 9);
            PESEL += rnd.Next(0, 9);
            switch (surnames[seed].Sex)
            {
                case "M":
                    {
                        PESEL += rnd.Next(0, 4) * 2;
                        Plec = "Mezczyzna";
                        Imie = MaleNames[rnd.Next(0, MaleNames.Length - 1)];
                        break;
                    }
                case "F":
                    {
                        PESEL += rnd.Next(0, 4) * 2 + 1;
                        Plec = "Kobieta";
                        Imie = FemaleNames[rnd.Next(0, FemaleNames.Length - 1)];
                        break;
                    }
            }
            PESEL += rnd.Next(0, 9);
        }
        public SqlCommand GetAsInsert(SqlConnection conn)
        {
            string InsertSql = $"insert into Osoba(PESEL, Plec, Wiek, Imie, Nazwisko) VALUES('{PESEL}', '{Plec}', {Wiek}, '{Imie}', '{Nazwisko}')";
            return new SqlCommand(InsertSql, conn);

        }
    }

}