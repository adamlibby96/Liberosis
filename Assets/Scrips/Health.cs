using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour {
    [SerializeField] private float health = 100;
    [SerializeField] private Slider healthBar;

    void Update()
    {
        healthBar.value = health;
    }

    public void consumeHealth(float amount)
    {
        health += amount;
    }


	public void deductHealth(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Debug.Log("Player died");
        }
    }
}
