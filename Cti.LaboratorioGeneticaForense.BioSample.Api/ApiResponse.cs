namespace Cti.LaboratorioGeneticaForense.BioSample.Api
{
    public class ApiResponse<T>
    {
        public int StatusCode { get; set; }
        public T Data { get; set; }
        public string ErrorMessage { get; set; }
    }
}
