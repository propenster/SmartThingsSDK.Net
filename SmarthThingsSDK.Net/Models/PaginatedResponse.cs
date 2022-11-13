using System;
using SmarthThingsSDK.Net.Interfaces;

namespace SmarthThingsSDK.Net.Models
{
    public class PaginatedResponse<T> : IEntity
    {
        public T items { get; set; }
        public Links links { get; set; }
    }

    
    public class Links
    {
        public Next next { get; set; }
        public Previous previous { get; set; }
    }

    public class Next
    {
        public string href { get; set; }
    }

    public class Previous
    {
        public string href { get; set; }
    }

    public class Root
    {
        public Links _links { get; set; }
    }

}

