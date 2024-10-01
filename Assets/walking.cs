using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class walking : MonoBehaviour
{
    public float spd=1.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.W))
        {
            transform.Translate(0,0,spd*Time.deltaTime);
        }

        if(Input.GetKey(KeyCode.S))
        {
            transform.Translate(0,0,spd*Time.deltaTime*-1);
        }

        if(Input.GetKey(KeyCode.D))
        {
            transform.Translate(spd*Time.deltaTime,0,0);
        }

        if(Input.GetKey(KeyCode.A))
        {
            transform.Translate(spd*Time.deltaTime*-1,0,0);
        }

        Vector2 positionOnScreen = Camera.main.WorldToViewportPoint(transform.position);

        Vector2 mouseOnScreen =(Vector2)Camera.main.ScreenToViewportPoint(Input.MousePosition);

        public float angle = Angle(positionOnScreen,mouseOnScreen);

        transform.rotation = Quaternion.Euler(new Vector3(0f,0f,angle));


    }

    float Angle(Vector3 a, Vector3 b)
    {
        return  Mathf.Atan2(a.y - b.y, a.x-b.x) * Mathf.Rad2Deg;
    }

    
}
