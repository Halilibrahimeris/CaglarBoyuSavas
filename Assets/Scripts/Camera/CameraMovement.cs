using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float speed;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D) && transform.position.z <= 12.08f)
        {
            transform.position += Vector3.forward * speed * Time.deltaTime;
            Debug.Log("Saga git");
        }
        else if(Input.GetKey(KeyCode.A) && transform.position.z >= -10.63)
        {
            transform.position += Vector3.back * speed * Time.deltaTime;
            Debug.Log("Sola git");
        }
    }
}
