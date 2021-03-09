using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiftUp : MonoBehaviour
{
    public Transform theDest;
    public Transform player;
    public bool holding = false;
    public GameObject camera;
    public float yeetForce = 500;
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && !holding)
        {
            float dist = Vector3.Distance(player.position, this.transform.position);
            if(dist <= 1.5)
            {
                holding = true;

                camera.SetActive(false);
                GetComponent<Rigidbody>().useGravity = false;
                GetComponent<Rigidbody>().freezeRotation = true;
                this.GetComponent<Rigidbody>().velocity = Vector3.zero;
                this.transform.position = theDest.position;
                this.transform.parent = GameObject.Find("Destination").transform;
                GetComponent<Rigidbody>().isKinematic = true;
            }
        }

        else if(Input.GetKeyDown(KeyCode.E) && holding)
        {
            holding = false;

            GetComponent<Rigidbody>().isKinematic = false;
            GetComponent<Rigidbody>().useGravity = true;
            GetComponent<Rigidbody>().freezeRotation = false;
            camera.SetActive(true);
            this.transform.parent = null;
        }

        if(Input.GetKeyDown(KeyCode.F) && holding)
        {
            holding = false;
            
            GetComponent<Rigidbody>().isKinematic = false;
            GetComponent<Rigidbody>().useGravity = true;
            GetComponent<Rigidbody>().freezeRotation = false;
            GetComponent<BoxCollider>().enabled = true;
            camera.SetActive(true);
            GetComponent<Rigidbody>().AddForce(player.transform.forward * yeetForce);
            this.transform.parent = null;
        }
    }

    
}
