namespace 枚举练习1_12._18
{
    enum SteamZT
    {
        ZaiXian,
        YinShen,
        LiKai,
        LiXian

    }

    internal class Program
    {
        static void Main(string[] args)
        {
            SteamZT P = SteamZT.ZaiXian;

            Console.WriteLine("请输入状态");
            Console.WriteLine("0：在线 1：隐身 2：离开 3：离线");
            int a = int.Parse(Console.ReadLine());
            SteamZT ZhuangTai = (SteamZT)a;


        }
    }
}
