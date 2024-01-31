using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TimeChange : MonoBehaviour
{
    public Button button;
    int buttonValue = 1;
    public TextMeshProUGUI text;
    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(ButtonPressed);
    }

    void ButtonPressed()
    {
        switch (buttonValue)
        {
            case 0:
                Time.timeScale = 1;
                buttonValue++;
                text.text = "1x";
                break;
            case 1:
                Time.timeScale = 2;
                buttonValue++;
                text.text = "2x";
                break;
            case 2:
                Time.timeScale = 3;
                buttonValue = 0;
                text.text = "3x";
                break;
        }
    }
}
