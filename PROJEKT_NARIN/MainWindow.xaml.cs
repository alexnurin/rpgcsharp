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
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
            if (Hero.race == "Человек")
            {
            }
            ImageBrush myBrush = new ImageBrush();
            myBrush.ImageSource = new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), "fone.jpg"));
            this.Background = myBrush;
            if (Hero.Gold == 0)
                mh.ShowDialog();
            hitsMax.Text = 0.ToString();
            hits.Text = 0.ToString();
            f5();
        }
        MyHero mh = new MyHero();
        
    public int dayNow = Hero.dayNow;
        private void heal_Click(object sender, RoutedEventArgs e)
        {
            dayNow++;
            day.Text = "День: " + dayNow.ToString();
            Hero.Hp += Hero.regen;
            hits.Text = Hero.Hp.ToString();
        }
        private void f5()
        {
            nameTbMain.Text = " " + Hero.race + "-" + Hero.clas + " " + Hero.Name + ":";
            hits.Text = Hero.Hp.ToString();
            hitsMax.Text = "из " + Hero.HpMax.ToString();
            damage.Text = Hero.Dmg.ToString();
            dmgType.Text = Hero.dmgType;
            money.Text = Hero.Gold.ToString();
            def.Text = Hero.Kd.ToString();
            day.Text = "День: " + dayNow.ToString();
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            f5();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (Hero.Hp == 0)
            {
                MessageBox.Show("Вы слишком слабы для атаки. Отдохните", "Мало здоровья", MessageBoxButton.OK, MessageBoxImage.Hand);
            }
            else
            {
                if (enemy1.IsChecked == true)
                {
                    Battle bat = new Battle("Крыса");
                    bat.ShowDialog(); dayNow += 3;
                }
                else if (enemy2.IsChecked == true)
                {
                    Battle bat = new Battle("Кобольд");
                    bat.ShowDialog(); dayNow += 3;
                }
                else if (enemy3.IsChecked == true)
                {
                    Battle bat = new Battle("Волк");
                    bat.ShowDialog(); dayNow += 3;
                }
                else if (enemy4.IsChecked == true)
                {
                    Battle bat = new Battle("Огр");
                    bat.ShowDialog(); dayNow += 3;
                }
                else if (enemy5.IsChecked == true)
                {
                    Battle bat = new Battle("Дракон");
                    bat.ShowDialog(); dayNow += 3;
                }
                else if (enemy6.IsChecked == true)
                {
                    Battle bat = new Battle("Тарраск");
                    bat.ShowDialog(); dayNow += 3;
                }
                else
                    MessageBox.Show("Выберите противника", "Противник не выбран", MessageBoxButton.OK, MessageBoxImage.Error);
                f5();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Inv a = new Inv();
            a.ShowDialog();
            f5();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            string klasKod = "0";
            if (Hero.clas == "Воин") klasKod = "1";
            if (Hero.clas == "Волшебник") klasKod = "2";
            if (Hero.clas == "Лучник") klasKod = "3";
            if (Hero.clas == "Колдун") klasKod = "4";
            if (Hero.clas == "Паладин") klasKod = "5";
            string raceKod = "0";
            if (Hero.race == "Человек") raceKod = "1";
            if (Hero.race == "Эльф") raceKod = "2";
            if (Hero.race == "Дварф") raceKod = "3";
            if (Hero.race == "Полурослик") raceKod = "4";
            if (Hero.race == "Орк") raceKod = "5";
            string kod = Hero.result.ToString("000");
            string kod2 = dayNow.ToString("000");
            MessageBox.Show("Запомните этот код вашего сохранения: " + klasKod + raceKod + kod + kod2, "Игра сохранена", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            Load l = new Load();
            l.Show();
            this.Close();
        }
    }
}
