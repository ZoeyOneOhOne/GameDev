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
        if(bh != null)
            bh.ChangeHealth(-damageAmount);
    }

    void OnCollisionEnter2D(Collision2D col)
    {

        Health bh = col.gameObject.GetComponent<Health>();
        if(bh != null)
        bh.ChangeHealth(-damageAmount); 
    }

}
