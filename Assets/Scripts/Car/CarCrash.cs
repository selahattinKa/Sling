using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarCrash : MonoBehaviour
{
    public bool isCrashed = false;
    public bool isActive = false;
    public GameObject gameOver;
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        gameOver.SetActive(isCrashed);
        if (isCrashed)
        {
            Time.timeScale = 0f;
            rb.constraints = RigidbodyConstraints2D.FreezeAll;        
        }
        
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Path"))
        {
            isCrashed = true;
        }
    }
}
