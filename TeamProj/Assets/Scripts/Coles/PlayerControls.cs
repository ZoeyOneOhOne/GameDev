using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControls : MonoBehaviour
{
    public bool facingRight = true;
    private Rigidbody2D rb;
    public Animator animator;
    //------------------------Movement----------------------//
    public float speed = 5;
    public float runspeed = 5;
    public float dashSpeed;
    private float dashTime;
    public float startDashTime;
    private int direction;
    //------------------------Respsawning---------------------//
    Vector2 respawnPoint;
    public static int respawns = 0;
    //------------------------Jumping----------------------//
    public bool isGrounded = true;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;
    int groundLayer;
    public int extraJumps;
    public int extraJumpValue = 2;
    //------------------------Shooting----------------------//
    public GameObject redLaser;
    public GameObject orbLaser;
    public float fireRate = 10;
    private float lastFireTime = float.MinValue;

    void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
        dashTime = startDashTime;
        groundLayer = LayerMask.NameToLayer("Ground");

        extraJumps = extraJumpValue;
        God.playerObject = gameObject;//4th way to reference a gameobject from another - have the gameobject tell the other one about itself instead of vice versa
        respawnPoint = transform.position;
	}

    void Update()//More responsive - checks our input each frame
    {
        //Checking to see if on ground and double jump stuff
        Collider2D result = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
        if (result)
            isGrounded = true;
        else
            isGrounded = false;

        if (transform.position.y <= -100)
        {
            rb.velocity = Vector2.zero;
          
            ChangeRespawns();
        }


        if (Input.GetButtonDown("Dash"))
        {

            if (dashTime <= 0)
            {
                dashTime = startDashTime;
            }

            else
            {
                Dash();
            }
  
        }


        //JUMPING
        if (isGrounded == true)
            extraJumps = extraJumpValue;
        //JUMP while in air
        if (Input.GetButtonDown("Jump"))
            Jump(); 


        //SHOOTING
        if (Input.GetAxis("Fire1") > 0)
        {
            if (Time.time - (1 / fireRate) > lastFireTime)
            {
                Quaternion spawnRotation = Quaternion.Euler(0, 0, facingRight ? 0 : 180);
                Instantiate(redLaser, gameObject.transform.GetChild(1).position, spawnRotation);
                lastFireTime = Time.time;
            }
        }

        //ALT SHOOTING
        if (Input.GetAxis("Fire2") >0 )
        {
                Quaternion spawnRotation = Quaternion.Euler(0, 0, facingRight ? 0 : 180);
                Instantiate(orbLaser, gameObject.transform.GetChild(1).position, spawnRotation);
        }
    }
	
	void FixedUpdate ()
    {
        //Handle left and right movement
        float movement = Input.GetAxis("Horizontal") * speed;

        animator.SetFloat("Speed", Mathf.Abs(movement));

        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector3(movement, rb.velocity.y, 0);

        float yVel = rb.velocity.y;
        animator.SetFloat("yVelocity", Mathf.Abs(yVel));

        //-------------------------------------------------------------- FLIPPING CHARACTER --------------------------------------------------------------------------------------//
        //Flip character sprite when going right direction
        if (facingRight == false && movement > 0)
        {
            Flip();
        }
        else if(facingRight == true && movement < 0)
        {
            Flip();
        }
        //-------------------------------------------------------------- END --------------------------------------------------------------------------------------//

    }

    public void ChangeRespawns()
    {
        transform.position = respawnPoint;
        respawns++;
        gameObject.GetComponent<Health>().Respawn();
        if (respawns == 3)
        {
            SceneManager.LoadScene("Main Menu");
        }
    }

    public void SetRespawnPoint(Vector2 vec)
    {
        respawnPoint = vec;
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }

    void Jump()
    {
        if (isGrounded == true)
            extraJumps = extraJumpValue;
        //JUMP while in air
        if (extraJumps > 0)
        {
            //Check if we are on the ground right now
            GameObject feet = transform.GetChild(0).gameObject;
            Collider2D[] colliders = Physics2D.OverlapCircleAll(feet.transform.position, 10f);
            foreach (Collider2D col in colliders)
            {
                //Don't jump off ourselves
                if (col.gameObject != this.gameObject)
                {
                    rb.velocity = new Vector2(rb.velocity.x, 0);//Ignore previous falling velocity so we jump the full amount each time.                                      
                    rb.AddForce(Vector2.up * 300);
                    extraJumps--;
                    break;
                }
            }
        }
    }

    void Dash()
    {
        animator.SetBool("isDashing", true);
        dashTime -= Time.deltaTime;
        rb.velocity = new Vector2(rb.velocity.x, dashSpeed);
    }
} 