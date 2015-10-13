using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ReptileManager.Models
{
    public class Notification
    {
        public int NotificationId { get; set; }
        public String Description { get; set; }
        public String Message { get; set; }
        [Display(Name = "Send At")]
        public DateTime SendAt { get; set; }
        public String ReptileId { get; set; }
        public virtual Reptile Reptile { get; set; }
    }
}