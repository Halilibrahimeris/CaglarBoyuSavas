using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelController : MonoBehaviour
{
    public GameObject[] Models;
    bool time1 = true;
    bool time2 = true;
    bool time3 = true;
    private void Start()
    {
        for (int i = 0; i < 3; i++)
        {
            Models[i].SetActive(false);
        }
        Models[0].SetActive(true);
    }
    private void Update()
    {
        if(GameManager.instance._Age == GameManager.Age.TasDevri && time1)
        {
            Models[0].SetActive(true);
            Models[1].SetActive(false);
            Models[2].SetActive(false);
            time1 = false;
        }
        else if (GameManager.instance._Age == GameManager.Age.OrtaCag && time2)
        {
            Models[0].SetActive(false);
            Models[1].SetActive(true);
            Models[2].SetActive(false);
            time2 = false;
        }
        else if(GameManager.instance._Age == GameManager.Age.UzayCagý && time3)
        {
            Models[0].SetActive(false);
            Models[1].SetActive(false);
            Models[2].SetActive(true);
            time3 = false;
        }

    }
}
