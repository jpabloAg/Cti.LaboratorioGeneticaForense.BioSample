using Cti.LaboratorioGeneticaForense.BioSample.Domain.Abstractions.Repositories;
using Cti.LaboratorioGeneticaForense.BioSample.Domain.ValueObjects;
using Cti.LaboratorioGeneticaForense.BioSample.Domain.Entities;
using MediatR;

namespace Cti.LaboratorioGeneticaForense.BioSample.Application.Muestradantes.Commands.CreateMuestradante;

internal sealed class CreateMuestradanteCommandHandler : IRequestHandler<CreateMuestradanteCommand, Guid>
{
    private readonly IMuestradanteRepository _muestradanteRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateMuestradanteCommandHandler(
        IMuestradanteRepository muestradanteRepository,
        IUnitOfWork unitOfWork)
    {
        _muestradanteRepository = muestradanteRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Guid> Handle(CreateMuestradanteCommand request, CancellationToken cancellationToken)
    {
        var lugarNacimiento = new Region(request.departamento, request.municipio);

        var muestradante = Muestradante.Create(
            Guid.NewGuid(),
            request.documentoIdentidad,
            request.tipoDocumento,
            request.nombre,
            request.primerApellido,
            request.segundoApellido,
            request.parentesco,
            new DateOnly(request.fechaNacimiento.Year, request.fechaNacimiento.Month, request.fechaNacimiento.Day),
            lugarNacimiento,
            request.direccion,
            request.telefono);

        _muestradanteRepository.Add(muestradante);
        await _unitOfWork.SaveChangesAsync();

        return muestradante.Id;
    }
}
