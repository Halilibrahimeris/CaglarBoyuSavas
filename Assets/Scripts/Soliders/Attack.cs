using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public Stats stats;
    Animator _anim;
    public AudioSource Source;

    public GameObject Enemy;
    public bool isEnd;
    private void Start()
    {
        _anim = GetComponent<Animator>();
        isEnd = true;
    }
    public void Fire()
    {
        isEnd = false;
        //Play Effect
        _anim.SetTrigger("Attack");
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
