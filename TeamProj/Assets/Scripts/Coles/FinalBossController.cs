using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalBossController : MonoBehaviour {
    public float speed;
    float Distance_;
    Vector3 playerPos;
    Vector3 newXPos;
    private Rigidbody2D rb;
    private float nextActionTime = 0.0f;
    public float period = .5f;
    public Animator animator;
    public bool facingLeft = true;


    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        GameObject player = God.playerObject;
        playerPos = player.transform.position;
        newXPos = new Vector3(playerPos.x, playerPos.y, 0);

        float xVel = rb.velocity.x;

        if (player)
        {
            //Following Player
            Distance_ = Vector3.Distance(gameObject.transform.position, player.transform.position);
            if (Distance_ <= 10f)
            {
                transform.position = Vector3.MoveTowards(transform.position, newXPos, speed);
            }
        }

        if (facingLeft == false && xVel > 0)
        {
            Flip();
        }
        else if (facingLeft == false && xVel < 0)
        {
            Flip();
        }

    }

    void Flip()
    {
        facingLeft = !facingLeft;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
}
