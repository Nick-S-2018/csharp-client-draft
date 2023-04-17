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
    /// Payload for delete request. Documents can be deleted either one by one by specifying the document id or by providing a query object. For more information see  [Delete API](https://manual.manticoresearch.com/Deleting_documents) 
    /// </summary>
    [DataContract(Name = "deleteDocumentRequest")]
    public partial class DeleteDocumentRequest : IEquatable<DeleteDocumentRequest>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteDocumentRequest" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected DeleteDocumentRequest() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteDocumentRequest" /> class.
        /// </summary>
        /// <param name="index">Index name (required).</param>
        /// <param name="cluster">cluster name.</param>
        /// <param name="id">Document ID.</param>
        /// <param name="query">Query tree object.</param>
        public DeleteDocumentRequest(string index = default(string), string cluster = default(string), long id = default(long), Object query = default(Object))
        {
            // to ensure "index" is required (not null)
            if (index == null)
            {
                throw new ArgumentNullException("index is a required property for DeleteDocumentRequest and cannot be null");
            }
            this.Index = index;
            this.Cluster = cluster;
            this.Id = id;
            this.Query = query;
        }

        /// <summary>
        /// Index name
        /// </summary>
        /// <value>Index name</value>
        [DataMember(Name = "index", IsRequired = true, EmitDefaultValue = false)]
        public string Index { get; set; }

        /// <summary>
        /// cluster name
        /// </summary>
        /// <value>cluster name</value>
        [DataMember(Name = "cluster", EmitDefaultValue = false)]
        public string Cluster { get; set; }

        /// <summary>
        /// Document ID
        /// </summary>
        /// <value>Document ID</value>
        [DataMember(Name = "id", EmitDefaultValue = false)]
        public long Id { get; set; }

        /// <summary>
        /// Query tree object
        /// </summary>
        /// <value>Query tree object</value>
        [DataMember(Name = "query", EmitDefaultValue = false)]
        public Object Query { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class DeleteDocumentRequest {\n");
            sb.Append("  Index: ").Append(Index).Append("\n");
            sb.Append("  Cluster: ").Append(Cluster).Append("\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  Query: ").Append(Query).Append("\n");
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
            return this.Equals(input as DeleteDocumentRequest);
        }

        /// <summary>
        /// Returns true if DeleteDocumentRequest instances are equal
        /// </summary>
        /// <param name="input">Instance of DeleteDocumentRequest to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(DeleteDocumentRequest input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.Index == input.Index ||
                    (this.Index != null &&
                    this.Index.Equals(input.Index))
                ) && 
                (
                    this.Cluster == input.Cluster ||
                    (this.Cluster != null &&
                    this.Cluster.Equals(input.Cluster))
                ) && 
                (
                    this.Id == input.Id ||
                    this.Id.Equals(input.Id)
                ) && 
                (
                    this.Query == input.Query ||
                    (this.Query != null &&
                    this.Query.Equals(input.Query))
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
                if (this.Index != null)
                {
                    hashCode = (hashCode * 59) + this.Index.GetHashCode();
                }
                if (this.Cluster != null)
                {
                    hashCode = (hashCode * 59) + this.Cluster.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.Id.GetHashCode();
                if (this.Query != null)
                {
                    hashCode = (hashCode * 59) + this.Query.GetHashCode();
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
