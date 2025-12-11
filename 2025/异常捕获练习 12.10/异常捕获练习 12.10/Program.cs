namespace 异常捕获练习_12._10
{
    internal class Program
    {
        static void Main(string[] args)
        {
           
            try
            {
                Console.WriteLine("请输入一个数字");
                string str = Console.ReadLine();
                int a = 0;
                a = int.Parse(str);
                Console.WriteLine(a);
            }
            catch 
            {
                Console.WriteLine("请输入数字");
            }
            
            
            try
            {
                Console.WriteLine("请输入姓名");
                string str1 = Console.ReadLine();
                Console.WriteLine("请输入语文成绩");
                string str2 = Console.ReadLine();
                Console.WriteLine("请输入数学成绩");
                string str3 = Console.ReadLine();
                Console.WriteLine("请输入英语成绩");
                string str4 = Console.ReadLine();
                int c1, c2, c3; 
                c1 = int.Parse(str2);
                c2 = int.Parse(str3); 
                c3 = int.Parse(str4);
            }
            catch {
                Console.WriteLine("请输入数字");
            }
            int c4 = int.Parse(Console.ReadLine());
            Console.WriteLine(c4);
        }
    }
}
