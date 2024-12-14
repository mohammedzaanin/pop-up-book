using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

namespace Popub_Book{
public class MoveWings : MonoBehaviour
{
    public Transform wing;  
    public Transform wing1; 
    public float speed = 10f; 
    public float range = 450f; 

    private float time;

    void FixedUpdate()
    {
        time += Time.deltaTime * speed;
        float angle = Mathf.Sin(time) * range;
        wing.Rotate(new Vector3(0f,-angle * Time.deltaTime, 0f), Space.Self);
        wing1.Rotate(new Vector3(0f,angle * Time.deltaTime, 0f), Space.Self);
    }
}
}
