using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyBase : MonoBehaviour
{
    public static MyBase instance;
    public Transform BaseSpawn;
    public void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    public void Spawn(Transform SpawnPoint, GameObject SpawnObject)
    {
        var Solider = Instantiate(SpawnObject, SpawnPoint);
    }
}
