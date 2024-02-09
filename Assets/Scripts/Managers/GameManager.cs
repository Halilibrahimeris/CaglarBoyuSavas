using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public enum Build
    {
        Android,
        PC
    }
    public Build BuildType;

    public static GameManager instance;

    public float MoneyTime;
    private float MoneyTimer;

    public int Money;
    public int AgeMoney;

    public TextMeshProUGUI AllyText;
    public EnemyBase EnemyBase;
    private void Start()
    {
        AllyText.text = Money.ToString();
        AgeMoney = 500;
    }
    public enum Age
    {
        TasDevri,
        OrtaCag,
        UzayCagý
    }
    public Age _Age;

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

    private void Update()
    {
        MoneyTimer += Time.deltaTime;
        if(MoneyTimer >= MoneyTime)
        {
            if (_Age == Age.TasDevri)
            {
                Money += 10;
                EnemyBase.Gold += 10;
                MoneyTimer = 0;
                AllyText.text = Money.ToString();
            }
            else if (_Age == Age.OrtaCag)
            {
                Money += 30;
                EnemyBase.Gold += 30;
                MoneyTimer = 0;
                AllyText.text = Money.ToString();
            }
            else
            {
                Money += 50;
                EnemyBase.Gold += 50;   
                MoneyTimer = 0;
                AllyText.text = Money.ToString();
            }
        }
    }

    public void AgeUp()
    {
        if(Money >= AgeMoney)
        {
            if(_Age == Age.TasDevri)
            {
                _Age = Age.OrtaCag;
                Money -= AgeMoney;
                AgeMoney = 1000;
            }
            else if(_Age == Age.OrtaCag)
            {
                _Age = Age.UzayCagý;
                Money -= AgeMoney;
            }
        }
    }
}
