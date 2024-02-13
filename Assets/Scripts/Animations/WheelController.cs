using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelController : MonoBehaviour
{
    public enum Type
    {
        Enemy,
        Ally
    }
    public MovementAndStates Parent;
    public Type SoliderType;
    public List<GameObject> Wheels;
    public float Speed;
    private void Start()
    {
        Parent = GetComponentInParent<MovementAndStates>();
    }
    private void Update()
    {
        foreach (var wheel in Wheels)
        {
            if (Parent.Run)
            {
                if (SoliderType == Type.Ally)
                {
                    wheel.transform.Rotate(0f, -Speed * Time.deltaTime, 0f);
                }
                else
                {
                    wheel.transform.Rotate(0f, Speed * Time.deltaTime, 0f);
                }
            }
        }
    }
}
