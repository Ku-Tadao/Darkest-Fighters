using System;
using System.Collections.Generic;
using System.Windows;
using Darkest_Fighters.Classes;

namespace Darkest_Fighters
{
    public partial class MainWindow
    {
        // create hero and enemy objects
        private readonly Hero _hero = new();
        private Enemy _enemy = new();

        // list to store attack powers for hero
        private List<double> _heroAttackPowers = new() { 10, 20, 30, 40, 50 };
        // array to store attack powers for enemy
        private readonly double[] _enemyAttackPowers = { 10, 20, 30, 40, 50 };

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
                // hero chooses attack type
                Player.AttackType type;
                if (rbNormal.IsChecked == true)
                {
                    type = Player.AttackType.Normal;
                }
                else if (rbMagic.IsChecked == true)
                {
                    type = Player.AttackType.Magic;
                }
                else
                {
                    type = Player.AttackType.Critical;
                }

                // hero attacks enemy
                _enemy = (Enemy)_hero.UseSpecialAttack(_enemy, type);
                txtEnemyHealth.Text = _enemy.Health.ToString();

                // check if enemy is still alive
                if (!_enemy.IsAlive)
                {
                    MessageBox.Show("You have defeated the enemy!");
                }
                else
                {
                    // enemy attacks hero
                    _hero.Attack(_hero, _enemyAttackPowers[new Random().Next(0, 5)]);
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
