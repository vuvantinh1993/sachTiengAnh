using System;
using System.Collections.Generic;
using System.Text;

namespace CTIN.Common.Models
{
    public class Baseclass
    {
        private int top;
        private int left;
        public Baseclass(int _top, int _left)
        {
            top = _top;
            left = _left;
        }

        public void Draw()
        {
            Console.WriteLine("day la base");
        }

    }
}
