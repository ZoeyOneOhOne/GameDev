using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{

    public float health;
    public float healthMax = 100;
    public Slider slider;
    private bool isDead;

    public void Start()
    { 
        health = healthMax;
        isDead = false;
        if (gameObject.tag == "Player")
        {
            slider.value = 1;
        }
    }

    public float healthPercent()
    {
        return health / healthMax;
    }

    public void ChangeHealth(float deltaHealth)
    {
        health = Mathf.Min(health + deltaHealth, healthMax); //Alter health but dont let it go below 0 and above 100

        if (health <= 0)
        {
            isDead = true;
            gameObject.GetComponent<PlayerControls>().ChangeRespawns();
        }
        if (slider)
            slider.value = healthPercent();
    }

    public bool IsDead()
    {
        return isDead;
    }

   

    public void Respawn()
    {
        health = healthMax;
        isDead = false;
        if (slider)
            slider.value = healthPercent();
    }
}

//If his health gets to zero i want him to respawn 
//And if he falls then reset health back to 100
