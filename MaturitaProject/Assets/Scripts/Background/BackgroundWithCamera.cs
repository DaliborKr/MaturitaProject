using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundWithCamera : MonoBehaviour
{
    private float startpos;
    public GameObject cam;
    public float parallaxEffect;
    public float xPos;


    // Start is called before the first frame update
    void Start()
    {
        startpos = transform.position.x;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float dist = (cam.transform.position.x);

        transform.position = new Vector3(startpos + dist + xPos, cam.transform.position.y, transform.position.z);
    }
}
