using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Concurrent;

namespace RDImageGallery_WebRole.Old_App_Code
{

    

    public class keywc
    {
        static public LinkedList<string> getWordlist()
        {
            LinkedList<string> wordlist = new LinkedList<string>();
            foreach (Word w in WordDB.GetWords())
            {
                wordlist.AddLast(w.Value);
            }
            return wordlist;
        }
        static public ConcurrentDictionary<string, int> count(LinkedList<string> input)
        {
           
            int c = 0;
            LinkedList<string> wordlist = getWordlist();
            ConcurrentDictionary<String, int> wordcount = new ConcurrentDictionary<String, int>();


            Parallel.ForEach(wordlist, word =>
            {
                foreach (string currentline in input)
                {
                    string replace = currentline;
                    char[] remove = new char[] { '.', ':', '\'', '#', '!', '=', '-', '+', ';', '<', '>', '{', '}', '(', ')', ' ', '*', '/', '%', ',', '\\', '\t', '[', ']' };
                    string[] line = replace.Split(remove, StringSplitOptions.RemoveEmptyEntries);   //Split(remove,StringSplitOptions.RemoveEmptyEntries).Join(' ');
                    //string[] line = currentline.Split(' ');

                    {
                        int count = 0;
                        foreach (string test in line)
                        {

                            if (test == word)
                            {
                                count++;
                            }

                        }
                        int x = wordcount.GetOrAdd(word, 0);
                        count += x;

                        while (!wordcount.TryUpdate(word, count, x)) ;
                    }
                    c = c + line.Length;



                }
            });
            while (!wordcount.TryAdd("WC", c)) ;
            return wordcount;

        }
    }
}