using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoGenericCollection
{
    public class Calculate<T>
    {
        public string Concat(T a, T b)
        {
            return a.ToString() + b.ToString();
        }    
    }
}
