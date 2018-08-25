using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiskovSubstitution_MFeathersExample
{
    /// <summary>
    /// An example of Liskov Substitution Violation from Michael Feathers, from his book "Working Effectively with Legacy Code", pg. 101-102.
    /// </summary>
    public class Program
    {
        static void Main(string[] args)
        {
            // Square inherits the SetWidth and SetHeight methods of Rectangle.
            Rectangle r = new Square(3);
            // What should the area be when we execute this code...?
            r.SetHeight(3);
            r.SetWidth(4);
            // So, not really a *square* after all...? Liskov Substition violation.
            
            // We could just override SetWidth and SetHeight so that they keep the square 'square', but that could lead to some counter-intuitive results.
            // Anyone who expects that all rectangles will have an area of 12 when their width is set to 3 and their height set to 4 is in for a surprise - they would get 16 instead.

            // This is a classic example of a LSP violation. Objects of subclasses should be substitutable for objects of their superclasses throughout our code.
            // If they aren't we could have silent errors in our code.
        }
    }


    public class Rectangle
    {
        int width, height;

        public Rectangle(int width, int height)
        {
            this.width = width;
            this.height = height;
        }

        public void SetWidth(int width)
        {
            this.width = width;
        }

        public void SetHeight( int height)
        {
            this.height = height;
        }

        public int GetArea()
        {
            return width * height;
        }
    }

    public class Square : Rectangle
    {
        public Square(int width): base(width,width)
        {
        }
    }

}
