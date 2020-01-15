using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace TransportSeed
{
    class Pojazd : IInsertable
    {
        string[] Bugatti = new string[] {
         "Veyron 16.4 13",
 "Veyron Gr.4",
 "Vision Gran Turismo Gr.1",
 "Vision Gran Turismo"};
        string[] Mazda = new string[]{
         "787B Race Car 91",
         "Atenza Gr.3",
 "Atenza Gr.3 Road Car",
 "Atenza Gr.4",
 "Atenza Sedan XD L Package 15",
 "Eunos Roadster(NA Special Package) 89",
   "Demio XD Touring 15",
    "LM55 Vision Gran Turismo Gr.1",
 "LM55 Vision Gran Turismo",
 "Roadster S(ND) 15",
 "Roadster Touring Car",
 "RX500 70Mazda RX-7 GT-X(FC) 90",
             "RX-7 Spirit R Type A(FD) 02",

        };
        string[] Shelby = new string[] {
         "Cobra 427 66Update Icon[1]",
 "Cobra Daytona Coupe 64Update Icon[1]",
 "GT350 65Update Icon[1]"};
        string NumerPlate;
        string Model;
        string Marka;
        string Uszkodzenia;
        string[] RozneUszkodzenia = new string[] { "Pelne", "Drobne", "Czesciowe" };
        int Wlasciciel;
        string[] Plates = new string[] { "GD", "GDA", "GKA", "GKS", "GKW", "GPU", "GSP" };
        public Pojazd(int MaxWlasciciel)
        {
            Random rnd = new Random();
            Wlasciciel = rnd.Next(1, MaxWlasciciel);
            NumerPlate = Plates[rnd.Next(0, Plates.Length - 1)] + rnd.Next(1234, 96000).ToString().PadLeft(5, '0');
            switch (rnd.Next(3))
            {
                case 0:
                    {
                        Model = Bugatti[rnd.Next(0, Bugatti.Length - 1)];
                        Marka = "Bugatti";
                        break;
                    }
                case 1:
                    {
                        Model = Mazda[rnd.Next(0, Mazda.Length - 1)];
                        Marka = "Mazda";
                        break;
                    }
                case 2:
                    {
                        Model = Shelby[rnd.Next(0, Shelby.Length - 1)];
                        Marka = "Shelby";
                        break;
                    }

            }
            Uszkodzenia = RozneUszkodzenia[rnd.Next(0, RozneUszkodzenia.Length - 1)];
        }
        public SqlCommand GetAsInsert(SqlConnection conn)
        {
            string InsertSql = $"insert into Pojazd(Numer_Rejestracyjny, Model, Marka, Uszkodzenia, Id_Wlasciciel) " +
     $"VALUES('{NumerPlate}', '{Model}', '{Marka}', '{Uszkodzenia}', {Wlasciciel})";
            return new SqlCommand(InsertSql, conn);
        }
    }
}
