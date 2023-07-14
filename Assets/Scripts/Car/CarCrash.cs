using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarCrash : MonoBehaviour
{
    public bool isCrashed = false;
    public bool isActive = false;
    public GameObject gameOver;

    private void Update()
    {
        gameOver.SetActive(isCrashed);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Path"))
        {
            if (isActive)
            {
                Time.timeScale = 0f;
                isCrashed = true;
            }
            
        }
    }
}
