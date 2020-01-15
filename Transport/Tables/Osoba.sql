CREATE TABLE [dbo].[Osoba]
(
	[Id] INT IDENTITY PRIMARY KEY, 
    [PESEL] NVARCHAR(50) NULL, 
    [Plec] NCHAR(10) NOT NULL, 
    [Wiek] INT NULL, 
    [Imie] NVARCHAR(50) NOT NULL, 
    [Nazwisko] VARCHAR(50) NULL
)
