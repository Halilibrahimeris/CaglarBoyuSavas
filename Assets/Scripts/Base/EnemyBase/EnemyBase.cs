using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    public TriggerCheck TriggerCheck;

    public float timer;
    public float SpawnTime;
    public int Gold;
    
    public Transform SpawnPoint;

    int meleeCount;
    int rangeCount;
    int heavyCount;
    private void Update()
    {

        timer += Time.deltaTime;
        if(timer >= SpawnTime)
        {
            timer = 0;
            if (TriggerCheck.CanSpawn)
            {
                Spawn(Gold);
            }
        }
    }

    private void Spawn(int Gold)
    {

        if (GameManager.instance._Age == GameManager.Age.TasDevri)
        {
           if(Gold >= 50 && Gold <= 100)
            {
                int a = Random.Range(0,3);
                switch (a)
                {
                    case 0:
                        var Solider = Instantiate(PrefabManager.instance.MeleeSolidersEnemy[0], SpawnPoint);
                        Solider.transform.localPosition = Vector3.zero;
                        this.Gold -= 50;
                        break;
                    case 1:
                        break;
                    case 2:
                        break;
                }
            }
        }
        else if (GameManager.instance._Age == GameManager.Age.OrtaCag)
        {
            
        }
        else if (GameManager.instance._Age == GameManager.Age.UzayCagý)
        {
            if (Gold >= 400)
            {
                int a = Random.Range(0, 3);
                switch (a)
                {
                    case 0:
                        var Solider = Instantiate(PrefabManager.instance.MeleeSolidersEnemy[2], SpawnPoint);
                        Solider.transform.localPosition = Vector3.zero;
                        this.Gold -= 200;
                        meleeCount++;
                        break;
                    case 1:
                        var Solider1 = Instantiate(PrefabManager.instance.RangeSolidersEnemy[2], SpawnPoint);
                        Solider1.transform.localPosition = Vector3.zero;
                        this.Gold -= 200;
                        rangeCount++;
                        break;
                    case 2:
                        var Solider2 = Instantiate(PrefabManager.instance.HeavySolidersEnemy[2], SpawnPoint);
                        Solider2.transform.localPosition = Vector3.zero;
                        this.Gold -= 200;
                        heavyCount++;
                        break;
                }
            }
        }
    }
}

//Tekrarý engellemek için yazýldý

/*switch (a)
{
    case 0:
        if (meleeCount == 3)
        {
            a = Random.Range(1, 3);
            meleeCount = 0;
        }
        break;
    case 1:
        if (rangeCount == 3)
        {
            a = Random.Range(1, 3);
            if (a == 1)
            {
                a = 0;
            }
            rangeCount = 0;
        }
        break;
    case 2:
        if (heavyCount == 3)
        {
            a = Random.Range(0, 1);
            heavyCount = 0;
        }
        break;
}//Tekrarý engellemek için yazýlan kod*/
