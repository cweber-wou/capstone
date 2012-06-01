using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Concurrent;

namespace RDImageGallery_WebRole.Old_App_Code
{



    public class KeyOrder
    {

        static public LinkedList<int> count(LinkedList<string> input, ConcurrentDictionary<string,int> wordlist)
        {

            int c = 0;

            //ConcurrentDictionary<String, int> wordcount = new ConcurrentDictionary<String, int>();
            LinkedList<int> order = new LinkedList<int>();

            
                foreach (string currentline in input)
                {
                    string replace = currentline;
                    char[] remove = new char[] { '.', ':', '\'', '#', '!', '=', '-', '+', ';', '<', '>', '{', '}', '(', ')', ' ', '*', '%', ',', '\\', '\t', '[', ']' };
                    string[] line = replace.Split(remove, StringSplitOptions.RemoveEmptyEntries);   //Split(remove,StringSplitOptions.RemoveEmptyEntries).Join(' ');
                    bool nextline = false;
                    //string[] line = currentline.Split(' ');
                    foreach (string test in line)
                    {
                        if (test.Contains("//"))
                        {
                            nextline = true;
                        }
                    

                        foreach (KeyValuePair<string, int> word in wordlist)  
                        {

                            if (test == word.Key && (!nextline))
                            {
                                order.AddLast(word.Value);
                            }

                        }
                        
                    }
                    c = c + line.Length;



                }
            
            //while (!wordcount.TryAdd("WC", c)) ;
            return order;

        }
    }
}