using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
	
    public float shakeDuration = 0.1f;

	private float timeCameraShakeLeft;

	public bool cameraShaking;

    // Start is called before the first frame update
    void Start()
    {
        cameraShaking = false;
        timeCameraShakeLeft = 0;
	}

    // Update is called once per frame
    void Update()
    {
		if (cameraShaking)
        {
			if (shakeDuration >= timeCameraShakeLeft)
            {
				transform.position = new Vector3(transform.position.x + Random.Range(-0.16f, 0.16f), 
                    transform.position.y + Random.Range(-0.16f, 0.16f), 0);
				timeCameraShakeLeft += Time.deltaTime;
			}
            else
            {
				cameraShaking = false;
				timeCameraShakeLeft = 0;
            }
        }
        
    }

    
}
