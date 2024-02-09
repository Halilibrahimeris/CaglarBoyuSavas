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
            if(Type == SolidersType.Ally)//Asker tipi Ally ise
            {
                this.transform.position += Vector3.forward * Speed * Time.deltaTime;// Karakter ileri gidecek (Yürüyecek)
            }
            else//Asker tipi Enemy ise
            {
                this.transform.position += Vector3.back * Speed * Time.deltaTime;// Karakter tersi yöne yürüyecek
            }
        }
        else if (Attack && Enemy!=null && attack.isEnd)// Saldýrý durumunda ve Düþman belirlendi ise
        {
            attack.Enemy = Enemy;
            attack.Fire();//attack classýndaki ateþ Fonksiyonuna düþman verilerek çalýþacak
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
            if (Type == SolidersType.Ally)//Asker tipi Ally ise
            {
                if (hit.collider.CompareTag("Ally"))//Askerin önünde ally var ise 
                {
                    Debug.Log("Ally Allyý buldu bulan çarýn ýsmý : " + this.gameObject.name);
                    Transform ally = hit.transform;
                    Ally = ally.transform.gameObject;
                    // Ray'i görselleþtir
                    Debug.DrawRay(raycastPos, rayDirection * hit.distance, Color.red);//raycast kýrmýzýya dönecek
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
                    Anim.SetBool("isRunning", false);;
                }//Karakter duracak idle pozisyonuna geçecek
                else//Önünde Enemy olmadýðý için yürüme durumuna geçecek
                {
                    Ally = null;
                    Run = true;
                    Anim.SetBool("isRunning", true);
                    Debug.Log(hit.collider.name + " " + gameObject.name + " " + transform.position);
                }
            }
            
        }
        else//Raycast bir yere çarpmadý ise
        {
            Debug.DrawRay(raycastPos, rayDirection * MoveDistance, Color.black);//raycast rengi yeþil olacak
            Ally = null;
            Run = true;
            Anim.SetBool("isRunning", true);
        }//Yürüme durumuna devam edecek
    }
    
}
