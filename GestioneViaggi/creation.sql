CREATE TABLE "Fornitore" 
(
  "Id" INTEGER PRIMARY KEY AUTOINCREMENT, 
  "RagioneSociale" VARCHAR(60) NOT NULL, 
  "Tariffa" DECIMAL NOT NULL 
);
CREATE TABLE "Prodotto" 
(
  "Id" INTEGER PRIMARY KEY AUTOINCREMENT, 
  "Descrizione" VARCHAR(60) NOT NULL 
);

CREATE TABLE "Viaggio" 
(
  "Id" INTEGER PRIMARY KEY AUTOINCREMENT, 
  "ClienteId" INTEGER NOT NULL, 
  "Data" VARCHAR(8000) NOT NULL, 
  "TargaAutomezzo" VARCHAR(30) NULL, 
  "Conducente" VARCHAR(60) NULL, 
  "ProdottoId" INTEGER NOT NULL, 
  "Pesata" DECIMAL NOT NULL, 
  "CaloPesoPercentuale" INTEGER NOT NULL, 

  CONSTRAINT "FK_Viaggio_Cliente_ClienteId" FOREIGN KEY ("ClienteId") REFERENCES "Cliente" ("Id"), 

  CONSTRAINT "FK_Viaggio_Prodotto_ProdottoId" FOREIGN KEY ("ProdottoId") REFERENCES "Prodotto" ("Id") 
);
CREATE UNIQUE INDEX uidx_cliente_ragionesociale ON "Cliente" ("RagioneSociale" ASC);
CREATE UNIQUE INDEX uidx_prodotto_descrizione ON "Prodotto" ("Descrizione" ASC);
