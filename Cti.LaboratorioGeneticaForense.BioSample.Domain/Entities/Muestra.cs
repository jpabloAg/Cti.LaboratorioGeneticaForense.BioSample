using Cti.LaboratorioGeneticaForense.BioSample.Domain.Enums;
using Cti.LaboratorioGeneticaForense.BioSample.Domain.Primitives;
using Cti.LaboratorioGeneticaForense.BioSample.Domain.ValueObjects;

namespace Cti.LaboratorioGeneticaForense.BioSample.Domain.Entities;

public sealed class Muestra : Entity
{
    private Muestra(
        Guid id,
        string? radicadoInterno,
        TipoMuestra tipoMuestra,
        Region lugarTomaMuestra,
        EstadoMuestra estadoMuestra,
        DateOnly fechaTomaMuestra,
        DateOnly fechaLlegadaLaboratorio,
        bool consentimientoPoblacional,
        Muestradante muestradante)
        : base(id)
    {
        RadicadoInterno = radicadoInterno;
        TipoMuestra = tipoMuestra;
        LugarTomaMuestra = lugarTomaMuestra;
        EstadoMuestra = estadoMuestra;
        FechaTomaMuestra = fechaTomaMuestra;
        FechaLlegadaLaboratorio = fechaLlegadaLaboratorio;
        ConsentimientoPoblacional = consentimientoPoblacional;
        MuestradanteId = muestradante.Id;
    }

    private Muestra()
    {
    }

    public string? RadicadoInterno { get; private set; }
    public TipoMuestra TipoMuestra { get; private set; }
    public Region LugarTomaMuestra { get; private set; }
    public EstadoMuestra EstadoMuestra { get; private set; }
    public DateOnly FechaTomaMuestra { get; private set; }
    public DateOnly FechaLlegadaLaboratorio { get; private set; }
    public bool ConsentimientoPoblacional { get; private set; }
    public Guid MuestradanteId { get; private set; }
    public ICollection<MuestraDesaparecido> MuestrasDesaparecidos { get; set; }
    public Anexo Anexo { get; set; }

    public static Muestra Create(
        Guid id,
        string? radicadoInterno,
        TipoMuestra tipoMuestra,
        Region lugarTomaMuestra,
        EstadoMuestra estadoMuestra,
        DateOnly fechaTomaMuestra,
        DateOnly fechaLlegadaLaboratorio,
        bool consentimientoPoblacional,
        Muestradante muestradante)
    {
        var muestra = new Muestra(
            id,
            radicadoInterno,
            tipoMuestra,
            lugarTomaMuestra,
            estadoMuestra,
            fechaTomaMuestra,
            fechaLlegadaLaboratorio,
            consentimientoPoblacional,
            muestradante);

        return muestra;
    }
}