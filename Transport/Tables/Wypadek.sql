CREATE TABLE [dbo].[Wypadek]
(
	[Id] INT IDENTITY PRIMARY KEY, 
    [Id_Sprawca] INT NOT NULL, 
    [Id_Poszkodowany] INT NULL, 
    [Miejsce_Zdarzenia] NVARCHAR(50) NOT NULL, 
    [Data_Zdarzenia] DATE NOT NULL, 
    [Godzina_Zdarzenia] TIME NOT NULL, 
    [Przyczyna] NVARCHAR(MAX) NOT NULL, 
    [Koszt_Zniszczen] INT NULL, 
    [Czy_Poszkodowani_Ludzie] BIT NOT NULL, 
    CONSTRAINT [FK_Wypadek_Sprawca] FOREIGN KEY (Id_Sprawca) REFERENCES Osoba(Id),
    CONSTRAINT [FK_Wypadek_Poszkodowany] FOREIGN KEY (Id_Poszkodowany) REFERENCES Osoba(Id)
)
