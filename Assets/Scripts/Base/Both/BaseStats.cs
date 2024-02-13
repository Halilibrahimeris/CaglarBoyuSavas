using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class BaseStats : MonoBehaviour
{
    public float CurrentHealth;
    public float MaxHealth;
    public TextMeshProUGUI Text;
    public GameObject WinPanel;
    public GameObject LosePanel;

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
            if (this.tag == "Enemy")
            {
                WinPanel.SetActive(true);
            }
            else
                LosePanel.SetActive(true);
            
            Destroy(this.gameObject);
            Time.timeScale = 0f;
        }
        Text.text = CurrentHealth.ToString();
    }
}
