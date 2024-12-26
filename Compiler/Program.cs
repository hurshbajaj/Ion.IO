using System;
using System.IO;
using System.Runtime.CompilerServices;
using Lexer;

namespace Compiler
{
    internal class Program
    {
        static void Main()
        {
            Lexer.Lexer lexer = new Lexer.Lexer(GetSrc());
            lexer.Lex();
            //Console.WriteLine("Src: " + string.Join(" " ,lexer.refe));
        }
        
        private static string GetSrc()
        {
            Console.WriteLine(Path.Combine(Directory.GetCurrentDirectory(), "Test.io"));
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "Test.io");
            return File.Exists(filePath) ? File.ReadAllText(filePath): "err";
        }
    }
}