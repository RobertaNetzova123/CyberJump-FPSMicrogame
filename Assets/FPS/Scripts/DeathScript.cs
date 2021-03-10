using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathScript : MonoBehaviour
{
    public EnemyScriptController Enemy1;
    public EnemyScriptController Enemy2;
    private bool E1D = false;
    private bool E2D = false;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        try
        {
            if(Enemy1.ReturnDeath())
            {
                E1D = true;
            }
            if (Enemy2.ReturnDeath())
            {
                E2D = true;
            }
        }
        catch (System.Exception)
        {

            throw;
        }
        if(E1D && E2D)
        {
            Destroy(gameObject);
        }
        
    }
    private void LateUpdate()
    {
        
    }
}
