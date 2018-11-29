using UnityEngine;

public class Projectile : MonoBehaviour
{
	void Update ()
    {
        GetComponent<Rigidbody2D>().velocity = transform.right * 10;
	}

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag != "Boss")
            Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag != "Boss")    
            Destroy(gameObject);
    }
}
