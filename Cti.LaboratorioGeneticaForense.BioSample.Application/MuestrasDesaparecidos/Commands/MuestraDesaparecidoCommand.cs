using Cti.LaboratorioGeneticaForense.BioSample.Domain.Entities;
using MediatR;

namespace Cti.LaboratorioGeneticaForense.BioSample.Application.MuestrasDesaparecidos.Commands;

public sealed record MuestraDesaparecidoCommand(Guid MuestraId, Guid DesaparecidoId) : IRequest<MuestraDesaparecido>;