using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace backend
{
    public class wc
    {
        static public int count(LinkedList <string> input)
        {
            LinkedListNode<string> n;
            int c = 0;
            
            n = input.First;
            while (n != null)
            {
                string[] f = n.Value.Split(' ');
                c = c + f.Length;
                n = n.Next;
            }

            
            return c;
        }
    }
} 