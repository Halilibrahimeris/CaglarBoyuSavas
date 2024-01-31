using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabManager : MonoBehaviour
{
    public GameObject[] MeleeSolidersAlly;
    public GameObject[] RangeSolidersAlly;
    public GameObject[] HeavySolidersAlly;

    public GameObject[] MeleeSolidersEnemy;
    public GameObject[] RangeSolidersEnemy;
    public GameObject[] HeavySolidersEnemy;

    public static PrefabManager instance;

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
