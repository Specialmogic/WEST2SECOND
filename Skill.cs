using System;
using System.Collections.Generic;
using System.Text;

namespace The_World
{
    public class Skill
    {
        public int id;
        public int damage;
        public string name;
        public int dream;
        public string describe;
        public int type;

        public static bool IfSkill (Skill skill){
            
                    if (Player.Instance().dream > skill.dream)
                    {
                        Player.Instance().dream -= skill.dream;
                          return true;
                    }
                    else
                    {
                        GameHelper.Talking("技能释放失败！梦之精华不足！ ", "无法启用梦之剑！", false);
                        Console.ReadKey(true);
                        GameHelper.TalkingEnd();
                        return false;
                    }
        }//技能使用成功返回true
        public static void LevelUp(ref Skill skill)
        {
            if (skill.id < 9&&Player.Instance().dream>30)
            {
                skill.id++;
                skill.damage = GameRes.skill[skill.id].damage;
                skill.dream = GameRes.skill[skill.id].dream;
                skill.name = GameRes.skill[skill.id].name;
                Player.Instance().dream -= 30;
                Player.Instance().Show();
            }
            else
            {
                GameHelper.Talking(" ", "升级所需梦之精华不足或已经满级！");
            }

        }//调用字典数据升级属性

        public static int UsingSkill(ref Monstor monstor, Skill skill, int dreamattack)
        {//只产生效果，技能具体伤害扣减由turn()决定
            Random random = new Random();
            float a = (float)(random.Next(80, 120)) / 100.0f;
            if (skill.id <= 8)  //勇者使用技能
            {
             
              
                    if (skill.type == 1)  //造成伤害并触发特效
                    {



                        if (skill.id == 4)  //特殊情况
                        {
                            Player.Instance().luck += Player.Instance().dreamsword.level * 2;
                            //此处加入音效，luck ！up！ 
                            return (int)((dreamattack * a + skill.damage) * a);
                        }
                        else
                        {//普通情况
                            return (int)((dreamattack * a + skill.damage) * a);
                        }

                    }
                    else   //type==2且处于玩家技能序列
                    {
                        Player.Instance().dream -= skill.dream;
                        int effect = (int)((Player.Instance().luck / 9) * a);

                        switch (skill.id)
                        {
                            case 5:
                                Player.Instance().hp += effect -= 10;
                                break;
                            case 6:
                                Player.Instance().hp += effect;
                                monstor.dreamattack -= Player.Instance().dreamsword.level;
                                break;
                            case 7:

                                Player.Instance().dream += effect;
                                Player.Instance().hp -= effect;
                                break;
                            case 8:
                                effect += 10;
                                Player.Instance().dream += effect * 2;
                                Player.Instance().hp -= effect;
                                break;
                        }//触发技能特效
                        return 0;
                    }

               

            }

            else    //使用对象为怪物
            {
                if (skill.type == 1)    //造成伤害同时有特效的技能
                {
                    int damage = (int)((dreamattack * a + skill.damage) * a);
                    monstor.dream -= skill.dream;
                    switch (skill.id - 10)   //触发技能特效
                    {
                        case 1:

                            Player.Instance().dream -= skill.dream;
                            break;

                        case 2:
                            monstor.hp += (damage / 2);
                            break;

                    }
                    return damage;
                }
                else     //触发技能不造成伤害，只有特效type==2
                {
                    switch (skill.id - 20)
                    {
                        case 1:
                            monstor.dreamattack += monstor.id;
                            break;
                        case 2:
                            monstor.dreamattack += monstor.id / 2;
                            monstor.hp += monstor.id * 2;
                            break;

                        case 3:
                            Player.Instance().luck -= monstor.id;

                            break;
                    }
                    return 0;
                }
            }
        }

    }
}
