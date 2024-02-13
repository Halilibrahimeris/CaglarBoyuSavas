using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    public TriggerCheck TriggerCheck;//Spawn atmamýza izin olup olmadýðýný kontrol eden script

    public float timer;
    public float SpawnTime;//Spawn atacak süreyi belirleyen deðiþken
    public int Gold;//Enemy base goldu
    
    public Transform SpawnPoint;//Nesneleri spawnladýðý nokta

    int a;
    private void Update()
    {

        timer += Time.deltaTime;//geçen süreyi tutan yer
        if(timer >= SpawnTime)
        {
            timer = 0;
            if (TriggerCheck.CanSpawn)
            {
                Spawn(Gold);//Spawn atmamýzý saðlayan kod
            }
        }
    }

    private void Spawn(int Gold)
    {

        if (GameManager.instance._Age == GameManager.Age.TasDevri)//taþ devrinde isek
        {
            a = Random.Range(0, 3);//rastgele asker seçiliyor
            switch (a)//seçilen asker case yapýsýnda bulunuyor
            {
                case 0:
                    var Solider = Instantiate(PrefabManager.instance.MeleeSolidersEnemy[0], SpawnPoint);
                    Solider.transform.localPosition = Vector3.zero;
                    this.Gold -= 200;
                    break;
                case 1:
                    var Solider1 = Instantiate(PrefabManager.instance.RangeSolidersEnemy[1], SpawnPoint);
                    Solider1.transform.localPosition = Vector3.zero;
                    this.Gold -= 200;
                    break;
                case 2:
                    var Solider2 = Instantiate(PrefabManager.instance.HeavySolidersEnemy[0], SpawnPoint);
                    Solider2.transform.localPosition = Vector3.zero;
                    this.Gold -= 200;
                    break;
            }
        }
        else if (GameManager.instance._Age == GameManager.Age.OrtaCag)//orta çaðda isek
        {
            a = Random.Range(0, 3);//rastgele asker seçiliyor
            switch (a)//seçilen asker case yapýsýnda bulunuyor
            {
                case 0:
                    var Solider = Instantiate(PrefabManager.instance.MeleeSolidersEnemy[1], SpawnPoint);
                    Solider.transform.localPosition = Vector3.zero;
                    this.Gold -= 200;
                    break;
                case 1:
                    var Solider1 = Instantiate(PrefabManager.instance.RangeSolidersEnemy[1], SpawnPoint);
                    Solider1.transform.localPosition = Vector3.zero;
                    this.Gold -= 200;
                    break;
               case 2:
                    var Solider2 = Instantiate(PrefabManager.instance.HeavySolidersEnemy[1], SpawnPoint);
                    Solider2.transform.localPosition = Vector3.zero;
                    this.Gold -= 200;
                    break;
            }
        }
        else if (GameManager.instance._Age == GameManager.Age.UzayCagý)//uzay çaðýnda isek
        {
            if (Gold >= 400)//Goldumuz 400 den fazla ise 3 ayrý tipde asker spawnlanabilir
            {
                a = Random.Range(0, 3);//rastgele asker seçiliyor
                switch (a)//seçilen asker case yapýsýnda bulunuyor
                {
                    case 0:
                        var Solider = Instantiate(PrefabManager.instance.MeleeSolidersEnemy[2], SpawnPoint);
                        Solider.transform.localPosition = Vector3.zero;
                        this.Gold -= 200;
                        break;
                    case 1:
                        var Solider1 = Instantiate(PrefabManager.instance.RangeSolidersEnemy[2], SpawnPoint);
                        Solider1.transform.localPosition = Vector3.zero;
                        this.Gold -= 200;
                        break;
                    case 2:
                        var Solider2 = Instantiate(PrefabManager.instance.HeavySolidersEnemy[2], SpawnPoint);
                        Solider2.transform.localPosition = Vector3.zero;
                        this.Gold -= 200;
                        break;
                }//askerler spawnlanýyor
            }
        }
    }
}
