using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControls : MonoBehaviour
{
    public float speed = 5;
    Vector2 respawnPoint;
    public static int respawns = 0;


    public GameObject redLaser;
    public float fireRate = 10;
    private float lastFireTime = float.MinValue;

    void Start ()
    {
        God.playerObject = gameObject;//4th way to reference a gameobject from another - have the gameobject tell the other one about itself instead of vice versa
        respawnPoint = transform.position;
	}

    void Update()//More responsive - checks our input each frame
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();

        if (transform.position.y <= -10)
        {
            rb.velocity = Vector2.zero;
          
            ChangeRespawns();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Check if we are on the ground right now
            GameObject feet = transform.GetChild(0).gameObject;
            Collider2D[] colliders = Physics2D.OverlapCircleAll(feet.transform.position, .5f);
            foreach (Collider2D col in colliders)
            {
                //Don't jump off ourselves
                if (col.gameObject != this.gameObject)
                {
                    rb.velocity = new Vector2(rb.velocity.x, 0);//Ignore previous falling velocity so we jump the full amount each time.
                                        
                    rb.AddForce(Vector2.up * 300);

                    break;
                }
            }
        }

        if (Input.GetAxis("Fire1") > 0)
        {
            if (Time.time - (1 / fireRate) > lastFireTime)
            {
                bool goingRight = true;
                Quaternion spawnRotation = Quaternion.Euler(0, 0, goingRight ? 0 : 180);
                Instantiate(redLaser, gameObject.transform.GetChild(1).position, spawnRotation);
                lastFireTime = Time.time;
                //GetComponent<AudioSource>().Play();
            }
        }
       /* if (GetComponent<Health>().IsDead())
            ChangeRespawns(); */
    }
	
	void FixedUpdate ()
    {
        //Handle left and right movement
        float movement = Input.GetAxis("Horizontal") * speed;
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector3(movement, rb.velocity.y, 0);       
	}

    public void ChangeRespawns()
    {
        transform.position = respawnPoint;
        respawns++;
        gameObject.GetComponent<Health>().Respawn();
        Debug.Log(respawns);
        if (respawns == 3)
        {
            SceneManager.LoadScene("Main Menu");
        }
    }

    public void SetRespawnPoint(Vector2 vec)
    {
        respawnPoint = vec;
    }
} 