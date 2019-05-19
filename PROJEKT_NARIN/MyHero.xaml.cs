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
    /// Логика взаимодействия для MyHero.xaml
    /// </summary>
    public partial class MyHero : Window
    {
        public MyHero()
        {
            InitializeComponent();

        }
        public bool correct = true;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            if (pol2.IsChecked == true)
            {
                Hero.IsMan = false;
            }
            else if (pol1.IsChecked == true || pol3.IsChecked == true)
            {
                Hero.IsMan = true;
            }
            else
            {
                correct = false;
            }

            if (nameTb.Text == "")
            {
                correct = false;
            }
            else
            {
                Hero.Name = nameTb.Text;
            }

            if (class1.IsChecked == true)
            {
                Hero.clas = "Воин";
                Hero.dmgType = "Меч";
                Hero.Dmg+=2;
            }
            else if (class2.IsChecked == true)
            {
                Hero.clas = "Волшебник";
                Hero.dmgType = "Посох";
                Hero.Bonus++;
            }
            else if (class3.IsChecked == true)
            {
                Hero.clas = "Лучник";
                Hero.dmgType = "Лук";
                Hero.Crit++;
            }
            else if (class4.IsChecked == true)
            {
                Hero.clas = "Колдун";
                Hero.dmgType = "Заговор";
                Hero.HpMax += 5;
            }
            else if (class5.IsChecked == true)
            {
                Hero.clas = "Паладин";
                Hero.dmgType = "Молот";
                Hero.Kd += 2;
            }
            else
            {
                correct = false;
            }





            if (race1.IsChecked == true)
            {
                Hero.race = "Человек";

            }
            else if (race2.IsChecked == true)
            {
                Hero.race = "Эльф";
            }
            else if (race3.IsChecked == true)
            {
                Hero.race = "Дварф";
            }
            else if (race4.IsChecked == true)
            {
                Hero.race = "Полурослик";
                Hero.regen+=2;
                Hero.Crit++;
            }
            else if (race5.IsChecked == true)
            {
                Hero.race = "Орк";
                Hero.Dmg += 2;
            }
            else
            {
                correct = false;
            }
            if (correct == true)
            {
                Hero.price1 = 10;
                Hero.price2 = 15;
                Hero.price3 = 20;
                Hero.price4 = 15;
                Hero.price5 = 10;
                Hero.price6 = 20;

                if (Hero.race == "Человек")
                {
                    Hero.price1 -= 8;
                    Hero.price2 -= 8;
                    Hero.price3 -= 8;
                    Hero.price4 -= 8;
                    Hero.price5 -= 8;
                    Hero.price6 -= 8;
                }
                Hero.HpMax += 50;
                Hero.regen += 3;
                Hero.Hp = Hero.HpMax;
                Hero.Dmg += 5;
                Hero.critKoef = 2;
                Hero.Kd = 10;
                Hero.Crit += 1;
                Hero.Bonus = 1;
                Hero.Bonus2 = 1;
                this.Close();
            }
            else
            {
                MessageBox.Show("Не все данные введены корректно!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                correct = true;
            }

                       
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            race1.IsChecked = true;
            class1.IsChecked = true;
            nameTb.Text = "Герой";
            pol1.IsChecked = true;
        }
    }
}
