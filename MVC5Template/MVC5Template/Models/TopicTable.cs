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
        [DisplayName("�g�s�b�NID")]
        public string TopicId { get; set; }

        [StringLength(100)]
        [DisplayName("�^�C�g��")]
        public string Title { get; set; }

        [DisplayName("�ڍ�")]
        public string Detail { get; set; }

        [DisplayName("�쐬��ID")]
        public int? InsertUserId { get; set; }

        [DisplayName("�쐬�Җ�")]
        public string UserName { get; set; }

        [DisplayName("�쐬��")]
        [Column(TypeName = "date")]
        public DateTime? InsertDate { get; set; }      

    }
}
