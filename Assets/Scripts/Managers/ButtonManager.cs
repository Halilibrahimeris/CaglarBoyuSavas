using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    [SerializeField] TriggerCheck TriggerCheck;

    public enum Type
    {
        Melee,
        Range,
        Heavy
    }
    public Type ButtonType;

    Button button;

    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(ButtonClick);
    }
    private void Update()
    {
        if(TriggerCheck.CanSpawn == true)
        {
            button.interactable = true;
        }
        else
        {
            button.interactable = false;
        }
    }
    public void ButtonClick()
    {
        if(ButtonType == Type.Melee)
        {
            if (GameManager.instance._Age == GameManager.Age.TasDevri && GameManager.instance.Money >= 50)
            {
                GameManager.instance.Money -= 50;
                var Solider = Instantiate(PrefabManager.instance.MeleeSolidersAlly[0], MyBase.instance.BaseSpawn);
                Solider.transform.localPosition = Vector3.zero;
            }
            else if (GameManager.instance._Age == GameManager.Age.OrtaCag && GameManager.instance.Money >= 100)
            {
                var Solider = Instantiate(PrefabManager.instance.MeleeSolidersAlly[1], MyBase.instance.BaseSpawn);
                Solider.transform.localPosition = Vector3.zero;
            }
            else if (GameManager.instance._Age == GameManager.Age.UzayCagý && GameManager.instance.Money >= 200)
            {
                var solider = Instantiate(PrefabManager.instance.MeleeSolidersAlly[2], MyBase.instance.BaseSpawn);
                solider.transform.localPosition = Vector3.zero;
                GameManager.instance.Money -= 200;
            }
        }
        if(ButtonType == Type.Range)
        {
            if (GameManager.instance._Age == GameManager.Age.TasDevri && GameManager.instance.Money >= 75)
            {
                GameManager.instance.Money -= 50;
                var Solider = Instantiate(PrefabManager.instance.RangeSolidersAlly[0], MyBase.instance.BaseSpawn);
                Solider.transform.localPosition = Vector3.zero;
            }
            else if (GameManager.instance._Age == GameManager.Age.OrtaCag && GameManager.instance.Money >= 150)
            {
                var Solider = Instantiate(PrefabManager.instance.RangeSolidersAlly[1], MyBase.instance.BaseSpawn);
                Solider.transform.localPosition = Vector3.zero;
            }
            else if (GameManager.instance._Age == GameManager.Age.UzayCagý && GameManager.instance.Money >= 300)
            {
                var Solider = Instantiate(PrefabManager.instance.RangeSolidersAlly[2], MyBase.instance.BaseSpawn);
                Solider.transform.localPosition = Vector3.zero;
                GameManager.instance.Money -= 300;

            }
        }
        if(ButtonType == Type.Heavy)
        {
            if (GameManager.instance._Age == GameManager.Age.TasDevri && GameManager.instance.Money >= 100)
            {
                GameManager.instance.Money -= 50;
                var Solider = Instantiate(PrefabManager.instance.HeavySolidersAlly[0], MyBase.instance.BaseSpawn);
                Solider.transform.localPosition = Vector3.zero;
            }
            else if (GameManager.instance._Age == GameManager.Age.OrtaCag && GameManager.instance.Money >= 200)
            {
                var Solider = Instantiate(PrefabManager.instance.HeavySolidersAlly[1], MyBase.instance.BaseSpawn);
                Solider.transform.localPosition = Vector3.zero;
            }
            else if (GameManager.instance._Age == GameManager.Age.UzayCagý && GameManager.instance.Money >= 400)
            {
                var Solider = Instantiate(PrefabManager.instance.HeavySolidersAlly[2], MyBase.instance.BaseSpawn);
                Solider.transform.localPosition = Vector3.zero;
            }
        }
        GameManager.instance.AllyText.text = GameManager.instance.Money.ToString();


    }
}
