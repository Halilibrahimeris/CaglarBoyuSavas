using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float speed;
    public float LeftLimit, RightLimit;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D) && transform.position.z <= RightLimit)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                transform.position += Vector3.forward * speed * 5 * Time.deltaTime;
                Debug.Log("Saga git Shift");
            }
            else
            {
                transform.position += Vector3.forward * speed * Time.deltaTime;
                Debug.Log("Saga git");
            }
        }
        else if (Input.GetKey(KeyCode.A) && transform.position.z >= LeftLimit)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                transform.position += Vector3.back * speed * 5 * Time.deltaTime;
                Debug.Log("Sola git Shift");
            }
            else
            {
                transform.position += Vector3.back * speed * Time.deltaTime;
                Debug.Log("Sola git");
            }
        }
    }


}

