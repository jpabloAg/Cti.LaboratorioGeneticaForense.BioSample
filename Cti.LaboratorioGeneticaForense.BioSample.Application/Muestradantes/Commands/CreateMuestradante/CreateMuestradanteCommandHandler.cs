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
        var existsMuestradanteByDocumentoIdentidad = await _muestradanteRepository.GetByDocumentoIdentidadAsync(request.documentoIdentidad);
        if (existsMuestradanteByDocumentoIdentidad is not null)
        {
            return Guid.Empty;
        }

        var lugarNacimiento = new Region(request.departamento.ToUpper(), request.municipio.ToUpper());

        var muestradante = Muestradante.Create(
            Guid.NewGuid(),
            request.documentoIdentidad,
            request.tipoDocumento.ToUpper(),
            request.nombre.ToUpper(),
            request.primerApellido.ToUpper(),
            request.segundoApellido?.ToUpper(),
            request.parentesco.ToUpper(),
            new DateTime(request.fechaNacimiento.Year, request.fechaNacimiento.Month, request.fechaNacimiento.Day),
            lugarNacimiento,
            request.direccion?.ToUpper(),
            request.telefono,
            request.genero);

        _muestradanteRepository.Add(muestradante);
        await _unitOfWork.SaveChangesAsync();

        return muestradante.Id;
    }
}
