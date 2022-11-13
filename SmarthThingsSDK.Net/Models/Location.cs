using System;
using System.Collections.Generic;
using System.ComponentModel;
using Newtonsoft.Json;

namespace SmarthThingsSDK.Net.Interfaces
{
    public class Location
    {

        public partial class LocationModel : LocationCreate, IEntity
        {
            /**
	 * The ID of the location.
	 * @format uuid
	 */
            [JsonProperty("locationId")]
            public string LocationId { get; set; }

            /**
             * An ID matching the Java Time Zone ID of the location. Automatically generated if latitude and longitude have been
             * provided.
             */
            [JsonProperty("timeZoneId")]
            public string TimeZoneId { get; set; }

            /**
             * Not currently in use.
             * @example null
             */
            [JsonProperty("backgroundImage")]
            public string? BackgroundImage { get; set; }

            /**
             * List of client-facing action identifiers that are currently permitted for the user.
             * If the value of this property is not null, then any action not included in the list
             * value of the property is currently prohibited for the user.
             */
            [JsonProperty("allowed")]
            public string[]? Allowed { get; set; }
            [JsonProperty("parent")]
            public LocationParent? Parent { get; set; }

            /**
             * The timestamp of when a location was created in UTC.
             * @format date-time
             */
            [JsonProperty("created")]
            public string? Created { get; set; }

            /**
             * The timestamp of when a location was last updated in UTC.
             * @format date-time
             */
            [JsonProperty("lastModified")]
            public string? LastModified { get; set; }
        }


        public partial class LocationGetOptions
        {
            /**
	 * If set to true, the items in the response may contain the allowed list property.
	 */
            [JsonProperty("allowed")]
            public bool Allowed { get; set; }
        }

        /**
 * A slimmed down representation of the Location model.
 */
        public partial class LocationItem : IEntity
        {
            /**
             * The ID of the location.
             * @format uuid
             */
            [JsonProperty("locationId")]
            public string? LocationId { get; set; }
            [JsonProperty("name")]
            public string? Name { get; set; }

            /**
             * List of client-facing action identifiers that are currently permitted for the user.
             * If the value of this property is not null, then any action not included in the list
             * value of the property is currently prohibited for the user.
             */
            //export type LocationClientAction = 'w:locations' | 'd:locations' | 'w:devices' | 'w:locations:geo' | 'w:rooms'
            [JsonProperty("allowed")]
            public string[]? Allowed { get; set; }
            [JsonProperty("parent")]
            public LocationParent? Parent { get; set; }
        }

        public partial class LocationCreate : LocationUpdate
        {
            /**
             * An ISO Alpha-3 country code (e.g. GBR, USA)
             * @pattern ^[A-Z]{3}$
             */
            [JsonProperty("countryCode")]
            //[RegularExpression(@"^[A-Z]{3}")]
            public string? CountryCode { get; set; } //USA

        }

        //public partial class LocationClientAction
        //{

        //}
        public enum LocationParentType
        {
            //'LOCATIONGROUP' | 'ACCOUNT'
            LOCATIONGROUP = 0,
            ACCOUNT = 1
        }
        public partial class LocationParent
        {
            [JsonProperty("type")]
            public LocationParentType? Type { get; set; }

            /**
             * The ID of the parent
             * @format ^[0-9a-fA-F]{8}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{12}$
             */
            [JsonProperty("id")]
            public string? Id { get; set; }
        }

        public partial class LocationUpdate
        {
            [JsonProperty("name")]
            public string Name { get; set; }

            /**
             * A geographical latitude.
             * @min -90
             * @max 90
             */
            [JsonProperty("latitude")]
            public double? Latitude { get; set; }

            /**
             * A geographical longitude.
             * @min -180
             * @max 180
             */
            [JsonProperty("longitude")]
            public double? Longitude { get; set; }

            /**
             * The radius in meters (integer) around latitude and longitude which defines this location.
             * @min 20
             * @max 500000
             */
            //[Minimum(20, 500000)]
            [JsonProperty("regionRadius")]
            public int? RegionRadius { get; set; }

            /** The desired temperature scale used for the Location. Values include F and C. */
            [JsonProperty("temperatureScale")]
            public char? TemperatureScale { get; set; } = 'F'; //'F' | 'C'

            /**
             * We expect a POSIX locale but we also accept an IETF BCP 47 language tag.
             * @example en_US
             */
            [JsonProperty("locale")]
            public string? Locale { get; set; } = "en_US";

            /** Additional information about the Location that allows SmartThings to further define your Location. */
            [JsonProperty("additionalProperties")]
            public Dictionary<string, object>? AdditionalProperties { get; set; } = new Dictionary<string, object>();


        }


    }
}

