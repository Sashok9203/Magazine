using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magazine_manager
{
    internal static class Input
    {
        public static int GetInt(int min, int max)
        {
            int value, X, Y;
            string? str = null;
            X = Console.CursorLeft;
            Y = Console.CursorTop;
            do
            {
                string cl = new(' ', str?.Length ?? 0);
                Console.SetCursorPosition(X, Y);
                Console.Write(cl);
                Console.SetCursorPosition(X, Y);
                str = Console.ReadLine();
            }
            while (!int.TryParse(str, out value) || value < min || value > max);
            return value;
        }
    }
}
