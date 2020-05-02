using System;

namespace ApiAcceptanceTests
{
    public class AppSettings
    {
        public string ApiUrl { get; set; }
        public Guid XCorrelationId { get; set; }
    }
}