﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Dtos.Category
{
    public class CategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }


        public static CategoryDto EmptyCategory = new CategoryDto();
    }
}
