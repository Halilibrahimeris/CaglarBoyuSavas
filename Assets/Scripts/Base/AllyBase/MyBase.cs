using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyBase : MonoBehaviour
{
    public static MyBase instance;

    public Transform BaseSpawn;//Nesneleri spawnladýðýmýz nokta
    public void Awake()//instance kodu
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
    
    public void Spawn(Transform SpawnPoint, GameObject SpawnObject)//nesnemizin içinde bulunan spawn atmamýzý saðlayan fonksiyon
    {
        var Solider = Instantiate(SpawnObject, SpawnPoint);
    }
}
