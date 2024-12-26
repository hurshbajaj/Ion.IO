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
            Console.WriteLine(GetSrc());
            
            // Lexer.Lexer lexer = new Lexer.Lexer(GetSrc());
            // lexer.Lex();
            
            // for (int i = 0; i <= lexer.LexedArrRef.Count; i++)
            // {
            //     Console.WriteLine(lexer.LexedArrRef[i]);
            // }
            
        }
        
        private static string GetSrc()
        {
            Console.WriteLine(Path.Combine(Directory.GetCurrentDirectory(), "Test.io"));
            string filePath = "C:\\Users\\Hursh Bajaj\\RiderProjects\\Ion.io\\Compiler\\Test.io";
            return File.Exists(filePath) ? File.ReadAllText(filePath): "err";
        }
    }
}