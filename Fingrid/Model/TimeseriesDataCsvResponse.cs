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

namespace Fingrid.Model
{
    /// <summary>
    /// TimeseriesDataCsvResponse
    /// </summary>
    [DataContract(Name = "TimeseriesDataCsvResponse")]
    public partial class TimeseriesDataCsvResponse : IEquatable<TimeseriesDataCsvResponse>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TimeseriesDataCsvResponse" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected TimeseriesDataCsvResponse() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="TimeseriesDataCsvResponse" /> class.
        /// </summary>
        /// <param name="pagination">pagination (required).</param>
        /// <param name="data">data (required).</param>
        public TimeseriesDataCsvResponse(IPagination pagination = default(IPagination), string data = default(string))
        {
            // to ensure "pagination" is required (not null)
            if (pagination == null)
            {
                throw new ArgumentNullException("pagination is a required property for TimeseriesDataCsvResponse and cannot be null");
            }
            this.Pagination = pagination;
            // to ensure "data" is required (not null)
            if (data == null)
            {
                throw new ArgumentNullException("data is a required property for TimeseriesDataCsvResponse and cannot be null");
            }
            this.Data = data;
        }

        /// <summary>
        /// Gets or Sets Pagination
        /// </summary>
        [DataMember(Name = "pagination", IsRequired = true, EmitDefaultValue = true)]
        public IPagination Pagination { get; set; }

        /// <summary>
        /// Gets or Sets Data
        /// </summary>
        [DataMember(Name = "data", IsRequired = true, EmitDefaultValue = true)]
        public string Data { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class TimeseriesDataCsvResponse {\n");
            sb.Append("  Pagination: ").Append(Pagination).Append("\n");
            sb.Append("  Data: ").Append(Data).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public virtual string ToJson()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this, Newtonsoft.Json.Formatting.Indented);
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            return this.Equals(input as TimeseriesDataCsvResponse);
        }

        /// <summary>
        /// Returns true if TimeseriesDataCsvResponse instances are equal
        /// </summary>
        /// <param name="input">Instance of TimeseriesDataCsvResponse to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(TimeseriesDataCsvResponse input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.Pagination == input.Pagination ||
                    (this.Pagination != null &&
                    this.Pagination.Equals(input.Pagination))
                ) && 
                (
                    this.Data == input.Data ||
                    (this.Data != null &&
                    this.Data.Equals(input.Data))
                );
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
                if (this.Pagination != null)
                {
                    hashCode = (hashCode * 59) + this.Pagination.GetHashCode();
                }
                if (this.Data != null)
                {
                    hashCode = (hashCode * 59) + this.Data.GetHashCode();
                }
                return hashCode;
            }
        }

        /// <summary>
        /// To validate all properties of the instance
        /// </summary>
        /// <param name="validationContext">Validation context</param>
        /// <returns>Validation Result</returns>
        public IEnumerable<System.ComponentModel.DataAnnotations.ValidationResult> Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }

}
