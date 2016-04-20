namespace MVC5Template.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CommentTable")]
    public partial class CommentTable
    {
        public string TopicId { get; set; }

        public int No { get; set; }

        public string Comment { get; set; }

        public int? InsertUserId { get; set; }

        public string UserName { get; set; }

        [Column(TypeName = "date")]
        public DateTime? InsertDate { get; set; }
    }
}
