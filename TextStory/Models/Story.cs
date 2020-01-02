using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace TextStory.Models
{
    public class Story
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [StringLength(50, MinimumLength = 3)]
        public string Title { get; set; }

        [StringLength(400, MinimumLength = 3)]
        public string Description { get; set; }

        public string UserId { get; set; }

        public String Image { get; set; }

        public int CollectionID { get; set; }

        public Collection Collection { get; set; }

        public List<Message> Messages { get; set; }

        public int MessageRowCount { get; set; }
        
    }
}
