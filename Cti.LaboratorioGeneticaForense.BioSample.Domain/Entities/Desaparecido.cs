using Cti.LaboratorioGeneticaForense.BioSample.Domain.Enums;
using Cti.LaboratorioGeneticaForense.BioSample.Domain.Primitives;
using Cti.LaboratorioGeneticaForense.BioSample.Domain.ValueObjects;

namespace Cti.LaboratorioGeneticaForense.BioSample.Domain.Entities;

public sealed class Desaparecido : Entity
{
    private Desaparecido(
        Guid id,
        string nombre, 
        string documentoIdentidad, 
        string tipoDocumento, 
        string primerApellido, 
        string? segundoApellido, 
        string genero, 
        string sirdec, 
        Region lugarNacimiento, 
        Region lugarTomaCuerpo) 
        : base(id)
    {
        Nombre = nombre;
        this.documentoIdentidad = documentoIdentidad;
        TipoDocumento = tipoDocumento;
        PrimerApellido = primerApellido;
        SegundoApellido = segundoApellido;
        Genero = genero;
        Sirdec = sirdec;
        LugarNacimiento = lugarNacimiento;
        LugarTomaCuerpo = lugarTomaCuerpo;
    }

    private Desaparecido()
    {
    }

    public string Nombre { get; private set; }
    public string documentoIdentidad { get; private set; }
    public string TipoDocumento { get; private set; }
    public string PrimerApellido { get; private set; }
    public string? SegundoApellido { get; private set; }
    public string Genero { get; private set; }
    public string Sirdec { get; private set; }
    public Region LugarNacimiento { get; private set; }
    public Region LugarTomaCuerpo { get; private set; }
    public ICollection<MuestraDesaparecido> MuestrasDesaparecidos { get; set; }

    public static Desaparecido Create(
        Guid id,
        string nombre,
        string documentoIdentidad,
        string tipoDocumento,
        string primerApellido,
        string? segundoApellido,
        string genero,
        string sirdec,
        Region lugarNacimiento,
        Region lugarTomaCuerpo) 
    {
        var desaparecido = new Desaparecido(
            id,
            nombre,
            documentoIdentidad,
            tipoDocumento,
            primerApellido,
            segundoApellido,
            genero,
            sirdec,
            lugarNacimiento,
            lugarTomaCuerpo);

        return desaparecido;
    }
}

public class DesaparecidoDto : Entity
{
    public string Nombre { get; set; }
    public string documentoIdentidad { get; set; }
    public string TipoDocumento { get; set; }
    public string PrimerApellido { get; set; }
    public string? SegundoApellido { get; set; }
    public string Genero { get; set; }
    public string Sirdec { get; set; }
    public string LugarNacimientoMunicipio { get; set; }
    public string LugarNacimientoDepartamento { get; set; }
    public string LugarTomaCuerpoMunicipio { get; set; }
    public string LugarTomaCuerpoDepartamento { get; set; }
}