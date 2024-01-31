using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCheck : MonoBehaviour
{
    [SerializeField] string Type;
    public GameObject Object;
    public bool CanSpawn;
    private void OnTriggerStay(Collider other)
    {
        if(other.tag == Type)
        {
            if(Object == null)
            {
                Object = other.gameObject;
                CanSpawn = false;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        Object = null;
        CanSpawn = true;
    }


}
