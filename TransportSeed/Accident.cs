using System;
using System.Data.SqlClient;

namespace TransportSeed
{
    class Accident : IInsertable
    {

        int Sprawca;
        int Poszkodowany;
        string MiejsceZdarzenia;
        string DataZdarzenia;
        string GodzinaZdarzenia;
        string Przyczyna;
        int KosztZniszczen;
        bool CzyPoszkodowaniLudzie;
        string[] Przyczyny = new string[] {
        "Niedostosowanie prędkości do warunków na drodze.",
"Nieudzielenie pierwszeństwa przejazdu.",
"Nieprawidłowe zachowanie się wobec pieszego.",
"Nieprawidłowe wyprzedzanie.",
"Niezachowanie bezpiecznej odległości między pojazdami.",
"Jazda po niewłaściwej stronie drogi.",
"Prowadzenie pod wpływem alkoholu."};
        string[] Miasta = new string[] {
"Białystok",
"Bydgoszcz",
"Gdańsk",
"Gorzów Wielkopolski",
"Katowice",
"Kielce",
"Lublin",
"Łódź",
"Olsztyn",
"Opole",
"Poznań",
"Rzeszów",
"Szczecin",
"Toruń",
"Warszawa",
"Wrocław",
"Zielona Góra"};
        public Accident(int MaxSprawca)
        {
            Random rnd = new Random();
            Sprawca = rnd.Next(1, MaxSprawca - 1);
            Poszkodowany = rnd.Next(1, MaxSprawca - 1);
            MiejsceZdarzenia = Miasta[rnd.Next(0, Miasta.Length - 1)];
            TimeSpan timeSpan = DateTime.Now - DateTime.Now.AddYears(-10);
            var eventDate = DateTime.Now.AddYears(-10) + new TimeSpan(0, rnd.Next(0, (int)timeSpan.TotalMinutes), 0);
            GodzinaZdarzenia = eventDate.ToString("HH:mm");
            DataZdarzenia = eventDate.ToString("MM/dd/yyyy");
            Przyczyna = Przyczyny[rnd.Next(0, Przyczyny.Length - 1)];
            KosztZniszczen = rnd.Next(0, 50000);
            CzyPoszkodowaniLudzie = rnd.Next(2) == 0;

        }

        public SqlCommand GetAsInsert(SqlConnection conn)
        {
            string InsertSql = $"insert into Wypadek(Id_Sprawca, Id_Poszkodowany, Miejsce_Zdarzenia, Data_Zdarzenia, Godzina_Zdarzenia,Przyczyna,Koszt_Zniszczen,Czy_Poszkodowani_Ludzie) " +
                $"VALUES({Sprawca}, {Poszkodowany}, '{MiejsceZdarzenia}', '{DataZdarzenia}', '{GodzinaZdarzenia}','{Przyczyna}',{KosztZniszczen},'{CzyPoszkodowaniLudzie}')";
            return new SqlCommand(InsertSql, conn);

        }
    }
}
