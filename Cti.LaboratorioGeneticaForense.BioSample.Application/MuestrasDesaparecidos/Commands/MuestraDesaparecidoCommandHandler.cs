using Cti.LaboratorioGeneticaForense.BioSample.Domain.Abstractions.Repositories;
using Cti.LaboratorioGeneticaForense.BioSample.Domain.Entities;
using MediatR;

namespace Cti.LaboratorioGeneticaForense.BioSample.Application.MuestrasDesaparecidos.Commands;

public sealed class MuestraDesaparecidoCommandHandler : IRequestHandler<MuestraDesaparecidoCommand, MuestraDesaparecido>
{
    private readonly IMuestraDesaparecidoRepository _muestraDesaparecidoRepository;
    private readonly IUnitOfWork _unitOfWork;

    public MuestraDesaparecidoCommandHandler(IMuestraDesaparecidoRepository muestraDesaparecidoRepository, IUnitOfWork unitOfWork)
    {
        _muestraDesaparecidoRepository = muestraDesaparecidoRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<MuestraDesaparecido?> Handle(MuestraDesaparecidoCommand request, CancellationToken cancellationToken)
    {
        var vinculadoExists = await _muestraDesaparecidoRepository.ExistMuestraDesaparecido(request.MuestraId, request.DesaparecidoId);

        if (vinculadoExists)
        {
            return null;
        }

        var muestraVinculada = new MuestraDesaparecido()
        {
            MuestraId = request.MuestraId,
            DesaparecidoId = request.DesaparecidoId
        };

        _muestraDesaparecidoRepository.VincularMuestraDesaparecido(muestraVinculada);
        await _unitOfWork.SaveChangesAsync();
        return muestraVinculada;
    }
}
