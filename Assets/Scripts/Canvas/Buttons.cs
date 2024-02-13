using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    public enum ButtonType
    {
        Restart,
        Exit
    }
    public ButtonType Type;
    Button button;
    private void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(Button);
    }

    public void Button()
    {
        if (Type == ButtonType.Restart)
            SceneManager.LoadScene(0);
        else
            Application.Quit();
    }
}
