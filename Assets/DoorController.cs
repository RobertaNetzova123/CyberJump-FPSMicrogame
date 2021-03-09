using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    [SerializeField]
    Animator _doorAnim;
    [SerializeField]
    GameObject door;

    // Start is called before the first frame update
    void Start()
    {
        _doorAnim = door.GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        _doorAnim.SetBool("isOpening", true);
        Debug.Log(other.gameObject.name + " entered");
    }

    private void OnTriggerExit(Collider other)
    {
        _doorAnim.SetBool("isOpening", false);
        Debug.Log(other.gameObject.name + " exited");
    }
}