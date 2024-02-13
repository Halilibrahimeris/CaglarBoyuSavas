using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float speed;//kamera hýzýný belirten deðiþken
    public float LeftLimit, RightLimit;//kameranýn gideceði max limitler

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
    }
}

