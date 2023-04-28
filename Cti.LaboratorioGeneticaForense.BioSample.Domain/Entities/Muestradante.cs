using Cti.LaboratorioGeneticaForense.BioSample.Domain.Enums;
using Cti.LaboratorioGeneticaForense.BioSample.Domain.Primitives;
using Cti.LaboratorioGeneticaForense.BioSample.Domain.ValueObjects;

namespace Cti.LaboratorioGeneticaForense.BioSample.Domain.Entities;

public sealed class Muestradante : Entity
{
    private Muestradante(
        Guid id,
        string documentoIdentidad,
        TipoDocumento tipoDocumento,
        string nombre,
        string primerApellido,
        string? segundoApellido,
        Parentesco parentesco,
        DateOnly fechaNacimiento,
        Region lugarNacimiento,
        string? direccion,
        string? telefono)
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
    }

    private Muestradante()
    {
    }

    public string DocumentoIdentidad { get; private set; }
    public string Nombre { get; private set; }
    public string PrimerApellido { get; private set; }
    public string? SegundoApellido { get; private set; }
    public Parentesco Parentesco { get; private set; }
    public DateOnly FechaNacimiento { get; private set; }
    public Region LugarNacimiento { get; private set; }
    public string? Direccion { get; private set; }
    public string? Telefono { get; private set; }
    public TipoDocumento TipoDocumento { get; private set; }
    public Muestra muestra { get; set; }

    public static Muestradante Create(
        Guid id,
        string documentoIdentidad,
        TipoDocumento tipoDocumento,
        string nombre,
        string primerApellido,
        string? segundoApellido,
        Parentesco parentesco,
        DateOnly fechaNacimiento,
        Region lugarNacimiento,
        string? direccion,
        string? telefono)
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
            telefono);

        return muestradante;
    }
}

public class MuestradanteDto : Entity
{
    public string DocumentoIdentidad { get; private set; }
    public string Nombre { get; private set; }
    public string PrimerApellido { get; private set; }
    public string? SegundoApellido { get; private set; }
    public Parentesco Parentesco { get; private set; }
    public DateTime FechaNacimiento { get; private set; }
    public Region LugarNacimiento { get; private set; }
    public string? Direccion { get; private set; }
    public string? Telefono { get; private set; }
    public TipoDocumento TipoDocumento { get; private set; }
}