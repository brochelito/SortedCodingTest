using Rainfall.Application.Models;
using Rainfall.Application.Responses;

public interface IRainfallApiService
{
    Task<BaseResponse<RainfallReadingApiResponse>> GetRainfallData(string stationId, int count);
}
