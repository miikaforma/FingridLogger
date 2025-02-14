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
    /// From T, pick a set of properties whose keys are in the union K
    /// </summary>
    [DataContract(Name = "Pick_FileDataPrivate.Exclude_keyofFileDataPrivate.datasetId__")]
    public partial class PickFileDataPrivateExcludeKeyofFileDataPrivateDatasetId : IEquatable<PickFileDataPrivateExcludeKeyofFileDataPrivateDatasetId>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PickFileDataPrivateExcludeKeyofFileDataPrivateDatasetId" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected PickFileDataPrivateExcludeKeyofFileDataPrivateDatasetId() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="PickFileDataPrivateExcludeKeyofFileDataPrivateDatasetId" /> class.
        /// </summary>
        /// <param name="id">id (required).</param>
        /// <param name="modifiedAtUtc">modifiedAtUtc.</param>
        /// <param name="createdAtUtc">createdAtUtc.</param>
        /// <param name="filenameFi">filenameFi (required).</param>
        /// <param name="filenameEn">filenameEn (required).</param>
        /// <param name="messageFi">messageFi (required).</param>
        /// <param name="messageEn">messageEn (required).</param>
        /// <param name="link">link (required).</param>
        /// <param name="fileType">fileType (required).</param>
        /// <param name="size">size (required).</param>
        /// <param name="dataFrom">dataFrom (required).</param>
        /// <param name="dataTo">dataTo (required).</param>
        public PickFileDataPrivateExcludeKeyofFileDataPrivateDatasetId(double id = default(double), DateTime modifiedAtUtc = default(DateTime), DateTime createdAtUtc = default(DateTime), string filenameFi = default(string), string filenameEn = default(string), string messageFi = default(string), string messageEn = default(string), string link = default(string), string fileType = default(string), double size = default(double), DateTime dataFrom = default(DateTime), DateTime dataTo = default(DateTime))
        {
            this.Id = id;
            // to ensure "filenameFi" is required (not null)
            if (filenameFi == null)
            {
                throw new ArgumentNullException("filenameFi is a required property for PickFileDataPrivateExcludeKeyofFileDataPrivateDatasetId and cannot be null");
            }
            this.FilenameFi = filenameFi;
            // to ensure "filenameEn" is required (not null)
            if (filenameEn == null)
            {
                throw new ArgumentNullException("filenameEn is a required property for PickFileDataPrivateExcludeKeyofFileDataPrivateDatasetId and cannot be null");
            }
            this.FilenameEn = filenameEn;
            // to ensure "messageFi" is required (not null)
            if (messageFi == null)
            {
                throw new ArgumentNullException("messageFi is a required property for PickFileDataPrivateExcludeKeyofFileDataPrivateDatasetId and cannot be null");
            }
            this.MessageFi = messageFi;
            // to ensure "messageEn" is required (not null)
            if (messageEn == null)
            {
                throw new ArgumentNullException("messageEn is a required property for PickFileDataPrivateExcludeKeyofFileDataPrivateDatasetId and cannot be null");
            }
            this.MessageEn = messageEn;
            // to ensure "link" is required (not null)
            if (link == null)
            {
                throw new ArgumentNullException("link is a required property for PickFileDataPrivateExcludeKeyofFileDataPrivateDatasetId and cannot be null");
            }
            this.Link = link;
            // to ensure "fileType" is required (not null)
            if (fileType == null)
            {
                throw new ArgumentNullException("fileType is a required property for PickFileDataPrivateExcludeKeyofFileDataPrivateDatasetId and cannot be null");
            }
            this.FileType = fileType;
            this.Size = size;
            this.DataFrom = dataFrom;
            this.DataTo = dataTo;
            this.ModifiedAtUtc = modifiedAtUtc;
            this.CreatedAtUtc = createdAtUtc;
        }

        /// <summary>
        /// Gets or Sets Id
        /// </summary>
        [DataMember(Name = "id", IsRequired = true, EmitDefaultValue = true)]
        public double Id { get; set; }

        /// <summary>
        /// Gets or Sets ModifiedAtUtc
        /// </summary>
        [DataMember(Name = "modifiedAtUtc", EmitDefaultValue = false)]
        public DateTime ModifiedAtUtc { get; set; }

        /// <summary>
        /// Gets or Sets CreatedAtUtc
        /// </summary>
        [DataMember(Name = "createdAtUtc", EmitDefaultValue = false)]
        public DateTime CreatedAtUtc { get; set; }

        /// <summary>
        /// Gets or Sets FilenameFi
        /// </summary>
        [DataMember(Name = "filenameFi", IsRequired = true, EmitDefaultValue = true)]
        public string FilenameFi { get; set; }

        /// <summary>
        /// Gets or Sets FilenameEn
        /// </summary>
        [DataMember(Name = "filenameEn", IsRequired = true, EmitDefaultValue = true)]
        public string FilenameEn { get; set; }

        /// <summary>
        /// Gets or Sets MessageFi
        /// </summary>
        [DataMember(Name = "messageFi", IsRequired = true, EmitDefaultValue = true)]
        public string MessageFi { get; set; }

        /// <summary>
        /// Gets or Sets MessageEn
        /// </summary>
        [DataMember(Name = "messageEn", IsRequired = true, EmitDefaultValue = true)]
        public string MessageEn { get; set; }

        /// <summary>
        /// Gets or Sets Link
        /// </summary>
        [DataMember(Name = "link", IsRequired = true, EmitDefaultValue = true)]
        public string Link { get; set; }

        /// <summary>
        /// Gets or Sets FileType
        /// </summary>
        [DataMember(Name = "fileType", IsRequired = true, EmitDefaultValue = true)]
        public string FileType { get; set; }

        /// <summary>
        /// Gets or Sets Size
        /// </summary>
        [DataMember(Name = "size", IsRequired = true, EmitDefaultValue = true)]
        public double Size { get; set; }

        /// <summary>
        /// Gets or Sets DataFrom
        /// </summary>
        [DataMember(Name = "dataFrom", IsRequired = true, EmitDefaultValue = true)]
        public DateTime DataFrom { get; set; }

        /// <summary>
        /// Gets or Sets DataTo
        /// </summary>
        [DataMember(Name = "dataTo", IsRequired = true, EmitDefaultValue = true)]
        public DateTime DataTo { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class PickFileDataPrivateExcludeKeyofFileDataPrivateDatasetId {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  ModifiedAtUtc: ").Append(ModifiedAtUtc).Append("\n");
            sb.Append("  CreatedAtUtc: ").Append(CreatedAtUtc).Append("\n");
            sb.Append("  FilenameFi: ").Append(FilenameFi).Append("\n");
            sb.Append("  FilenameEn: ").Append(FilenameEn).Append("\n");
            sb.Append("  MessageFi: ").Append(MessageFi).Append("\n");
            sb.Append("  MessageEn: ").Append(MessageEn).Append("\n");
            sb.Append("  Link: ").Append(Link).Append("\n");
            sb.Append("  FileType: ").Append(FileType).Append("\n");
            sb.Append("  Size: ").Append(Size).Append("\n");
            sb.Append("  DataFrom: ").Append(DataFrom).Append("\n");
            sb.Append("  DataTo: ").Append(DataTo).Append("\n");
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
            return this.Equals(input as PickFileDataPrivateExcludeKeyofFileDataPrivateDatasetId);
        }

        /// <summary>
        /// Returns true if PickFileDataPrivateExcludeKeyofFileDataPrivateDatasetId instances are equal
        /// </summary>
        /// <param name="input">Instance of PickFileDataPrivateExcludeKeyofFileDataPrivateDatasetId to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(PickFileDataPrivateExcludeKeyofFileDataPrivateDatasetId input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.Id == input.Id ||
                    this.Id.Equals(input.Id)
                ) && 
                (
                    this.ModifiedAtUtc == input.ModifiedAtUtc ||
                    (this.ModifiedAtUtc != null &&
                    this.ModifiedAtUtc.Equals(input.ModifiedAtUtc))
                ) && 
                (
                    this.CreatedAtUtc == input.CreatedAtUtc ||
                    (this.CreatedAtUtc != null &&
                    this.CreatedAtUtc.Equals(input.CreatedAtUtc))
                ) && 
                (
                    this.FilenameFi == input.FilenameFi ||
                    (this.FilenameFi != null &&
                    this.FilenameFi.Equals(input.FilenameFi))
                ) && 
                (
                    this.FilenameEn == input.FilenameEn ||
                    (this.FilenameEn != null &&
                    this.FilenameEn.Equals(input.FilenameEn))
                ) && 
                (
                    this.MessageFi == input.MessageFi ||
                    (this.MessageFi != null &&
                    this.MessageFi.Equals(input.MessageFi))
                ) && 
                (
                    this.MessageEn == input.MessageEn ||
                    (this.MessageEn != null &&
                    this.MessageEn.Equals(input.MessageEn))
                ) && 
                (
                    this.Link == input.Link ||
                    (this.Link != null &&
                    this.Link.Equals(input.Link))
                ) && 
                (
                    this.FileType == input.FileType ||
                    (this.FileType != null &&
                    this.FileType.Equals(input.FileType))
                ) && 
                (
                    this.Size == input.Size ||
                    this.Size.Equals(input.Size)
                ) && 
                (
                    this.DataFrom == input.DataFrom ||
                    (this.DataFrom != null &&
                    this.DataFrom.Equals(input.DataFrom))
                ) && 
                (
                    this.DataTo == input.DataTo ||
                    (this.DataTo != null &&
                    this.DataTo.Equals(input.DataTo))
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
                hashCode = (hashCode * 59) + this.Id.GetHashCode();
                if (this.ModifiedAtUtc != null)
                {
                    hashCode = (hashCode * 59) + this.ModifiedAtUtc.GetHashCode();
                }
                if (this.CreatedAtUtc != null)
                {
                    hashCode = (hashCode * 59) + this.CreatedAtUtc.GetHashCode();
                }
                if (this.FilenameFi != null)
                {
                    hashCode = (hashCode * 59) + this.FilenameFi.GetHashCode();
                }
                if (this.FilenameEn != null)
                {
                    hashCode = (hashCode * 59) + this.FilenameEn.GetHashCode();
                }
                if (this.MessageFi != null)
                {
                    hashCode = (hashCode * 59) + this.MessageFi.GetHashCode();
                }
                if (this.MessageEn != null)
                {
                    hashCode = (hashCode * 59) + this.MessageEn.GetHashCode();
                }
                if (this.Link != null)
                {
                    hashCode = (hashCode * 59) + this.Link.GetHashCode();
                }
                if (this.FileType != null)
                {
                    hashCode = (hashCode * 59) + this.FileType.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.Size.GetHashCode();
                if (this.DataFrom != null)
                {
                    hashCode = (hashCode * 59) + this.DataFrom.GetHashCode();
                }
                if (this.DataTo != null)
                {
                    hashCode = (hashCode * 59) + this.DataTo.GetHashCode();
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
