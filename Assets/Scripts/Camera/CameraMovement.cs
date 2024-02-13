using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float speed;//kamera h�z�n� belirten de�i�ken
    public float LeftLimit, RightLimit;//kameran�n gidece�i max limitler

    void Update()
    {
        if (Input.GetKey(KeyCode.D) && transform.position.z <= RightLimit)//D tu�una bas�yorsak ve limiti a�mad�ysak
        {
            if (Input.GetKey(KeyCode.LeftShift))//shifte bas�yorsak daha h�zl� gidece�iz
            {
                transform.position += Vector3.forward * speed * 5 * Time.deltaTime;
            }
            else//shifte bas�m�yorsak normal gidece�iz
            {
                transform.position += Vector3.forward * speed * Time.deltaTime;
            }
        }
        else if (Input.GetKey(KeyCode.A) && transform.position.z >= LeftLimit)//A tu�una bas�yorsak ve limiti a�mad�ysak
        {
            if (Input.GetKey(KeyCode.LeftShift))//shifte bas�yorsak daha h�zl� gidece�iz
            {
                transform.position += Vector3.back * speed * 5 * Time.deltaTime;
            }
            else//shifte bas�m�yorsak normal gidece�iz
            {
                transform.position += Vector3.back * speed * Time.deltaTime;
            }
        }
    }
}

