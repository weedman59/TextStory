using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TextStory.Models
{
    public class Collection
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [StringLength(50, MinimumLength = 3)]
        public string Title { get; set; }
        [StringLength(50, MinimumLength = 3)]
        public string Description { get; set; }
        
        public ICollection<Story> Stories { get; set; }
    }
}
