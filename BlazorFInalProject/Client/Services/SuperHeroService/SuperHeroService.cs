using BlazorFInalProject.Shared;
using System.Net.Http.Json;

namespace BlazorFInalProject.Client.Services.SuperHeroService
{

    public class SuperHeroService : ISuperHeroService
    {
        private readonly HttpClient _http;

        public SuperHeroService(HttpClient http)
        {
            _http = http;
        }

        public List<SuperHero> Heroes { get; set; } = new List<SuperHero>();
        public List<Comic> Comics { get; set; } = new List<Comic> ();

        public Task GetComics()
        {
            throw new NotImplementedException();
        }

        public async Task<SuperHero> GetSingleHero(int id)
        {
            var result = await _http.GetFromJsonAsync<SuperHero>($"api/SuperHero/{id}");
            if (result != null)
                return result;
            throw new Exception("Hero Not Found!");
        }

        public async Task GetSuperHeroes()
        {
            var result = await _http.GetFromJsonAsync<List<SuperHero>>("api/SuperHero");
            if(result != null)
                Heroes = result;
        }
    }
}
