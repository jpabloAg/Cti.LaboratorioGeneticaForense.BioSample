using Cti.LaboratorioGeneticaForense.BioSample.Domain.Abstractions.Repositories;
using Cti.LaboratorioGeneticaForense.BioSample.Domain.Entities;
using Cti.LaboratorioGeneticaForense.BioSample.Domain.ValueObjects;
using MediatR;

namespace Cti.LaboratorioGeneticaForense.BioSample.Application.Desaparecidos.Commands;

public sealed class CreateDesaparecidoCommandHandler : IRequestHandler<CreateDesaparecidoCommand, Guid>
{
    private readonly IDesaparecidoRepository _desaparecidoRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateDesaparecidoCommandHandler(IDesaparecidoRepository desaparecidoRepository, IUnitOfWork unitOfWork = null)
    {
        _desaparecidoRepository = desaparecidoRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Guid> Handle(CreateDesaparecidoCommand request, CancellationToken cancellationToken)
    {
        var lugarNacimiento = new Region(request.lugarNacimientoDepartamento.ToUpper(), request.lugarNacimientoMunicipio.ToUpper());
        var lugarTomaCuerpo = new Region(request.lugarTomaCuerpoDepartamento.ToUpper(), request.lugarTomaCuerpoMunicipio.ToUpper());

        var desaparecido = Desaparecido.Create(
            Guid.NewGuid(),
            request.nombre.ToUpper(),
            request.documentoIdentidad,
            request.tipoDocumento.ToUpper(),
            request.primerApellido.ToUpper(),
            request.segundoApellido.ToUpper(),
            request.genero.ToUpper(),
            request.sirdec,
            lugarNacimiento,
            lugarTomaCuerpo);

        _desaparecidoRepository.Add(desaparecido);
        await _unitOfWork.SaveChangesAsync();

        return desaparecido.Id;
    }
}