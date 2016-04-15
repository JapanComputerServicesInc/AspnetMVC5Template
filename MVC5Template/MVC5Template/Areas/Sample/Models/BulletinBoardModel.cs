using MVC5Template.Models;
using System.Collections.Generic;

namespace MVC5Template.Areas.Sample.Models
{

    public class BulletinBoardModel
    {
        public IEnumerable<TopicTable> Topics { get; set; }
        public IEnumerable<CommentTable> Comments { get; set; }
    }

}