using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpBossController : MonoBehaviour {

    public float speed;
    float Distance_;
    Vector3 playerPos;
    Vector3 newXPos;


    void Update()
    {
        GameObject player = God.playerObject;
        playerPos = player.transform.position;
        newXPos = new Vector3(playerPos.x, playerPos.y, 0);

        if (player)
        {

            Distance_ = Vector3.Distance(gameObject.transform.position, player.transform.position);

            //Following Player

            if (Distance_ <= 10f)
            {
                transform.position = Vector3.MoveTowards(transform.position, newXPos, speed);
            }
        }

    }
}
