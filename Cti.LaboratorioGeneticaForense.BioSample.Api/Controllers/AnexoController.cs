using Amazon.S3;
using Amazon.S3.Model;
using Cti.LaboratorioGeneticaForense.BioSample.Domain.Abstractions.Repositories;
using Cti.LaboratorioGeneticaForense.BioSample.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cti.LaboratorioGeneticaForense.BioSample.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnexoController : ControllerBase
    {
        private readonly IAnexoRepository _anexoRepository;
        private readonly IUnitOfWork _unitOfWork;

        public AnexoController(IAnexoRepository anexoRepository, IUnitOfWork unitOfWork = null)
        {
            _anexoRepository = anexoRepository;
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        public async Task<Guid> RegisterAnexo([FromBody] Anexo request)
        {
            _anexoRepository.Add(request);
            await _unitOfWork.SaveChangesAsync();

            return request.Id;
        }

        [HttpPost("documentacion")]
        public async Task<Anexo> RegisterDocumentation([FromQuery] Guid anexoId, IFormFile formFile)
        {
            // Crear Bucket
            var keyObject = $"{DateTime.Now:yyyMMddhhmmss}-{formFile.FileName}";
            var client = new AmazonS3Client();
            var objectRequest = new PutObjectRequest()
            {
                BucketName = "muestrasanexo",
                Key = keyObject,
                ContentType = formFile.ContentType,
                InputStream = formFile.OpenReadStream()
            };
            await client.PutObjectAsync(objectRequest);

            var anexo = await _anexoRepository.GetById(anexoId);
            anexo.UriDocumentacion = $"https://muestras.s3.us-east-1.amazonaws.com/{keyObject}";
            await _unitOfWork.SaveChangesAsync();

            return anexo;
        }
    }
}
