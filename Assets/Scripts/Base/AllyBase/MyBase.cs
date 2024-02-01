using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyBase : MonoBehaviour
{
    public static MyBase instance;

    public Transform BaseSpawn;//Nesneleri spawnlad���m�z nokta
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
    
    public void Spawn(Transform SpawnPoint, GameObject SpawnObject)//nesnemizin i�inde bulunan spawn atmam�z� sa�layan fonksiyon
    {
        var Solider = Instantiate(SpawnObject, SpawnPoint);
    }
}
