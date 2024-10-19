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

    
        //if (shield > 0)
        //{
        //    damage -= shield;
        //    shield = Math.Max(0, shield - damage);
        //    damage = Math.Max(0, damage);
        //}

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
        lives = 1;
    }

    // Optional XP system methods
    public void IncreaseXP(int exp)
    {
        // Implement XP increase and level-up logic
    }
}