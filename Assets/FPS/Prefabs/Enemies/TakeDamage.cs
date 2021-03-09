using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamage : MonoBehaviour
{

    public enum collisionType { head, body }
    public collisionType damageType;
    public EnemyScriptController controller;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HIT(double value)
    {
        try
        {
            controller.hp -= value;
            if (controller.hp <= 0)
            {
                controller.Die();
            }
        }
        catch
        {

            print("controller is not connected");
        }
    }
}
