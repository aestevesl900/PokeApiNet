using PokeApiNet;
using System;
using System.Threading.Tasks;

namespace ConsoleAppFrontEnd.Controller
{
    public class UserSelectionProcessor : IDisposable
    {
        public async Task<Pokemon[]> GetTopTenPockemonsAsync()
        {
            Pokemon[] ret = new Pokemon[10];

            for (int i = 0; i < ret.Length; i++)
            {
                ret[i] = await Client.GetResourceAsync<Pokemon>(i + 1);
            }

            return await Task.FromResult(ret);
        }

        public async Task<Pokemon> GetPockemonsByIdAsync(int id) => await Client.GetResourceAsync<Pokemon>(id);

        private PokeApiClient Client => client ??= new PokeApiClient();
        private PokeApiClient client;

        public void Dispose() => client?.Dispose();
    }
}