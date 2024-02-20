using Rainfall.Application.Models;
using Rainfall.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Rainfall.Application.Services
{
    public class RainfallApiService : IRainfallApiService
    {
        private readonly HttpClient _httpClient;

        public RainfallApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<BaseResponse<RainfallReadingApiResponse>> GetRainfallData(string stationId, int count)
        {
            var response = new BaseResponse<RainfallReadingApiResponse>();

            try
            {
                var apiUrl = $"https://environment.data.gov.uk/flood-monitoring/id/stations/{stationId}/readings?_sorted&_limit={count}";

                HttpResponseMessage httpResponse = await _httpClient.GetAsync(apiUrl);

                if (httpResponse.IsSuccessStatusCode)
                {
                    string json = await httpResponse.Content.ReadAsStringAsync();
                    response.Success = true;
                    response.Data = JsonSerializer.Deserialize<RainfallReadingApiResponse>(json);
                }
                else
                {
                    response.Success = false;
                    response.ErrorMessage = $"Error: {httpResponse.StatusCode} - {httpResponse.ReasonPhrase}";
                }
            }
            catch (Exception ex)
            {             
                Console.WriteLine($"Exception: {ex.Message}");
                response.Success = false;
                response.ErrorMessage = $"Exception: {ex.Message}";
            }

            return response;
        }
    }
}
