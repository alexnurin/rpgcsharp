using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJEKT_NARIN
{
    public class Hero
    {
        public Hero() {

        }
        private static string name;
        private static bool isMan;
        private static int hp;
        private static int crit;
        private static int hpMax;
        private static int dmg;
        private static int kd;
        private static int bonus = 2;
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
        private static int bonus2 = 2;
        public static int Bonus2
        {
            get
            {
                return bonus2;
            }
            set
            {
                bonus2 = value;
            }
        }

        public static int price1;
        public static int price2;
        public static int price3;
        public static int price4;
        public static int price5;
        public static int price6;
        public static int result;
        public static int critKoef;
        public static int dayNow=0;
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
                if (hp < 0)
                    hp = 0;
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
        public static string clas;
        public static string race;
        public static string dmgType;
        public static Random r = new Random();
        private static int D(int dice, int chance, int crit)
        {
            int a = r.Next(1, dice + 1);
            if (a + Bonus >= 20 - crit || a == dice)
                return 2;
            if (a + Bonus >= chance)
                return 1;
            else
                return 0;
        }
        private static bool D(int dice, int chance)
        {
            int a = r.Next(1, dice + 1);
            if (a + Bonus >= 20 - crit || a == dice || a + Bonus >= chance)
                return true;
            else
                return false;
        }
        public static int regen = 2;
        public static string Attak(string nameCast)
        {
            string s;
            bool a = D(20, Enemy.Kd - Bonus + 1);
            if (!a)
            {
                s = "Вы промахнулись заклинанием. \n";
            }
            else
            {
                Enemy.Hp -= Dmg + Bonus;
                s = "Противник получил " + (Dmg + Bonus).ToString() + " урона от вашего заклинания - " + nameCast + "\n";
            }
            return s;

        }
        public static string Attak()
        {
            string s;
            int a = D(20, Enemy.Kd, Crit);
            if (a == 0)
            {
                s = "Вы ударяете - промах! \n";
            }
            else if (a == 1)
            {
                Enemy.Hp -= Dmg;
                s = "Противник получил " + Hero.Dmg + " урона от вашей атаки - " + Hero.dmgType + "\n";
            }
            else
            {
                Enemy.Hp -= Dmg * critKoef;
                s = "Вы ударяете - критический удар! Нанесено " + (Dmg * critKoef).ToString() + " урона. \n";
            }
            return s;
        }
        private static int gold;
        public static int Gold
        {
            get{ return gold; }
            set {
                if (gold + value >= 0)
                {
                    gold = value;
                }
            }
        }
    }
}
