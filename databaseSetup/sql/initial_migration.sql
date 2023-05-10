CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
    "MigrationId" character varying(150) NOT NULL,
    "ProductVersion" character varying(32) NOT NULL,
    CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY ("MigrationId")
);

START TRANSACTION;

CREATE TABLE "Muestradante" (
    "Id" uuid NOT NULL,
    "DocumentoIdentidad" text NOT NULL,
    "Nombre" text NOT NULL,
    "PrimerApellido" text NOT NULL,
    "SegundoApellido" text NULL,
    "Parentesco" integer NOT NULL,
    "FechaNacimiento" date NOT NULL,
    "Departamento" text NOT NULL,
    "Municipio" text NOT NULL,
    "Direccion" text NULL,
    "Telefono" text NULL,
    "TipoDocumento" integer NOT NULL,
    CONSTRAINT "PK_Muestradante" PRIMARY KEY ("Id")
);

CREATE TABLE "Muestra" (
    "Id" uuid NOT NULL,
    "RadicadoInterno" text NULL,
    "TipoMuestra" integer NOT NULL,
    "Departamento" text NOT NULL,
    "Municipio" text NOT NULL,
    "EstadoMuestra" integer NOT NULL,
    "FechaTomaMuestra" date NOT NULL,
    "FechaLlegadaLaboratorio" date NOT NULL,
    "ConsentimientoPoblacional" boolean NOT NULL,
    "MuestradanteId" uuid NOT NULL,
    CONSTRAINT "PK_Muestra" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_Muestra_Muestradante_MuestradanteId" FOREIGN KEY ("MuestradanteId") REFERENCES "Muestradante" ("Id") ON DELETE CASCADE
);

CREATE UNIQUE INDEX "IX_Muestra_MuestradanteId" ON "Muestra" ("MuestradanteId");

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20230315160100_InitialMigration', '6.0.15');

COMMIT;

