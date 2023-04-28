using Cti.LaboratorioGeneticaForense.BioSample.Domain.Entities;
using MediatR;

namespace Cti.LaboratorioGeneticaForense.BioSample.Application.Muestradantes.Queries.GetMuestradantesBySimilarityName;

public sealed record GetMuestradanteBySimilarityNameQuery(string nombre, string primerApellido, string segundoApellido) 
    : IRequest<IEnumerable<MuestradanteDto>>;