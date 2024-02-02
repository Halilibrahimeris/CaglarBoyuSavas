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
                if (states.Enemy == null)// Aktif bir d��man yok ise
                {
                    states.Enemy  = other.gameObject;//Giren nesne d��man olacak
                    states.Attack = true;//attack durumuna ge�ilecek
                    states.Run = false;//ko�ma durumu kapal� olacak
                    states.Anim.SetBool("isRunning", false);//animasyon ko�ma durumu kapat�lacak
                }
            }
        }
        else//ASker tipi Enemy ise
        {
            if (other.CompareTag("Ally"))//Giren nesne Ally ise
            {
                if (states.Enemy == null)// Aktif bir d��man yok ise
                {
                    states.Enemy = other.gameObject;//Giren nesne d��man olacak
                    states.Attack = true;//attack durumuna ge�ilecek
                    states.Run = false;//ko�ma durumu kapal� olacak
                    states.Anim.SetBool("isRunning", false);//animasyon ko�ma durumu kapat�lacak
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
                states.Run = false;//ko�ma durumu kapal� kalacak
                states.Anim.SetBool("isRunning", false);//animasyon ko�ma durumu kapal� kalacak
            }
        }
        else//Asker tipi Enemy ise
        {
            if (other.CompareTag("Ally"))//Duran nesne Ally ise
            {
                states.Attack = true;//attack durumunda duracak
                states.Run = false;//ko�ma durumu kapal� kalacak
                states.Anim.SetBool("isRunning", false);//animasyon ko�ma durumu kapal� kalacak
            }
        }

    }
    private void OnTriggerExit(Collider other) //Karakterde bulunan colliderdan bir nesne ��kt� ise
    {
        if (states.Type == AllyMovementAndStates.SolidersType.Ally)  //Asker tipi Ally ise
        {
            if (other.CompareTag("Enemy"))  //��kan nesne Enemy ise
            {
                states.Attack = false;                  //Attack durumu kapat�lacak
                states.Enemy = null;                    //Enemy olmad��� kabul edilecek
                states.Run = true;                      //Y�r�me durumu ba�layacak
                states.Anim.SetBool("isRunning", true); //Y�r�me animasyonu ba�lat�lacak
            }
        }
        else                               //Asker tipi Enemy ise
        {
            if (other.CompareTag("Ally"))  //��kan nesne Ally ise
            {
                states.Attack = false;                  //Attack durumu kapat�lacak
                states.Enemy = null;                    //Enemy olmad��� kabul edilecek
                states.Run = true;                      //Y�r�me durumu ba�layacak
                states.Anim.SetBool("isRunning", true); //Y�r�me animasyonu ba�lat�lacak
            }
        }

    }
}
