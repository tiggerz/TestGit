using System;
using System.Collections.Generic;
using System.Text;

namespace Test
{
    class Class1
    {
        static void Vxx()
        {
            string text = "Here's some text including a \u00ff non-ASCII character";
            foreach (char c in text)
            {
                int unicode = c;
                Console.WriteLine(unicode < 128 ? "ASCII: {0}" : "Non-ASCII: {0}", unicode);
            }
        }
    }
}
