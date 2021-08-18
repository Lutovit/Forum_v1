using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Forum_v1.Models
{
    public class TopicCreateViewModel
    {
        [Required]
        [Display(Name = "Наименование.")]
        public string TopicName { set; get; }

        [Required]
        [Display(Name = "Описание.")]
        public string TopicDescription { set; get; }

    }
}
