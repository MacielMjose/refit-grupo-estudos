using RefitGrupoDeEstudos.Interfaces.External;

namespace RefitGrupoDeEstudos.Services
{
    public class AdviceServiceApi : IAdviceServiceApi
    {
        private readonly HttpClient _httpClient;
        
        public AdviceServiceApi(HttpClient httpClient)
        {
            _httpClient = httpClient;        
        }

        public async Task<dynamic> GetAsync(string slipId)
        {
            if(string.IsNullOrEmpty(slipId))
                throw new ArgumentNullException(nameof(slipId));
            
            var advice = await _httpClient.GetAsync($"advice/{slipId}");

            return advice.Content.ReadFromJsonAsync<dynamic>().Result;
        }

        public async Task<dynamic> GetAsync()
        {
            var advice = await _httpClient.GetAsync("");
            
            return advice.Content.ReadFromJsonAsync<dynamic>().Result;
        }
    }
}
