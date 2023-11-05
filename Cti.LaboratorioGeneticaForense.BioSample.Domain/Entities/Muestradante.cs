using Cti.LaboratorioGeneticaForense.BioSample.Domain.Enums;
using Cti.LaboratorioGeneticaForense.BioSample.Domain.Primitives;
using Cti.LaboratorioGeneticaForense.BioSample.Domain.ValueObjects;

namespace Cti.LaboratorioGeneticaForense.BioSample.Domain.Entities;

public sealed class Muestradante : Entity
{
    private Muestradante(
        Guid id,
        string documentoIdentidad,
        string tipoDocumento,
        string nombre,
        string primerApellido,
        string? segundoApellido,
        string parentesco,
        DateTime fechaNacimiento,
        Region lugarNacimiento,
        string? direccion,
        string? telefono,
        string? genero)
        : base(id)
    {
        DocumentoIdentidad = documentoIdentidad;
        TipoDocumento = tipoDocumento;
        Nombre = nombre;
        PrimerApellido = primerApellido;
        SegundoApellido = segundoApellido;
        Parentesco = parentesco;
        FechaNacimiento = fechaNacimiento;
        LugarNacimiento = lugarNacimiento;
        Direccion = direccion;
        Telefono = telefono;
        Genero = genero;
    }

    private Muestradante()
    {
    }

    public string DocumentoIdentidad { get; private set; }
    public string Nombre { get; private set; }
    public string PrimerApellido { get; private set; }
    public string? SegundoApellido { get; private set; }
    public string Parentesco { get; private set; }
    public DateTime FechaNacimiento { get; private set; }
    public Region LugarNacimiento { get; private set; }
    public string? Direccion { get; private set; }
    public string? Telefono { get; private set; }
    public string TipoDocumento { get; private set; }
    public string? Genero { get; private set; }
    public Muestra muestra { get; set; }

    public static Muestradante Create(
        Guid id,
        string documentoIdentidad,
        string tipoDocumento,
        string nombre,
        string primerApellido,
        string? segundoApellido,
        string parentesco,
        DateTime fechaNacimiento,
        Region lugarNacimiento,
        string? direccion,
        string? telefono,
        string? genero)
    {
        var muestradante = new Muestradante(
            id,
            documentoIdentidad,
            tipoDocumento,
            nombre,
            primerApellido,
            segundoApellido,
            parentesco,
            fechaNacimiento,
            lugarNacimiento,
            direccion,
            telefono,
            genero);

        return muestradante;
    }
}

public class MuestradanteDto : Entity
{
    public string DocumentoIdentidad { get; set; }
    public string Nombre { get; set; }
    public string PrimerApellido { get; set; }
    public string? SegundoApellido { get; set; }
    public string Parentesco { get; set; }
    public DateTime FechaNacimiento { get; set; }
    public string Departamento { get; set; }
    public string Municipio { get; set; }
    public string? Direccion { get; set; }
    public string? Telefono { get; set; }
    public string TipoDocumento { get; set; }
    public string? Genero { get; set; }
}