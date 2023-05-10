using Cti.LaboratorioGeneticaForense.BioSample.Domain.Entities;
using Dapper;
using MediatR;
using Npgsql;

namespace Cti.LaboratorioGeneticaForense.BioSample.Application.Muestradantes.Queries.GetMuestradantesBySimilarityName;

internal sealed class GetMuestradanteBySimilarityNameQueryHandler : IRequestHandler<GetMuestradanteBySimilarityNameQuery, IEnumerable<MuestradanteDto>>
{
    private NpgsqlConnection connection;
    public GetMuestradanteBySimilarityNameQueryHandler()
    {
        connection = new NpgsqlConnection("Server=biosample-db;Port=5432;Database=biosample;User Id=postgres;Password=postgres");
        connection.Open();
    }
    public async Task<IEnumerable<MuestradanteDto>> Handle(GetMuestradanteBySimilarityNameQuery request, CancellationToken cancellationToken)
    {
        var filter = $"{request.nombre} {request.primerApellido} {request.segundoApellido}";
        string commandText = $"SELECT * FROM \"Muestradante\" as m WHERE word_similarity('Andrea garcia', 'Andrea garcia') >= 0.15 ORDER BY similarity('Andrea garcia', 'Andrea garcia') DESC;";

        string commandText2 = $"SELECT * FROM \"Muestradante\" as m WHERE word_similarity(concat(\"Nombre\" , ' ', \"PrimerApellido\" , ' ', \"SegundoApellido\"), \'{filter}\') >= 0.15 ORDER BY similarity(concat(\"Nombre\" , ' ', \"PrimerApellido\" , ' ', \"SegundoApellido\"), \'{filter}\') DESC;";

        var result = await connection.QueryAsync<MuestradanteDto>(commandText2);

        return result;
    }
}