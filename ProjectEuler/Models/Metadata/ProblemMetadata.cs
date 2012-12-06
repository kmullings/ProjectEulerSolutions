using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProjectEuler.Models
{
    [MetadataType(typeof(ProblemMetadata))]
    public partial class Problem { }

    public partial class ProblemMetadata
    {

        [DisplayName("Problem Id")]
        [Required]
        public int ProblemId { get; set; }

        [DisplayName("ID")]
        [Required]
        public int Id { get; set; }

        [DisplayName("Title")]
        [Required]
        [MaxLength(50)]
        public string Title { get; set; }

        [DisplayName("Summary")]
        [DataType(DataType.MultilineText)]
        [Required]
        public string Summary { get; set; }

        [DisplayName("Description")]
        [DataType(DataType.MultilineText)]
        [Required]
        public string Description { get; set; }

        [DisplayName("Answer")]
        public string Answer { get; set; }

        [DisplayName("Code")]
        public string Code { get; set; }

        [DisplayName("Language")]
        [MaxLength(50)]
        public string Language { get; set; }

        [DisplayName("Function Name")]
        [Required]
        [MaxLength(50)]
        public string FunctionName { get; set; }
    }
}

