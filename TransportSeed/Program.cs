using System;
using System.Data.SqlClient;

namespace TransportSeed
{
    class Program
    {
        static void Main(string[] args)
        {
            var PersonCount = 1000;
            var InjuryCount = 50;
            var WypadekCount = 5000;
            var CarCount = 1000;
            Console.WriteLine("Hello World!");
            var connectionString = @"Data Source=WIN10MAC\SQLEXPRESS;Initial Catalog=transportDb;Integrated Security=True;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            // 
            using (var conn = new SqlConnection(connectionString))

            {
                conn.Open();
                var cmd = new SqlCommand("", conn);

                string[] cleanupOrder = new string[] {
                    "DELETE FROM Wypadek" ,
                    "DELETE FROM Obrazenia",
                                    "DELETE FROM Pojazd",

                    "DELETE FROM Osoba",
                "DELETE FROM Uraz",
                };

                foreach (var item in cleanupOrder)
                {
                    cmd = new SqlCommand(item, conn);
                    cmd.ExecuteNonQuery();
                }

                using (System.IO.StreamWriter file =
            new System.IO.StreamWriter(@"seed.sql", true))
                {

                    #region Osoba

                    new SqlCommand("DBCC CHECKIDENT (Osoba, RESEED, 0)", conn).ExecuteNonQuery();
                    for (int i = 0; i < PersonCount; i++)
                    {
                        var randomPerson = new Person();
                        //var cmd = new SqlCommand(randomPerson.InsertSql, conn);
                        cmd = randomPerson.GetAsInsert(conn);
                        Console.WriteLine(cmd.CommandText);
                        file.WriteLine(cmd.CommandText);
                        cmd.ExecuteNonQuery();
                    }
                    #endregion

                    #region Uraz
                    new SqlCommand("DBCC CHECKIDENT (Uraz, RESEED, 0)", conn).ExecuteNonQuery();

                    for (int i = 0; i < InjuryCount; i++)
                    {
                        var everyInjury = new Injury();
                        //var cmd = new SqlCommand(randomPerson.InsertSql, conn);
                        cmd = everyInjury.GetAsInsert(conn);
                        Console.WriteLine(cmd.CommandText);
                        file.WriteLine(cmd.CommandText);

                        cmd.ExecuteNonQuery();
                    }
                    #endregion

                    #region Wypadek
                    Console.WriteLine("Wypadek");

                    new SqlCommand("DBCC CHECKIDENT (Wypadek, RESEED, 0)", conn).ExecuteNonQuery();

                    for (int i = 0; i < WypadekCount; i++)
                    {
                        var everyInjury = new Accident(PersonCount);
                        //var cmd = new SqlCommand(randomPerson.InsertSql, conn);
                        cmd = everyInjury.GetAsInsert(conn);
                        Console.WriteLine(cmd.CommandText);
                        file.WriteLine(cmd.CommandText);

                        cmd.ExecuteNonQuery();
                    }
                    #endregion

                    #region Obrazenia
                    new SqlCommand("DBCC CHECKIDENT (Obrazenia, RESEED, 0)", conn).ExecuteNonQuery();

                    for (int i = 0; i < InjuryCount; i++)
                    {
                        var everyInjury = new Obrazenia(InjuryCount, PersonCount);
                        cmd = everyInjury.GetAsInsert(conn);
                        Console.WriteLine(cmd.CommandText);
                        file.WriteLine(cmd.CommandText);

                        cmd.ExecuteNonQuery();
                    }
                    #endregion
                   
                    #region Pojazd
                    new SqlCommand("DBCC CHECKIDENT (Pojazd, RESEED, 0)", conn).ExecuteNonQuery();

                    for (int i = 0; i < CarCount; i++)
                    {
                        var everyInjury = new Pojazd(PersonCount);
                        cmd = everyInjury.GetAsInsert(conn);
                        Console.WriteLine(cmd.CommandText);
                        file.WriteLine(cmd.CommandText);

                        cmd.ExecuteNonQuery();
                    }
                    #endregion
                }
            }
        }
    }
}
