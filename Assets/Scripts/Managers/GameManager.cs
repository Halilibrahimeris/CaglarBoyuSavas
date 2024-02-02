using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public float BetweenAges;
    public float MoneyTime;
    private float MoneyTimer;
    public float AgeTimer;
    public int Money;

    public TextMeshProUGUI AllyText;
    public EnemyBase EnemyBase;
    private void Start()
    {
        AllyText.text = Money.ToString();
    }
    public enum Age
    {
        TasDevri,
        OrtaCag,
        UzayCag�
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
        AgeTimer += Time.deltaTime;
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
        if(AgeTimer >= BetweenAges)
        {
            if(_Age == Age.TasDevri)
            {
                _Age = Age.OrtaCag;
                AgeTimer = 0;
            }
            else if(_Age == Age.OrtaCag)
            {
                _Age = Age.UzayCag�;
            }
        }
    }
}
