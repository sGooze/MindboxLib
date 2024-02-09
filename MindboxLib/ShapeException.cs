using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MindboxLib
{
    /// <summary>
    /// Исключение, возникшее в процессе работы библиотеки
    /// </summary>
    public class ShapeException : Exception
    {
        public IShape Shape { get; init; }

        public ShapeException(IShape shape) { Shape = shape; }
        public ShapeException(IShape shape, string message) : base(message) { Shape = shape; }
        public ShapeException(IShape shape, string message, Exception inner) : base(message, inner) { Shape = shape; }

        public override string ToString()
        {
            return String.Join(Environment.NewLine, Shape.ToString(), base.ToString());
        }
    }
}
