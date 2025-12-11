namespace 随机数练习_12._11
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("按1进行攻击");

            //玩家攻击力
            Random wanjiaG = new Random();
            //获取经验值
            Random JingYan = new Random();
            //怪物血量
            int a = 20;
            //怪物防御
            int b = 10;
            //攻击
            int GJ = 0;
            //
            int JY = 0;
            while(a > 0)
            {
                Console.WriteLine("怪物血量为：" + a);
                int sb = Console.ReadKey(true).KeyChar;

                if (sb == '1')
                {
                    GJ = wanjiaG.Next(8,20);
                    if(GJ > b)
                    {
                        a = a +b - GJ;
                    }
                    
                }
            }
            Console.WriteLine("打败怪物了");
            JY = JingYan.Next(10,20);
            Console.WriteLine("获得" + JY + "经验值！");
        }
    }
}
