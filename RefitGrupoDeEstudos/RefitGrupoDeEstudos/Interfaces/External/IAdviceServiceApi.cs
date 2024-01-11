namespace RefitGrupoDeEstudos.Interfaces.External
{
    public interface IAdviceServiceApi
    {
        public Task<dynamic> GetAsync();

        public Task<dynamic> GetAsync(string slipId);
    }
}