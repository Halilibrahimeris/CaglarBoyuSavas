using System.Collections.Generic;
using UnityEngine;

public class AllyMovementAndStates : MonoBehaviour
{
    List<string> SoliderType = new List<string> { "Ally", "Enemy" };//Oyundaki Karakter Tipleri
    public string SoliderTypeS;//Karakter Tiplerinin bulunduðu string

    Attack attack; //Attack Classý
    public Animator Anim;//Animatör eriþimi

    public float Speed;//Karakterin yürüme hýzý
    public float MoveDistance;//Önündekini algýlayýp duracaðý mesafe

    public GameObject Enemy;//Algýladýðý düþman
    public GameObject Ally;//Algýladýðý dost

    public bool Attack;//Saldýrý kontrolü
    public bool Run;//Yürüme Kontrolü

    private void Start()
    {
        attack = GetComponentInChildren<Attack>();//Attack Classý eriþimi
    }

    private void FixedUpdate()
    {
        CheckForward();//Sürekli önünü kontrol etmesi için gerekli fonksiyon
    }

    private void Update()
    {

        if (Run)//Yürüme durumnda ise
        {
            if(SoliderTypeS == SoliderType[0])//Asker tipi Ally ise
            {
                this.transform.position += Vector3.forward * Speed * Time.deltaTime;// Karakter ileri gidecek (Yürüyecek)
            }
            else//Asker tipi Enemy ise
            {
                this.transform.position += Vector3.back * Speed * Time.deltaTime;// Karakter tersi yöne yürüyecek
            }
        }
        else if (Attack && Enemy!=null)// Saldýrý durumunda ve Düþman belirlendi ise
        {
            attack.Fire(Enemy);//attack classýndaki ateþ Fonksiyonuna düþman verilerek çalýþacak
        }
        if (Enemy == null)//Düþman yok ise
        {
            Attack = false;//saldýrý durumu false
        }
    }

    void CheckForward()//Asker raycast ile sürekli önünü kontrol ediyor
    {
        Vector3 raycastPos = this.transform.position;//Raycast pozisyonu

        Vector3 rayDirection = this.transform.forward;//Raycastin ilerleyeceði düzlem

        RaycastHit hit;//Raycastin çarptýðýnda kaydedileceði nesne

        if (Physics.Raycast(raycastPos, rayDirection, out hit, MoveDistance))//raycast bir yere verilen parametreler ile çarptýysa
        {
            if(SoliderTypeS == SoliderType[0])//Asker tipi Ally ise
            {
                if (hit.collider.CompareTag("Ally"))//Askerin önünde ally var ise 
                {
                    Transform ally = hit.transform;
                    GameObject allyGameObject = ally.transform.gameObject;
                    // Ray'i görselleþtir
                    Debug.DrawRay(raycastPos, rayDirection * hit.distance, Color.red);//raycast kýrmýzýya dönecek
                    Ally = allyGameObject;
                    Run = false;
                    Anim.SetBool("isRunning", false);
                }//Karakter duracak idle pozisyonuna geçecek
                else//Önünde Ally olmadýðý için yürüme durumuna geçecek
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
                    // Ray'i görselleþtir
                    Debug.DrawRay(raycastPos, rayDirection * hit.distance, Color.red);//raycast kýrmýzýya dönecek
                    Ally = allyGameObject;
                    Run = false;
                    Anim.SetBool("isRunning", false);
                }//Karakter duracak idle pozisyonuna geçecek
                else//Önünde Enemy olmadýðý için yürüme durumuna geçecek
                {
                    Ally = null;
                    Run = true;
                    Anim.SetBool("isRunning", true);
                }
            }
            
        }
        else//Raycast bir yere çarpmadý ise
        {
            Debug.DrawRay(raycastPos, rayDirection * MoveDistance, Color.green);//raycast rengi yeþil olacak
            Ally = null;
            Run = true;
            Anim.SetBool("isRunning", true);
        }//Yürüme durumuna devam edecek
    }
    private void OnTriggerEnter(Collider other)//Karakterde bulunan collidera bir nesne girer ise
    {
        if (SoliderTypeS == SoliderType[0])//Asker tipi Ally ise
        {
            if (other.CompareTag("Enemy"))//Giren nesne Enemy ise
            {
                if (Enemy == null)// Aktif bir düþman yok ise
                {
                    Enemy = other.gameObject;//Giren nesne düþman olacak
                    Attack = true;//attack durumuna geçilecek
                    Run = false;//koþma durumu kapalý olacak
                    Anim.SetBool("isRunning", false);//animasyon koþma durumu kapatýlacak
                }
            }
        }
        else//ASker tipi Enemy ise
        {
            if (other.CompareTag("Ally"))//Giren nesne Ally ise
            {
                if (Enemy == null)// Aktif bir düþman yok ise
                {
                    Enemy = other.gameObject;//Giren nesne düþman olacak
                    Attack = true;//attack durumuna geçilecek
                    Run = false;//koþma durumu kapalý olacak
                    Anim.SetBool("isRunning", false);//animasyon koþma durumu kapatýlacak
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
                Run = false;//koþma durumu kapalý kalacak
                Anim.SetBool("isRunning", false);//animasyon koþma durumu kapalý kalacak
            }
        }
        else//Asker tipi Enemy ise
        {
            if (other.CompareTag("Ally"))//Duran nesne Ally ise
            {
                Attack = true;//attack durumunda duracak
                Run = false;//koþma durumu kapalý kalacak
                Anim.SetBool("isRunning", false);//animasyon koþma durumu kapalý kalacak
            }
        }
          
    }
    private void OnTriggerExit(Collider other) //Karakterde bulunan colliderdan bir nesne çýktý ise
    {
        if(SoliderTypeS == SoliderType[0])  //Asker tipi Ally ise
        {
            if (other.CompareTag("Enemy"))  //Çýkan nesne Enemy ise
            {
                Attack = false;                  //Attack durumu kapatýlacak
                Enemy = null;                    //Enemy olmadýðý kabul edilecek
                Run = true;                      //Yürüme durumu baþlayacak
                Anim.SetBool("isRunning", true); //Yürüme animasyonu baþlatýlacak
            }
        }
        else                               //Asker tipi Enemy ise
        {
            if (other.CompareTag("Ally"))  //Çýkan nesne Ally ise
            {
                Attack = false;                  //Attack durumu kapatýlacak
                Enemy = null;                    //Enemy olmadýðý kabul edilecek
                Run = true;                      //Yürüme durumu baþlayacak
                Anim.SetBool("isRunning", true); //Yürüme animasyonu baþlatýlacak
            }
        }
        
    }
}
