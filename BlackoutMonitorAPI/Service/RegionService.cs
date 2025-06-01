using BlackoutMonitorAPI.Data;
using BlackoutMonitorAPI.Dto;
using BlackoutMonitorAPI.Model;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace BlackoutMonitorAPI.Service
{
    public class RegionService : IRegionService
    {
        private readonly HttpClient _httpClient;
        private readonly ApplicationDbContext _context;

        public RegionService(ApplicationDbContext context, HttpClient httpClient)
        {
            _context = context;
            _httpClient = httpClient;
        }

        public async Task<Region> GetOrCreateRegionByCepAsync(string cep)
        {
            string normalizedCep = new string(cep.Where(char.IsDigit).ToArray());

            var existing = await _context.Regions
                .FirstOrDefaultAsync(r => r.Cep == normalizedCep);

            if (existing != null)
            {
                return existing;
            }

            var response = await _httpClient.GetAsync($"https://viacep.com.br/ws/{normalizedCep}/json/");
            var content = await response.Content.ReadAsStringAsync();
            Console.WriteLine("Resposta ViaCEP: " + content);
            if (!response.IsSuccessStatusCode)
                throw new Exception("Erro ao consultar ViaCEP");

            var viaCep = await response.Content.ReadFromJsonAsync<ViaCepResponse>();

            if (viaCep == null || string.IsNullOrEmpty(viaCep.Cep))
                throw new Exception("CEP inválido ou não encontrado");

            var region = new Region
            {
                Cep = normalizedCep,
                Street = viaCep.Logradouro,
                Neighborhood = viaCep.Bairro,
                City = viaCep.Localidade,
                State = viaCep.Uf
            };

            _context.Regions.Add(region);
            await _context.SaveChangesAsync();

            return region;
        }
    }
}
