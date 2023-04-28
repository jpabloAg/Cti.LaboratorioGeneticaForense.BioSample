using Cti.LaboratorioGeneticaForense.BioSample.Domain.Entities;
using MediatR;

namespace Cti.LaboratorioGeneticaForense.BioSample.Application.Desaparecidos.Queries;

public sealed record GetDesaparecidoBySimilarityNameQuery(string nombre, string primerApellido, string segundoApellido)
        : IRequest<IEnumerable<DesaparecidoDto>>;
