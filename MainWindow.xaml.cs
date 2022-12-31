using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace Darkest_Fighters
{
    public partial class MainWindow : Window
    {
        // create hero and enemy objects
        private Hero _hero = new();
        private Enemy _enemy = new();

        // list to store attack powers for hero
        private List<double> _heroAttackPowers = new() { 10, 20, 30, 40, 50 };
        // array to store attack powers for enemy
        private double[] _enemyAttackPowers = { 10, 20, 30, 40, 50 };

        public MainWindow()
        {
            InitializeComponent();

            // set hero and enemy information on GUI
            txtHeroName.Text = _hero.Name;
            txtHeroHealth.Text = _hero.Health.ToString();
            txtHeroMana.Text = _hero.Mana.ToString();
            txtHeroAttackPower.Text = _hero.AttackPower.ToString();
            txtHeroHealPower.Text = _hero.HealPower.ToString();
            txtEnemyName.Text = _enemy.Name;
            txtEnemyHealth.Text = _enemy.Health.ToString();
            txtEnemyMana.Text = _enemy.Mana.ToString();
            txtEnemyAttackPower.Text = _enemy.AttackPower.ToString();
        }

        // event handler for Attack button click
        private void btnAttack_Click(object sender, RoutedEventArgs e)
        {
            // check if hero and enemy are still alive
            if (_hero.IsAlive && _enemy.IsAlive)
            {
                // hero attacks enemy with a random attack power from the list
                Random rnd = new Random();
                int index = rnd.Next(_heroAttackPowers.Count);
                _hero.Attack(_enemy, _heroAttackPowers[index]);
                txtEnemyHealth.Text = _enemy.Health.ToString();

                // check if enemy is still alive
                if (!_enemy.IsAlive)
                {
                    MessageBox.Show("Enemy defeated!");
                }
                else
                {
                    // enemy attacks hero with a random attack power from the array
                    index = rnd.Next(_enemyAttackPowers.Length);
                    _enemy.Attack(_hero, _enemyAttackPowers[index]);
                    txtHeroHealth.Text = _hero.Health.ToString();

                    // check if hero is still alive
                    if (!_hero.IsAlive)
                    {
                        MessageBox.Show("You have been defeated!");
                    }
                }
            }
            else
            {
                MessageBox.Show("Game over!");
            }
        }

        // event handler for Heal button click
        private void btnHeal_Click(object sender, RoutedEventArgs e)
        {
            // check if hero is still alive and has enough mana
            if (_hero.IsAlive && _hero.Mana >= 20)
            {
                _hero.Heal();
                txtHeroHealth.Text = _hero.Health.ToString();
                _hero.Mana -= 20;
                txtHeroMana.Text = _hero.Mana.ToString();
            }
            else if (!_hero.IsAlive)
            {
                MessageBox.Show("You have been defeated!");
            }
            else
            {
                MessageBox.Show("Not enough mana!");
            }
        }
    }


}
