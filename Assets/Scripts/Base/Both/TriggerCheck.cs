using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCheck : MonoBehaviour
{
    [SerializeField] string Type;//Kontrol edilecek nesnenin hedef tagi
    public GameObject Object;//Tespit edilen nesnenin GameObjecti
    public bool CanSpawn;//Spawn atabileceðimizi kontrol eden bool
    private void OnTriggerStay(Collider other)
    {
        if(other.tag == Type)//Triggerýn içinde duran nesnenin tagini kontrol ediyor
        {
            if(Object == null)//Nesnemiz yok ise 
            {
                Object = other.gameObject;//Ýçerideki nesne yeni nesne oluyor
                CanSpawn = false;//Spawn atmamýzý engelliyor
            }
        }
    }
    private void OnTriggerExit(Collider other)//içerideki nesne çýktý ise
    {
        Object = null;//nesnemizi sýfýrlýyoruz
        CanSpawn = true;//spawn izni veriyoruz
    }

    private void Update()
    {
        if(Object == null)
        {
            CanSpawn = true;
        }
    }
}
