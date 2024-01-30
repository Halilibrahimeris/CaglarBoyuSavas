using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Stats : MonoBehaviour
{
    public float CurrentHealth;
    public float AttackDamage;
    public float MaxHealth;

    public TextMeshProUGUI text;
    private void Start()
    {
        CurrentHealth = MaxHealth;
        if (text != null)
        {
            text.text = CurrentHealth.ToString();
        }
    }
    public void TakeDamage(float Damage)
    {
        CurrentHealth -= Damage;
        if(text != null)
        {
            text.text = CurrentHealth.ToString();
        }
        if(CurrentHealth <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
