using Newtonsoft.Json;

namespace LocalForecast53.Shared.Helpers
{
    public class APIHelper : IDisposable
    {
        private readonly HttpClient _httpClient;
        private bool _disposed;

        public APIHelper()
        {
            _httpClient = new HttpClient();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _httpClient?.Dispose();
                }
                _disposed = true;
            }
        }

        public async Task<T> GetAsync<T>(string url)
        {
            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(content);
        }

        ~APIHelper() { Dispose(false); }
    }
}
