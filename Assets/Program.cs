using System;
using UnityEngine;
using TMPro;
using JetBrains.Annotations;

public class HealthSystem
{
    // Variables
    public int health;
    public int shield;
    public int lives;

    public string healthStatus
    {
        get
        {
            if (health <= 0)
                return "Imminent Danger";
            else if (health <= 50)
                return "Badly Hurt";
            else if (health <= 75)
                return "Hurt";
            else if (health <= 90)
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
        
        return "";
    }

    public void TakeDamage(int damage)
    {
        if (damage < 0) 

        {
            if (shield > 0)
            {
            if (damage >= shield)
            {
                damage -= shield;
                shield = 0;
            }
            }
            else
            {
                shield -= damage;
                damage = 0;
            }
        }

        health = Math.Max(0, health - damage);

        if (health == 0)
        {
            Revive();
        }
            

        Debug.Log(health);
    }


    public void Heal(int hp)
    {
        health = Math.Min(100, health + hp);
    }

    public void RegenerateShield(int hp)
    {
        shield = Math.Min(100, shield + hp);
    }

    public void Revive()
    {
        if (lives > 0)
        {
            lives--;
            health = 100;
        }
        else
        {
            Debug.Log("Game Over");
        }
    }

    public void ResetGame()
    {
        //Reset all variables to default values
        health = 100;
        shield = 100;
        lives = 3;
    }

    // Optional XP system methods
    public void IncreaseXP(int exp)
    {
        // Implement XP increase and level-up logic
    }

}
    public class HealthSystemTests
    {
    public void RunTests()
    {
        Debug.Log("Starting Tests");
        Test_TakeDamage_OnlyShield();
        Test_TakeDamage_ShieldAndHealth();
        Test_TakeDamage_OnlyHealth();
        Test_TakeDamage_HealthZero();
        Test_TakeDamage_ShieldAndHealthZero();
        Test_TakeDamage_NegativeInput();
        Test_Heal_NormalHealing();
        Test_Heal_AtMaxHealth();
        Test_Heal_NegativeInput();
        Test_RegenerateShield_Normal();
        Test_RegenerateShield_AtMax();
        Test_RegenerateShield_NegativeInput();
        Test_Revive();

    }
        public void Test_TakeDamage_OnlyShield()
        {
            HealthSystem system = new HealthSystem();
            system.shield = 100;
            system.health = 100;
            system.lives = 3;

            system.TakeDamage(10);

            Debug.Assert(90 == system.shield);
            Debug.Assert(100 == system.health);
            Debug.Assert(3 == system.lives);
        }

        public void Test_TakeDamage_ShieldAndHealth()
        {
            HealthSystem system = new HealthSystem();
            system.shield = 50;
            system.health = 100;
            system.lives = 3;

            system.TakeDamage(60);

            Debug.Assert(0 == system.shield);
            Debug.Assert(40 == system.health);
            Debug.Assert(3 == system.lives);
        }

        public void Test_TakeDamage_OnlyHealth()
        {
            HealthSystem system = new HealthSystem();
            system.shield = 0;
            system.health = 100;
            system.lives = 3;

            system.TakeDamage(50);

            Debug.Assert(0 == system.shield);
            Debug.Assert(50 == system.health);
            Debug.Assert(3 == system.lives);
        }

        public void Test_TakeDamage_HealthZero()
        {
            HealthSystem system = new HealthSystem();
            system.shield = 0;
            system.health = 50;
            system.lives = 3;

            system.TakeDamage(50);

            Debug.Assert(0 == system.shield);
            Debug.Assert(0 == system.health);
            Debug.Assert(3 == system.lives);
        }

        public void Test_TakeDamage_ShieldAndHealthZero()
        {
            HealthSystem system = new HealthSystem();
            system.shield = 20;
            system.health = 30;
            system.lives = 3;

            system.TakeDamage(50);

            Debug.Assert(0 == system.shield);
            Debug.Assert(0 == system.health);
            Debug.Assert(3 == system.lives);
        }

        public void Test_TakeDamage_NegativeInput()
        {
            HealthSystem system = new HealthSystem();
            system.shield = 100;
            system.health = 100;
            system.lives = 3;

            system.TakeDamage(-10);

            Debug.Assert(100 == system.shield);
            Debug.Assert(100 == system.health);
            Debug.Assert(3 == system.lives);
        }

        public void Test_Heal_NormalHealing()
        {
            HealthSystem system = new HealthSystem();
            system.health = 50;
            

            system.Heal(30);

            Debug.Assert(80 == system.health);
        }

        public void Test_Heal_AtMaxHealth()
        {
            HealthSystem system = new HealthSystem();
            system.health = 100;


            system.Heal(30);

            Debug.Assert(100 == system.health);
        }

        public void Test_Heal_NegativeInput()
        {
            HealthSystem system = new HealthSystem();
            system.health = 50;

            system.Heal(-20);

            Debug.Assert(50 == system.health);
        }

        public void Test_RegenerateShield_Normal()
        {
            HealthSystem system = new HealthSystem();
            system.shield = 50;


            system.RegenerateShield(30);

            Debug.Assert(80 == system.shield);
        }

        public void Test_RegenerateShield_AtMax()
        {
            HealthSystem system = new HealthSystem();
            system.shield = 100;


            system.RegenerateShield(30);

            Debug.Assert(100 == system.shield);
        }

        public void Test_RegenerateShield_NegativeInput()
        {
            HealthSystem system = new HealthSystem();
            system.shield = 50;

            system.RegenerateShield(-20);

            Debug.Assert(50 == system.shield);
        }

        public void Test_Revive()
        {
            HealthSystem system = new HealthSystem();
            system.health = 0;
            system.shield = 0;
            system.lives = 3;

            system.Revive();

            Debug.Assert(100 == system.health);
            Debug.Assert(100 == system.shield);
            Debug.Assert(2 == system.lives);
        }
    }