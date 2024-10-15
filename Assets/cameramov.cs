using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameramov : MonoBehaviour
{
    public Camera cam;
    public Transform player;
    public float treshold;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousepos = cam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 targetpos = (player.position + mousepos)/2f;

        targetpos.x = Mathf.Clamp(targetpos.x, -treshold + player.position.x , treshold+player.position.x);
        targetpos.z = Mathf.Clamp(targetpos.z, -treshold + player.position.z , treshold+player.position.z);
        targetpos.y=6.5351f;

        this.transform.position=targetpos;
    }
}
