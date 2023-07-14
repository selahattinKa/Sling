using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    public float maxSpeed;

    public float acc;

    public float steering;

    private Rigidbody2D rb;

    private float X;

    private float Y = 1;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        X = Input.GetAxis("Horizontal");
        Vector2 speed = transform.up * (Y * acc);
        rb.AddForce(speed);

        float direction = Vector2.Dot(rb.velocity, rb.GetRelativeVector(Vector2.up));

        if (acc > 0)
        {
            if (direction > 0)
            {
                rb.rotation -= X * steering * (rb.velocity.magnitude / maxSpeed);
            }
            else
            {
                rb.rotation += X * steering * (rb.velocity.magnitude / maxSpeed);

            }
        }

        float dirtForce = Vector2.Dot(rb.velocity, rb.GetRelativeVector(Vector2.left)) * 2.0f;
        Vector2 relativeForce = Vector2.right * dirtForce;
        rb.AddForce(rb.GetRelativeVector(relativeForce));

        if (rb.velocity.magnitude > maxSpeed)
        {
            rb.velocity = rb.velocity.normalized * maxSpeed;
        }
        

    }
}
