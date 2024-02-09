using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    private Stats stats;
    private AudioSource Source;

    [HideInInspector]public GameObject Enemy;
    [HideInInspector]public bool isEnd;

    private void Start()
    {
        isEnd = true;
        stats = GetComponentInParent<Stats>();
        Source = GetComponent<AudioSource>();
    }
    public void Fire()
    {
        //Play Effect
        Debug.Log("Enemy Damage yedi");
        Stats _stats = Enemy.GetComponent<Stats>();
        BaseStats basestats = Enemy.GetComponent<BaseStats>();
        if (_stats != null)
        {
            _stats.TakeDamage(stats.AttackDamage);
        }
        if (basestats != null)
        {
            basestats.TakeDamage(stats.AttackDamage);
        }
        Source.Play();
    }

    public void End()
    {
        isEnd = true;
    }
}
