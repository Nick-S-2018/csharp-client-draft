/*
 * Manticore Search Client
 *
 * Low-level client for Manticore Search. 
 *
 * The version of the OpenAPI document: 1.0.0
 * Contact: info@manticoresearch.com
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
using FileParameter = ManticoreSearch.Client.FileParameter;
using OpenAPIDateConverter = ManticoreSearch.Client.OpenAPIDateConverter;

namespace ManticoreSearch.Model
{
    /// <summary>
    /// Query filter
    /// </summary>
    [DataContract(Name = "notFilterString")]
    public partial class NotFilterString : IEquatable<NotFilterString>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NotFilterString" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected NotFilterString() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="NotFilterString" /> class.
        /// </summary>
        /// <param name="filterField">filterField (required).</param>
        /// <param name="operation">operation (required).</param>
        /// <param name="filterValue">filterValue (required).</param>
        public NotFilterString(string filterField = default(string), string operation = default(string), string filterValue = default(string))
        {
            // to ensure "filterField" is required (not null)
            if (filterField == null)
            {
                throw new ArgumentNullException("filterField is a required property for NotFilterString and cannot be null");
            }
            this.FilterField = filterField;
            // to ensure "operation" is required (not null)
            if (operation == null)
            {
                throw new ArgumentNullException("operation is a required property for NotFilterString and cannot be null");
            }
            this.Operation = operation;
            // to ensure "filterValue" is required (not null)
            if (filterValue == null)
            {
                throw new ArgumentNullException("filterValue is a required property for NotFilterString and cannot be null");
            }
            this.FilterValue = filterValue;
        }

        /// <summary>
        /// Gets or Sets FilterField
        /// </summary>
        [DataMember(Name = "filter_field", IsRequired = true, EmitDefaultValue = false)]
        public string FilterField { get; set; }

        /// <summary>
        /// Gets or Sets Operation
        /// </summary>
        [DataMember(Name = "operation", IsRequired = true, EmitDefaultValue = false)]
        public string Operation { get; set; }

        /// <summary>
        /// Gets or Sets FilterValue
        /// </summary>
        [DataMember(Name = "filter_value", IsRequired = true, EmitDefaultValue = false)]
        public string FilterValue { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class NotFilterString {\n");
            sb.Append("  FilterField: ").Append(FilterField).Append("\n");
            sb.Append("  Operation: ").Append(Operation).Append("\n");
            sb.Append("  FilterValue: ").Append(FilterValue).Append("\n");
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
            return this.Equals(input as NotFilterString);
        }

        /// <summary>
        /// Returns true if NotFilterString instances are equal
        /// </summary>
        /// <param name="input">Instance of NotFilterString to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(NotFilterString input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.FilterField == input.FilterField ||
                    (this.FilterField != null &&
                    this.FilterField.Equals(input.FilterField))
                ) && 
                (
                    this.Operation == input.Operation ||
                    (this.Operation != null &&
                    this.Operation.Equals(input.Operation))
                ) && 
                (
                    this.FilterValue == input.FilterValue ||
                    (this.FilterValue != null &&
                    this.FilterValue.Equals(input.FilterValue))
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
                if (this.FilterField != null)
                {
                    hashCode = (hashCode * 59) + this.FilterField.GetHashCode();
                }
                if (this.Operation != null)
                {
                    hashCode = (hashCode * 59) + this.Operation.GetHashCode();
                }
                if (this.FilterValue != null)
                {
                    hashCode = (hashCode * 59) + this.FilterValue.GetHashCode();
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
