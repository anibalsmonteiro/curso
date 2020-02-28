﻿using System;
using System.Collections.Generic;
using System.Text;
using Source.Entities.Enums;

namespace Source.Entities
{
    abstract class Shape
    {
        public Color Color { get; set; }

        public Shape() { }

        public Shape(Color color)
        {
            Color = color;
        }

        public abstract double Area();
    }
}
