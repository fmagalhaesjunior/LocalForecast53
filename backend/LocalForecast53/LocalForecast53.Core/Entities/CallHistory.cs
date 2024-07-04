namespace LocalForecast53.Core.Entities
{
    public class CallHistory : BaseEntity
    {
        public decimal Latitude { get; private set; }
        public decimal Longitude { get; private set; }
        public DateTime CallTime { get; private set; }
        public string ResponseBody { get; private set; }  // Store as JSON string

        public CallHistory() {}

        public CallHistory(decimal latitude, decimal longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
            this.CallTime = DateTime.UtcNow;
        }

        public void SetResponseBody(string responseBody)
        {
            ResponseBody = responseBody;
        }
    }
}
