using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public Stats stats;
    Animator _anim;
    public AnimationClip attackanim;
    public AudioSource Source;

    public bool ReadyToShoot;
    public bool _allowReset = true;
    public float ShootingDelay;
    private void Start()
    {
        _anim = GetComponentInChildren<Animator>();
        if(attackanim != null)
        {
            ShootingDelay = attackanim.length;
        }

    }
    public void Fire(GameObject Enemy)
    {
        //Play Effect

        ReadyToShoot = false;

        if (_allowReset)
        {
            Invoke("ResetShoot", ShootingDelay);
            _anim.SetTrigger("Attack");
            Debug.Log("Enemy Damage yedi");
            Stats _stats = Enemy.GetComponent<Stats>();
            BaseStats basestats = Enemy.GetComponent<BaseStats>();
            if(_stats != null)
            {
                _stats.TakeDamage(stats.AttackDamage);
            }
            if(basestats != null)
            {
                basestats.TakeDamage(stats.AttackDamage);
            }
            _allowReset = false;
            Source.Play();
        }

    }

    public void ResetShoot()
    {
        ReadyToShoot = true;
        _allowReset = true;
    }
}
