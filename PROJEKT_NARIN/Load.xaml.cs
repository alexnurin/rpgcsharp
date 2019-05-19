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
    /// Логика взаимодействия для Load.xaml
    /// </summary>
    public partial class Load : Window
    {
        public Load()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (tb.Text.Length != 8)
                MessageBox.Show("Проверьте корректность данных", "Не все данные введены корректно", MessageBoxButton.OK);
            else
            {
                Hero.Name = tb2.Text;
                Hero.HpMax = 50;
                Hero.regen = 3;
                Hero.Hp = Hero.HpMax;
                Hero.Dmg = 5;
                Hero.critKoef = 2;
                Hero.Kd = 10;
                Hero.Crit += 1;
                Hero.Bonus = 1;
                Hero.Bonus2 = 1;
                string s = tb.Text;
                char cl = s[0];
                if (cl == '1')
                {
                    Hero.clas = "Воин";
                    Hero.dmgType = "Меч";
                    Hero.Dmg += 2;
                }
                else if (cl == '2')
                {
                    Hero.clas = "Волшебник";
                    Hero.dmgType = "Посох";
                    Hero.Bonus++;
                }
                else if (cl == '3')
                {
                    Hero.clas = "Лучник";
                    Hero.dmgType = "Лук";
                    Hero.Crit++;
                }
                else if (cl == '4')
                {
                    Hero.clas = "Колдун";
                    Hero.dmgType = "Заговор";
                    Hero.HpMax += 5;
                }
                else if (cl == '5')
                {
                    Hero.clas = "Паладин";
                    Hero.dmgType = "Молот";
                    Hero.Kd += 2;
                }

                char ra = s[1];
                if (ra == '1')
                {
                    Hero.race = "Человек";

                }
                else if (ra == '2')
                {
                    Hero.race = "Эльф";
                }
                else if (ra == '3')
                {
                    Hero.race = "Дварф";
                }
                else if (ra == '4')
                {
                    Hero.race = "Полурослик";
                    Hero.regen += 2;
                    Hero.Crit++;
                }
                else if (ra == '5')
                {
                    Hero.race = "Орк";
                    Hero.Dmg += 2;
                }
                Hero.Gold = ((s[2]-48) * 100 + (s[3] - 48) * 10 + s[4] - 48);
                Hero.result = Hero.Gold;
                Hero.dayNow = ((s[5] - 48) * 100 + (s[6] - 48) * 10 + s[7] - 48);
                MainWindow mw = new MainWindow();
                mw.Show();
                this.Close();
            }
        }
    }
}
