CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
    "MigrationId" character varying(150) NOT NULL,
    "ProductVersion" character varying(32) NOT NULL,
    CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY ("MigrationId")
);

START TRANSACTION;


DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20230315160100_InitialMigration') THEN
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
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20230315160100_InitialMigration') THEN
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
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20230315160100_InitialMigration') THEN
    CREATE UNIQUE INDEX "IX_Muestra_MuestradanteId" ON "Muestra" ("MuestradanteId");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20230315160100_InitialMigration') THEN
    INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
    VALUES ('20230315160100_InitialMigration', '6.0.15');
    END IF;
END $EF$;
COMMIT;

START TRANSACTION;


DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20230322150645_ManyToMany_MuestraDesaparecido_Migration') THEN
    CREATE TABLE "Desaparecido" (
        "Id" uuid NOT NULL,
        "Nombre" text NOT NULL,
        "documentoIdentidad" text NOT NULL,
        "TipoDocumento" integer NOT NULL,
        "PrimerApellido" text NOT NULL,
        "SegundoApellido" text NULL,
        "Genero" integer NOT NULL,
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
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20230322150645_ManyToMany_MuestraDesaparecido_Migration') THEN
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
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20230322150645_ManyToMany_MuestraDesaparecido_Migration') THEN
    CREATE INDEX "IX_MuestraDesaparecido_DesaparecidoId" ON "MuestraDesaparecido" ("DesaparecidoId");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20230322150645_ManyToMany_MuestraDesaparecido_Migration') THEN
    INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
    VALUES ('20230322150645_ManyToMany_MuestraDesaparecido_Migration', '6.0.15');
    END IF;
END $EF$;
COMMIT;
