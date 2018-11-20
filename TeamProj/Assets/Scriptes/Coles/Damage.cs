using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour {

    public float damageAmount = 25;

    private void Start()
    {
     
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        EnemyHealth bh = col.gameObject.GetComponent<EnemyHealth>();
        Health h = col.gameObject.GetComponent<Health>();
        if (bh != null)
            bh.ChangeHealth(-damageAmount);
        if (h != null)
        {
            h.ChangeHealth(-damageAmount);
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        EnemyHealth bh = col.gameObject.GetComponent<EnemyHealth>();
        Health h = col.gameObject.GetComponent<Health>();
        if(bh != null)
        bh.ChangeHealth(-damageAmount);
        if (h != null)
        {
            h.ChangeHealth(-damageAmount);
            Destroy(gameObject);
        }
    }

}
