using System;

namespace classdemo04 {
    interface IShape {
        double GetPerimeter ();
        double GetArea ();
    }

    class Circle : IShape {
        double _radius;
        public Circle (double radius) {
            _radius = radius;
        }

        public double GetArea () {
            return _radius * _radius * 3.14;
        }
        public double GetPerimeter () {
            return _radius*2 * 3.14;
        }

    }
    class Program {
        static void Main (string[] args) {
            Circle c = new Circle (10);
            Console.WriteLine ("Perimeter={0},Area is {1}", 
            c.GetPerimeter (), c.GetArea ());
        }
    }
}