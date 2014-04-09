CREATE TABLE "Fornitore" 
(
  "Id" INTEGER PRIMARY KEY AUTOINCREMENT, 
  "RagioneSociale" VARCHAR(60) NOT NULL
);

CREATE TABLE "Prodotto" 
(
  "Id" INTEGER PRIMARY KEY AUTOINCREMENT, 
  "Descrizione" VARCHAR(60) NOT NULL,
   "Costo" DECIMAL NOT NULL 
);

CREATE TABLE "Viaggio" 
(
  "Id" INTEGER PRIMARY KEY AUTOINCREMENT, 
  "FornitoreId" INTEGER NOT NULL, 
  "Data" VARCHAR(8000) NOT NULL, 
  "TargaAutomezzo" VARCHAR(30) NULL, 
  "Conducente" VARCHAR(60) NULL,
  
  CONSTRAINT "FK_Viaggio_Cliente_ClienteId" FOREIGN KEY ("FornitoreId") REFERENCES "Fornitore" ("Id") 
);

CREATE TABLE "RigaViaggio" 
(
  "Id" INTEGER PRIMARY KEY AUTOINCREMENT, 
  "ViaggioId" INTEGER NOT NULL, 
  "ProdottoId" INTEGER NOT NULL, 
  "Pesata" DECIMAL NOT NULL, 
  "CaloPesoPercentuale" INTEGER NOT NULL, 
  "Costo" DECIMAL NOT NULL, 

  CONSTRAINT "FK_RigaViaggio_Viaggio_ViaggioId" FOREIGN KEY ("ViaggioId") REFERENCES "Viaggio" ("Id"), 
  CONSTRAINT "FK_RigaViaggio_Prodotto_ProdottoId" FOREIGN KEY ("ProdottoId") REFERENCES "Prodotto" ("Id") 
);

CREATE UNIQUE INDEX uidx_fornitore_ragionesociale ON "Fornitore" ("RagioneSociale" ASC);
CREATE UNIQUE INDEX uidx_prodotto_descrizione ON "Prodotto" ("Descrizione" ASC);
