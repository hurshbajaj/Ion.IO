using System;
using System.Collections.Generic;

namespace Lexer
{
    public class Lexer 
    {
        public struct token 
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

        public string[] FlagTypes = [
            "(string)",
            "(bool)",
            "integer",
            "(double)",
            "(function)",
            "(construct)",
            "(type)",
            
            "(static)",
            "(const)"
        ];
        public static List<string>? SrcString = null;

        public static List<token> LexedArr = new List<token>();
        public List<token> LexedArrRef => LexedArr;
        

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
            
            while (SrcString.Count > 0)
            {
                switch (SrcString[0])
                {
                    case "(":
                        if (!isAlpha())
                        {
                            LexedArr.Add(tokenize(shift(), TokenTypes.openParen));
                        }
                        else
                        {
                            string flag = shift();
                            while (shift() != ")")
                            {
                                flag += SrcString[0];
                            }
                            flag += shift();
                            if (FlagTypes.Contains(flag))
                            {
                                LexedArr.Add(tokenize(flag, TokenTypes.flag));
                            }
                            else
                            {
                                Console.Error.WriteLine("Invalid flag: " + flag);
                            }

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