using System.ComponentModel.DataAnnotations;

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


    public class MessageCreateViewModel
    {
        [Required]
        [Display(Name = "Сообщение")]
        public string Text { set; get; }

    }
}
