using System;
namespace SmarthThingsSDK.Net.Interfaces
{
    public class App
    {







        public enum AppType
        {
            LAMBDA_SMART_APP = 0,
            WEBHOOK_SMART_APP = 1,
            API_ONLY = 2
        }
        public enum AppClassification
        {
            AUTOMATION = 0,
            SERVICE = 1,
            DEVICE = 2,
            CONNECTED_SERVICE = 3,
        }

        public enum AppTargetStatus
        {
            PENDING = 0,
            CONFIRMED = 1,
        }

        public enum SignatureType
        {
            APP_RSA = 0,
            ST_PADLOCK = 1,
        }
    }

}

