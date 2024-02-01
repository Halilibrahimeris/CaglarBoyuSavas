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
                }
            }
        }
    }
}
