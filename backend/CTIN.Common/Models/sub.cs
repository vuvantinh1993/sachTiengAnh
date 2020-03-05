using System;
using System.Collections.Generic;
using System.Text;

namespace CTIN.Common.Models
{
    public class Sub : Baseclass
    {
        public string content;
        public Sub(int _top, int _left, string _content) : base(_top, _left)
        {
            content = _content;
        }

        public new void Draw()
        {
            base.Draw();
            Console.WriteLine("them con tent");
        }
    }
}
