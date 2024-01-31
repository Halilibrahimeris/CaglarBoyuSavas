using System.Collections.Generic;
using UnityEngine;

public class AllyMovementAndStates : MonoBehaviour
{
    List<string> SoliderType = new List<string> { "Ally", "Enemy" };//Oyundaki Karakter Tipleri
    public string SoliderTypeS;//Karakter Tiplerinin bulundu�u string

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
            if(SoliderTypeS == SoliderType[0])//Asker tipi Ally ise
            {
                this.transform.position += Vector3.forward * Speed * Time.deltaTime;// Karakter ileri gidecek (Y�r�yecek)
            }
            else//Asker tipi Enemy ise
            {
                this.transform.position += Vector3.back * Speed * Time.deltaTime;// Karakter tersi y�ne y�r�yecek
            }
        }
        else if (Attack && Enemy!=null)// Sald�r� durumunda ve D��man belirlendi ise
        {
            attack.Fire(Enemy);//attack class�ndaki ate� Fonksiyonuna d��man verilerek �al��acak
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
            if(SoliderTypeS == SoliderType[0])//Asker tipi Ally ise
            {
                if (hit.collider.CompareTag("Ally"))//Askerin �n�nde ally var ise 
                {
                    Transform ally = hit.transform;
                    GameObject allyGameObject = ally.transform.gameObject;
                    // Ray'i g�rselle�tir
                    Debug.DrawRay(raycastPos, rayDirection * hit.distance, Color.red);//raycast k�rm�z�ya d�necek
                    Ally = allyGameObject;
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
                    Anim.SetBool("isRunning", false);
                }//Karakter duracak idle pozisyonuna ge�ecek
                else//�n�nde Enemy olmad��� i�in y�r�me durumuna ge�ecek
                {
                    Ally = null;
                    Run = true;
                    Anim.SetBool("isRunning", true);
                }
            }
            
        }
        else//Raycast bir yere �arpmad� ise
        {
            Debug.DrawRay(raycastPos, rayDirection * MoveDistance, Color.green);//raycast rengi ye�il olacak
            Ally = null;
            Run = true;
            Anim.SetBool("isRunning", true);
        }//Y�r�me durumuna devam edecek
    }
    private void OnTriggerEnter(Collider other)//Karakterde bulunan collidera bir nesne girer ise
    {
        if (SoliderTypeS == SoliderType[0])//Asker tipi Ally ise
        {
            if (other.CompareTag("Enemy"))//Giren nesne Enemy ise
            {
                if (Enemy == null)// Aktif bir d��man yok ise
                {
                    Enemy = other.gameObject;//Giren nesne d��man olacak
                    Attack = true;//attack durumuna ge�ilecek
                    Run = false;//ko�ma durumu kapal� olacak
                    Anim.SetBool("isRunning", false);//animasyon ko�ma durumu kapat�lacak
                }
            }
        }
        else//ASker tipi Enemy ise
        {
            if (other.CompareTag("Ally"))//Giren nesne Ally ise
            {
                if (Enemy == null)// Aktif bir d��man yok ise
                {
                    Enemy = other.gameObject;//Giren nesne d��man olacak
                    Attack = true;//attack durumuna ge�ilecek
                    Run = false;//ko�ma durumu kapal� olacak
                    Anim.SetBool("isRunning", false);//animasyon ko�ma durumu kapat�lacak
                }
            }
        }
    }

    private void OnTriggerStay(Collider other)//Karakterde bulunan collidera bir nesne duruyor ise
    {
        if (SoliderTypeS == SoliderType[0])//Asker tipi Ally ise
        {
            if (other.CompareTag("Enemy"))//Duran nesne Enemy ise
            {
                Attack = true;//attack durumunda duracak
                Run = false;//ko�ma durumu kapal� kalacak
                Anim.SetBool("isRunning", false);//animasyon ko�ma durumu kapal� kalacak
            }
        }
        else//Asker tipi Enemy ise
        {
            if (other.CompareTag("Ally"))//Duran nesne Ally ise
            {
                Attack = true;//attack durumunda duracak
                Run = false;//ko�ma durumu kapal� kalacak
                Anim.SetBool("isRunning", false);//animasyon ko�ma durumu kapal� kalacak
            }
        }
          
    }
    private void OnTriggerExit(Collider other) //Karakterde bulunan colliderdan bir nesne ��kt� ise
    {
        if(SoliderTypeS == SoliderType[0])  //Asker tipi Ally ise
        {
            if (other.CompareTag("Enemy"))  //��kan nesne Enemy ise
            {
                Attack = false;                  //Attack durumu kapat�lacak
                Enemy = null;                    //Enemy olmad��� kabul edilecek
                Run = true;                      //Y�r�me durumu ba�layacak
                Anim.SetBool("isRunning", true); //Y�r�me animasyonu ba�lat�lacak
            }
        }
        else                               //Asker tipi Enemy ise
        {
            if (other.CompareTag("Ally"))  //��kan nesne Ally ise
            {
                Attack = false;                  //Attack durumu kapat�lacak
                Enemy = null;                    //Enemy olmad��� kabul edilecek
                Run = true;                      //Y�r�me durumu ba�layacak
                Anim.SetBool("isRunning", true); //Y�r�me animasyonu ba�lat�lacak
            }
        }
        
    }
}
