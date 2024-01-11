using Refit;

namespace RefitGrupoDeEstudos.Interfaces.External
{
    public interface IAdviceApi
    {
        [Get("")]
        public Task<dynamic> Get();

        [Get("/{slipId}")]
        public Task<dynamic> Get(string slipId);
    }
}
