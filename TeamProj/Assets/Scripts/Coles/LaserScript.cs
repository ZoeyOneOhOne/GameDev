using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserScript : MonoBehaviour {

    public AudioSource sound;

    void Start()
    {
        Invoke("DieOff", 1); //call another functino after x seconds
        gameObject.GetComponent<Rigidbody2D>().velocity = (50 * gameObject.transform.right);
    }

    void Update()
    {

    }

    void DieOff()
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag != "Player")
         Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "Player")
            Destroy(gameObject);
    }

}