using Cti.LaboratorioGeneticaForense.BioSample.Domain.Entities;
using Dapper;
using MediatR;
using Npgsql;

namespace Cti.LaboratorioGeneticaForense.BioSample.Application.Desaparecidos.Queries;

public sealed class GetDesaparecidoBySimilarityNameQueryHandler :
    IRequestHandler<GetDesaparecidoBySimilarityNameQuery, IEnumerable<DesaparecidoDto>>
{
    private NpgsqlConnection connection;
    public GetDesaparecidoBySimilarityNameQueryHandler()
    {
        connection = new NpgsqlConnection("Server=biosample-db;Port=5432;Database=biosample;User Id=postgres;Password=postgres");
        connection.Open();
    }
    public async Task<IEnumerable<DesaparecidoDto>> Handle(GetDesaparecidoBySimilarityNameQuery request, CancellationToken cancellationToken)
    {
        var filter = $"{request.nombre} {request.primerApellido} {request.segundoApellido}";
        string commandText2 = $"SELECT * FROM \"Desaparecido\" as m WHERE word_similarity(concat(\"Nombre\" , ' ', \"PrimerApellido\" , ' ', \"SegundoApellido\"), \'{filter}\') >= 0.15 ORDER BY similarity(concat(\"Nombre\" , ' ', \"PrimerApellido\" , ' ', \"SegundoApellido\"), \'{filter}\') DESC;";

        var result = await connection.QueryAsync<DesaparecidoDto>(commandText2);

        return result;
    }
}
