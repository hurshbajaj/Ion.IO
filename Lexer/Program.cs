using System;
using System.Collections.Generic;

namespace Lexer
{
    public class Lexer 
    {
        public struct token 
        {
            public string value { get; set; }
            public TokenTypes type { get; set; }

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
            flag,
            lineEnd
        }

        public string[] FlagTypes = new String[]{
            "(string)",
            "(bool)",
            "integer",
            "(double)",
            "(function)",
            "(construct)",
            "(type)",
            
            "(static)",
            "(const)"
        };

        public string[] Keywords = new String[]{
            "$", //just one for now (:
        };
        public static List<string>? SrcString = null;

        public static List<token> LexedArr = new List<token>();
        public List<token> LexedArrRef => LexedArr;
        

        public Lexer(string src)
        {
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
                        if (!isAlpha(1))
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
                    case ")":
                        LexedArr.Add(tokenize(shift(), TokenTypes.closeParen));
                        break;
                    case ";":
                        LexedArr.Add(tokenize(shift(), TokenTypes.lineEnd));
                        break;
                    default:
                        //Is Identifier
                        if (SrcString[0].StartsWith("$"))
                        {
                            string keyword = shift();
                            while (isAlpha(0))
                            {
                                keyword += SrcString[0];
                            }
                            LexedArr.Add(tokenize(keyword, TokenTypes.keyword));
                        }
                        
                        //isKeyword   
                        if (isAlpha(0))
                        {
                            //2 possibilities now
                            string group = "";
                            while (isAlpha(0))
                            {
                                group += shift(); 
                            }

                            
                            LexedArr.Add(tokenize(group, TokenTypes.identifier));
                            
                        }
                        //Is Number
                        else if (isDigit(0))
                        {
                            string number = "";
                            while (isDigit(0))
                            {
                                number += shift();
                            }
                            
                            LexedArr.Add(tokenize(number, TokenTypes.number));
                        }
                        //isSkippable
                        else if (isSkippable(0))
                        {
                            break;
                        }
                        //Is err
                        else
                        {
                            Console.Error.WriteLine("Invalid token: " + SrcString[0]);
                            shift();
                            
                        }
                        break;
                }
            }
            Console.WriteLine(LexedArr[0]);
        }
        
        private string? shift()
        {
            string element = SrcString[0];
            SrcString.RemoveAt(0);
            return element;
        }

        private bool isAlpha(int i) 
        {
            return SrcString[i].ToLower() != SrcString[i].ToUpper();
        }

        public token tokenize(string val, TokenTypes type)
        {
            return new token(val, type); 
        }

        private bool isDigit(int i)
        {
            try
            {
                int holder = int.Parse(SrcString[i]);
                return true;
            }
            catch (FormatException ex)
            {
                return false;
            }
        } //hmm, we also have a syntax error, i wonder why c# didnt tell us

        private bool isSkippable(int i) //oops
        {
            return SrcString[i].StartsWith('\\') || SrcString[i].StartsWith(" "); 
        }

    } 
}