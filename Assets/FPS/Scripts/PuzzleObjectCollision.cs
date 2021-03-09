using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleObjectCollision : MonoBehaviour
{
    //gameObjects = GameObject.FindGameObjectWithTag("Puzzle Piece");
    // Start is called before the first frame update
    public Animator animator;
    void Start()
    {
        //Debug.Log("In collission script");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        Debug.Log("On collision");
        Debug.Log("other " + other.gameObject.name);
        Debug.Log("normal " + gameObject.name);
        if (other.gameObject.tag == "Puzzle Piece" && gameObject.tag == "Puzzle Piece")
        {
            Debug.Log(".....................Collision with piece registered");
            animator.SetBool("Door_open", true);
        }
    }
}
