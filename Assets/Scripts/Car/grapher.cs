using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class grapher : MonoBehaviour
{
        public Rigidbody2D carRigidbody; // Arabanın Rigidbody2D bileşeni
        public Rigidbody2D connectRb;

       public LineRenderer _lineRenderer;
       [FormerlySerializedAs("_distanceJoint")] public HingeJoint2D  _hingeJoint2D;
       public bool isTrigger = false;
       public Vector3 flagPos;
       public float motorSpeed = -500f;
   
       // Start is called before the first frame update
       void Start()
       {
           _hingeJoint2D.enabled = false;
       }
   
       // Update is called once per frame
       void Update()
       {
           if (Input.GetKeyDown(KeyCode.Mouse0))
           {
               StartGrapple();
           }
           else if (Input.GetKeyUp(KeyCode.Mouse0))
           {
               StopGrapple();
           }
           if (_hingeJoint2D.enabled) 
           {
               _lineRenderer.SetPosition(1, transform.position);
           }
       }
       void LateUpdate() {
           // DrawRope();
       }

       private void StopGrapple()
       {
           JointMotor2D motor2D = _hingeJoint2D.motor;
           motor2D.motorSpeed = 0f;
           _hingeJoint2D.motor = motor2D;
           _hingeJoint2D.enabled = false;
           _lineRenderer.enabled = false;
       }

       private void StartGrapple()
       {
           if (isTrigger)
           {
               _lineRenderer.SetPosition(0, flagPos);
               Debug.Log(flagPos);
               _lineRenderer.SetPosition(1, transform.position);
               _hingeJoint2D.connectedAnchor = flagPos;
               _hingeJoint2D.connectedBody = connectRb;
               JointMotor2D motor2D = _hingeJoint2D.motor;
               motor2D.motorSpeed = motorSpeed;
               _hingeJoint2D.motor = motor2D;
               
               _hingeJoint2D.enabled = true;
               _lineRenderer.enabled = true;
           
              // currentGrapplePosition = transform.position;

           }
       }
    
       

       private void OnTriggerEnter2D(Collider2D col)
       {
           if (col.gameObject.layer == LayerMask.NameToLayer("Flag"))
           {
               connectRb = col.GetComponent<Rigidbody2D>();
               Vector3 flagPosition = col.transform.position;
               flagPos = flagPosition;
               isTrigger = true;
               Debug.Log("Triggerlandı!");

           }

           else if (col.gameObject.layer != LayerMask.NameToLayer("Flag"))
           {
               isTrigger = false;
           }
       }
       
       
}
