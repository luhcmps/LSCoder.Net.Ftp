using System;
using System.Collections.Generic;
using System.Text;

namespace LSCoder.Net.Ftp.ConsoleApplication.Helper
{
    public static class ConsoleHelper
    {
        public static string ReadLine(bool hidden = false)
        {
            var byteStack = new Stack<byte>();

            for (var keyInfo = Console.ReadKey(true); keyInfo.Key != ConsoleKey.Enter; keyInfo = Console.ReadKey(true))
            {
                if(keyInfo.Key == ConsoleKey.Backspace)
                {
                    if(byteStack.Count > 0)
                    {
                        Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                        Console.Write(" ");
                        Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                        byteStack.Pop();
                    }
                }
                else
                {
                    Console.Write(hidden ? '*' : keyInfo.KeyChar);
                    byteStack.Push((byte)keyInfo.KeyChar);
                }
            }

            var byteArray = byteStack.ToArray();
            Array.Reverse(byteArray);

            return Encoding.UTF8.GetString(byteArray);
        }
    }
}