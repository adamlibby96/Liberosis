using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {
    [SerializeField] private float health = 100;
	
	public void deductHealth(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Debug.Log("Player died");
        }
    }
}
