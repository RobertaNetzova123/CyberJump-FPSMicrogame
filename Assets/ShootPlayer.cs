using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootPlayer : MonoBehaviour   
{
    public EnemyScriptController controller;
    public float EnemyRange = 15f;
    private bool Rotates = false;
    public float RotationSpeed = 25f;

    public Transform target;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Rotates && !controller.ReturnDeath())
        {
            var q = Quaternion.LookRotation(target.position - transform.position);
            q.x = 0f;
            q.z = 0f;
        transform.rotation = Quaternion.RotateTowards(transform.rotation, q, RotationSpeed * Time.deltaTime);

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        Rotates = true;
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
            Rotates = false;
    }
}
