namespace 显式转换练习_12._10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int a = 24069;
            char b1 = (char)a; 
            char b2 = Convert.ToChar(a);
            int c1 =0, c2 = 0, c3 = 0;
            string str,str1, str2, str3;
            Console.WriteLine(b1);
            Console.WriteLine(b2);
            Console.WriteLine("请输入姓名");
            str = Console.ReadLine();
            Console.WriteLine("请输入数学成绩");
            str1 = Console.ReadLine();
            Console.WriteLine("请输入语文成绩");
            str2 = Console.ReadLine();
            Console.WriteLine("请输入英语成绩");
            str3 = Console.ReadLine();
            c1 = int.Parse(str1);
            c2 = int.Parse(str2);
            c3 = int.Parse(str3);
            Console.WriteLine("你的名字是" + str + "数学" + c1 + "语文" + c2 + "英语" + c3);
            Console.WriteLine("Hello, World!");
        }
    }
}
