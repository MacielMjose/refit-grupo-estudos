using BenchmarkDotNet.Attributes;
using Refit;
using RefitGrupoDeEstudos.Controllers;
using RefitGrupoDeEstudos.Interfaces.External;
using RefitGrupoDeEstudos.Services;

namespace RefitBenchmark
{
    public class MyRefitBenchmark
    {
        private readonly IHttpClientFactory _httpClientFactoryService;
        private readonly IHttpClientFactory _httpClientFactoryRefit;
        private readonly AdviceControllerWithRefit _refitController;
        private readonly AdviceControllerWithoutRefit _serviceController;

        public MyRefitBenchmark()
        {
            // Inicializar REFIT
            var refitHttpClient = _httpClientFactoryRefit.CreateClient();
            refitHttpClient.BaseAddress =  new Uri("https://api.adviceslip.com/advice");
            var myApi = RestService.For<IAdviceApi>(refitHttpClient);
            _refitController = new AdviceControllerWithRefit(myApi);

            // Inicializar Service
            var serviceHttpClient = _httpClientFactoryService.CreateClient();
            serviceHttpClient.BaseAddress = new Uri("https://api.adviceslip.com/advice");
            var adviceService = new AdviceServiceApi(serviceHttpClient);
            _serviceController = new AdviceControllerWithoutRefit(adviceService);
        }

        [Benchmark]
        public async Task RefitBenchmarkAsync()
        {
            // Chame métodos que utilizam Refit aqui
            await _refitController.Get();
        }

        [Benchmark]
        public async Task ServiceBenchmarkAsync()
        {
            // Chame métodos que utilizam a service diretamente aqui
            await _serviceController.Get();
        }
    }
}
