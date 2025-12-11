using System.Security.Authentication;

namespace 控制台相关练习_12._11
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //改变控制台颜色
            Console.SetWindowSize(50, 25);
            Console.BackgroundColor = ConsoleColor.Red;
            Console.Clear();
            Console.SetBufferSize(100, 100);//缓冲区大小
            Console.ForegroundColor = ConsoleColor.Yellow;
           //隐藏光标
            Console.CursorVisible = false;
            int x = 5;
            int y = 5;
            Console.SetCursorPosition(x, y);
            Console.WriteLine("■");

            while (true)
            {
                //Console.Clear();
                Console.SetCursorPosition(x, y);
                Console.WriteLine("■");
                char a = Console.ReadKey(true).KeyChar;
                Console.SetCursorPosition(x, y);
                Console.WriteLine(" ");

                if (a == 'w' || a == 'W')
                {
                    if (y > 0)
                        y--;

                }
                else if (a == 'a' || a == 'A')
                {
                    if(x>0)
                    x--;
                }
                else if (a == 's' || a == 'S')
                {
                    if(y < Console.BufferWidth - 1) 
                    y++;
                }
                else if (a == 'd' || a == 'D')
                {
                    if(x<Console.BufferHeight - 1)
                    x++;
                }
                else
                {
                    ;
                }





            }
        }

    }
}
