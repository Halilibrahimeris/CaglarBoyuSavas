using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private Camera Cam;

    [HideInInspector] public bool splineGoForward;
    [HideInInspector] public bool splineGoBack;

    public float speed;//kamera hýzýný belirten deðiþken
    public float LeftLimit, RightLimit;//kameranýn gideceði max limitler
    public float MaxZoom, MinZoom;

    private void Start()
    {
        Cam = Camera.main;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.D) && transform.position.z <= RightLimit)//D tuþuna basýyorsak ve limiti aþmadýysak
        {
            if (Input.GetKey(KeyCode.LeftShift))//shifte basýyorsak daha hýzlý gideceðiz
            {
                transform.position += Vector3.forward * speed * 5 * Time.deltaTime;
            }
            else//shifte basýmýyorsak normal gideceðiz
            {
                transform.position += Vector3.forward * speed * Time.deltaTime;
            }
        }
        else if (Input.GetKey(KeyCode.A) && transform.position.z >= LeftLimit)//A tuþuna basýyorsak ve limiti aþmadýysak
        {
            if (Input.GetKey(KeyCode.LeftShift))//shifte basýyorsak daha hýzlý gideceðiz
            {
                transform.position += Vector3.back * speed * 5 * Time.deltaTime;
            }
            else//shifte basýmýyorsak normal gideceðiz
            {
                transform.position += Vector3.back * speed * Time.deltaTime;
            }
        }
        if (Input.GetKey(KeyCode.W))
        {
            splineGoForward = true;
        }
        else
            splineGoForward = false;
        if (Input.GetKey(KeyCode.S))
        {
            splineGoBack = true;
        }
        else
            splineGoBack = false;

        if (Input.mouseScrollDelta.y >= 1 && Cam.fieldOfView > MaxZoom)
        {
            Cam.fieldOfView -= 1;
        }
        else if (Input.mouseScrollDelta.y <= -1 && Cam.fieldOfView < MinZoom)
            Cam.fieldOfView += 1;
    }
}

