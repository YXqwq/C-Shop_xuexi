namespace 格林营救爱丽丝
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region 控制台相关设置
            //光标隐藏
            Console.CursorVisible = false;
            //窗口设置
            int ChuangKoC = 50;//长
            int ChuangKoK = 40;//宽
            //窗口大小
            Console.SetWindowSize(ChuangKoC, ChuangKoK);
            Console.SetBufferSize(ChuangKoC, ChuangKoK);
            #endregion
            #region 变量相关设置
            bool TuiChu = true;//控制开始场景退出游戏
            bool JieShuTuiChu = true;//控制结束场景退出游戏
            int ChangJingID = 1;//控制场景变换
            //随机数
            Random r = new Random();
            //玩家选择
            int XZ = 0;
            //选择位置
            int XZWeiZi = 0;//0指向开始1指向结束
            //控制游戏场景循环的结束
           bool GameTuiChu = true;
            //玩家移动输入
            char PlayerYiDong = '0';
            //玩家动作选择标记
            int DongZuoXZ = 0;
            //控制玩家选择结束
            bool DongZuoTuiChu = true;
            //控制结束场景显示的文字
            int JieShuWenZi = 1;
            #endregion
            #region boos属性相关
            int BossHP = 2000;//血量
            int BossATKMax = 150;//攻击力最大值
            int BossATKMin = 60;//攻击力最小值
            int BossX = 24;
            int BossY = 20;
            int BossGJ = 0;//boss攻击
            //boss图标
            string BossCot = "■";
            //boss颜色
            ConsoleColor BossColor = ConsoleColor.White;
            //boss回合计数
            int BossHuihe = 0;
            //boss使用的招式
            int BossJiNeng = 0;
            #endregion
            #region player玩家相关
            int PlayerHP = 800;
            int PlayerATKMax = 100;
            int PlayerATKMin = 50;
            int PlayerX = 2;
            int PlayerY = 1;
            int PlayerGJ = 0;//玩家攻击
            //玩家状态
            bool PlayerZhuangTai = true;//true为移动 0为战斗
            //玩家图标
            string PlayerCot = "●";
            //玩家颜色
            ConsoleColor PlayerColor = ConsoleColor.Yellow;
            //相关计数器
            //蓄力
            int XuLi = 0;
            //弹反
            int TanFan = 0;
            //闪避
            int SanBi = 0;
            #endregion
            #region 公主属性相关
            //公主图标
            string GongZhuCot = "★";
            //公主颜色
            ConsoleColor GongZhuColor = ConsoleColor.Yellow;
            //公主位置
            int GongZhuX = 24;
            int GongZhuY = 8;
            #endregion
            while (true)
            {
                switch (ChangJingID)
                {
                    case 1:
                        Console.Clear();
                        #region 开始场景
                        while (TuiChu)
                        {
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.SetCursorPosition(ChuangKoC / 2 - 6, 10);//居中光标
                            Console.WriteLine("格林营救爱丽丝");
                            Console.SetCursorPosition(ChuangKoC / 2 - 3, 15);//居中光标
                            Console.ForegroundColor = XZWeiZi == 0 ? ConsoleColor.Red : ConsoleColor.White;
                            Console.WriteLine("开始游戏");
                            Console.ForegroundColor = XZWeiZi == 0 ? ConsoleColor.White : ConsoleColor.Red;
                            Console.SetCursorPosition(ChuangKoC / 2 - 3, 17);//居中光标
                            Console.WriteLine("退出游戏");
                            //选择
                            XZ = Console.ReadKey(true).KeyChar;
                            switch (XZ)
                            {
                                case 'W':
                                case 'w':
                                    XZWeiZi--;
                                    if (XZWeiZi < 0)
                                        XZWeiZi = 1;
                                    break;
                                case 'S':
                                case 's':
                                    XZWeiZi++;
                                    if (XZWeiZi > 1)
                                        XZWeiZi = 0;
                                    break;
                                case 'J':
                                case 'j':
                                    if (XZWeiZi == 0)
                                    {
                                        ChangJingID = 2;
                                        TuiChu = false;
                                        GameTuiChu = true;
                                        JieShuTuiChu = true;
                                        //重置状态
                                        PlayerHP = 800;
                                        BossHP = 2000;
                                        XuLi = 0;
                                        TanFan = 0;
                                        SanBi = 0;
                                        PlayerX = 2;
                                        PlayerY = 1;
                                    }
                                    else
                                    {

                                        Environment.Exit(0);
                                        TuiChu = false;
                                    }
                                    break;
                            }

                        }

                        #endregion
                        break;
                    case 2:

                        Console.Clear();
                        #region 游戏场景
                        #region 不变的红墙
                        Console.ForegroundColor = ConsoleColor.Red;
                        for (int i = 0; i <= ChuangKoC -2; i+=2)
                        {
                            Console.SetCursorPosition(i,0);
                            Console.Write("■");
                            Console.SetCursorPosition(i, ChuangKoK - 10);
                            Console.Write("■");
                            Console.SetCursorPosition(i, ChuangKoK-1);
                            Console.Write("■");
                        }
                        for(int i = 0;i <= ChuangKoK - 1;i++)
                        {
                            Console.SetCursorPosition(0,i);
                            Console.Write("■");
                            Console.SetCursorPosition(ChuangKoC - 2, i);
                            Console.Write("■");

                        }
                        #endregion
                        while (GameTuiChu)
                        {
                            #region boss状态
                            // boss位置和公主信息
                            
                            if(BossHP > 0)
                            {
                                Console.SetCursorPosition(BossX, BossY);
                                Console.ForegroundColor = BossColor;
                                Console.Write(BossCot);
                            }
                            else if(BossHP<= 0)
                            {
                                Console.SetCursorPosition(GongZhuX, GongZhuY);
                                Console.ForegroundColor = GongZhuColor;
                                Console.Write(GongZhuCot);
                            }
                                //boss战斗信息
                                #endregion
                                #region 玩家状态
                                // 玩家位置信息
                                Console.SetCursorPosition(PlayerX, PlayerY);
                            if(PlayerHP > 0)
                            {
                                Console.ForegroundColor = PlayerColor;
                                Console.Write(PlayerCot);
                            }

                            //玩家战斗信息
                            #endregion
                            if (PlayerZhuangTai == true)
                            {
                                #region  玩家动作(移动)
                                PlayerYiDong = Console.ReadKey(true).KeyChar;//接收玩家输入的按键
                                switch (PlayerYiDong)
                                {
                                    case 'W':
                                    case 'w':
                                        Console.SetCursorPosition(PlayerX, PlayerY);
                                        Console.Write("  ");
                                        PlayerY--;
                                        if (PlayerY < 1)
                                            PlayerY = 1;
                                        if (PlayerX == BossX && PlayerY == BossY && BossHP > 0)
                                            PlayerY++;
                                        if (PlayerX == GongZhuX && PlayerY == GongZhuY && BossHP <= 0)
                                            PlayerY++;
                                        break;
                                    case 'S':
                                    case 's':
                                        Console.SetCursorPosition(PlayerX, PlayerY);
                                        Console.Write("  ");
                                        PlayerY++;
                                        if (PlayerY > ChuangKoK - 11)
                                            PlayerY--;
                                        if (PlayerX == BossX && PlayerY == BossY && BossHP > 0)
                                            PlayerY--;
                                        if (PlayerX == GongZhuX && PlayerY == GongZhuY && BossHP <= 0)
                                            PlayerY--;
                                        break;
                                    case 'A':
                                    case 'a':
                                        Console.SetCursorPosition(PlayerX, PlayerY);
                                        Console.Write("  ");
                                        PlayerX -= 2;
                                        if (PlayerX < 2)
                                            PlayerX = 2;
                                        if (PlayerX == BossX && PlayerY == BossY && BossHP > 0)
                                            PlayerX += 2;
                                        if (PlayerX == GongZhuX && PlayerY == GongZhuY && BossHP <= 0)
                                            PlayerX += 2;
                                        break;
                                    case 'D':
                                    case 'd':
                                        Console.SetCursorPosition(PlayerX, PlayerY);
                                        Console.Write("  ");
                                        PlayerX += 2;
                                        if (PlayerX > ChuangKoC - 4)
                                            PlayerX -= 2;
                                        if (PlayerX == BossX && PlayerY == BossY && BossHP > 0)
                                            PlayerX -= 2;
                                        if (PlayerX == GongZhuX && PlayerY == GongZhuY && BossHP <= 0)
                                            PlayerX -= 2;
                                        break;
                                    case 'J':
                                    case 'j':
                                        if ((PlayerX + 2 == BossX && PlayerY == BossY ||
                                            PlayerX - 2 == BossX && PlayerY == BossY ||
                                            PlayerY - 1 == BossY && PlayerX == BossX ||
                                            PlayerY + 1 == BossY && PlayerX == BossX) && BossHP > 0 )
                                        {
                                            PlayerZhuangTai = false;
                                            Console.SetCursorPosition(2, ChuangKoK - 9);
                                            Console.Write("开始战斗");
                                            Console.SetCursorPosition(2, ChuangKoK - 8);
                                            Console.Write("按任意键继续");
                                            Console.ReadKey(true);
                                        }
                                        else if((PlayerX + 2 == GongZhuX && PlayerY == GongZhuY ||
                                            PlayerX - 2 == GongZhuX && PlayerY == GongZhuY ||
                                            PlayerY - 1 == GongZhuY && PlayerX == GongZhuX ||
                                            PlayerY + 1 == GongZhuY && PlayerX == GongZhuX) && BossHP <= 0)
                                        {
                                            Console.SetCursorPosition(2, ChuangKoK - 9);
                                            Console.Write("拯救爱丽丝成功");
                                            Console.SetCursorPosition(2, ChuangKoK - 8);
                                            Console.Write("按任意键继续");
                                            Console.ReadKey(true);
                                            ChangJingID = 3;
                                            GameTuiChu = false;
                                            TuiChu = true;
                                            PlayerZhuangTai = true;
                                            JieShuWenZi = 1;
                                        }
                                            break;
                                }
                                #endregion
                            }
                            else if(PlayerZhuangTai == false)
                            {
                                #region 玩家动作(战斗)
                               
                                #region 清空面板
                                for(int i = ChuangKoK -9;i<ChuangKoK-1;i++)
                                {
                                    Console.SetCursorPosition(2,i);
                                    Console.Write("                                             ");
                                }
                                #endregion
                                #region 当前局势
                                Console.SetCursorPosition(2, ChuangKoK - 9);
                                Console.Write("玩家血量为{0} boss血量为{1}",PlayerHP,BossHP);
          
                                #endregion
                                Console.ReadKey(true);
                                #region 清空面板
                                for (int i = ChuangKoK - 9; i < ChuangKoK - 1; i++)
                                {
                                    Console.SetCursorPosition(2, i);
                                    Console.Write("                                             ");
                                }
                                #endregion
                                #region 动作选择
                                DongZuoTuiChu = true;
                                while (DongZuoTuiChu)
                                {
                                    Console.SetCursorPosition(2, ChuangKoK - 9);
                                    Console.ForegroundColor = DongZuoXZ == 0 ? ConsoleColor.Red : ConsoleColor.White;
                                    Console.Write("攻击");
                                    Console.SetCursorPosition(2, ChuangKoK - 8);
                                    Console.ForegroundColor = DongZuoXZ == 1 ? ConsoleColor.Red : ConsoleColor.White;
                                    Console.Write("弹反");
                                    Console.SetCursorPosition(2, ChuangKoK - 7);
                                    Console.ForegroundColor = DongZuoXZ == 2 ? ConsoleColor.Red : ConsoleColor.White;
                                    Console.Write("蓄力");
                                    Console.SetCursorPosition(2, ChuangKoK - 6);
                                    Console.ForegroundColor = DongZuoXZ == 3 ? ConsoleColor.Red : ConsoleColor.White;
                                    Console.Write("闪避");
                                    Console.SetCursorPosition(2, ChuangKoK - 5);
                                    Console.ForegroundColor = DongZuoXZ == 4 ? ConsoleColor.Red : ConsoleColor.White;
                                    Console.Write("狮子斩");
                                    PlayerYiDong = Console.ReadKey(true).KeyChar;//接收玩家输入的按键
                                    switch (PlayerYiDong)
                                    {
                                        case 'W':
                                        case 'w':
                                            DongZuoXZ--;
                                            if (DongZuoXZ < 0)
                                                DongZuoXZ = 4;
                                            break;
                                        case 'S':
                                        case 's':
                                            DongZuoXZ++;
                                            if (DongZuoXZ > 4)
                                                DongZuoXZ = 0;
                                            break;
                                        case 'J':
                                        case 'j':

                                            DongZuoTuiChu = false;
                                            break;
                                    }

                                }

                                #endregion
                                #region 玩家回合
                                #region 清空面板
                                for (int i = ChuangKoK - 9; i < ChuangKoK - 1; i++)
                                {
                                    Console.SetCursorPosition(2, i);
                                    Console.Write("                                             ");
                                }
                                #endregion
                                PlayerGJ = 0;//先重置攻击力
                                SanBi = 0;
                                TanFan = 0;
                                if (DongZuoXZ == 0)
                                {
                                    if(XuLi > 0)
                                    {
                                        PlayerGJ = (r.Next(PlayerATKMin, PlayerATKMax))*(XuLi+1);//得到最后的攻击
                                        XuLi = 0;
                                    }
                                    else
                                    {
                                        PlayerGJ = (r.Next(PlayerATKMin, PlayerATKMax));
                                    }
                                        BossHP = BossHP - PlayerGJ;//开始攻击
                                    Console.SetCursorPosition(2, ChuangKoK - 9);
                                    Console.Write("使出了攻击！造成了{0}点伤害！",PlayerGJ);
                                  
                                }
                                else if(DongZuoXZ == 1)
                                {
                                    TanFan++;
                                    Console.SetCursorPosition(2, ChuangKoK - 9);
                                    Console.Write("使出了弹反！");
                                }
                                else if(DongZuoXZ == 2)
                                {
                                    XuLi++;
                                    Console.SetCursorPosition(2, ChuangKoK - 9);
                                    Console.Write("使出了蓄力！");
                                }
                                else if(DongZuoXZ == 3)
                                {
                                    SanBi++;
                                    Console.SetCursorPosition(2, ChuangKoK - 9);
                                    Console.Write("使出了闪避!");
                                }
                                else if(DongZuoXZ == 4)
                                {
                                    if (XuLi > 0)
                                    {
                                        PlayerGJ = (r.Next(PlayerATKMin, PlayerATKMax)) * (XuLi + 1) * 2;//得到最后的攻击
                                        XuLi = 0;
                                    }
                                    else
                                    {
                                        PlayerGJ = (r.Next(PlayerATKMin, PlayerATKMax)) * 2;
                                    }

                                    BossHP = BossHP - PlayerGJ;//开始攻击
                                    PlayerHP = PlayerHP - (PlayerGJ/3)-25;
                                    Console.SetCursorPosition(2, ChuangKoK - 9);
                                    Console.Write("使出了狮子斩!对自身扣{0}点血,造成了{1}点伤害", (PlayerGJ / 3)+25,PlayerGJ);
                                }
                                Console.ReadKey(true);
                                #endregion
                                #region 清空面板
                                for (int i = ChuangKoK - 9; i < ChuangKoK - 1; i++)
                                    {
                                        Console.SetCursorPosition(2, i);
                                        Console.Write("                                             ");
                                    }
                                #endregion
                                #region boss回合
                                BossGJ = 0;
                                //先判断死没死
                                if(BossHP <= 0)
                                {
                                    ;
                                }
                                else
                                {
                                    //随机boss招式
                                    if (BossHuihe == 0)//在用龙之吐息和冲撞时不会变招式
                                    {
                                        BossJiNeng = r.Next(0, 4);
                                        //
                                    }
                                    BossGJ = 0;
                                    switch (BossJiNeng)
                                    {
                                        case 0://龙之吐息
                                            if (BossHuihe == 3)
                                            {
                                                BossGJ = (r.Next(BossATKMin, BossATKMax)) * 3;//伤害计算
                                                Console.SetCursorPosition(2, ChuangKoK - 9);
                                                Console.Write("boss使用了龙之吐息!");
                                               
                                            }
                                            else
                                            {
                                               
                                                Console.SetCursorPosition(2, ChuangKoK - 9);
                                                Console.Write("boss无动于衷");

                                            }
                                            break;
                                        case 1://冲撞
                                            if (BossHuihe == 2)
                                            {
                                                BossGJ = (r.Next(BossATKMin, BossATKMax)) * 2;
                                                Console.SetCursorPosition(2, ChuangKoK - 9);
                                                Console.Write("boss使出了冲撞");
                                            
                                            }
                                            else
                                            {
                                                
                                                Console.SetCursorPosition(2, ChuangKoK - 9);
                                                Console.Write("boss无动于衷");
                                            }
                                            break;
                                        case 2://爪击
                                            BossGJ = r.Next(BossATKMin, BossATKMax);
                                            Console.SetCursorPosition(2, ChuangKoK - 9);
                                            Console.Write("boss使用了爪击");
                                            break;
                                        case 3://龙舞
                                            BossATKMax += 25;
                                            BossATKMin += 25;
                                            Console.SetCursorPosition(2, ChuangKoK - 9);
                                            Console.Write("boss使用了龙舞!");
                                            break;
                                    }
                                    Console.ReadKey(true);
                                    #region 清空面板
                                    for (int i = ChuangKoK - 9; i < ChuangKoK - 1; i++)
                                    {
                                        Console.SetCursorPosition(2, i);
                                        Console.Write("                                             ");
                                    }
                                    #endregion
                                    //怪物攻击

                                    if( BossJiNeng == 2)
                                    {
                                        if(TanFan == 1)
                                        {
                                            BossHP -= BossGJ;
                                            Console.SetCursorPosition(2, ChuangKoK - 9);
                                            Console.Write("弹反成功！");
                                            Console.SetCursorPosition(2, ChuangKoK - 8);
                                            Console.Write("对boss反弹了{0}点伤害！",BossGJ);
                                        }
                                        else
                                        {
                                            PlayerHP -= BossGJ;
                                            Console.SetCursorPosition(2, ChuangKoK - 9);
                                            Console.Write("Boss对你造成了{0}点伤害!", BossGJ);
                                        }
                                    }
                                    else if (BossJiNeng == 1)//冲撞
                                    {
                                        if (BossHuihe == 2 && TanFan == 1)
                                        {
                                            BossHP -= BossGJ;
                                            Console.SetCursorPosition(2, ChuangKoK - 9);
                                            Console.Write("弹反成功！");
                                            Console.SetCursorPosition(2, ChuangKoK - 8);
                                            Console.Write("对boss反弹了{0}点伤害！", BossGJ);
                                            BossHuihe = 0;
                                        }
                                        else if(BossHuihe == 2 && TanFan !=1)
                                        {
                                            PlayerHP -= BossGJ;
                                            Console.SetCursorPosition(2, ChuangKoK - 9);
                                            Console.Write("Boss对你造成了{0}点伤害!", BossGJ);
                                            BossHuihe = 0;
                                        }
                                        else if(BossHuihe<2)
                                        {
                                            BossHuihe++;
                                            Console.SetCursorPosition(2, ChuangKoK - 9);
                                            Console.Write("Boss似乎在准备什么", BossGJ);
                                        }
                                    }
                                    else if (BossJiNeng == 0)//龙之吐息
                                    {
                                        if (BossHuihe == 3 && SanBi == 1)
                                        {
                                            Console.SetCursorPosition(2, ChuangKoK - 9);
                                            Console.Write("闪避成功！");
                                            BossHuihe = 0;
                                        }
                                        else if (BossHuihe == 3 && SanBi !=1)
                                        {
                                            PlayerHP -= BossGJ;
                                            Console.SetCursorPosition(2, ChuangKoK - 9);
                                            Console.Write("Boss对你造成了{0}点伤害！不疼qwq ", BossGJ);
                                            BossHuihe = 0;
                                        }
                                        else if(BossHuihe < 3)
                                        {
                                            BossHuihe++;
                                            Console.SetCursorPosition(2, ChuangKoK - 9);
                                            Console.Write("Boss似乎在准备什么", BossGJ);
                                        }
                                    }
                                    else if (BossJiNeng == 3)//龙舞
                                    {
                                        Console.SetCursorPosition(2, ChuangKoK - 9);
                                        Console.Write("攻击力上升了！");
                                    }
                                        Console.ReadKey(true);
                                }

                                #endregion
                                #region  回合结算
                                if(BossHP <= 0 )//Boss死亡
                                {
                                    PlayerZhuangTai = true;
                                    Console.SetCursorPosition(BossX, BossY);
                                    Console.Write("  ");
                                    Console.SetCursorPosition(2, ChuangKoK - 9);
                                    Console.Write("已打败白龙希斯!    ");
                                    Console.ReadKey(true);
                                    Console.SetCursorPosition(2, ChuangKoK - 8);
                                    Console.Write("获得了月光大剑!    ");
                                    Console.ReadKey(true);
                                    Console.SetCursorPosition(2, ChuangKoK - 7);
                                    Console.Write("快去拯救爱丽丝吧!    ");
                                    Console.ReadKey(true);
                                    PlayerZhuangTai = true;
                                    #region 清空面板
                                    for (int i = ChuangKoK - 9; i < ChuangKoK - 1; i++)
                                    {
                                        Console.SetCursorPosition(2, i);
                                        Console.Write("                                             ");
                                    }
                                    #endregion
                                }
                                if (PlayerHP <= 0 )
                                {
                                    #region 清空面板
                                    for (int i = ChuangKoK - 9; i < ChuangKoK - 1; i++)
                                    {
                                        Console.SetCursorPosition(2, i);
                                        Console.Write("                                             ");
                                    }
                                    #endregion
                                    //玩家死亡
                                    Console.SetCursorPosition(2, ChuangKoK - 9);
                                    Console.Write("GAME OVER");
                                    Console.SetCursorPosition(2, ChuangKoK - 8);
                                    Console.Write("按任意键继续");
                                    Console.ReadKey(true);
                                    ChangJingID = 3;
                                    GameTuiChu = false;
                                    TuiChu = true;
                                    PlayerZhuangTai = true;
                                    JieShuWenZi = 0;
                                    
                                }
                                #endregion



                                #endregion
                           }

                        }
                        #endregion
                        break;
                    case 3:
                        Console.Clear();
                        #region 结束场景
                        while (JieShuTuiChu)
                        {
                            if(JieShuWenZi == 1)
                            {
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.SetCursorPosition(ChuangKoC / 2 - 5, 10);//居中光标
                                Console.WriteLine("我深爱着你");
                                Console.SetCursorPosition(ChuangKoC / 2 - 3, 11);
                                Console.WriteLine("--致爱你的爱丽丝");
                            }
                            else if(JieShuWenZi == 0)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.SetCursorPosition(ChuangKoC / 2 - 4, 10);//居中光标
                                Console.WriteLine("GameOver");
                                Console.SetCursorPosition(ChuangKoC / 2 - 1, 11);
                                Console.WriteLine("--菜");
                            }
                                Console.SetCursorPosition(ChuangKoC / 2 - 3, 15);//居中光标
                            Console.ForegroundColor = XZWeiZi == 0 ? ConsoleColor.Red : ConsoleColor.White;
                            Console.WriteLine("重新游戏");
                            Console.ForegroundColor = XZWeiZi == 0 ? ConsoleColor.White : ConsoleColor.Red;
                            Console.SetCursorPosition(ChuangKoC / 2 - 3, 17);//居中光标
                            Console.WriteLine("退出游戏");
                            //选择
                            XZ = Console.ReadKey(true).KeyChar;
                            switch (XZ)
                            {
                                case 'W':
                                case 'w':
                                    XZWeiZi--;
                                    if (XZWeiZi < 0)
                                        XZWeiZi = 1;
                                    break;
                                case 'S':
                                case 's':
                                    XZWeiZi++;
                                    if (XZWeiZi > 1)
                                        XZWeiZi = 0;
                                    break;
                                case 'J':
                                case 'j':
                                    if (XZWeiZi == 0)
                                    {
                                        ChangJingID = 1;
                                        JieShuTuiChu = false;
                                        TuiChu = true;
                                        PlayerZhuangTai = true;
                                    }
                                    else
                                    {

                                        Environment.Exit(0);
                                        TuiChu = false;
                                    }
                                    break;
                            }

                        }

                        
                       #endregion

                        break;

                }
                
            }
            
                

            
        }
    }
}
