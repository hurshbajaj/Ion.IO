using System;

namespace Lexer
{
    public class Lexer 
    {
        private struct token 
        {
            string value { get; set; }
            TokenTypes type { get; set; }

            public token(string value, TokenTypes type)
            {
                this.value = value;
                this.type = type;
            }
        }

        public enum TokenTypes
        {
            keyword,
            identifier,
            number,
            binOp,
            openParen,
            closeParen,
            flag
        }
        
        public static List<string>? SrcString = null;
        public string? refe => string.Join(", ", SrcString);

        private static List<token> LexedStr = new List<token>(); 

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
                        if (!isAlpha())
                        {
                            LexedStr.Add(tokenize("(", TokenTypes.openParen));
                        }
                        else
                        {
                            
                        }
                        break;
                }
            }
        }

        private string? shift()
        {
            string element = SrcString[0];
            SrcString.RemoveAt(0);
            return element;
        }

        private bool isAlpha() 
        {
            return SrcString[0].ToLower() == SrcString[0].ToUpper();
        }

        private token tokenize(string val, TokenTypes type)
        {
            return new token(val, type); 
        }
    }
}