using UnityEngine;

public class mainButton : MonoBehaviour
{
    bool buttonPressed = false;

    void Update()
    {
        if (buttonPressed)
        {
            Application.Quit();
        }
    }
    void OnClick()
    {
        buttonPressed = true;
    }
}