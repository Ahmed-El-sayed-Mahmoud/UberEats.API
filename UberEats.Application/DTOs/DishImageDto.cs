﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UberEats.Domain.Entities;

namespace UberEats.Application.DTOs
{
    public class DishImageDto
    {
        public int Id { get; set; }

        public int DishId { get; set; }

        [MaxLength(100)]
        public string FileName { get; set; }
        [MaxLength(100)]
        public string FileExtension { get; set; }
        public long FileSizeBytes { get; set; }
        [MaxLength(300)]
        public string FilePath { get; set; }
    }
}
