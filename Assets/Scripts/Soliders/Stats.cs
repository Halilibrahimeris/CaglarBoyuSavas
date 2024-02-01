using UnityEngine.UI;
using UnityEngine;
using TMPro;
public class Stats : MonoBehaviour
{
    public float CurrentHealth;
    public float AttackDamage;
    public float MaxHealth;

    public Slider Slider;
    private void Start()
    {
        CurrentHealth = MaxHealth;
        if (Slider != null)
        {
            Slider.maxValue = MaxHealth;
            Slider.minValue = 0;
            Slider.value = CurrentHealth;
        }
    }
    public void TakeDamage(float Damage)
    {
        CurrentHealth -= Damage;
        if(Slider != null)
        {
            Slider.value = CurrentHealth;
        }
        if(CurrentHealth <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
