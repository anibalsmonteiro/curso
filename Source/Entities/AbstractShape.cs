using Source.Entities.Enums;

namespace Source.Entities
{
    abstract class AbstractShape : IShape
    {
        public Color Color { get; set; }

        public AbstractShape() { }

        public AbstractShape(Color color)
        {
            Color = color;
        }

        public abstract double Area();
    }
}
