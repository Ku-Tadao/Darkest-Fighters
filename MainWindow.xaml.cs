using System;
using System.Windows;
using System.Windows.Controls;
using Darkest_Fighters.Classes;

namespace Darkest_Fighters
{

    public partial class MainWindow : Window
    {
        Enemy _enemy;


        public MainWindow()
        {
            InitializeComponent();


            // Create a new enemy with the random name and specified rarity
            Enemy _enemy = new Enemy( 20, 3, 2, 3, 5);
        }


        private void CreateHero(string? heroType, int maxHealthPoints)
        {
          
        }


        private void Class_click(object sender, RoutedEventArgs e)
        {
          _enemy.TakeDamage(10);
        }
        

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            // Disable all buttons
            BtnAssassin.IsEnabled = false;
            BtnBruiser.IsEnabled = false;
            BtnTank.IsEnabled = false;
        }
    }
}
