﻿using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;


namespace LocalForecast53.Core.Entities
{
    [Table("call_history")]
    public class CallHistory : BaseEntity
    {
        public double Latitude { get; private set; }
        public double Longitude { get; private set; }
        public DateTime CallTime { get; private set; }

        [Column(TypeName = "jsonb")]
        public object ResponseBody { get; private set; }

        public CallHistory() {}

        public CallHistory(double latitude, double longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
            this.CallTime = DateTime.UtcNow;
        }

        public void SetResponseBody(object responseBody)
        {
            ResponseBody = JsonConvert.SerializeObject(responseBody);
        }
    }
}
