using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporting4 : MonoBehaviour
{
    public Transform teleportTarget;
    public GameObject Player;

    void OnTriggerEnter(Collider other)
    {
        Player.transform.position = teleportTarget.transform.position;
        Player.transform.eulerAngles = new Vector3(0, 90, 0);
    }

}
