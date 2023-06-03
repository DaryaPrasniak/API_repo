using AngleSharp.Dom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TAF_TMS_C1onl.Models
{
    public class Case
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("title")]
        public string Title { get; set; }
        [JsonPropertyName("section_id")]
        public int SectionId { get; set; }
        [JsonPropertyName("type_id")]
        public int? TypeId { get; set; }
        [JsonPropertyName("priority_id")]
        public int? PriorityId { get; set; }
        [JsonPropertyName("milestone_id")] 
        public int? MilestoneId { get; set; }

        [JsonPropertyName("refs")] 
        public string Refs { get; set; }
        [JsonPropertyName("created_by")]
        public int CreatedBy { get; set; }
        [JsonPropertyName("created_on")]
        public int CreatedOn { get; set; }
        [JsonPropertyName("updated_by")]
        public int UpdatedBy { get; set; }
        [JsonPropertyName("updated_on")]
        public int UpdatedOn { get; set; }
        [JsonPropertyName("estimate")]
        public string Estimate { get; set; }
        [JsonPropertyName("estimate_forecast")]
        public string EstimateForecast { get; set; }
        [JsonPropertyName("suite_id")]
        public int SuiteId { get; set; }

        public override string ToString()
        {
            return
            $"{nameof(Id)}: {Id}, {nameof(Title)}: {Title}, {nameof(SectionId)}: {SectionId}, {nameof(TypeId)}: " +
                $"{TypeId}, {nameof(PriorityId)}: {PriorityId}, {nameof(CreatedBy)}: " +
                $"{CreatedBy}, {nameof(CreatedOn)}: {CreatedOn}, {nameof(UpdatedBy)}: {UpdatedBy}, {nameof(SuiteId)}: " +
                $"{SuiteId}";
        }

        protected bool Equals(Case other)
        {
            return Title == other.Title && SectionId == other.SectionId &&
                   UpdatedBy == other.UpdatedBy && TypeId == other.TypeId &&
                   PriorityId == other.PriorityId && CreatedBy == other.CreatedBy &&
                   CreatedOn == other.CreatedOn && SuiteId == other.SuiteId;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Title, SectionId, TypeId, PriorityId, CreatedBy, CreatedOn, SuiteId);
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;

            return Equals((Case)obj);
        }
    }
}
