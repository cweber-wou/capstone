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
            wordlist.AddFirst("abstract");
            wordlist.AddFirst("continue");
            wordlist.AddFirst("for");
            wordlist.AddFirst("new");
            wordlist.AddFirst("switch");
            wordlist.AddFirst("assert");
            wordlist.AddFirst("default");
            wordlist.AddFirst("goto");
            wordlist.AddFirst("package");
            wordlist.AddFirst("synchronized");
            wordlist.AddFirst("boolean");
            wordlist.AddFirst("do");
            wordlist.AddFirst("if");
            wordlist.AddFirst("private");
            wordlist.AddFirst("this");
            wordlist.AddFirst("break");
            wordlist.AddFirst("double");
            wordlist.AddFirst("implements");
            wordlist.AddFirst("protected");
            wordlist.AddFirst("throw");
            wordlist.AddFirst("byte");
            wordlist.AddFirst("else");
            wordlist.AddFirst("import");
            wordlist.AddFirst("public");
            wordlist.AddFirst("throws");
            wordlist.AddFirst("case");
            wordlist.AddFirst("enum");
            wordlist.AddFirst("instanceof");
            wordlist.AddFirst("return");
            wordlist.AddFirst("transient");
            wordlist.AddFirst("catch");
            wordlist.AddFirst("extends");
            wordlist.AddFirst("int");
            wordlist.AddFirst("short");
            wordlist.AddFirst("try");
            wordlist.AddFirst("char");
            wordlist.AddFirst("final");
            wordlist.AddFirst("interface");
            wordlist.AddFirst("static");
            wordlist.AddFirst("void");
            wordlist.AddFirst("class");
            wordlist.AddFirst("finally");
            wordlist.AddFirst("long");
            wordlist.AddFirst("strictfp");
            wordlist.AddFirst("volatile");
            wordlist.AddFirst("const");
            wordlist.AddFirst("float");
            wordlist.AddFirst("native");
            wordlist.AddFirst("super");
            wordlist.AddFirst("while");
            return wordlist;
        }
        static public ConcurrentDictionary<string, int> count(LinkedList<string> input)
        {
           
            int c = 0;
            LinkedList<string> wordlist = getWordlist();
            ConcurrentDictionary<String, int> wordcount = new ConcurrentDictionary<String, int>();
            
            

            foreach(string currentline in input)
            {
                string replace = currentline;
                char[] remove = new char[] {'.',':','\'','#','!','=','-','+',';','<','>','{','}','(',')',' ','*','/','%',',','\\','\t','[',']'};
                string[] line= replace.Split(remove,StringSplitOptions.RemoveEmptyEntries);   //Split(remove,StringSplitOptions.RemoveEmptyEntries).Join(' ');
                //string[] line = currentline.Split(' ');
                Parallel.ForEach(wordlist, word =>
                {
                    int count = 0;
                    foreach(string test in line)
                    {

                        if (test == word)
                        {
                            count++;
                        }

                    }
                    int x = wordcount.GetOrAdd(word,0);
                    count += x;
                    
                    while (!wordcount.TryUpdate(word,count,x));
                });
                c = c + line.Length;
                
                

            }
            while (!wordcount.TryAdd("WC", c)) ;
            return wordcount;

        }
    }
}