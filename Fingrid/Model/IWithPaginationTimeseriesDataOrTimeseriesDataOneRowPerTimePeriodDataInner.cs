/*
 * avoindata-api
 *
 * API for Fingrid Open Data
 *
 * The version of the OpenAPI document: 1.0
 * Generated by: https://github.com/openapitools/openapi-generator.git
 */


using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.IO;
using System.Runtime.Serialization;
using System.Text;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System.ComponentModel.DataAnnotations;
using OpenAPIDateConverter = Fingrid.Client.OpenAPIDateConverter;
using System.Reflection;

namespace Fingrid.Model
{
    /// <summary>
    /// IWithPaginationTimeseriesDataOrTimeseriesDataOneRowPerTimePeriodDataInner
    /// </summary>
    [JsonConverter(typeof(IWithPaginationTimeseriesDataOrTimeseriesDataOneRowPerTimePeriodDataInnerJsonConverter))]
    [DataContract(Name = "IWithPagination_TimeseriesData_or_TimeseriesDataOneRowPerTimePeriod__data_inner")]
    public partial class IWithPaginationTimeseriesDataOrTimeseriesDataOneRowPerTimePeriodDataInner : AbstractOpenAPISchema, IEquatable<IWithPaginationTimeseriesDataOrTimeseriesDataOneRowPerTimePeriodDataInner>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IWithPaginationTimeseriesDataOrTimeseriesDataOneRowPerTimePeriodDataInner" /> class
        /// with the <see cref="TimeseriesData" /> class
        /// </summary>
        /// <param name="actualInstance">An instance of TimeseriesData.</param>
        public IWithPaginationTimeseriesDataOrTimeseriesDataOneRowPerTimePeriodDataInner(TimeseriesData actualInstance)
        {
            this.IsNullable = false;
            this.SchemaType= "anyOf";
            this.ActualInstance = actualInstance ?? throw new ArgumentException("Invalid instance found. Must not be null.");
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IWithPaginationTimeseriesDataOrTimeseriesDataOneRowPerTimePeriodDataInner" /> class
        /// with the <see cref="TimeseriesDataOneRowPerTimePeriod" /> class
        /// </summary>
        /// <param name="actualInstance">An instance of TimeseriesDataOneRowPerTimePeriod.</param>
        public IWithPaginationTimeseriesDataOrTimeseriesDataOneRowPerTimePeriodDataInner(TimeseriesDataOneRowPerTimePeriod actualInstance)
        {
            this.IsNullable = false;
            this.SchemaType= "anyOf";
            this.ActualInstance = actualInstance ?? throw new ArgumentException("Invalid instance found. Must not be null.");
        }


        private Object _actualInstance;

        /// <summary>
        /// Gets or Sets ActualInstance
        /// </summary>
        public override Object ActualInstance
        {
            get
            {
                return _actualInstance;
            }
            set
            {
                if (value.GetType() == typeof(TimeseriesData))
                {
                    this._actualInstance = value;
                }
                else if (value.GetType() == typeof(TimeseriesDataOneRowPerTimePeriod))
                {
                    this._actualInstance = value;
                }
                else
                {
                    throw new ArgumentException("Invalid instance found. Must be the following types: TimeseriesData, TimeseriesDataOneRowPerTimePeriod");
                }
            }
        }

        /// <summary>
        /// Get the actual instance of `TimeseriesData`. If the actual instance is not `TimeseriesData`,
        /// the InvalidClassException will be thrown
        /// </summary>
        /// <returns>An instance of TimeseriesData</returns>
        public TimeseriesData GetTimeseriesData()
        {
            return (TimeseriesData)this.ActualInstance;
        }

        /// <summary>
        /// Get the actual instance of `TimeseriesDataOneRowPerTimePeriod`. If the actual instance is not `TimeseriesDataOneRowPerTimePeriod`,
        /// the InvalidClassException will be thrown
        /// </summary>
        /// <returns>An instance of TimeseriesDataOneRowPerTimePeriod</returns>
        public TimeseriesDataOneRowPerTimePeriod GetTimeseriesDataOneRowPerTimePeriod()
        {
            return (TimeseriesDataOneRowPerTimePeriod)this.ActualInstance;
        }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class IWithPaginationTimeseriesDataOrTimeseriesDataOneRowPerTimePeriodDataInner {\n");
            sb.Append("  ActualInstance: ").Append(this.ActualInstance).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public override string ToJson()
        {
            return JsonConvert.SerializeObject(this.ActualInstance, IWithPaginationTimeseriesDataOrTimeseriesDataOneRowPerTimePeriodDataInner.SerializerSettings);
        }

        /// <summary>
        /// Converts the JSON string into an instance of IWithPaginationTimeseriesDataOrTimeseriesDataOneRowPerTimePeriodDataInner
        /// </summary>
        /// <param name="jsonString">JSON string</param>
        /// <returns>An instance of IWithPaginationTimeseriesDataOrTimeseriesDataOneRowPerTimePeriodDataInner</returns>
        public static IWithPaginationTimeseriesDataOrTimeseriesDataOneRowPerTimePeriodDataInner FromJson(string jsonString)
        {
            IWithPaginationTimeseriesDataOrTimeseriesDataOneRowPerTimePeriodDataInner newIWithPaginationTimeseriesDataOrTimeseriesDataOneRowPerTimePeriodDataInner = null;

            if (string.IsNullOrEmpty(jsonString))
            {
                return newIWithPaginationTimeseriesDataOrTimeseriesDataOneRowPerTimePeriodDataInner;
            }

            try
            {
                newIWithPaginationTimeseriesDataOrTimeseriesDataOneRowPerTimePeriodDataInner = new IWithPaginationTimeseriesDataOrTimeseriesDataOneRowPerTimePeriodDataInner(JsonConvert.DeserializeObject<TimeseriesData>(jsonString, IWithPaginationTimeseriesDataOrTimeseriesDataOneRowPerTimePeriodDataInner.SerializerSettings));
                // deserialization is considered successful at this point if no exception has been thrown.
                return newIWithPaginationTimeseriesDataOrTimeseriesDataOneRowPerTimePeriodDataInner;
            }
            catch (Exception exception)
            {
                // deserialization failed, try the next one
                System.Diagnostics.Debug.WriteLine(string.Format("Failed to deserialize `{0}` into TimeseriesData: {1}", jsonString, exception.ToString()));
            }

            try
            {
                newIWithPaginationTimeseriesDataOrTimeseriesDataOneRowPerTimePeriodDataInner = new IWithPaginationTimeseriesDataOrTimeseriesDataOneRowPerTimePeriodDataInner(JsonConvert.DeserializeObject<TimeseriesDataOneRowPerTimePeriod>(jsonString, IWithPaginationTimeseriesDataOrTimeseriesDataOneRowPerTimePeriodDataInner.SerializerSettings));
                // deserialization is considered successful at this point if no exception has been thrown.
                return newIWithPaginationTimeseriesDataOrTimeseriesDataOneRowPerTimePeriodDataInner;
            }
            catch (Exception exception)
            {
                // deserialization failed, try the next one
                System.Diagnostics.Debug.WriteLine(string.Format("Failed to deserialize `{0}` into TimeseriesDataOneRowPerTimePeriod: {1}", jsonString, exception.ToString()));
            }

            // no match found, throw an exception
            throw new InvalidDataException("The JSON string `" + jsonString + "` cannot be deserialized into any schema defined.");
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            return this.Equals(input as IWithPaginationTimeseriesDataOrTimeseriesDataOneRowPerTimePeriodDataInner);
        }

        /// <summary>
        /// Returns true if IWithPaginationTimeseriesDataOrTimeseriesDataOneRowPerTimePeriodDataInner instances are equal
        /// </summary>
        /// <param name="input">Instance of IWithPaginationTimeseriesDataOrTimeseriesDataOneRowPerTimePeriodDataInner to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(IWithPaginationTimeseriesDataOrTimeseriesDataOneRowPerTimePeriodDataInner input)
        {
            if (input == null)
                return false;

            return this.ActualInstance.Equals(input.ActualInstance);
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                int hashCode = 41;
                if (this.ActualInstance != null)
                    hashCode = hashCode * 59 + this.ActualInstance.GetHashCode();
                return hashCode;
            }
        }

        /// <summary>
        /// To validate all properties of the instance
        /// </summary>
        /// <param name="validationContext">Validation context</param>
        /// <returns>Validation Result</returns>
        IEnumerable<System.ComponentModel.DataAnnotations.ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }

    /// <summary>
    /// Custom JSON converter for IWithPaginationTimeseriesDataOrTimeseriesDataOneRowPerTimePeriodDataInner
    /// </summary>
    public class IWithPaginationTimeseriesDataOrTimeseriesDataOneRowPerTimePeriodDataInnerJsonConverter : JsonConverter
    {
        /// <summary>
        /// To write the JSON string
        /// </summary>
        /// <param name="writer">JSON writer</param>
        /// <param name="value">Object to be converted into a JSON string</param>
        /// <param name="serializer">JSON Serializer</param>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteRawValue((string)(typeof(IWithPaginationTimeseriesDataOrTimeseriesDataOneRowPerTimePeriodDataInner).GetMethod("ToJson").Invoke(value, null)));
        }

        /// <summary>
        /// To convert a JSON string into an object
        /// </summary>
        /// <param name="reader">JSON reader</param>
        /// <param name="objectType">Object type</param>
        /// <param name="existingValue">Existing value</param>
        /// <param name="serializer">JSON Serializer</param>
        /// <returns>The object converted from the JSON string</returns>
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if(reader.TokenType != JsonToken.Null)
            {
                return IWithPaginationTimeseriesDataOrTimeseriesDataOneRowPerTimePeriodDataInner.FromJson(JObject.Load(reader).ToString(Formatting.None));
            }
            return null;
        }

        /// <summary>
        /// Check if the object can be converted
        /// </summary>
        /// <param name="objectType">Object type</param>
        /// <returns>True if the object can be converted</returns>
        public override bool CanConvert(Type objectType)
        {
            return false;
        }
    }

}
