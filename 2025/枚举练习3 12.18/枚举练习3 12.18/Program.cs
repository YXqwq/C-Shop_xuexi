namespace 枚举练习3_12._18
{
    enum Six
    {
        Nan,
        Nv
    }

    enum ZhiYe
    {
        ZhanShi,
        LieRe,
        FaShi
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("请输入性别 0:男 1:女");
            Six XingBie = (Six)int.Parse(Console.ReadLine());
            Console.WriteLine("请输入职业 0:战士 1:猎人 2:法师");
            ZhiYe ZY = (ZhiYe)int.Parse(Console.ReadLine());
            int FangYu = 0;
            int GongJi = 0;
            string JiNeng = "0";
            string XB = "0";
            string ZhiYeA = "0";
            switch (XingBie)
            {
                case Six.Nan:
                    GongJi += 50;
                    FangYu += 100;
                    XB = "男性";
                    break;
                    case Six.Nv:
                    GongJi += 150;
                    FangYu += 20;
                    XB = "女性";
                    break;
            }
            switch (ZY)
            {
                case ZhiYe.ZhanShi:
                    GongJi += 20;
                    FangYu += 100;
                    JiNeng = "狮子斩";
                    ZhiYeA = "战士";
                    break;
                    case ZhiYe.LieRe:
                    GongJi += 120;
                    FangYu += 30;
                    JiNeng = "假死";
                    ZhiYeA = "猎人";
                    break;
                    case ZhiYe.FaShi:
                    GongJi += 200;
                    FangYu += 10;
                    JiNeng = "彗星亚兹勒";
                    ZhiYeA = "法师";
                    break;



            }
            Console.WriteLine("你选择了“{0}{1}”,攻击力{2}, 防御力{3},职业技能:{4}", XB, ZhiYeA, GongJi, FangYu, JiNeng);




        }
    }
}
