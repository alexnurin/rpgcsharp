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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PROJEKT_NARIN
{
    /// <summary>
    /// Логика взаимодействия для Inv.xaml
    /// </summary>
    public partial class Inv : Window
    {
        public Inv()
        {
            InitializeComponent();
            f5();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
        private void f5()
        {
            gold.Text = Hero.Gold.ToString();
            invNow1.Text = Hero.Dmg.ToString();
            invNow2.Text = Hero.Kd.ToString();
            invNow3.Text = Hero.Bonus.ToString();
            invNow4.Text = Hero.HpMax.ToString();
            invNow5.Text = Hero.regen.ToString();
            invNow6.Text = Hero.Bonus2.ToString();
            invCost1.Text = Hero.price1.ToString();
            invCost2.Text = Hero.price2.ToString();
            invCost3.Text = Hero.price3.ToString();
            invCost4.Text = Hero.price4.ToString();
            invCost5.Text = Hero.price5.ToString();
            invCost6.Text = Hero.price6.ToString();

            if (Hero.Gold - Hero.price1 >= 0)
                inv1.IsEnabled = true;
            else
                inv1.IsEnabled = false;
            if (Hero.Gold - Hero.price2 >= 0)
                inv2.IsEnabled = true;
            else
                inv2.IsEnabled = false;
            if (Hero.Gold - Hero.price3 >= 0)
                inv3.IsEnabled = true;
            else
                inv3.IsEnabled = false;
            if (Hero.Gold - Hero.price4 >= 0)
                inv4.IsEnabled = true;
            else
                inv4.IsEnabled = false;
            if (Hero.Gold - Hero.price5 >= 0)
                inv5.IsEnabled = true;
            else
                inv5.IsEnabled = false;
            if (Hero.Gold - Hero.price6 >= 0)
                inv6.IsEnabled = true;
            else
                inv6.IsEnabled = false;
        }

        private void inv1_Click(object sender, RoutedEventArgs e)
        {
            if (Hero.Gold - Hero.price1 >= 0)
            {
                Hero.Gold -= Hero.price1;
                Hero.price1 += (1 + Hero.price1 /20) * 5;
                Hero.Dmg++;
                f5();
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void inv2_Click(object sender, RoutedEventArgs e)
        {
            if (Hero.Gold - Hero.price2 >= 0)
            {
                Hero.Gold -= Hero.price2;
                Hero.price2 += (1 + Hero.price2 / 15) * 5;
                Hero.Kd++;
                f5();
            }
        }

        private void inv3_Click(object sender, RoutedEventArgs e)
        {
            if (Hero.Gold - Hero.price3 >= 0)
            {
                Hero.Gold -= Hero.price3;
                Hero.price3 += (1 + Hero.price3 / 5) * 5;
                Hero.Bonus++;
                f5();
            }
        }

        private void inv6_Click(object sender, RoutedEventArgs e)
        {
            if (Hero.Gold - Hero.price6 >= 0)
            {
                Hero.Gold -= Hero.price6;
                Hero.price6 += (1 + Hero.price6 / 5) * 5;
                Hero.Bonus2++;
                f5();
            }
        }
        

        private void inv5_Click(object sender, RoutedEventArgs e)
        {
            if (Hero.Gold - Hero.price5 >= 0)
            {
                Hero.Gold -= Hero.price5;
                Hero.price5 += (1 + Hero.price5 / 10) * 5;
                Hero.regen++;
                if (Hero.regen % 4 == 0)
                    Hero.Crit++;
                f5();
            }
        }

        private void inv4_Click_1(object sender, RoutedEventArgs e)
        {
            if (Hero.Gold - Hero.price4 >= 0)
            {
                Hero.Gold -= Hero.price4;
                Hero.price4 += (1 + Hero.price4 / 10) * 5;
                Hero.HpMax += 5;
                if (Hero.race == "Дварф" || Hero.race == "Эльф")
                    Hero.HpMax+=2;
                f5();
            }
        }
    }
}
