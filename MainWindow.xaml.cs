using System;
using System.Windows;
using System.Windows.Controls;
using Darkest_Fighters.Classes;

namespace Darkest_Fighters
{

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CreateHero(string heroType)
        {
            // Create a new hero of the specified type
            Hero hero = new Hero(heroType);
            // Update the UI with the hero's stats
            LblAttackDamage.Content = $"AD: {hero.AttackDamage}";
            PbHealtBar.Maximum = hero.HealthPoints;
            PbHealtBar.Value = hero.HealthPoints;
            LblArmor.Content = $"Armor: {hero.AttackResist}";
            LblExperience.Content = $"XP: {hero.ExperiencePoints}";
            LblGold.Content = $"Gold: {hero.Gold}";
        }

        private void Class_click(object sender, RoutedEventArgs e)
        {
            // Get the button that was clicked
            Button? button = sender as Button;

            // Create a hero of the specified type
            CreateHero(button?.Tag.ToString());
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Check if the health bar is at maximum
            if (Math.Abs(PbHealtBar.Value - 100) < 0.001)
            {
                // If it is, return without doing anything
                return;
            }

            // Create a new Enemies object
            Enemies enemies = new Enemies();

            // Get a random enemy name
            var randomEnemy = enemies.RandomEnemies();
            foreach (var enemy in randomEnemy)
            {
                // Display the enemy name to the user
                MessageBox.Show("You encountered a " + enemy + "!");
            }

            // Disable all buttons
            BtnAssassin.IsEnabled = false;
            BtnBruiser.IsEnabled = false;
            BtnTank.IsEnabled = false;
        }
    }
}
