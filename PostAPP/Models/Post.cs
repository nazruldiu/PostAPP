using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PostAPP.Models
{
    public class Post
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string PostDetails { get; set; }
        public DateTime PostDate { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}
