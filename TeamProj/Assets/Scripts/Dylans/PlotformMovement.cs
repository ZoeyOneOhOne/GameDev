using UnityEngine;
using UnityEngine.UI;

public class PlotformMovement : MonoBehaviour {

    public Slider slider;
    public Vector3 startPoint, endPoint;
    float currentPercentage = 0;
    public float travelSpeed = 1;

    void Start()
    {
        startPoint = transform.GetChild(0).position;
        endPoint = transform.GetChild(1).position;
        slider = (Slider)gameObject.GetComponentInChildren(typeof(Slider));
    }

    void Update()
    {
        currentPercentage = Mathf.PingPong(Time.time, travelSpeed);
        if (slider)
            slider.value = currentPercentage;
        transform.position = Vector3.Lerp(startPoint, endPoint, currentPercentage);
    }

}
