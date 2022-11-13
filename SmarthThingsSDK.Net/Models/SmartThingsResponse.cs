using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using SmarthThingsSDK.Net.Interfaces;
using static SmarthThingsSDK.Net.Models.Error;

namespace SmarthThingsSDK.Net.Models
{
    public class SmartThingsResponse <T>
    {
        //[DataMember]
        public ErrorResponse Error { get; set; }

        //[DataMember]
        public T ResultObject { get; set; }

        //[DataMember]
        public bool Success { get; private set; }

        public SmartThingsResponse(ErrorResponse error)
        {
            Error = error;
            Success = false;
        }

        public SmartThingsResponse(T resultObject)
        {
            ResultObject = resultObject;
            Success = true;
        }

        public SmartThingsResponse()
        {

        }
    }

    public class EmptyResponse : IEntity
    {
        public string SuccessValue { get; set; } = "success";
    }
}

