using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JacksAIController : MonoBehaviour {

    public float speed;
    float Distance_;
    Vector3 playerPos;
    Vector3 newPos;
    public Transform explosion;


    void Update()
    {
        GameObject player = God.playerObject;
        playerPos = player.transform.position;
        newPos = new Vector3(playerPos.x, playerPos.y, 0);

        if (player)
        {
            //Following Player
            Distance_ = Vector3.Distance(gameObject.transform.position, player.transform.position);

            if (Distance_ <= 10f && Distance_ >= 5f);
            {
                transform.position = Vector3.MoveTowards(transform.position, newPos, speed);
            }
        }

    }
}
