using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMenu : MonoBehaviour
{
    private float length, startpos;
    public float speed;


    // Start is called before the first frame update
    void Start()
    {
        startpos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = new Vector3(transform.position.x - speed, transform.position.y, transform.position.z);

        if (transform.position.x < startpos - length)
        {
            transform.position = new Vector3(startpos, transform.position.y, transform.position.z);
        }
    }
}
