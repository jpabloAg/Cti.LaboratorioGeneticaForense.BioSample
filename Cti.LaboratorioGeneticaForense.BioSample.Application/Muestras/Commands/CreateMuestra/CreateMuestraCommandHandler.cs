using Cti.LaboratorioGeneticaForense.BioSample.Domain.Abstractions.Repositories;
using Cti.LaboratorioGeneticaForense.BioSample.Domain.Entities;
using Cti.LaboratorioGeneticaForense.BioSample.Domain.ValueObjects;
using MediatR;

namespace Cti.LaboratorioGeneticaForense.BioSample.Application.Muestras.Commands.CreateMuestra
{
    public sealed class CreateMuestraCommandHandler : IRequestHandler<CreateMuestraCommand, Guid>
    {
        private readonly IMuestraRepository _muestraRepository;
        private readonly IMuestradanteRepository _muestradanteRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateMuestraCommandHandler(
        IMuestraRepository muestraRepository,
        IUnitOfWork unitOfWork,
        IMuestradanteRepository muestradanteRepository)
        {
            _muestraRepository = muestraRepository;
            _muestradanteRepository = muestradanteRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(CreateMuestraCommand request, CancellationToken cancellationToken)
        {
            var muestradante = await _muestradanteRepository.GetByDocumentoIdentidadAsync(request.documentoIdentidadMuestradante);

            if(muestradante is null)
            {
                return Guid.Empty;
            }

            var existMuestra = await _muestraRepository.ExistsMuestra(muestradante.Id);

            if (existMuestra)
            {
                return Guid.Empty;
            }

            var lugarTomaMuestra = new Region(request.departamento, request.municipio);
            var muestra = Muestra.Create(
                Guid.NewGuid(),
                request.radicadoInterno,
                request.tipoMuestra,
                lugarTomaMuestra,
                request.estadoMuestra,
                new DateOnly(request.fechaTomaMuestra.Year, request.fechaTomaMuestra.Month, request.fechaTomaMuestra.Day),
                new DateOnly(request.fechaLlegadaLaboratorio.Year, request.fechaLlegadaLaboratorio.Month, request.fechaLlegadaLaboratorio.Day),
                request.consentimientoPoblacional,
                muestradante);

            _muestraRepository.Add(muestra);
            await _unitOfWork.SaveChangesAsync();

            return muestra.Id;
        }
    }
}
