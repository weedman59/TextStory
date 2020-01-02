using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TextStory.Models
{
    public class Message
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [StringLength(400, MinimumLength = 1)]
        public string Content { get; set; }

        public int PauseMins { get; set; }

        public int PauseSeconds { get; set; }

        public int Sequence { get; set; }

        public int StoryId { get; set; }

        public Story Story { get; set; }

        }
}
