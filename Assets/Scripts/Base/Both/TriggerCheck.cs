using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCheck : MonoBehaviour
{
    [SerializeField] string Type;//Kontrol edilecek nesnenin hedef tagi
    public GameObject Object;//Tespit edilen nesnenin GameObjecti
    public bool CanSpawn;//Spawn atabilece�imizi kontrol eden bool
    private void OnTriggerStay(Collider other)
    {
        if(other.tag == Type)//Trigger�n i�inde duran nesnenin tagini kontrol ediyor
        {
            if(Object == null)//Nesnemiz yok ise 
            {
                Object = other.gameObject;//��erideki nesne yeni nesne oluyor
                CanSpawn = false;//Spawn atmam�z� engelliyor
            }
        }
    }
    private void OnTriggerExit(Collider other)//i�erideki nesne ��kt� ise
    {
        Object = null;//nesnemizi s�f�rl�yoruz
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
