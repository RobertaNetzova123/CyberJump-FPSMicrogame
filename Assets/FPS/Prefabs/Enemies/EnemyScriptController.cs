using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScriptController : MonoBehaviour
{

    public double hp = 100;

    private Animator animator;
    private bool Dead = false;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void Die()
    {
        animator.SetBool("Dead", true);
        Dead = true;
        Invoke("RemoveBody", 10);
       
    }

    public bool ReturnDeath()
    {
        return Dead;
    }

    public void RemoveBody()
    {
        Destroy(gameObject);
    }
  
}
