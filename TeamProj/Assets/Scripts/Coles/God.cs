using UnityEngine;

public class God : MonoBehaviour
{
    public static GameObject globalsObject;
    public static GameObject playerObject;
    public static God Instance;

    public GameObject player;

	void Awake ()//Awake is another Unity (MonoBehavior) that is like start but always runs before any Start runs
    {
        //Reason to put this in Awake is to make sure these references are set before any object's Start function tries to use them

        globalsObject = gameObject;

        playerObject = player;//If an object was linked in the editor, use that
        if (!playerObject)//Otherwise find the player by tag
            playerObject = GameObject.FindGameObjectWithTag("Player");
        if (!playerObject)//Otherwise find the player by finding anything with a PlayerControls script
            playerObject = GameObject.FindObjectOfType<PlayerControls>().gameObject;
        player = playerObject;


        //Perserving stats
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    
        
	}
}
