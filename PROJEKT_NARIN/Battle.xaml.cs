using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PROJEKT_NARIN
{
    /// <summary>
    /// Логика взаимодействия для Battle.xaml
    /// </summary>
    public partial class Battle : Window
    {
        public Battle(string enemyClass)
        {

            InitializeComponent();
            u.battleHp.Content = Hero.Hp.ToString();
            enemy.battleHp.Content = Enemy.Hp.ToString();
            enemy.tbName.Text = enemyClass;
            u.tbName.Text = Hero.clas + "-" + Hero.race + " " + Hero.Name;
            Enemy en = new Enemy(enemyClass);
            f5();
            setImage(Hero.clas, enemyClass);
            Buff buff = new Buff();
            stat.Text = "Бой начался!\n";
        }
        public void setImage(string heroClass, string enemyClass)
        {
            if (heroClass == "Воин")
            {
                u.icon.Source = new BitmapImage(new Uri("warrior.png", UriKind.Relative));
                ab1.Content = "Поднять щиты";
                ab2.Content = "Ярость";
            }
            if (heroClass == "Волшебник")
            {
               u.icon.Source = new BitmapImage(new Uri("mage.png", UriKind.Relative));
                ab1.Content = "Магический выстрел";
                ab2.Content = "Пламя";
            }
            if (heroClass == "Лучник")
            {
                u.icon.Source = new BitmapImage(new Uri("archer.png", UriKind.Relative));
                ab1.Content = "Меткий выстрел";
                ab2.Content = "Близость к природе";
            }
            if (heroClass == "Колдун")
            {
                u.icon.Source = new BitmapImage(new Uri("sorcer.png", UriKind.Relative));
                ab1.Content = "Похищение жизни";
                ab2.Content = "Обман";
            }
            if (heroClass == "Паладин")
            {
                u.icon.Source = new BitmapImage(new Uri("paladin.png", UriKind.Relative));
                ab1.Content = "Исцеление";
                ab2.Content = "Божественный щит";
            }

            if (enemyClass == "Крыса")
            {
                enemy.icon.Source = new BitmapImage(new Uri("rat.png", UriKind.Relative));
            }
            if (enemyClass == "Кобольд")
            {
                enemy.icon.Source = new BitmapImage(new Uri("cobold.png", UriKind.Relative));
            }
            if (enemyClass == "Волк")
            {
                enemy.icon.Source = new BitmapImage(new Uri("wolf.png", UriKind.Relative));
            }
            if (enemyClass == "Огр")
            {
                enemy.icon.Source = new BitmapImage(new Uri("org.png", UriKind.Relative));
            }
            if (enemyClass == "Дракон")
            {
                enemy.icon.Source = new BitmapImage(new Uri("dragon.png", UriKind.Relative));
            }
            if (enemyClass == "Тарраск")
            {
                enemy.icon.Source = new BitmapImage(new Uri("tarrasque.png", UriKind.Relative));
            }
            enemy.TBab1.Text = "";
            enemy.TBab2.Text = "";
            enemy.ddd.Text = "";

        }
        public int turn = 0;
        public int a1 = 0;
        public int a2 = 0;
        public int a1buff = 0;
        public int a2buff = 0;
        public void f5()
        {
            if (Hero.Hp > 0)
            {
                u.battleHp.Width = 260 * Hero.Hp / Hero.HpMax;
                u.battleHp.Content = Hero.Hp.ToString();
            }
            else
            {
                u.battleHp.Width = 1;
                u.battleHp.Content = Hero.Hp.ToString();
                Close();
            }
            if (Enemy.Hp > 0)
            {

                enemy.battleHp.Width = 260 * Enemy.Hp / Enemy.HpMax;
                enemy.battleHp.Content = Enemy.Hp.ToString();
            }
            else
            {
                enemy.battleHp.Width = 1;
                enemy.battleHp.Content = Enemy.Hp.ToString();
                Close();
            }
            if (Hero.Hp == 0 && Enemy.Hp == 0)
            {
                if (a1buff > turn || a2buff > turn)
                    Buff.CastEnd();
                Hero.Kd -= shieldUsed;
                MessageBox.Show("Вы отступили, но противник погиб от ран", "Ну типа ничья", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else if (Hero.Hp == 0)
            {
                if (a1buff > turn || a2buff > turn)
                    Buff.CastEnd();
                Hero.Kd -= shieldUsed;
                MessageBox.Show("Вы отступили. " + Enemy.Name + " - пока слишком опасный противник для вас", "Поражение", MessageBoxButton.OK, MessageBoxImage.Hand);
                
            }
            else if (Enemy.Hp <= 0)
            {
                if (a1buff > turn || a2buff > turn)
                    Buff.CastEnd();
                int a = Enemy.Reward();
                MessageBox.Show("Вы победили противника - " + Enemy.Name + "\nВы получили " + a.ToString() + " золота.", "Победа", MessageBoxButton.OK, MessageBoxImage.Information);
                Hero.Kd -= shieldUsed;
                Hero.Gold += a;
                Hero.result += a;
            }
            if (a1 < turn) a1 = turn;
            if (a2 < turn) a2 = turn;
            u.TBab1.Text = (a1 - turn).ToString();
            u.TBab2.Text = (a2 - turn).ToString();
            u.TBdmg.Text = Hero.Dmg.ToString();
            u.TBkd.Text = Hero.Kd.ToString();
            enemy.TBdmg.Text = Enemy.Dmg.ToString();
            enemy.TBkd.Text = Enemy.Kd.ToString();

        }
       
        private void NextTurn_Click(object sender, RoutedEventArgs e)
        {
            if (Hero.Hp > 0 && Enemy.Hp > 0)
            {
                turn++;
                AbilityChek();
                stat2.Text = stat.Text;
                stat.Text = "Ход " + turn.ToString() + ": \n";
                string uo = Hero.Attak();
                string en = Enemy.Attak();
                Enemy.Passive(turn);
                f5();
                stat.Text += uo + en;

            }
        }
        private bool D(int dice, int chance)
        {
            Random r = new Random();
            int a = r.Next(1, dice+1);
            if (a > chance)
            {
                return true;
            }
            else return false;
        }
        public int shieldUsed = 0;
        private void AbilityChek()
        {
            if (a1 == turn)
            {
                ab1.IsEnabled = true;
            }
            if (a2 == turn)
            {
                ab2.IsEnabled = true;
            }
            if (a1buff == turn)
            {
                Buff.CastEnd();
            }
            if (a2buff == turn)
            {
                Buff.CastEnd();
            }
            f5();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Hero.clas == "Воин")
            {
                Buff.BuffSet(3, 0, 0, 1, 2);
                a1buff = Buff.Cast() + turn;
                a1 = a1buff + 3;
                ab1.IsEnabled = false;
                stat.Text += "Поднять щиты! Защита увеличена на " + 3.ToString() + ". \n";
                f5();
            }
            else if (Hero.clas == "Волшебник")
            {
                Shot he = new Shot(Hero.Dmg + 5);
                a1 = 2 + turn;
                string res = Hero.Attak("Магический выстрел");
                ab1.IsEnabled = false;
                stat.Text += res;
                f5();
            }
            else if (Hero.clas == "Лучник")
            {
                Heal he = new Heal(Hero.regen);
                a1 = he.Cast(true) + turn + 2;
                ab1.IsEnabled = false;
                stat.Text += "Ход " + (turn + 1).ToString() + ":\nМеткий выстрел - вы нанесли противнику " + (Hero.Dmg + Hero.Bonus).ToString()  + " урона. \n";
                Enemy.Hp -= (Hero.Dmg + Hero.Bonus);
                turn++;
                f5();
            }
            else if (Hero.clas == "Колдун")
            {
                Heal he = new Heal(Hero.regen + Hero.Bonus + 5);
                a1 = he.Cast(true) + turn + 2;
                ab1.IsEnabled = false;
                stat.Text += "Вы похитили вражеское здоровье: " + (Hero.Bonus + Hero.regen+5).ToString() + " хп. \n";
                f5();
            }
            else if (Hero.clas == "Паладин")
            {
                Heal he = new Heal(Hero.regen + Hero.Bonus + 5);
                a1 = he.Cast(false) + turn;
                ab1.IsEnabled = false;
                stat.Text += "Вы исцелили себе " + (5 + Hero.regen + Hero.Bonus).ToString() + " хп. \n";
               
                f5();
            }
        }
    

        private void ab2_Click(object sender, RoutedEventArgs e)
        {
            if (Hero.clas == "Воин")
            {
                Shot he = new Shot((Hero.HpMax - Hero.Hp) / 2);
                a2 = he.Cast() + turn + 3;
                ab2.IsEnabled = false;
                stat.Text += "Ярость! Вы нанесли врагу " + he.ShotDmg.ToString() + " урона. \n";
                f5();
            }
            else if (Hero.clas == "Волшебник")
            {
                Buff.BuffSet(0, 0, 2+Hero.Bonus2, 2, 4);
                a1buff = Buff.Cast() + turn;
                a1 = a1buff + 3;
                ab1.IsEnabled = false;
                stat.Text += "Вы опалили противника, уменьшив его защиту на " + (2 + Hero.Bonus2).ToString() + " и нанеся " + (Hero.Bonus2+1).ToString() + " урона. \n";
                f5();
            }
            else if (Hero.clas == "Лучник")
            {
                Heal he = new Heal(Hero.regen);
                a2 = he.Cast(true) + turn + 2;
                ab2.IsEnabled = false;
                stat.Text += "Единство с природой - исцеление и броня увеличены \n";
                Enemy.Hp -= (Hero.Dmg + Hero.Bonus);
                turn++;
                f5();
            }
            else if (Hero.clas == "Колдун")
            {
                ab2.IsEnabled = false;
                int resDmg = Enemy.Dmg + Hero.Bonus2 - 10;
                if (resDmg < 1) resDmg = 1;
                Shot he = new Shot(resDmg);
                a2 = he.Cast() + turn + 2;
                stat.Text += "Вы затуманили разум противника. Он получил " + (resDmg).ToString() + " урона. \n";
                f5();
            }
            else if (Hero.clas == "Паладин")
            {
                Hero.Kd += Hero.Bonus2/3+1;
                a2 = 5 + turn;
                ab2.IsEnabled = false;
                Buff.KdBuff += Hero.Bonus2 / 3 + 1;
                stat.Text += "Божественный щит! Вы получаете " + (Hero.Bonus2/3+1).ToString() + " защиты до конца боя. \n";
                shieldUsed++;
                f5();
            }
        }
    }
}
