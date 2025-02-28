using System.Net.Http;
using System.Net.Http.Json;
using Lab8Bai3.Models; // Đảm bảo có dòng này

namespace Lab8Bai3.Services
{
    public class ReservationService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiBaseUrl = "http://localhost:5107/api/reservations";

        public ReservationService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Reservation>> GetAllAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<Reservation>>(_apiBaseUrl);
        }

        public async Task<Reservation> GetByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<Reservation>($"{_apiBaseUrl}/{id}");
        }

        public async Task CreateAsync(Reservation reservation)
        {
            await _httpClient.PostAsJsonAsync(_apiBaseUrl, reservation);
        }

        public async Task UpdateAsync(int id, Reservation reservation)
        {
            await _httpClient.PutAsJsonAsync($"{_apiBaseUrl}/{id}", reservation);
        }

        public async Task DeleteAsync(int id)
        {
            await _httpClient.DeleteAsync($"{_apiBaseUrl}/{id}");
        }
    }
}
