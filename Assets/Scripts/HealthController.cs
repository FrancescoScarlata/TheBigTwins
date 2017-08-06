using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Networking;

public class HealthController : NetworkBehaviour {

    const int maxHealth = 500;
    [SyncVar(hook ="OnChangeHealth")]
    public int currentHealth = maxHealth;

    public RectTransform healthBar;


    public void TakeDamage(int amount)
    {
        if (!isServer)
        {
            return;
        }

        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Debug.Log("Dead!"); // da modificare
        }

        
    }

    void OnChangeHealth(int health)
    {
        healthBar.sizeDelta = new Vector2(health, healthBar.sizeDelta.y);
    }

}
