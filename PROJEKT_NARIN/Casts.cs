using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJEKT_NARIN
{
    class Heal:Ability
    {
        public Heal(int heal):base()
        {
            healToHero = heal;
            Reload = 3;
        }
        private int healToHero;
        public int Cast(bool res)
        {
            if (res)
                Enemy.Hp -= healToHero;
            Hero.Hp += healToHero;
            return Reload;
        }
    }
    class Buff : Ability
    {
        private static int dmgBuff;
        private static int dmgDeBuff;
        private static int kdDeBuff;
        private static int kdBuff;
        private static int time;
        public static int DmgBuff { get { return dmgBuff; } set { dmgBuff = value; } }
        public static int DmgDeBuff { get { return dmgDeBuff; } set { dmgDeBuff = value; } }
        public static int KdDeBuff { get { return kdDeBuff; } set { kdDeBuff = value; } }
        public static int KdBuff { get { return kdBuff; } set { kdBuff = value; } }
        public static int Time { get { return time; } set { time = value; } }
        public Buff() : base()
        {
        
        }
        public static void BuffSet(int a, int b, int c, int d, int t)
        {
            KdBuff = a;
            DmgBuff = b;
            KdDeBuff = c;
            DmgDeBuff = d;
            Time = t;
        }
        public static int Cast()
        {
            Hero.Kd += kdBuff;
            Hero.Dmg += dmgBuff;
            Enemy.Kd -= kdDeBuff;
            Enemy.Dmg -= dmgDeBuff;
            return time;
        }
        public static void CastEnd()
        {
            Hero.Kd -= kdBuff;
            Hero.Dmg -= dmgBuff;
            Enemy.Kd += kdDeBuff;
            Enemy.Dmg += dmgDeBuff;
        }
    }
    class Shot : Ability
    {
        public Shot(int dmg) : base()
        {
            shotDmg = dmg;
            Reload = 3;
        }
        private int shotDmg;
        public int ShotDmg
        {
            get { return shotDmg; }
            set {
                shotDmg = value;
                if (shotDmg < 0) shotDmg = 0;
            }
        }
        public int Cast()
        {
            Enemy.Hp -= shotDmg;
            return Reload;
        }
    }
}
