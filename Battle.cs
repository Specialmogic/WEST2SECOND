using System;
using System.Collections.Generic;
using System.Text;

namespace The_World
{
    public static class Battle
    {
        public static bool WinOrLose(bool winorlose)
        {
            const int lieshu = 50;
            if (winorlose == false)
            {

                GameHelper.Talking("", "不行，我还不能放弃！可我", false,lieshu, 36);
                Console.SetCursorPosition(lieshu, 38);
                Console.WriteLine("1.这次就这样败了吗……我不甘心！");
                Console.SetCursorPosition(lieshu, 39);
                Console.WriteLine("2.就这样吧……");
                Console.SetCursorPosition(lieshu, 40);


                int choose = int.Parse(Console.ReadLine());
                if (choose == 2)
                {
                    GameHelper.TalkingEnd(lieshu);
                    GameHelper.TalkingEnd(lieshu, 38);
                    Environment.Exit(0);
                    return false;
                }
                GameHelper.TalkingEnd(lieshu, 36);
                GameHelper.TalkingEnd(lieshu, 38);
                return false;
            }
            else
            {
                GameHelper.TalkingEnd(lieshu, 36);
                GameHelper.TalkingEnd(lieshu, 38);
                return true;
            }
        } //如果失败还想继续挑战返回false；
        //失败不想挑战直接退出程序；胜利直接返回true
        public static int AttackDamage(int attack,int luck=135,int crit=35)
        {
            Random random = new Random();
            float a = (float)(random.Next(7, 13)) / 10.0f;
            int b = random.Next(1, 100);
            if (b <= crit)
            {
                attack = (int)(float)(attack * luck / 100.0f)+1;
            }
            return (int)(attack * a);
        }//平A 伤害

       //1表示通用的伤害输出
            //2表示怪物使用技能产生效果     3表示勇者使用技能额外产生的效果
            //战斗日志输出 
        public static void BattleInformation(string attackname,string beatenname,
            int damageorluck,int type=1,string skilldescribe="" )
          
        {    int x=80, y = 26;
            Console.SetCursorPosition(x++, y++);
            switch (type)
            {
                case 1:
                    Console.WriteLine(attackname + "对 {0} 造成了 {1} 点伤害        ",beatenname, damageorluck);
                    Console.SetCursorPosition(x, y);
                    Console.ReadKey(true);
                
                    break;
                case 2:
                    Console.WriteLine(attackname + "  " + skilldescribe+ "                 ");
                    Console.SetCursorPosition(x, y);
                    Console.ReadKey(true);
                    break;

            }
             
            Console.SetCursorPosition(x-1, y-1);
            Console.WriteLine("                                                                                 ");
        }
        public static bool BattleFighting(ref Monstor monstor, int xh = 0)
        {
            bool dreamoff = false;//默认返回没有进入梦之地
            int duihuacishu = 0;
            GameHelper.Talking(monstor.name, monstor.beforefight);
            Console.ReadKey(true);
            GameHelper.Talking(Player.Instance().name, monstor.playeranswer);
            Monstor.Show(monstor);
            GameHelper.TalkingEnd();
            bool winorlose = false;//失败时会不断挑战
            int hp = Player.Instance().hp;
            int dream = Player.Instance().dream;
            while (winorlose != true)
            {
                while ( monstor.hp >= 0&&Player.Instance().hp>0)
                {
                    
                    Player.Instance().Turn(ref monstor);
                    Monstor.Turn(monstor);
                    Player.Instance().Show();duihuacishu++;
                    if (duihuacishu % 2 == 0&&duihuacishu<8)  //每隔一段时间触发对话
                    {
                        
                        int j = xh + 4;
                        for(;xh<j ;xh++)
                        {
                            GameHelper.Talking(GameRes.dialogue[xh].name, GameRes.dialogue[xh].text);
                            Console.ReadKey(true);
                        }
                    }
                    
                }
                if (Player.Instance().hp <= 0)
                {
                    winorlose = false; winorlose = WinOrLose(winorlose);
                    Player.ReSet(hp, dream);
                }
                else
                {
                    winorlose = true;
                }
            }
            if (monstor.id % 2 != 0&& monstor.id <= 4)
            {
                GameHelper.Talking("", "是时候给予致命一击了！");
                GameHelper.TalkingEnd();
                GameHelper.Talking("1.给予致命一击，收割大量梦之精华！", "2.够了吧……不知道为什么，忍不下心来……", false);
                int choose = int.Parse(Console.ReadLine());
                if (choose == 1)
                {
                    Player.Instance().dream += monstor.dream += 20;
                    Player.Instance().hp += 20;
                    GameHelper.Talking("", "战斗结束！                 ", false);
                    Console.ReadKey(true);
                    GameHelper.TalkingEnd();
                    Player.Instance().Show(); Monstor.ShowEnd();


                }
                else
                {
                    Player.Instance().dream += (monstor.dream / 4);
                    Player.Instance().hp += 40;
                    Console.SetCursorPosition(50, 39);
                    Console.ReadKey(true);
                    Player.Instance().Show(); Monstor.ShowEnd();
                    dreamoff = true;
                }
            }
            return dreamoff;

        }
        //战斗进程


    }
}
