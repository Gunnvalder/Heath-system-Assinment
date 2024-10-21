using System;
using UnityEngine;

public class HealthSystem
{
    // Variables
    public int playerHealth;
    public int enemyHealth;
    public int playerShield;
    public int enemyShield;
    public int lives;
    public GameObject Player;
    public GameObject Enemy;

    public string playerHealthStatus
    {
        get
        {
            if (playerHealth <= 0)
                return "Imminent Danger";
            else if (playerHealth <= 50)
                return "Badly Hurt";
            else if (playerHealth <= 75)
                return "Hurt";
            else if (playerHealth <= 90)
                return "Healthy";
            else return "Perfect Health";
        }
    }

    public string enemyHealthStatus
    {
        get
        {
            if (enemyHealth <= 0)
                return "Imminent Danger";
            else if (enemyHealth <= 50)
                return "Badly Hurt";
            else if (enemyHealth <= 75)
                return "Hurt";
            else if (enemyHealth <= 90)
                return "Healthy";
            else return "Perfect Health";
        }
    }

    // Optional XP system variables
    public int xp;
    public int level;

    public HealthSystem()
    {
        ResetGame();
    }

    public string ShowHUD()
    {
        // Implement HUD display
        return "";
    }

    public void PlayerTakeDamage(int damage)
    {
        if (damage < 0) return;
        {
            if (playerShield > 0)
            {
                if (damage >= playerShield)
                {
                    damage -= playerShield;
                    playerShield = 0;
                    playerHealth = Mathf.Max(playerHealth - damage, 0);
                }
            }
            else
            {
                playerShield -= damage;
                playerHealth = Mathf.Max(playerHealth - damage, 0);
            }
        }


        if (playerShield > 0)
        {
            damage -= playerShield;
            playerShield = Math.Max(0, playerShield - damage);
            damage = Math.Max(0, damage);
        }

        playerHealth = Math.Max(0, playerHealth - damage);

        if (playerHealth == 0)
           Revive();

        Debug.Log(playerHealth);
    }

    public void EnemyTakeDamage(int damage)
    {
        if (damage < 0) return;
        {
            if (enemyShield > 0)
            {
                if (damage >= enemyShield)
                {
                    damage -= enemyShield;
                    enemyShield = 0;
                    enemyHealth = Mathf.Max(enemyHealth - damage, 0);
                }
            }
            else
            {
                enemyShield -= damage;
                enemyHealth = Mathf.Max(enemyHealth - damage, 0);
            }
        }


        //if (shield > 0)
        //{
        //    damage -= shield;
        //    shield = Math.Max(0, shield - damage);
        //    damage = Math.Max(0, damage);
        //}

        enemyHealth = Math.Max(0, enemyHealth - damage);

        if (enemyHealth == 0)
            Revive();

        Debug.Log(enemyHealth);
    }

    public void Heal(int hp)
    {
        playerHealth = Math.Min(100, playerHealth + hp);
    }

    public void RegenerateShield(int hp)
    {
        playerShield = Math.Min(100, playerShield + hp);   
    }

    public void Revive()
    {
        lives = Math.Max(0, lives - 1);
        playerHealth = 100;

        if (lives <= 0)
        {
            Debug.Log("Game Over");
        }
    }

    public void ResetGame()
    {
        //Reset all variables to default values
        playerHealth = 100;
        playerShield = 100;
        enemyHealth = 100;
        enemyShield = 100;
        lives = 3;
    }

    // Optional XP system methods
    public void IncreaseXP(int exp)
    {
        // Implement XP increase and level-up logic
    }

    public class HealthSystemTests
    {
        public void Test_PlayerTakeDamage_OnlyShield()
        {
            HealthSystem system = new HealthSystem();
            system.playerShield = 100;
            system.playerHealth = 100;
            system.lives = 3;

            system.PlayerTakeDamage(10);

            Debug.Assert(90 == system.playerShield);
            Debug.Assert(100 == system.playerHealth);
            Debug.Assert(3 == system.lives);
        }

        public void Test_PlayerTakeDamage_ShieldAndHealth()
        {
            HealthSystem system = new HealthSystem();
            system.playerShield = 50;
            system.playerHealth = 100;
            system.lives = 3;

            system.PlayerTakeDamage(60);

            Debug.Assert(0 == system.playerShield);
            Debug.Assert(40 == system.playerHealth);
            Debug.Assert(3 == system.lives);
        }

        public void Test_PlayerTakeDamage_OnlyHealth()
        {
            HealthSystem system = new HealthSystem();
            system.playerShield = 0;
            system.playerHealth = 100;
            system.lives = 3;

            system.PlayerTakeDamage(50);

            Debug.Assert(0 == system.playerShield);
            Debug.Assert(50 == system.playerHealth);
            Debug.Assert(3 == system.lives);
        }

        public void Test_PlayerTakeDamage_HealthZero()
        {
            HealthSystem system = new HealthSystem();
            system.playerShield = 0;
            system.playerHealth = 50;
            system.lives = 3;

            system.PlayerTakeDamage(50);

            Debug.Assert(0 == system.playerShield);
            Debug.Assert(0 == system.playerHealth);
            Debug.Assert(3 == system.lives);
        }

        public void Test_PlayerTakeDamage_ShieldAndHealthZero()
        {
            HealthSystem system = new HealthSystem();
            system.playerShield = 20;
            system.playerHealth = 30;
            system.lives = 3;

            system.PlayerTakeDamage(50);

            Debug.Assert(0 == system.playerShield);
            Debug.Assert(0 == system.playerHealth);
            Debug.Assert(3 == system.lives);
        }

        public void Test_PlayerTakeDamage_NegativeInput()
        {
            HealthSystem system = new HealthSystem();
            system.playerShield = 100;
            system.playerHealth = 100;
            system.lives = 3;

            system.PlayerTakeDamage(-10);

            Debug.Assert(100 == system.playerShield);
            Debug.Assert(100 == system.playerHealth);
            Debug.Assert(3 == system.lives);
        }

        public void Test_Heal_NormalHealing()
        {
            HealthSystem system = new HealthSystem();
            system.playerHealth = 50;
            

            system.Heal(30);

            Debug.Assert(80 == system.playerHealth);
        }

        public void Test_Heal_AtMaxHealth()
        {
            HealthSystem system = new HealthSystem();
            system.playerHealth = 100;


            system.Heal(30);

            Debug.Assert(100 == system.playerHealth);
        }

        public void Test_Heal_NegativeInput()
        {
            HealthSystem system = new HealthSystem();
            system.playerHealth = 50;

            system.Heal(-20);

            Debug.Assert(50 == system.playerHealth);
        }

        public void Test_RegenerateShield_Normal()
        {
            HealthSystem system = new HealthSystem();
            system.playerShield = 50;


            system.RegenerateShield(30);

            Debug.Assert(80 == system.playerShield);
        }

        public void Test_RegenerateShield_AtMax()
        {
            HealthSystem system = new HealthSystem();
            system.playerShield = 100;


            system.RegenerateShield(30);

            Debug.Assert(100 == system.playerShield);
        }

        public void Test_RegenerateShield_NegativeInput()
        {
            HealthSystem system = new HealthSystem();
            system.playerShield = 50;

            system.RegenerateShield(-20);

            Debug.Assert(50 == system.playerShield);
        }

        public void Test_Revive()
        {
            HealthSystem system = new HealthSystem();
            system.playerHealth = 0;
            system.playerShield = 0;
            system.lives = 3;

            system.Revive();

            Debug.Assert(100 == system.playerHealth);
            Debug.Assert(100 == system.playerShield);
            Debug.Assert(2 == system.lives);
        }
    }

}