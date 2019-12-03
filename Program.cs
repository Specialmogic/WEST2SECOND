using System;

namespace The_World
{

    class Program
    {
        #region  游戏文本序号
        public static int scene0_start = 0;
        public static int scene0_end = 9;




        #endregion
        public static int monsterskilltype1maxnumber = 4;//在原有基础上+10
        public static int monsterskilltype2maxnumber = 3;//在原有基础上+20
        static void Main(string[] args)
        {
           Console.SetWindowSize(200, 55);
            if (GameRes.LoadGameRes())
            {
               
                GameHelper.StartGame();
            }
            else
            {
                Console.WriteLine("游戏载入失败！");
                Console.WriteLine("将整个文件夹移动至C盘根目录下（非桌面）");
                Console.WriteLine("或进入GameRes函数修改XML文件载入路径(Path)！");
            }
         






        }
    }
}
