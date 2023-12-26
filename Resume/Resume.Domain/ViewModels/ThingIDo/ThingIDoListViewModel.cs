﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Domain.ViewModels.ThingIDo
{
    public class ThingIDoListViewModel
    {
        public long ID { get; set; }

        public string Icon { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public int ColumnLg { get; set; }

        public int Order { get; set; } 
    }
}
