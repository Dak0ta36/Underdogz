using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class walking : MonoBehaviour
{
    public float spd=0.000001f;
    public Camera cam;
    public GameObject bulletPrefab;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {    


        RaycastHit hit;
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray, out hit))
        {
            Vector3 hitPoint = hit.point;
            hitPoint.y = transform.position.y;
            transform.LookAt(hitPoint);
        }

        anim();
        if(Input.GetMouseButtonDown(0))
        {
            shoot();
        }


    }

    public void anim()
    {
        if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))   
        {
            this.GetComponent<Animator>().Play("demo_combat_run");
        }
        else
        {
            this.GetComponent<Animator>().Play("demo_combat_idle");  
        }
    }

    public void FixedUpdate()
    {
        Vector3 dir= transform.forward;
        dir = transform.InverseTransformDirection(dir);
        dir.y = 0;
        dir.Normalize();
        Vector3 dir1 = transform.right;
        dir1 = transform.InverseTransformDirection(dir1);
        dir1.y=0;
        dir1.Normalize();

        if(Input.GetKey(KeyCode.W))
        {
            transform.position += dir * Input.GetAxis("Vertical" ) * spd;
        }

        if(Input.GetKey(KeyCode.S))
        {
            transform.position += dir * Input.GetAxis("Vertical" ) * spd;
        }

        
        if(Input.GetKey(KeyCode.D))
        {
            transform.position += dir1 * Input.GetAxis("Horizontal" ) * spd;
        }

        if(Input.GetKey(KeyCode.A))
        {
            transform.position += dir1 * Input.GetAxis("Horizontal" ) * spd;
        }

        
    }
    
    public void shoot()
    {
        GameObject bullet = GameObject.Instantiate(bulletPrefab);
        bullet.transform.position = transform.position + new Vector3 (0f,2f,0);
        bullet.GetComponent<Rigidbody>().AddForce(transform.forward * 400);

    }

    
}
