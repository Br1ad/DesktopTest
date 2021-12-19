using UnityEngine;
using System.Collections;

public class NewPause : MonoBehaviour
{
    public float timer;
    public bool isPause;
    public bool guiPause;

    void Update()
    {
        Time.timeScale = timer;
        if (Input.GetKeyDown(KeyCode.Escape) && isPause == false)
        {
            isPause = true;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && isPause == true)
        {
            isPause = false;
        }
        if (isPause == true)
        {
            timer = 0;
            guiPause = true;

        }
        else if (isPause == false)
        {
            timer = 1f;
            guiPause = false;

        }
    }
    public void OnGUI()
    {
        if (guiPause == true)
        {
            Cursor.visible = true;// включаем отображение курсора
            if (GUI.Button(new Rect((float)(Screen.width / 2), (float)(Screen.height / 2) - 150f, 150f, 45f), "Продолжить"))
            {
                isPause = false;
                timer = 0;
                Cursor.visible = false;
            }
            if (GUI.Button(new Rect((float)(Screen.width / 2), (float)(Screen.height / 2) - 100f, 150f, 45f), "Сохранить"))
            {

            }
            if (GUI.Button(new Rect((float)(Screen.width / 2), (float)(Screen.height / 2) - 50f, 150f, 45f), "Загрузить"))
            {

            }
            if (GUI.Button(new Rect((float)(Screen.width / 2), (float)(Screen.height / 2), 150f, 45f), "В Меню"))
            {
                isPause = false;
                timer = 0;
                Application.LoadLevel("Menu"); // здесь при нажатии на кнопку загружается другая сцена, вы можете изменить название сцены на свое

            }
        }
    }
}