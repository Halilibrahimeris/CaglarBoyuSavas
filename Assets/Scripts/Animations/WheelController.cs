using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelController : MonoBehaviour
{
    public List<GameObject> Wheels;
    public float Speed;
    private void Update()
    {
        foreach (var wheel in Wheels)
        {
            wheel.transform.Rotate(0f, -Speed * Time.deltaTime, 0f);
        }
    }
}
