using System;
using System.Collections.Generic;
using System.Text;

namespace The_World
{
    public class Player
    {
        #region 勇者属性
        public Weapon dreamsword;
        public int luck;
        public string name;
        public int hp;
        public int dream;
        public int crit;
        public int id;
        public int skillamount = 4;
        public Skill[] playerskill = new Skill[4];
        public const int left = 150; public const int top = 20;
        #endregion
        private static Player instance = null;
        private Player() { }
        public static Player Instance()
        {
            if (instance == null)
            {
                instance = new Player();
            }
            return instance;
        }

        public void Show()
        {
            int j = 0;
            Console.SetCursorPosition(left, top - 14);
            Console.WriteLine("姓名：     " + name + "   ");
            Console.SetCursorPosition(left, top - 12);
            Console.WriteLine("生命值:    " + Player.Instance().hp + "  ");
            Console.SetCursorPosition(left, top - 10);
            Console.WriteLine("目前所持有的梦之精华:  " + Player.Instance().dream + "   ");
            Console.SetCursorPosition(left, top - 8);
            Console.WriteLine("武器名称：             " + dreamsword.name);
            Console.SetCursorPosition(left, top - 6);
            Console.WriteLine("武器等级：             " + dreamsword.level);
            Console.SetCursorPosition(left, top - 4);
            Console.WriteLine("武器攻击力：           " + dreamsword.dreamattack);
            Console.SetCursorPosition(left, top - 2);
            Console.WriteLine("武器升级所需的梦之精华:" + dreamsword.experience);

            Console.SetCursorPosition(left, top - 1);
            Console.WriteLine("目前已掌握技能一览:                   ");

            for (int i = 0; i < 3; i++)
            {

                Console.SetCursorPosition(left, top + j);

                Console.WriteLine("技能{0}  名称  {1}  技能消耗值:{2}   ", i + 1, Player.Instance().playerskill[i].name, Player.Instance().playerskill[i].dream);
                Console.SetCursorPosition(left, top + 1 + j);
                Console.WriteLine("      ————{0}     ", Player.Instance().playerskill[i].describe);
                j += 2;
            }
            Console.SetCursorPosition(left, top + j);
            Console.WriteLine("技能4  名称  {0}  技能消耗值:???   ", Player.Instance().playerskill[3].name);
            Console.SetCursorPosition(left, top + 1 + j);
            Console.WriteLine("      ————{0}    ", Player.Instance().playerskill[3].describe);

        }           //展示勇者属性

        public void Turn(ref Monstor monstor)
        {
            GameHelper.Talking(Player.Instance().name, "这次决定很重要……我想——");
            GameHelper.Talking("1.那就普通攻击吧！", "2.利用梦之精华释放技能好了", false);

            int a = int.Parse(Console.ReadLine());
            GameHelper.TalkingEnd(); int skilleffect;
            switch (a)
            {
                case 1:
                    int damage = Battle.AttackDamage(Player.Instance().dreamsword.dreamattack);
                    Battle.BattleInformation(Player.Instance().name, monstor.name, damage);
                    monstor.hp -= damage;
                    Player.Instance().Show();
                    break;
                case 2:
                    GameHelper.Talking("", "那这次就决定是技能——", false);
                    int skillid = int.Parse(Console.ReadLine()) - 1;//从技能1到技能4选择
                    GameHelper.TalkingEnd();
                    if (Skill.IfSkill(Player.Instance().playerskill[skillid]))//技能释放成功
                    {
                        skilleffect = Skill.UsingSkill(ref monstor,
                        Player.Instance().playerskill[skillid], dreamsword.dreamattack);
                        if (Instance().playerskill[skillid].type == 1)
                        {//使用伤害性技能
                            monstor.hp -= skilleffect;
                            Battle.BattleInformation(Player.Instance().name, monstor.name, skilleffect);

                        }
                        else
                        {//调用辅助类技能
                            Battle.BattleInformation(Player.Instance().name, monstor.name, skilleffect, 2,
                            Player.Instance().playerskill[skillid].describe);

                        }
                        Player.Instance().Show();
                    }
                    break;
            }//1为使用平A 2为技能 
        }

        public static void ReSet(int hp,int dream)
        {
            Player.Instance().hp = hp+=20;
            Player.Instance().dream = dream;
        }
        
        public static void Sleep()
        {
            if (Player.Instance().dream > 20)
            {
                Player.Instance().dream -= 20;
            }
            else
            {
                Player.Instance().dream = 0;
            }
        }









    }   //勇者类



}
