using System;
using Newtonsoft.Json;

namespace SmarthThingsSDK.Net.Interfaces
{
    public class Room
    {




        public partial class RoomRequest : IEntity
        {
            /**
             * A name given for the room (eg. Living Room)
             */
            [JsonProperty("name")]
            public string Name { get; set; }
        }
        public partial class RoomModel : RoomRequest
        {
            /**
	 * The ID of the parent location.
	 */
            [JsonProperty("locationId")]
            public string LocationId { get; set; }

            /**
             * The ID of the room.
             */
            [JsonProperty("roomId")]
            public string RoomId { get; set; }
        }


    }
}

