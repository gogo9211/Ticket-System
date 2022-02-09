using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TS.DAL.Entities
{
    public class Ticket
    {
        public Ticket()
        {
            Comments = new List<Comment>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        public virtual User User { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
    }
}
