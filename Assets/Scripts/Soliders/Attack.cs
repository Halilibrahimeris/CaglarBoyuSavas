using UnityEngine;

public class Attack : MonoBehaviour
{
    private Stats stats;
    private MovementAndStates parent;
    private AudioSource Source;
    [HideInInspector]public bool isEnd;

    private void Start()
    {
        isEnd = true;
        stats = GetComponentInParent<Stats>();
        Source = GetComponent<AudioSource>();
        parent = GetComponentInParent<MovementAndStates>();
    }
    public void Fire()
    {
        //Play Effect
        Debug.Log("Enemy Damage yedi");
        if(parent.Enemy != null)
        {
            Stats _stats = parent.Enemy.GetComponent<Stats>();
            BaseStats basestats = parent.Enemy.GetComponent<BaseStats>();

            if (_stats != null)
                _stats.TakeDamage(stats.AttackDamage);

            if (basestats != null)
                basestats.TakeDamage(stats.AttackDamage);

            if (Source != null)
                Source.Play();
        }
        else
        {
            Debug.Log(parent.gameObject.name);
        }
    }

    public void End()
    {
        isEnd = true;
    }
}
