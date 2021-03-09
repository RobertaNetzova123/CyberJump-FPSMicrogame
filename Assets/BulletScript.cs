using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public Transform target;
    public Transform bulletStart;
    public EnemyScriptController controller;
    [SerializeField]
    bool canShoot = false;
    [SerializeField]
    public RaycastHit raycast;
    public GameObject projectile;
    public bool canShoot2 = true;
    public float ConeSize =1f;
    public float ShootSpeed = 525f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (canShoot && !controller.ReturnDeath())
        {
            Vector3 targetDir = target.position - transform.position;
            var q = Quaternion.LookRotation(target.position - transform.position);
            
            float angleToPlayer = (Vector3.Angle(targetDir, transform.forward));
            bulletStart.LookAt(target, Vector3.up);
            if (angleToPlayer >= -60 && angleToPlayer <= 60 && canShoot2) // 100° FOV
            {
                float xSpread = Random.Range(-10, 10);
                float ySpread = Random.Range(-10, 10);
                Vector3 spread = new Vector3(xSpread, ySpread, 0.0f).normalized * ConeSize;
                Quaternion rotation = Quaternion.Euler(spread) * bulletStart.rotation;

                GameObject instFoam = Instantiate(projectile, bulletStart.position, rotation);
                Rigidbody instFoamRB = instFoam.GetComponent<Rigidbody>();
                canShoot2 = false;
                instFoamRB.AddRelativeForce(Vector3.forward * ShootSpeed);
                Invoke("ResetShoot", 0.5f);
                Destroy(instFoam, 3f);


            }

        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
            canShoot = true;
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
            canShoot = false;
    }
    private void ResetShoot()
    {
        canShoot2 = true;
    }
}
