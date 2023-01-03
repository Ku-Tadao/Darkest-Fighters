using System.Windows;
using Darkest_Fighters.Classes;
using static Darkest_Fighters.Classes.Player;

namespace Darkest_Fighters
{
    public partial class MainWindow
    {
        private readonly Hero _hero;
        private readonly Enemy _enemy;
        private int _round;

        public MainWindow()
        {
            InitializeComponent();

            // Initialize hero and enemy
            _hero = new Hero("Hero", 100, 100, 10, 5);
            _enemy = new Enemy("Enemy", 100, 100, 5, 2);

            // Set initial values for UI elements
            txtHeroName.Text = _hero.Name;
            txtHeroHealth.Text = _hero.Health.ToString();
            txtHeroMana.Text = _hero.Mana.ToString();
            txtHeroAttackPower.Text = _hero.AttackPower.ToString();
            txtHeroHealPower.Text = _hero.HealPower.ToString();
            txtEnemyName.Text = _enemy.Name;
            txtEnemyHealth.Text = _enemy.Health.ToString();
            txtEnemyMana.Text = _enemy.Mana.ToString();
            txtEnemyAttackPower.Text = _enemy.AttackPower.ToString();
            _round = 1;
            lblRound.Text = "Round: " + _round;
        }
        private void AddToGameLog(string message)
        {
            lvGameLog.Items.Add(message);
        }

        private void PlayGame()
        {
            // Game loop code...

            while (_hero.Health > 0 && _enemy.Health > 0)
            {
                // Hero's turn
                var attackType = GetAttackType();
                var damage = _hero.Attack(attackType, _enemy);
                _enemy.TakeDamage(damage);
                UpdateUi();
                AddToGameLog($"Hero attacks with {attackType} for {damage} damage.");
                if (_enemy.Health <= 0)
                {
                    break;
                }

                // Enemy's turn
                damage = _enemy.Attack(_hero);
                _hero.TakeDamage(damage);
                UpdateUi();
                AddToGameLog($"Enemy attacks for {damage} damage.");
            }
        }

        private AttackType GetAttackType()
        {
            throw new System.NotImplementedException();
        }

        private void UpdateUi()
        {
            txtHeroName.Text = _hero.Name;
            txtHeroHealth.Text = _hero.Health.ToString();
            txtHeroMana.Text = _hero.Mana.ToString();
            txtHeroAttackPower.Text = _hero.AttackPower.ToString();
            txtHeroHealPower.Text = _hero.HealPower.ToString();

            txtEnemyName.Text = _enemy.Name;
            txtEnemyHealth.Text = _enemy.Health.ToString();
            txtEnemyAttackPower.Text = _enemy.AttackPower.ToString();
        }


        private void btnAttack_Click(object sender, RoutedEventArgs e)
        {
            // Get attack type
            AttackType attackType;
            if (rbNormal.IsChecked == true)
                attackType = AttackType.Normal;
            else if (rbMagic.IsChecked == true)
                attackType = AttackType.Magic;
            else
                attackType = AttackType.Critical;

            // Attack enemy
            var damage = _hero.Attack(attackType, _enemy);
            _enemy.TakeDamage(damage);

            // Update UI
            txtEnemyHealth.Text = _enemy.Health.ToString();

            // Check if game is over
            if (_enemy.Health <= 0)
            {
                MessageBox.Show("You win!");
                Close();
            }
            else
            {
                // Enemy's turn
                var enemyDamage = _enemy.Attack(_hero);
                _hero.TakeDamage(enemyDamage);

                // Update UI
                txtHeroHealth.Text = _hero.Health.ToString();

                // Check if game is over
                if (_hero.Health <= 0)
                {
                    MessageBox.Show("You lose!");
                    Close();
                }
            }

            // Update round number
            _round++;
            lblRound.Text = "Round: " + _round;
        }

        private void btnHeal_Click(object sender, RoutedEventArgs e)
        {
            // Heal hero
            _hero.Heal();

            // Update UI
            txtHeroHealth.Text = _hero.Health.ToString();
            txtHeroMana.Text = _hero.Mana.ToString();

            // Enemy's turn
            var enemyDamage = _enemy.Attack(_hero);
            _hero.TakeDamage(enemyDamage);

            // Update UI
            txtHeroHealth.Text = _hero.Health.ToString();

            // Check if game is over
            if (_hero.Health <= 0)
            {
                MessageBox.Show("You lose!");
                Close();
            }
            // Update round number
            _round++;
            lblRound.Text = "Round: " + _round;
        }
    }




}
