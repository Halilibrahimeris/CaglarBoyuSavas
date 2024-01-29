using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{

    public float AttackDamage;
    public float Health;

    public void TakeDamage(float Damage)
    {
        Health -= Damage;
        if(Health <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
