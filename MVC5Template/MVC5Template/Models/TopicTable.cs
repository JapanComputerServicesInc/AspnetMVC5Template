namespace MVC5Template.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

using System.ComponentModel;
    [Table("TopicTable")]
    public partial class TopicTable
    {
        [Key]
        [StringLength(4)]
        [DisplayName("トピックID")]
        public string TopicId { get; set; }

        [StringLength(100)]
        [DisplayName("タイトル")]
        public string Title { get; set; }

        [DisplayName("詳細")]
        public string Detail { get; set; }

        [DisplayName("作成者ID")]
        public int? InsertUserId { get; set; }

        [DisplayName("作成者名")]
        public string UserName { get; set; }

        [DisplayName("作成日")]
        [Column(TypeName = "date")]
        public DateTime? InsertDate { get; set; }      

    }
}
