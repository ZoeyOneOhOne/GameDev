using UnityEngine;

public class Turret : MonoBehaviour
{
    public GameObject laserPrefab;
    public float fireRate = 1;
    public bool useLineOfSight;
    public float Distance_;

    float lastFireTime = float.MinValue;

    /*
     * SOH CAH TOA
     * Sin Opposite over Hypoteneuse
     * Cosine Adjacent over Hypoteneuse
     * Tangent Opposite over Adjacent
        Θ = Theta = Angle
        Tan(Θ) = Opposite/Adjacent
        Θ = ArcTan(Opposite/Adjacent)
        ArcTan returns only 0-90 degrees
        Most math libraries/game engines have an 'ATAN2' function that returns 0-360 degrees
        */


    void Update ()
    {
        GameObject player = God.playerObject;

        Distance_ = Vector3.Distance(gameObject.transform.position, player.transform.position);

        Vector3 dif = player.transform.position - transform.position;

        if (Distance_ < 5)
        {
            float angle = Mathf.Rad2Deg * Mathf.Atan2(dif.y, dif.x);
            transform.eulerAngles = new Vector3(0, 0, angle);

            if (Time.time - (1 / fireRate) > lastFireTime)
            {
                Instantiate(laserPrefab, transform.position, transform.rotation);
                lastFireTime = Time.time;
            }
        }
	}
}
