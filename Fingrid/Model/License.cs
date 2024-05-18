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
    /// License
    /// </summary>
    [DataContract(Name = "License")]
    public partial class License : IEquatable<License>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="License" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected License() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="License" /> class.
        /// </summary>
        /// <param name="name">name (required).</param>
        /// <param name="termsLink">termsLink (required).</param>
        public License(string name = default(string), string termsLink = default(string))
        {
            // to ensure "name" is required (not null)
            if (name == null)
            {
                throw new ArgumentNullException("name is a required property for License and cannot be null");
            }
            this.Name = name;
            // to ensure "termsLink" is required (not null)
            if (termsLink == null)
            {
                throw new ArgumentNullException("termsLink is a required property for License and cannot be null");
            }
            this.TermsLink = termsLink;
        }

        /// <summary>
        /// Gets or Sets Name
        /// </summary>
        [DataMember(Name = "name", IsRequired = true, EmitDefaultValue = true)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or Sets TermsLink
        /// </summary>
        [DataMember(Name = "termsLink", IsRequired = true, EmitDefaultValue = true)]
        public string TermsLink { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class License {\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  TermsLink: ").Append(TermsLink).Append("\n");
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
            return this.Equals(input as License);
        }

        /// <summary>
        /// Returns true if License instances are equal
        /// </summary>
        /// <param name="input">Instance of License to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(License input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.Name == input.Name ||
                    (this.Name != null &&
                    this.Name.Equals(input.Name))
                ) && 
                (
                    this.TermsLink == input.TermsLink ||
                    (this.TermsLink != null &&
                    this.TermsLink.Equals(input.TermsLink))
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
                if (this.Name != null)
                {
                    hashCode = (hashCode * 59) + this.Name.GetHashCode();
                }
                if (this.TermsLink != null)
                {
                    hashCode = (hashCode * 59) + this.TermsLink.GetHashCode();
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
