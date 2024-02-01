using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class BaseStats : MonoBehaviour
{
    public float CurrentHealth;
    public float MaxHealth;
    public TextMeshProUGUI Text;

    private void Start()
    {
        CurrentHealth = MaxHealth;
        Text.text = CurrentHealth.ToString();
    }
    public void TakeDamage(float Damage)
    {
        CurrentHealth -= Damage;
        if (CurrentHealth <= 0)
        {
            Destroy(this.gameObject);
        }
        Text.text = CurrentHealth.ToString();
    }
}
