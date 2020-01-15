CREATE TABLE [dbo].[Obrazenia]
(
	[Id] int identity PRIMARY KEY, 
    [Id_Uraz] int NOT NULL, 
    [Id_Poszkodowany] int NOT NULL, 
    CONSTRAINT [FK_Obrazenia_Poszkodowany] FOREIGN KEY (Id_Poszkodowany) REFERENCES Osoba(Id),
    CONSTRAINT [FK_Obrazenia_Uraz] FOREIGN KEY (Id_Uraz) REFERENCES Uraz(Id)
)
