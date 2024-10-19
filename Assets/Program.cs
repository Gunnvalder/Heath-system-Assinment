using System;
using UnityEngine;

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
        // Implement HUD display
        return "";
    }

    public void TakeDamage(int damage)
    {
        if (damage < 0) return;
        {
            if (shield > 0)
            {
                if (damage >= shield)
                {
                    damage -= shield;
                    shield = 0;
                    health = Mathf.Max(health - damage, 0);
                }
            }
            else
            {
                shield -= damage;
                health = Mathf.Max(health - damage, 0);
            }
        }

    
        //if (shield > 0)
        //{
        //    damage -= shield;
        //    shield = Math.Max(0, shield - damage);
        //    damage = Math.Max(0, damage);
        //}

        health = Math.Max(0, health - damage);

        if (health == 0)
           Revive();

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
        lives = Math.Max(0, lives - 1);
        health = 100;

        if (lives <= 0)
        {
            Debug.Log("Game Over");
        }
    }

    public void ResetGame()
    {
        //Reset all variables to default values
        health = 100;
        shield = 100;
        lives = 1;
    }

    // Optional XP system methods
    public void IncreaseXP(int exp)
    {
        // Implement XP increase and level-up logic
    }
}