using System.Collections;
using UnityEngine;

public class Test : MonoBehaviour
{
    public string nameTrigger; // Открытие двери
    public string nameTrigger2; // Закрытие двери

    public Transform player; // Игрок
    public Transform button; // Кнопка

    public GameObject gameObjects; // Объект дверь
    public GameObject buttonObject; // Объект кнопка

    public bool isPermanent = true;
    public float delay;
    private float distantion;
    public float maxDistance = 4f;

    void OnMouseOver()
    {
        distantion = Vector3.Distance(player.position, button.position);

        if ((Input.GetKeyDown(KeyCode.E)) && (distantion < maxDistance))
        {
            this.gameObject.GetComponent<Renderer>().material.color = Color.green;

            if (!isPermanent)
            {
                StartCoroutine(WaitAndDo());
            }
        }
    }

    IEnumerator WaitAndDo()
    {
        yield return new WaitForSeconds(delay);

        this.gameObject.GetComponent<Renderer>().material.color = Color.gray;
    }
}