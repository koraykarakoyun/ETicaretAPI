﻿using ETicaretAPI.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Domain.Entities
{
    public class Slider : BaseEntity
    {
        public string FileName { get; set; }

        public string Path { get; set; }

        public bool ShowCase { get; set; }
    }
}
