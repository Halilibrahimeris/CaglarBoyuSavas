using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Triggers : MonoBehaviour
{
    AllyMovementAndStates states;
    private void Start()
    {
        states = GetComponentInParent<AllyMovementAndStates>();
    }

    private void OnTriggerEnter(Collider other)//Karakterde bulunan collidera bir nesne girer ise
    {
        if (states.Type == AllyMovementAndStates.SolidersType.Ally)//Asker tipi Ally ise
        {
            if (other.CompareTag("Enemy"))//Giren nesne Enemy ise
            {
                if (states.Enemy == null)// Aktif bir düþman yok ise
                {
                    states.Enemy  = other.gameObject;//Giren nesne düþman olacak
                    states.Attack = true;//attack durumuna geçilecek
                    states.Run = false;//koþma durumu kapalý olacak
                    states.Anim.SetBool("isRunning", false);//animasyon koþma durumu kapatýlacak
                }
            }
        }
        else//ASker tipi Enemy ise
        {
            if (other.CompareTag("Ally"))//Giren nesne Ally ise
            {
                if (states.Enemy == null)// Aktif bir düþman yok ise
                {
                    states.Enemy = other.gameObject;//Giren nesne düþman olacak
                    states.Attack = true;//attack durumuna geçilecek
                    states.Run = false;//koþma durumu kapalý olacak
                    states.Anim.SetBool("isRunning", false);//animasyon koþma durumu kapatýlacak
                }
            }
        }
    }

    private void OnTriggerStay(Collider other)//Karakterde bulunan collidera bir nesne duruyor ise
    {
        if (states.Type == AllyMovementAndStates.SolidersType.Ally)//Asker tipi Ally ise
        {
            if (other.CompareTag("Enemy"))//Duran nesne Enemy ise
            {
                states.Attack = true;//attack durumunda duracak
                states.Run = false;//koþma durumu kapalý kalacak
                states.Anim.SetBool("isRunning", false);//animasyon koþma durumu kapalý kalacak
            }
        }
        else//Asker tipi Enemy ise
        {
            if (other.CompareTag("Ally"))//Duran nesne Ally ise
            {
                states.Attack = true;//attack durumunda duracak
                states.Run = false;//koþma durumu kapalý kalacak
                states.Anim.SetBool("isRunning", false);//animasyon koþma durumu kapalý kalacak
            }
        }

    }
    private void OnTriggerExit(Collider other) //Karakterde bulunan colliderdan bir nesne çýktý ise
    {
        if (states.Type == AllyMovementAndStates.SolidersType.Ally)  //Asker tipi Ally ise
        {
            if (other.CompareTag("Enemy"))  //Çýkan nesne Enemy ise
            {
                states.Attack = false;                  //Attack durumu kapatýlacak
                states.Enemy = null;                    //Enemy olmadýðý kabul edilecek
                states.Run = true;                      //Yürüme durumu baþlayacak
                states.Anim.SetBool("isRunning", true); //Yürüme animasyonu baþlatýlacak
            }
        }
        else                               //Asker tipi Enemy ise
        {
            if (other.CompareTag("Ally"))  //Çýkan nesne Ally ise
            {
                states.Attack = false;                  //Attack durumu kapatýlacak
                states.Enemy = null;                    //Enemy olmadýðý kabul edilecek
                states.Run = true;                      //Yürüme durumu baþlayacak
                states.Anim.SetBool("isRunning", true); //Yürüme animasyonu baþlatýlacak
            }
        }

    }
}
