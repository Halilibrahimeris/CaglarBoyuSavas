using System.Collections.Generic;
using UnityEngine;

public class AllyMovementAndStates : MonoBehaviour
{
    public enum SolidersType
    {
        Ally,
        Enemy
    }
    public SolidersType Type;

    Attack attack; //Attack Class�
    public Animator Anim;//Animat�r eri�imi

    public float Speed;//Karakterin y�r�me h�z�
    public float MoveDistance;//�n�ndekini alg�lay�p duraca�� mesafe

    public GameObject Enemy;//Alg�lad��� d��man
    public GameObject Ally;//Alg�lad��� dost

    public bool Attack;//Sald�r� kontrol�
    public bool Run;//Y�r�me Kontrol�

    private void Start()
    {
        attack = GetComponentInChildren<Attack>();//Attack Class� eri�imi
    }

    private void FixedUpdate()
    {
        CheckForward();//S�rekli �n�n� kontrol etmesi i�in gerekli fonksiyon
    }

    private void Update()
    {

        if (Run)//Y�r�me durumnda ise
        {
            if(Type == SolidersType.Ally)//Asker tipi Ally ise
            {
                this.transform.position += Vector3.forward * Speed * Time.deltaTime;// Karakter ileri gidecek (Y�r�yecek)
            }
            else//Asker tipi Enemy ise
            {
                this.transform.position += Vector3.back * Speed * Time.deltaTime;// Karakter tersi y�ne y�r�yecek
            }
        }
        else if (Attack && Enemy!=null && attack.isEnd)// Sald�r� durumunda ve D��man belirlendi ise
        {
            attack.Enemy = Enemy;
            attack.Fire();//attack class�ndaki ate� Fonksiyonuna d��man verilerek �al��acak
        }
        if (Enemy == null)//D��man yok ise
        {
            Attack = false;//sald�r� durumu false
        }
    }

    void CheckForward()//Asker raycast ile s�rekli �n�n� kontrol ediyor
    {
        Vector3 raycastPos = this.transform.position;//Raycast pozisyonu

        Vector3 rayDirection = this.transform.forward;//Raycastin ilerleyece�i d�zlem

        RaycastHit hit;//Raycastin �arpt���nda kaydedilece�i nesne

        if (Physics.Raycast(raycastPos, rayDirection, out hit, MoveDistance))//raycast bir yere verilen parametreler ile �arpt�ysa
        {
            if (Type == SolidersType.Ally)//Asker tipi Ally ise
            {
                if (hit.collider.CompareTag("Ally"))//Askerin �n�nde ally var ise 
                {
                    Debug.Log("Ally Ally� buldu bulan �ar�n �sm� : " + this.gameObject.name);
                    Transform ally = hit.transform;
                    Ally = ally.transform.gameObject;
                    // Ray'i g�rselle�tir
                    Debug.DrawRay(raycastPos, rayDirection * hit.distance, Color.red);//raycast k�rm�z�ya d�necek
                    Run = false;
                    Anim.SetBool("isRunning", false);
                }//Karakter duracak idle pozisyonuna ge�ecek
                else//�n�nde Ally olmad��� i�in y�r�me durumuna ge�ecek
                {
                    Ally = null;
                    Run = true;
                    Anim.SetBool("isRunning", true);
                }
            }
            else//Asker tipi Enemy ise
            {
                if (hit.collider.CompareTag("Enemy"))
                {
                    Transform ally = hit.transform;
                    GameObject allyGameObject = ally.transform.gameObject;
                    // Ray'i g�rselle�tir
                    Debug.DrawRay(raycastPos, rayDirection * hit.distance, Color.red);//raycast k�rm�z�ya d�necek
                    Ally = allyGameObject;
                    Run = false;
                    Anim.SetBool("isRunning", false);;
                }//Karakter duracak idle pozisyonuna ge�ecek
                else//�n�nde Enemy olmad��� i�in y�r�me durumuna ge�ecek
                {
                    Ally = null;
                    Run = true;
                    Anim.SetBool("isRunning", true);
                    Debug.Log(hit.collider.name + " " + gameObject.name + " " + transform.position);
                }
            }
            
        }
        else//Raycast bir yere �arpmad� ise
        {
            Debug.DrawRay(raycastPos, rayDirection * MoveDistance, Color.black);//raycast rengi ye�il olacak
            Ally = null;
            Run = true;
            Anim.SetBool("isRunning", true);
        }//Y�r�me durumuna devam edecek
    }
    
}
