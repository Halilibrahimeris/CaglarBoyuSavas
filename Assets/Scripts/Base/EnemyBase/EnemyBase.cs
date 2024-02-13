using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    public TriggerCheck TriggerCheck;//Spawn atmam�za izin olup olmad���n� kontrol eden script

    public float timer;
    public float SpawnTime;//Spawn atacak s�reyi belirleyen de�i�ken
    public int Gold;//Enemy base goldu
    
    public Transform SpawnPoint;//Nesneleri spawnlad��� nokta

    int a;
    private void Update()
    {

        timer += Time.deltaTime;//ge�en s�reyi tutan yer
        if(timer >= SpawnTime)
        {
            timer = 0;
            if (TriggerCheck.CanSpawn)
            {
                Spawn(Gold);//Spawn atmam�z� sa�layan kod
            }
        }
    }

    private void Spawn(int Gold)
    {

        if (GameManager.instance._Age == GameManager.Age.TasDevri)//ta� devrinde isek
        {
            a = Random.Range(0, 3);//rastgele asker se�iliyor
            switch (a)//se�ilen asker case yap�s�nda bulunuyor
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
        else if (GameManager.instance._Age == GameManager.Age.OrtaCag)//orta �a�da isek
        {
            a = Random.Range(0, 3);//rastgele asker se�iliyor
            switch (a)//se�ilen asker case yap�s�nda bulunuyor
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
        else if (GameManager.instance._Age == GameManager.Age.UzayCag�)//uzay �a��nda isek
        {
            if (Gold >= 400)//Goldumuz 400 den fazla ise 3 ayr� tipde asker spawnlanabilir
            {
                a = Random.Range(0, 3);//rastgele asker se�iliyor
                switch (a)//se�ilen asker case yap�s�nda bulunuyor
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
                }//askerler spawnlan�yor
            }
        }
    }
}
