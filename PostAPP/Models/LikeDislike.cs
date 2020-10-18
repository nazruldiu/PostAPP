using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PostAPP.Models
{
    public class LikeDislike
    {
        [Key]
        public int Id { get; set; }
        public bool Like { get; set; }
        public bool Dislike { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public int CommentId { get; set; }
        public virtual Comment Comment { get; set; }
    }
}
