using System;
using System.Collections.Generic;
using System.Text;

namespace The_World
{
    public class Monstor
    {
        public int id;
        public int dream;
        public string name;
        public int dreamattack;
        public int hp;
        public string beforefight;
        public string playeranswer;
        public static void Show(Monstor monstor)
        {
            int x = 30, y = 4;
            Console.SetCursorPosition(x, y);
            Console.WriteLine("怪物信息一览：         ");
            Console.SetCursorPosition(x, y + 1);
            Console.ReadKey(true);
            Console.SetCursorPosition(x, y + 2);
            Console.WriteLine("怪物名称：            " + monstor.name);
            Console.SetCursorPosition(x, y + 3);
            Console.ReadKey(true);
            Console.SetCursorPosition(x, y + 4);
            Console.WriteLine("怪物所携带梦之精华：  " + monstor.dream);
            Console.SetCursorPosition(x, y + 5);
            Console.ReadKey(true);
            Console.SetCursorPosition(x, y + 6);
            Console.WriteLine("怪物生命值 ：         ???");
            Console.SetCursorPosition(x, y + 7);
            Console.ReadKey(true);
            Console.SetCursorPosition(x, y + 8);
            Console.WriteLine("怪物攻击力 ：         ???");


        }

        public static void ShowEnd()
        {
            int x = 30, y = 4;
            Console.SetCursorPosition(x, y);
            Console.WriteLine("                                         ");
            Console.SetCursorPosition(x, y + 2);
            Console.WriteLine("                                         ");
            Console.SetCursorPosition(x, y + 4);
            Console.WriteLine("                                        ");
            Console.SetCursorPosition(x, y + 6);
            Console.WriteLine("                                        ");
            Console.SetCursorPosition(x, y + 8);
            Console.WriteLine("                                        ");
        }

        public static void Turn(Monstor monstor)
        {
 
            Random random = new Random();
            int choose = random.Next(1, 2);
            switch (choose)
            {
                case 1:
                    int damage = Battle.AttackDamage(monstor.dreamattack);
                    Battle.BattleInformation(monstor.name, Player.Instance().name, damage);
                    Player.Instance().hp -= damage;
                    Player.Instance().Show();
                    break;

                case 2:
                    Skill monsterskill;
                    int a = random.Next(1, 2);//选择技能类型
                    if (a == 1)
                    {
                        a = random.Next(1, Program.monsterskilltype1maxnumber);
                        monsterskill = GameRes.skill[a + 10];
                    }
                    else
                    {
                        a = random.Next(1, Program.monsterskilltype2maxnumber);
                        monsterskill = GameRes.skill[a + 20];
                    }
                    int skilleffect = Skill.UsingSkill(ref monstor,
                         monsterskill, monstor.dreamattack);
                    if (monsterskill.type == 1)
                    {//使用伤害性技能
                        Player.Instance().hp -= skilleffect;
                        Battle.BattleInformation(monstor.name, Player.Instance().name, skilleffect);
                    }
                    else
                    {//调用辅助类技能
                        Battle.BattleInformation(monstor.name, Player.Instance().name, skilleffect, 2,
                            monsterskill.describe);

                    }
                    Player.Instance().Show();
                    break;
            }//1为使用平A 2为技能 

        }


    }   //怪物属性
}
