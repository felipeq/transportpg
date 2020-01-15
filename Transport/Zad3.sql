-- 1. Wyswietl liste wypadków bez ofiar wśród ludzi
select * from Wypadek w where w.Czy_Poszkodowani_Ludzie = 0

-- 2. Wyswiel miejsce z najwieksza iloscia wypadkow
select w.Miejsce_Zdarzenia, count(*) as 'Ilosc wypadkow' from Wypadek w group by w.Miejsce_Zdarzenia order by  'Ilosc wypadkow' desc

-- 3. Wyswietl osobe, ktora spowodowala najwieksze szkody finansowe
select o.PESEL, o.Imie, o.Nazwisko, sum(w.Koszt_Zniszczen) As 'Koszt Zniszczen', count(*) AS 'Liczba Wypadkow' from Wypadek w left join Osoba o on w.Id_Sprawca = o.Id group by o.PESEL, o.Imie, o.Nazwisko ORDER BY 'Koszt Zniszczen' DESC

-- 4. Wyswietl najpopularniejsza marke samochodu
select p.Marka, count(*) from Pojazd p group by p.Marka


select s.Plec as 'Plec Sprawcy', s.Wiek as 'Wiek Sprawcy', p.Plec as 'Plec Poszkodowanego', p.Wiek as 'Wiek Poszkodowanego', w.Miejsce_Zdarzenia, w.Data_Zdarzenia,w.Godzina_Zdarzenia, w.Przyczyna, w.Koszt_Zniszczen from Wypadek w left join Osoba s on s.Id = w.Id_Sprawca left join Osoba p on p.Id = w.Id_Poszkodowany