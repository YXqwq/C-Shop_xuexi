namespace 枚举练习2_12._18
{


    enum XingBaKe
    {
      Zhong,
      Da,
      ChaoDa

    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("请输入要购买的类型");
            Console.WriteLine("0：中杯 1：大杯 2：超大杯");
            int a = int.Parse(Console.ReadLine());
            int JiaGe = 0;
            string XingHao = "0";
            XingBaKe LeiXing = (XingBaKe)a;
            switch (LeiXing)
            {
                case XingBaKe.Zhong:
                    XingHao = "中杯";
                    JiaGe = 35;
                    break;
                case XingBaKe.Da:
                    XingHao = "大杯";
                    JiaGe = 40;
                    break;
                case XingBaKe.ChaoDa:
                    XingHao = "超大杯";
                    JiaGe = 43;
                    break;

            }

            Console.WriteLine("你购买了{0}咖啡，花费了{1}元",XingHao,JiaGe);

        }
    }
}
