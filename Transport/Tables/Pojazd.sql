CREATE TABLE [dbo].[Pojazd]
(
	[Id] INT identity PRIMARY KEY, 
    [Numer_Rejestracyjny] NVARCHAR(MAX) NOT NULL, 
    [Model] NVARCHAR(MAX) NOT NULL, 
    [Marka] NVARCHAR(MAX) NOT NULL, 
    [Uszkodzenia] NVARCHAR(MAX) NOT NULL, 
    [Id_Wlasciciel] INT NOT NULL, 
    CONSTRAINT [FK_Pojazd_Osoba] FOREIGN KEY (Id_Wlasciciel) REFERENCES Osoba(Id)
)
