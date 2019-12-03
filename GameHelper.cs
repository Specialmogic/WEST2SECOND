using System;
using System.Collections.Generic;
using System.Text;

namespace The_World
{
    class GameHelper
    {
       
        public static void Talking(string name,string sentence,bool mh=true,int i=50,int j=37)
       {
            Console.SetCursorPosition(i, j++);
            if (mh == true)
            {
                 Console.WriteLine(name + ":                          ");
            }
            else
            {
                Console.WriteLine(name + "                                        ");
            }
            Console.SetCursorPosition(i, j++);
            Console.WriteLine(sentence+ "                                                                                                  ");
            Console.SetCursorPosition(i, j);
        }
        public static void TalkingEnd(int i = 50, int j = 37)
        {
            Console.SetCursorPosition(i, j++);
            Console.WriteLine("                                                                                       ");
            Console.SetCursorPosition(i, j++);
            Console.WriteLine("                                                                                                                                             ");
            Console.SetCursorPosition(i, j++);
            Console.WriteLine("                                                 ");
            Console.SetCursorPosition(i, j);
            Console.WriteLine("                                                    ");

        }

        private static void TextRain(string s ,int i=85,int j = 23)
        {
             Console.SetCursorPosition(i, j);
            for (int ik = 0; ik<s.Length; ik++)
            {
                Console.Write(s[ik]);
                for (int jl = 0; jl < 15000 * 10000; jl++)
                {
                    ;
                }
            }
        }
        public static void StartGame()
        {

            Console.ForegroundColor = ConsoleColor.Red;
             TextRain("The World . ");
             TextRain( "世 界 因   ________  而 改  变。", 75,  24);
             TextRain("The World . ",85,25);
             Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
             #region  序章
            int xh ;int choose;int truth = 0;
            for ( xh=Program.scene0_start;xh<Program.scene0_end;xh++)
            {
               GameHelper.Talking(GameRes.dialogue[xh].name, GameRes.dialogue[xh].text);
                Console.ReadKey(true);
                if (xh == 5)
                {
                    GameHelper.Talking("1.让世界长存——", " 2.让世界破灭——", false);
                    Console.ReadKey(true);
                }
             }TalkingEnd();
            xh =100;
            
            GameHelper.Talking(GameRes.dialogue[xh].name, GameRes.dialogue[xh].text);
             Console.ReadKey(true);
            xh++;  GameHelper.Talking(GameRes.dialogue[xh].name, GameRes.dialogue[xh].text);
            Console.ReadKey(true);
            #region 选择分支的粗略实现;选择1
            xh++;GameHelper.Talking("1.你是谁？"," 2.我这是在哪里？", false);
                
            choose = int.Parse(Console.ReadLine());
            if (choose == 1)
            {
                xh = 110; GameHelper.Talking(GameRes.dialogue[xh].name, GameRes.dialogue[xh].text);
                Console.ReadKey(true);
                xh++; GameHelper.Talking(GameRes.dialogue[xh].name, GameRes.dialogue[xh].text);
                Console.ReadKey(true);
            }
            else
            {
                xh = 120;
                GameHelper.Talking(GameRes.dialogue[xh].name, GameRes.dialogue[xh].text);
                Console.ReadKey(true);
            }
            #endregion

            for (xh = 130; xh <= 135; xh++)
            {
                GameHelper.Talking(GameRes.dialogue[xh].name, GameRes.dialogue[xh].text);
                Console.ReadKey(true);
                if (xh == 132)
                {
                  GameHelper.Talking("1.那我是谁？", "2.我是，一个勇者？", false);
                    Console.ReadKey(true);
                }
            }
            GameHelper.Talking("1.魔王？我要怎么打败他？", "2.什么，魔王！我要怎么打败他？", false);
            choose = int.Parse(Console.ReadLine());
            if (choose == 1)
            {
                xh = 140;
                GameHelper.Talking(GameRes.dialogue[xh].name, GameRes.dialogue[xh].text);
                Console.ReadKey(true);
                xh++; GameHelper.Talking(GameRes.dialogue[xh].name, GameRes.dialogue[xh].text);
                Console.ReadKey(true);
                xh++; GameHelper.Talking(GameRes.dialogue[xh].name, GameRes.dialogue[xh].text);
                Console.ReadKey(true);
            }
            for (xh = 150; xh <= 176; xh++)
            {
                GameHelper.Talking(GameRes.dialogue[xh].name, GameRes.dialogue[xh].text);
                Console.ReadKey(true);
            }

            Player.Instance().Show();//音效呲呲
            
            //每章开头与结尾询问是否升级武器、技能（30精华一个）
            //战斗前 简单介绍勇者西行时在想的事情
            //遇到敌人 第一选择比如跳开攻击或者迎接攻击，影响战斗状态
            //战斗中敌人会说话，勇者做出对应的回应（暂不设选择分支）
            //战斗结束勇者选择进入梦境（即梦中梦）就能进一步了解这个世界的秘密
            //如此循环2章，进入终章
            //终章故事十分精彩，争取插入BGM.
            #endregion

            #region 第一章
            Monstor monstor = GameRes.monstor[1];
            for (xh = 200; xh <= 208; xh++)
            {
                GameHelper.Talking(GameRes.dialogue[xh].name, GameRes.dialogue[xh].text);
                Console.ReadKey(true);
            }//战斗前
            if (Battle.BattleFighting(ref monstor, 210))//进入梦境了
            {
                truth++;//最终结局要求
                for (xh = 240; xh <= 264; xh++)
                {
                    GameHelper.Talking(GameRes.dialogue[xh].name, GameRes.dialogue[xh].text);
                    Console.ReadKey(true);
                    if (xh == 249)
                    {
                         GameHelper.Talking("1.坐下", "2.有点累了……", false);
                         choose = int.Parse(Console.ReadLine());
                    }
                }//梦境战斗前

                monstor = GameRes.monstor[2];
                Battle.BattleFighting(ref monstor, 270);
                for (xh = 282; xh <= 286; xh++)
                {
                    GameHelper.Talking(GameRes.dialogue[xh].name, GameRes.dialogue[xh].text);
                    Console.ReadKey(true);
                }
                GameHelper.Talking(GameRes.dialogue[xh].name, GameRes.dialogue[xh].text);
                choose = int.Parse(Console.ReadLine());
                switch (choose)
                {
                    case 1:
                        for (xh = 310; xh <=317;xh++)
                        {
                            GameHelper.Talking(GameRes.dialogue[xh].name, GameRes.dialogue[xh].text);
                            Console.ReadKey(true);
                        }
                        break;
                    case 2:
                        xh = 288;
                        GameHelper.Talking(GameRes.dialogue[xh].name, GameRes.dialogue[xh].text);
                        Console.ReadKey(true);
                        break;
                    case 3:
                        xh = 290;
                        GameHelper.Talking(GameRes.dialogue[xh].name, GameRes.dialogue[xh].text);
                        Console.ReadKey(true);
                        break;

                }
                if (choose != 1)
                {
                    for (xh = 291; xh <= 306; xh++)
                    {
                        GameHelper.Talking(GameRes.dialogue[xh].name, GameRes.dialogue[xh].text);
                        Console.ReadKey(true);
                    }
                }//梦境战斗结束
            }//默认胜利
            #region 升级模块
            GameHelper.Talking( "   ","梦之剑开始散发出粉红色的光芒，我似乎明白了应该做什么了");
            Console.ReadKey(true);
            GameHelper.Talking("勇者", "所以我1.升级梦之剑2.升级梦之剑携带的战斗技能3.下次吧", false);
            choose = int.Parse(Console.ReadLine());
            if (choose == 1)
            {
                Weapon.LevelUp();
            }else if (choose == 2)
            {
                GameHelper.Talking("要升级哪一个技能呢？", "技能1  技能2  技能3 技能4（每个技能只可以升级一次）", false);
                choose = int.Parse(Console.ReadLine());
                Skill.LevelUp(ref Player.Instance().playerskill[choose - 1]);
            }//升级技能或者武器
            Player.Instance().Show();
            #endregion
            for (xh = 320; xh <= 332; xh++)
            {
                GameHelper.Talking(GameRes.dialogue[xh].name, GameRes.dialogue[xh].text);
                Console.ReadKey(true);
            }
            #endregion

            #region 第二章
            Player.Sleep();
            for (xh = 400; xh <= 409; xh++)
            {
             GameHelper.Talking(GameRes.dialogue[xh].name, GameRes.dialogue[xh].text);
             Console.ReadKey(true);
            }
            monstor = GameRes.monstor[3];//与第三个怪物战斗
            if (Battle.BattleFighting(ref monstor, 420))//战斗对话420-431
            {//如果进入梦境
                truth++;//最终结局要求
                int max = 494;
                #region 升级模块
                GameHelper.Talking("   ", "梦之剑开始散发出粉红色的光芒，我似乎明白了应该做什么了");
                Console.ReadKey(true);
                GameHelper.Talking("勇者", "所以我  1.升级梦之剑  2.升级梦之剑携带的战斗技能   3.下次吧", false);
                choose = int.Parse(Console.ReadLine());
                if (choose == 1)
                {
                    Weapon.LevelUp();
                }
                else if (choose == 2)
                {
                    GameHelper.Talking("要升级哪一个技能呢？", "技能1  技能2  技能3 技能4（每个技能只可以升级一次）", false);
                    choose = int.Parse(Console.ReadLine());
                    Skill.LevelUp(ref Player.Instance().playerskill[choose - 1]);
                }//升级技能或者武器
                Player.Instance().Show();
                #endregion
                for (xh=460;xh<=max; xh++)
                {

                    GameHelper.Talking(GameRes.dialogue[xh].name, GameRes.dialogue[xh].text);
                    Console.ReadKey(true); 
                    if (xh==478){
                        choose = int.Parse(Console.ReadLine());
                        if (choose == 1)
                        {
                        xh++;max = 484;
                        }
                        else
                        {
                            xh = 489;
                        }

                    }
                }
                for(xh=500;xh<=549; xh++)
                {
                    GameHelper.Talking(GameRes.dialogue[xh].name, GameRes.dialogue[xh].text);
                    Console.ReadKey(true); 
                    if (xh == 538)
                    {
                        GameHelper.Talking("1.我亲自建造了这个世界？", "2.我在不断进行杀戮？", false);
                        choose = int.Parse(Console.ReadLine());
                    }
                }
                monstor = GameRes.monstor[4];
                Battle.BattleFighting(ref monstor, 550);max = 604;
                for(xh=562;xh<= max; xh++)
                {
                    GameHelper.Talking(GameRes.dialogue[xh].name, GameRes.dialogue[xh].text);
                    Console.ReadKey(true);
                    if (xh ==565)
                    {
                        GameHelper.Talking("1.魔王的蛊惑真是越来越多了，还是不看为好。", "2.稍微好奇一点应该不会怎么样吧……", false);
                        choose = int.Parse(Console.ReadLine());
                        if (choose == 1)
                        {
                            max = 569;
                        }
                        else
                        {
                            xh = 569;
                            truth++;//最终结局要求
                        }
                    }
                }

              

            }
            else
            {
                for (xh = 440; xh <= 457; xh++)
                {
                    GameHelper.Talking(GameRes.dialogue[xh].name, GameRes.dialogue[xh].text);
                    Console.ReadKey(true);
                }//第一部分对话

            }
            //上方战斗全部结束了

            Player.Sleep();
                for (xh = 604; xh <= 613; xh++)
                {
                    GameHelper.Talking(GameRes.dialogue[xh].name, GameRes.dialogue[xh].text);
                    Console.ReadKey(true);
                }
            #region 升级模块
            GameHelper.Talking("   ", "梦之剑开始散发出粉红色的光芒，我似乎明白了应该做什么了");
            Console.ReadKey(true);
            GameHelper.Talking("勇者", "所以我  1.升级梦之剑  2.升级梦之剑携带的战斗技能   3.下次吧", false);
            choose = int.Parse(Console.ReadLine());
            if (choose == 1)
            {
                Weapon.LevelUp();
            }
            else if (choose == 2)
            {
                GameHelper.Talking("要升级哪一个技能呢？", "技能1  技能2  技能3 技能4（每个技能只可以升级一次）", false);
                choose = int.Parse(Console.ReadLine());
                Skill.LevelUp(ref Player.Instance().playerskill[choose - 1]);
            }//升级技能或者武器
            Player.Instance().Show();
            #endregion
            for (xh = 614; xh <= 617; xh++)
            {
                GameHelper.Talking(GameRes.dialogue[xh].name, GameRes.dialogue[xh].text);
                Console.ReadKey(true);
            }
            #endregion

            #region 第三章后续添加
            //Battle.BattleFighting(1);

            #endregion

            #region 终章
            for (xh = 620; xh <= 645; xh++)
            {
                GameHelper.Talking(GameRes.dialogue[xh].name, GameRes.dialogue[xh].text);
                Console.ReadKey(true);
                if (xh == 633 )
                {
                    monstor = GameRes.monstor[5];
                    Battle.BattleFighting(ref monstor, 020);
                    #region 升级模块
                    GameHelper.Talking("   ", "梦之剑开始散发出粉红色的光芒，我似乎明白了应该做什么了");
                    Console.ReadKey(true);
                    GameHelper.Talking("勇者", "所以我  1.升级梦之剑  2.升级梦之剑携带的战斗技能   3.下次吧", false);
                    choose = int.Parse(Console.ReadLine());
                    if (choose == 1)
                    {
                        Weapon.LevelUp();
                    }
                    else if (choose == 2)
                    {
                        GameHelper.Talking("要升级哪一个技能呢？", "技能1  技能2  技能3 技能4（每个技能只可以升级一次）", false);
                        choose = int.Parse(Console.ReadLine());
                        Skill.LevelUp(ref Player.Instance().playerskill[choose - 1]);
                    }//升级技能或者武器
                    Player.Instance().Show();
                    #endregion
                }
                else if (xh == 634)
                {
                    monstor = GameRes.monstor[6];
                    Battle.BattleFighting(ref monstor, 020);
                    #region 升级模块
                    GameHelper.Talking("   ", "梦之剑开始散发出粉红色的光芒，我似乎明白了应该做什么了");
                    Console.ReadKey(true);
                    GameHelper.Talking("勇者", "所以我  1.升级梦之剑  2.升级梦之剑携带的战斗技能   3.下次吧", false);
                    choose = int.Parse(Console.ReadLine());
                    if (choose == 1)
                    {
                        Weapon.LevelUp();
                    }
                    else if (choose == 2)
                    {
                        GameHelper.Talking("要升级哪一个技能呢？", "技能1  技能2  技能3 技能4（每个技能只可以升级一次）", false);
                        choose = int.Parse(Console.ReadLine());
                        Skill.LevelUp(ref Player.Instance().playerskill[choose - 1]);
                    }//升级技能或者武器
                    Player.Instance().Show();
                    #endregion
                }
            }
            //开始结局真相选择,xh=646
            GameHelper.Talking(GameRes.dialogue[xh].name, GameRes.dialogue[xh].text,false);
            choose = int.Parse(Console.ReadLine());
            if (choose == 1)
            {
                //魔王路线开启
                monstor = GameRes.monstor[8];
                for (xh = 650; xh <= 673; xh++)
                {
                    GameHelper.Talking(GameRes.dialogue[xh].name, GameRes.dialogue[xh].text);
                    if (xh==659||xh==656) {
                        choose = int.Parse(Console.ReadLine());
                    }
                    else
                    {
                        Console.ReadKey(true);
                    }
                
                
                }//战斗前夕

                monstor.hp = Player.Instance().hp;
                monstor.dream = Player.Instance().dream;
                monstor.dreamattack = Player.Instance().dreamsword.dreamattack;
                //属性互换
                Player.Instance().hp = 3000;
                Player.Instance().dream = 5000;
                Player.Instance().dreamsword = GameRes.weapon[5];
                Player.Instance().playerskill[0] = GameRes.skill[2];
                Player.Instance().playerskill[1] = GameRes.skill[4];
                Player.Instance().playerskill[2] = GameRes.skill[6];
                Player.Instance().playerskill[3] = GameRes.skill[8];
                GameHelper.Talking("勇者","这场战斗的胜者必定是我！");
                Player.Instance().Show();
                Battle.BattleFighting(ref monstor, 680);
                for(xh=700;xh<=726; xh++)
                {
                    //魔王结局
                    GameHelper.Talking(GameRes.dialogue[xh].name, GameRes.dialogue[xh].text);
                    Console.ReadKey(true);
                }
                Console.ForegroundColor=ConsoleColor.Red;
                //xh=727
                GameHelper.Talking(GameRes.dialogue[xh].name, GameRes.dialogue[xh].text);
                Console.ReadKey(true);
                //魔王结局结束
            }
            else if (choose == 2)
            {
                //勇者路线开启
                monstor = GameRes.monstor[8];
                //战斗前夕
                for(xh=750;xh<= 761 ; xh++)
                {
                    GameHelper.Talking(GameRes.dialogue[xh].name, GameRes.dialogue[xh].text);

                    if (xh == 753)
                    {
                        choose = int.Parse(Console.ReadLine());
                        if (choose == 2)
                        {
                            xh = 754;
                        }
                    }
                    else
                    {
                        Console.ReadKey(true);
                    }
                    if (xh == 756)
                    {
                        int ij;
                        for (ij = 321; ij <= 325; ij++)
                        {
                            GameHelper.Talking(GameRes.dialogue[xh].name, GameRes.dialogue[xh].text);
                            Console.ReadKey(true);

                        }
                        for (ij = 614; ij <=617; ij++)
                        {
                            GameHelper.Talking(GameRes.dialogue[xh].name, GameRes.dialogue[xh].text);
                            Console.ReadKey(true);

                        }


                    }
                    if (xh == 757)
                    {
                        for(int i = 0; i <= 9; i++)
                        {
                            GameHelper.Talking(GameRes.dialogue[xh].name, GameRes.dialogue[xh].text);
                            Console.ReadKey(true);
                        }
                    }
                    //以上为回忆杀

                }
                //正式战斗
                Battle.BattleFighting(ref monstor, 770);
                //第二形态
                for (xh = 782; xh <= 796; xh++)
                {
                    GameHelper.Talking(GameRes.dialogue[xh].name, GameRes.dialogue[xh].text);
                    Console.ReadKey(true);
                }
                monstor = GameRes.monstor[9];
                Battle.BattleFighting(ref monstor, 800);
                for (xh = 821; xh <= 838; xh++)
                {
                    GameHelper.Talking(GameRes.dialogue[xh].name, GameRes.dialogue[xh].text);
                    Console.ReadKey(true);
                }
                Console.ForegroundColor = ConsoleColor.Red;
                GameHelper.Talking(GameRes.dialogue[xh].name, GameRes.dialogue[xh].text);
                Console.ReadKey(true);
                Console.ForegroundColor = ConsoleColor.White;
                for (xh = 840; xh <= 861; xh++)
                {
                    GameHelper.Talking(GameRes.dialogue[xh].name, GameRes.dialogue[xh].text);
                    Console.ReadKey(true);
                }
                Console.ForegroundColor = ConsoleColor.Red;
                GameHelper.Talking(GameRes.dialogue[xh].name, GameRes.dialogue[xh].text);
                Console.ReadKey(true);
                Console.ForegroundColor = ConsoleColor.White;
                //勇者路线完

            }
            else if (truth == 3)
            {
                //真相路线开启
                for (xh = 900; xh <= 1038; xh++)
                {
                    GameHelper.Talking(GameRes.dialogue[xh].name, GameRes.dialogue[xh].text);

                    if (xh == 908)
                    {
                        choose = int.Parse(Console.ReadLine());
                        if (choose == 2)
                        {
                            xh = 910;
                        }
                    }
                    else if (xh == 915)
                    {
                        choose = int.Parse(Console.ReadLine());
                        if (choose == 1)
                        {
                            xh = 916;
                        }
                    }
                    else if (xh == 919)
                    {
                        choose = int.Parse(Console.ReadLine());
                        if (choose == 2)
                        {
                            xh = 920;
                        }
                    }
                    else if (xh == 942)
                    {
                        choose = int.Parse(Console.ReadLine());
                        if (choose == 2)
                        {
                            xh = 943;
                        }
                    }
                    else if (xh == 945)
                    {
                        choose = int.Parse(Console.ReadLine());
                        if (choose == 2)
                        {
                            xh = 946;
                        }
                    }
                    else if (xh == 955)
                    {
                        Console.ReadKey(true);
                        for(int i = 528; i <= 549; i++)
                        {
                            GameHelper.Talking(GameRes.dialogue[xh].name, GameRes.dialogue[xh].text);
                            Console.ReadKey(true);
                        }
                    }
                    else if (xh == 957)
                    {
                        choose = int.Parse(Console.ReadLine());
                        if (choose == 2)
                        {
                            xh = 958;
                        }
                    }
                    else if (xh == 960)
                    {
                        choose = int.Parse(Console.ReadLine());

                    }
                    else if (xh == 973)
                    {
                        Console.ReadKey(true);
                        for (int i = 158; i <= 160; i++)
                        {
                            GameHelper.Talking(GameRes.dialogue[xh].name, GameRes.dialogue[xh].text);
                            Console.ReadKey(true);
                        }
                        for (int i = 424; i <= 427; i++)
                        {
                            GameHelper.Talking(GameRes.dialogue[xh].name, GameRes.dialogue[xh].text);
                            Console.ReadKey(true);
                        }
                    }
                    else if (xh == 977)
                    {
                        choose = int.Parse(Console.ReadLine());
                        if (choose == 1)
                        {
                            xh = 978;
                        }

                    }
                    else if (xh == 1028)
                    {
                        Console.ReadKey(true);
                        Console.ForegroundColor = ConsoleColor.Red;xh++;
                        GameHelper.Talking(GameRes.dialogue[xh].name, GameRes.dialogue[xh].text);
                        Console.ReadKey(true); ;
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        Console.ReadKey(true);
                    }
                }
                monstor = GameRes.monstor[10];
                Battle.BattleFighting(ref monstor, 1040);
                for (xh = 1070; xh <= 1084; xh++)
                {
                    GameHelper.Talking(GameRes.dialogue[xh].name, GameRes.dialogue[xh].text);
                    Console.ReadKey(true);
                }
                //真相路线暂时完结

            }
            else
            { //魔王路线开启
                monstor = GameRes.monstor[8];
                for (xh = 650; xh <= 673; xh++)
                {
                    GameHelper.Talking(GameRes.dialogue[xh].name, GameRes.dialogue[xh].text);
                    if (xh == 659 || xh == 656)
                    {
                        choose = int.Parse(Console.ReadLine());
                    }
                    else
                    {
                        Console.ReadKey(true);
                    }


                }//战斗前夕

                monstor.hp = Player.Instance().hp;
                monstor.dream = Player.Instance().dream;
                monstor.dreamattack = Player.Instance().dreamsword.dreamattack;
                //属性互换
                Player.Instance().hp = 3000;
                Player.Instance().dream = 5000;
                Player.Instance().dreamsword = GameRes.weapon[5];
                Player.Instance().playerskill[0] = GameRes.skill[2];
                Player.Instance().playerskill[1] = GameRes.skill[4];
                Player.Instance().playerskill[2] = GameRes.skill[6];
                Player.Instance().playerskill[3] = GameRes.skill[8];
                GameHelper.Talking("勇者", "这场战斗的胜者必定是我！");
                Player.Instance().Show();
                Battle.BattleFighting(ref monstor, 680);
                for (xh = 700; xh <= 726; xh++)
                {
                    //魔王结局
                    GameHelper.Talking(GameRes.dialogue[xh].name, GameRes.dialogue[xh].text);
                    Console.ReadKey(true);
                }
                Console.ForegroundColor = ConsoleColor.Red;
                //xh=727
                GameHelper.Talking(GameRes.dialogue[xh].name, GameRes.dialogue[xh].text);
                Console.ReadKey(true);
                //魔王结局结束

            }
            Console.ForegroundColor = ConsoleColor.Green;
            TextRain("The World . ");
            TextRain( "世 界 因   ________  而 改  变。", 75,  24);
            TextRain("The World . ",85,25);
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Blue;
            for (xh = 2000; xh <= 2005; xh++)
            {
               TextRain(GameRes.dialogue[xh].text);
               Console.Clear();
            }
            #endregion


        }
    }
}
