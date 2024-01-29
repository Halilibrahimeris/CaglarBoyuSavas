using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public float BetweenAges;
    public float timer;
    public int Money;

    public TextMeshProUGUI AllyText;
    private void Start()
    {
        AllyText.text = Money.ToString();
    }
    public enum Age
    {
        TasDevri,
        OrtaCag,
        UzayCagý
    }
    public Age _Age;

    private void Update()
    {
        timer += Time.deltaTime;
        if(timer >= BetweenAges)
        {
            if(_Age == Age.TasDevri)
            {
                _Age = Age.OrtaCag;
                timer = 0;
            }
            else if(_Age == Age.OrtaCag)
            {
                _Age = Age.UzayCagý;
            }
        }
    }

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
}
