using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJEKT_NARIN
{
    public class Enemy
    {
        private static int reward1;
        private static int reward2;
        private static string name;
        private static bool isMan;
        private static int hp;
        private static int crit;
        private static int hpMax;
        private static int dmg;
        private static int kd;
        public static int Kd
        {
            get
            {
                return kd;
            }
            set
            {
                if (value >= 0)
                    kd = value;
            }
        }
        public static int Dmg
        {
            get
            {
                return dmg;
            }
            set
            {
                if (value >= 0)
                    dmg = value;
            }
        }
        public static string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
        public static bool IsMan
        {
            get
            {
                return isMan;
            }
            set
            {
                isMan = value;
            }
        }
        public static int Hp
        {
            get
            {
                return hp;
            }
            set
            {

                hp = value;
                if (hp > hpMax)
                    hp = hpMax;
            }
        }
        public static int HpMax
        {
            get
            {
                return hpMax;
            }
            set
            {
                if (value >= 0)
                    hpMax = value;
            }
        }
        public static int Crit
        {
            get
            {
                return crit;
            }
            set
            {
                if (value >= 0)
                    crit = value;
            }
        }
        private static int bonus;
        public static int Bonus
        {
            get
            {
                return bonus;
            }
            set
            {
                bonus = value;
            }
        }
        public static int Reward()
        {
            Random r = new Random();
            int a = r.Next(reward1, reward2+1);
            return a;
        }
        public Enemy(string enemyClass)
        {
            if (enemyClass == "Крыса")
            {
                HpMax = 30;
                Hp = 30;
                Dmg = 4;
                Crit = 1;
                critKoef = 2;
                Kd = 8;
                Bonus = 1;
                reward1 = 2;
                reward2 = 5;
                Name = "Крыса";
            }
            if (enemyClass == "Кобольд")
            {
                HpMax = 40;
                Hp = 40;
                Dmg = 7;
                Crit = 1;
                critKoef = 2;
                Kd = 11;
                Bonus = 4;
                reward1 = 5;
                reward2 = 9;
                Name = "Кобольд";
            }
            if (enemyClass == "Волк")
            {
                HpMax = 70;
                Hp = 70;
                Dmg = 12;
                Crit = 1;
                critKoef = 2;
                Kd = 12;
                Bonus = 3;
                reward1 = 14;
                reward2 = 19;
                Name = "Волк";
            }
            if (enemyClass == "Огр")
            {
                HpMax = 150;
                Hp = 150;
                Dmg = 15;
                Crit = 2;
                critKoef = 2;
                Kd = 12;
                Bonus = 4;
                reward1 = 29;
                reward2 = 33;
                Name = "Огр";
            }
            if (enemyClass == "Дракон")
            {
                HpMax = 200;
                Hp = 200;
                Dmg = 30;
                Crit = 3;
                critKoef = 2;
                Kd = 17;
                Bonus = 5;
                reward1 = 47;
                reward2 = 51;
                Name = "Дракон";
            }
            if (enemyClass == "Тарраск")
            {
                HpMax = 350;
                Hp = 350;
                Dmg = 100;
                Crit = 10;
                critKoef = 2;
                Kd = 20;
                Bonus = 8;
                reward1 = 60;
                reward2 = 67;
                Name = "Тарраск";
            }
        } 

        private static int critKoef;

        public static Random ra = new Random();
        private static int R(int dice, int chance, int crit)
        {

            int a = ra.Next(1, dice + 1);
            if (a + Bonus >= 20 - crit || a == dice)
                return 2;
            if (a + Bonus >= chance)
                return 1;
            else
                return 0;
        }
        public static string Attak()
        {
            string s;
            int a = R(20, Hero.Kd, Crit);
            if (a == 0)
            {
                s = "Вы увернулись от атаки противника \n";
            }
            else if (a == 1)
            {
                Hero.Hp -= Dmg;
                s = "Противник нанёс вам " + Dmg.ToString() + " урона. \n ";
            }
            else
            {
                Hero.Hp -= Dmg * critKoef;
                s = "Противник наносит критический удар! " + (Dmg * critKoef).ToString() + " урона. \n";
            }   
            return s;
        }
        public static void Passive(int turn)
        {
            if (Name == "Крыса")
            {
                Hero.Hp--;
            }
            if (Name == "Кобольд")
            {
                Hero.Hp -= turn / 3;
            }
            if (Name == "Волк")
            {
                Hp += 2;
            }
            if (Name == "Огр")
            {
                Dmg = 15 + turn / 2;
            }
            if (Name == "Дракон")
            {
                if (turn % 4 == 0)
                {
                    Hero.Kd--;
                }
            }
            if (Name == "Тарраск")
            {
                if (turn % 5 == 0)
                    Enemy.Hp += 50;
            }
        }
    }
}
