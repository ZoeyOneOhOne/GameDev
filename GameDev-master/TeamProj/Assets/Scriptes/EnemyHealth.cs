using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyHealth : MonoBehaviour {

    private float health;
    public float healthMax = 100;
    private bool isDead;

    public AudioSource deathSound;

    public void Start()
    {
        health = healthMax;
        isDead = false;
    }


    public void ChangeHealth(float deltaHealth)
    {
        health = Mathf.Min(health + deltaHealth, healthMax); //Alter health but dont let it go below 0 and above 100

        if (health <= 0)
        {
            isDead = true;
            Destroy(gameObject);
            if (gameObject.tag == "Boss")
                SceneManager.LoadScene("Main Menu");
        }

    }

    public bool IsDead()
    {
        return isDead;
    }
}
