CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
    "MigrationId" character varying(150) NOT NULL,
    "ProductVersion" character varying(32) NOT NULL,
    CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY ("MigrationId")
);

START TRANSACTION;


DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20231105022227_PrimeraMigracion') THEN
    CREATE TABLE "Desaparecido" (
        "Id" uuid NOT NULL,
        "Nombre" text NOT NULL,
        "documentoIdentidad" text NOT NULL,
        "TipoDocumento" text NOT NULL,
        "PrimerApellido" text NOT NULL,
        "SegundoApellido" text NULL,
        "Genero" text NOT NULL,
        "Sirdec" text NOT NULL,
        "LugarNacimientoDepartamento" text NOT NULL,
        "LugarNacimientoMunicipio" text NOT NULL,
        "LugarTomaCuerpoDepartamento" text NOT NULL,
        "LugarTomaCuerpoMunicipio" text NOT NULL,
        CONSTRAINT "PK_Desaparecido" PRIMARY KEY ("Id")
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20231105022227_PrimeraMigracion') THEN
    CREATE TABLE "Muestradante" (
        "Id" uuid NOT NULL,
        "DocumentoIdentidad" text NOT NULL,
        "Nombre" text NOT NULL,
        "PrimerApellido" text NOT NULL,
        "SegundoApellido" text NULL,
        "Parentesco" text NOT NULL,
        "FechaNacimiento" timestamp with time zone NOT NULL,
        "Departamento" text NOT NULL,
        "Municipio" text NOT NULL,
        "Direccion" text NULL,
        "Telefono" text NULL,
        "TipoDocumento" text NOT NULL,
        "Genero" text NULL,
        CONSTRAINT "PK_Muestradante" PRIMARY KEY ("Id")
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20231105022227_PrimeraMigracion') THEN
    CREATE TABLE "Usuario" (
        "Id" uuid NOT NULL,
        "Username" text NOT NULL,
        "Password" text NOT NULL,
        "EmailAddress" text NOT NULL,
        "Role" text NOT NULL,
        "Surname" text NOT NULL,
        "GivenName" text NOT NULL,
        CONSTRAINT "PK_Usuario" PRIMARY KEY ("Id")
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20231105022227_PrimeraMigracion') THEN
    CREATE TABLE "Muestra" (
        "Id" uuid NOT NULL,
        "RadicadoInterno" text NULL,
        "TipoMuestra" text NOT NULL,
        "Departamento" text NOT NULL,
        "Municipio" text NOT NULL,
        "EstadoMuestra" text NOT NULL,
        "FechaTomaMuestra" date NOT NULL,
        "FechaLlegadaLaboratorio" date NOT NULL,
        "ConsentimientoPoblacional" boolean NOT NULL,
        "MuestradanteId" uuid NOT NULL,
        CONSTRAINT "PK_Muestra" PRIMARY KEY ("Id"),
        CONSTRAINT "FK_Muestra_Muestradante_MuestradanteId" FOREIGN KEY ("MuestradanteId") REFERENCES "Muestradante" ("Id") ON DELETE CASCADE
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20231105022227_PrimeraMigracion') THEN
    CREATE TABLE "Anexo" (
        "Id" uuid NOT NULL,
        "OT" text NULL,
        "Perito" text NULL,
        "Observaciones" text NULL,
        "UriDocumentacion" text NULL,
        "MuestraId" uuid NOT NULL,
        CONSTRAINT "PK_Anexo" PRIMARY KEY ("Id"),
        CONSTRAINT "FK_Anexo_Muestra_MuestraId" FOREIGN KEY ("MuestraId") REFERENCES "Muestra" ("Id") ON DELETE CASCADE
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20231105022227_PrimeraMigracion') THEN
    CREATE TABLE "MuestraDesaparecido" (
        "MuestraId" uuid NOT NULL,
        "DesaparecidoId" uuid NOT NULL,
        CONSTRAINT "PK_MuestraDesaparecido" PRIMARY KEY ("MuestraId", "DesaparecidoId"),
        CONSTRAINT "FK_MuestraDesaparecido_Desaparecido_DesaparecidoId" FOREIGN KEY ("DesaparecidoId") REFERENCES "Desaparecido" ("Id") ON DELETE CASCADE,
        CONSTRAINT "FK_MuestraDesaparecido_Muestra_MuestraId" FOREIGN KEY ("MuestraId") REFERENCES "Muestra" ("Id") ON DELETE CASCADE
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20231105022227_PrimeraMigracion') THEN
    CREATE UNIQUE INDEX "IX_Anexo_MuestraId" ON "Anexo" ("MuestraId");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20231105022227_PrimeraMigracion') THEN
    CREATE UNIQUE INDEX "IX_Muestra_MuestradanteId" ON "Muestra" ("MuestradanteId");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20231105022227_PrimeraMigracion') THEN
    CREATE INDEX "IX_MuestraDesaparecido_DesaparecidoId" ON "MuestraDesaparecido" ("DesaparecidoId");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20231105022227_PrimeraMigracion') THEN
    INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
    VALUES ('20231105022227_PrimeraMigracion', '6.0.15');
    END IF;
END $EF$;
COMMIT;

