﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.EntityLayer.Concrete
{
    public class Notification
    {
        public int NotificationId { get; set; }
        public string NotificationTitle { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; set; }

    }
}
