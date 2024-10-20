using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
}
