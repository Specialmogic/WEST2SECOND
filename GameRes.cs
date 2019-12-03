using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
namespace The_World
{
  

    public class Dialogue
    {
        public int id;
        public string text;
        public string name;
    }   //对话类
    public  class Weapon
    {
        public int level;
        public string name;
        public int dreamattack;
        public int experience;

        //每次战斗结束都可以选择是否升级梦之剑和升级技能
        public static void LevelUp()  
        {
            if (Player.Instance().dream > Player.Instance().dreamsword.experience)
            {
                GameHelper.Talking("正在升级武器！", "正在消耗梦之精华为梦之剑注入魔力", false);
                GameHelper.TalkingEnd();
                Player.Instance().dream -= Player.Instance().dreamsword.experience;
                Player.Instance().dreamsword.level++;
                Player.Instance().dreamsword.name = GameRes.weapon[Player.Instance().dreamsword.level].name;
                Player.Instance().dreamsword.experience = GameRes.weapon[Player.Instance().dreamsword.level].experience;
                Player.Instance().dreamsword.dreamattack = GameRes.weapon[Player.Instance().dreamsword.level].dreamattack;
                Player.Instance().dream -= 30;
                Player.Instance().Show();
            }
            else
            {
                GameHelper.Talking("", "梦之精华不足！", false);
                GameHelper.TalkingEnd();
            }
            
        }

    }   //梦之剑属性
    class GameRes
    {
        #region 读取数据并存在字典里
        public static Dictionary<int, Weapon> weapon = new Dictionary<int, Weapon>();
        public static Dictionary<int, Skill> skill = new Dictionary<int, Skill>();
        public static Dictionary<int, Monstor> monstor = new Dictionary<int, Monstor>();
        public static Dictionary<int, Dialogue> dialogue = new Dictionary<int, Dialogue>();
        #endregion
       
        public static bool LoadGameRes()
        {
            XmlDocument xml = new XmlDocument();
            const string ResPath = @"C:\The World\TheWorld.xml";
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.IgnoreComments = true;//忽略文档里面的注释
            try
            {
                xml.Load(ResPath);
                XmlNode root = xml.SelectSingleNode("TheWorld");
                XmlNode role = root.SelectSingleNode("hero");
                Player.Instance().hp = int.Parse(role.Attributes["hp"].Value);
                Player.Instance().id = int.Parse(role.Attributes["id"].Value);
                Player.Instance().dream = int.Parse(role.Attributes["dream"].Value);
                Player.Instance().luck = int.Parse(role.Attributes["luck"].Value);
                Player.Instance().name = role.Attributes["name"].Value;
                Player.Instance().crit = int.Parse(role.Attributes["crit"].Value);

                XmlNodeList list = root.SelectNodes("weapon");
                foreach (XmlNode wq in list)
                {
                    Weapon _weapon = new Weapon();
                    _weapon.level = int.Parse(wq.Attributes["level"].Value);
                    _weapon.name = wq.Attributes["name"].Value;
                    _weapon.dreamattack = int.Parse(wq.Attributes["dreamattack"].Value);
                    _weapon.experience = int.Parse(wq.Attributes["experience"].Value);
                    weapon.Add(_weapon.level, _weapon);
                }
                Player.Instance().dreamsword = weapon[1];
                list = root.SelectNodes("skill");
                foreach (XmlNode jn in list)
                {
                    Skill _skill = new Skill();
                    _skill.id = int.Parse(jn.Attributes["id"].Value);
                    _skill.name = jn.Attributes["name"].Value;
                    _skill.damage = int.Parse(jn.Attributes["damage"].Value);
                    _skill.dream = int.Parse(jn.Attributes["dream"].Value);
                    _skill.describe = jn.Attributes["describe"].Value;
                    _skill.type = int.Parse(jn.Attributes["type"].Value);
                    skill.Add(_skill.id, _skill);
                }          
                list = root.SelectNodes("monstor");
                foreach (XmlNode gw in list)
                {
                    Monstor _monstor = new Monstor();
                    _monstor.id = int.Parse(gw.Attributes["id"].Value);
                    _monstor.name = gw.Attributes["name"].Value;
                    _monstor.hp = int.Parse(gw.Attributes["hp"].Value);
                    _monstor.dream = int.Parse(gw.Attributes["dream"].Value);
                    _monstor.dreamattack = int.Parse(gw.Attributes["dreamattack"].Value);
                    _monstor.beforefight= gw.Attributes["beforefight"].Value;
                    _monstor.playeranswer = gw.Attributes["playeranswer"].Value;
                    monstor.Add(_monstor.id, _monstor);
                }

                xml.Load(@"C:\The World\Text.xml");
                root = xml.SelectSingleNode("Text");
                list = root.SelectNodes("wb");
                foreach (XmlNode dh in list)
                {
                    Dialogue _dialogue = new Dialogue();
                    _dialogue.id = int.Parse(dh.Attributes["id"].Value);
                    _dialogue.text = dh.Attributes["text"].Value;
                    _dialogue.name = dh.Attributes["name"].Value;
                    dialogue.Add(_dialogue.id, _dialogue);
                }
                //角色技能初始化
                int x = 0;
                for(int i = 1; i < Player.Instance().skillamount * 2; i += 2)  //技能初始载入
                {   
                    Player.Instance().playerskill[x++] = GameRes.skill[i];
                }
         

            }
#pragma warning disable CA1031 // Do not catch general exception types
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
#pragma warning restore CA1031 // Do not catch general exception types


            return true;
        }    //加载xml文件






    }
}
