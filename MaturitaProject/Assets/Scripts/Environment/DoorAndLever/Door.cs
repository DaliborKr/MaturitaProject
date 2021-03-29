using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private Vector3 closePos;
    private Vector3 openPos;

    public Lever[] levers;
    public SpriteRenderer[] lights;

    public float speed;

    private bool isDoorOpen;
    
    public Sprite leverIsActivated;
    public Sprite leverIsNotActivated;

    public bool isHorizontal;

    void Start()
    {
        isDoorOpen = false;

        closePos = transform.position;
        if (isHorizontal)
        {
            openPos = new Vector3(closePos.x - 2.5f, closePos.y, closePos.z);
        }
        else
        {
            openPos = new Vector3(closePos.x, closePos.y + 2.5f, closePos.z);
        }
        
    }

    void Update()
    {
        CheckLeversActivated();
        DoorMove();
        CheckLights();
    }

    public void CheckLeversActivated()
    {
        bool allLeversActivated = true;

        foreach(Lever lever in levers)
        {
            if (!lever.isActivated)
            {
                allLeversActivated = false;
            }
        }

        if (allLeversActivated)
        {
            isDoorOpen = true;
        }
        else
        {
            isDoorOpen = false;
        }

    }

    public void DoorMove()
    {
        if (!isHorizontal)
        {
            if (isDoorOpen && transform.position.y < openPos.y)
            {
                transform.Translate(Vector2.up * speed * Time.deltaTime);
            }
            else if (isDoorOpen && transform.position.y >= openPos.y)
            {
                transform.position = openPos;
            }
            else if (!isDoorOpen && transform.position.y > closePos.y)
            {
                transform.Translate(Vector2.down * speed * Time.deltaTime);
            }
            else if (!isDoorOpen && transform.position.y <= closePos.y)
            {
                transform.position = closePos;
            }
        }
        else
        {
            if (isDoorOpen && transform.position.x > openPos.x)
            {
                transform.Translate(Vector2.up * speed * Time.deltaTime);
            }
            else if (isDoorOpen && transform.position.x <= openPos.x)
            {
                transform.position = openPos;
            }
            else if (!isDoorOpen && transform.position.x < closePos.x)
            {
                transform.Translate(Vector2.down * speed * Time.deltaTime);
            }
            else if (!isDoorOpen && transform.position.x >= closePos.x)
            {
                transform.position = closePos;
            }
        }
    }

    public void CheckLights()
    {
        for (int i = 0; i < lights.Length; i++)
        {
            if (i < levers.Length)
            {
                lights[i].enabled = true;

                if (levers[i].isActivated)
                {
                    lights[i].sprite = leverIsActivated;
                }
                else
                {
                    lights[i].sprite = leverIsNotActivated;
                }

            }
            else
            {
                lights[i].enabled = false;
            }

        }
    }
}
