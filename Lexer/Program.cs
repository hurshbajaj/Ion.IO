using System;

namespace Lexer
{
    public class Lexer
    {
        private struct token
        {
            string value { get; set; }
            TokenTypes type { get; set; }
            
        }

        private enum TokenTypes
        {
            keyword,
            identifier,
            number,
            binOp,
            flag
        }
        
        public static List<string>? SrcString = null;
        public string? refe => string.Join(", ", SrcString);

        private static List<string> LexedStr = new List<string>(); 

        public Lexer(string src)
        {
            Console.WriteLine("construct");
            SrcString = src.ToCharArray().Select(c => c.ToString()).ToList();
        }

        public static void Main()
        {
            Console.WriteLine("Main");
            
        }

        public void Lex()
        {
            
            foreach (string i in SrcString)
            {
                Console.WriteLine(i);
                switch (i)
                {
                    case "(":
                        break;
                }
            }
        }

        //private string? shift()
        
    }
}