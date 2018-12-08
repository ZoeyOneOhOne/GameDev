using UnityEngine;

public class BossDoorControl : MonoBehaviour {


    public Transform redLight;
    bool bossDoorOpen = false; 

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject != God.playerObject || bossDoorOpen == true)
        {
            return;
        }
        else
        {
            if (redLight)
                Instantiate(redLight, transform.GetChild(0).transform.position, transform.rotation);

            if(bossDoorOpen == false)
            {
                Destroy(GameObject.FindWithTag("Boss Door"));
            }
        }
    }
}
