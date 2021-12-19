using UnityEngine;

public class LeverController : MonoBehaviour
{
    public string nameTrigger; // Открытие двери
    public string nameTrigger2; // Закрытие двери

    public string nameLeverAnim; // Анимация активации рычага
    public string nameLeverAnim2; // Анимация деактивации рычага

    public GameObject leverObject; 
    public GameObject gameObjects;

    public Transform player;
    public Transform lever;

    private bool isActivated = false;

    private float distantion;

    public float maxDistance = 4;

    void OnMouseOver()
    {
        distantion = Vector3.Distance(player.position, lever.position);
        
        if ((Input.GetKeyDown(KeyCode.E)) & (distantion < maxDistance))
        {
            isActivated = !isActivated;
        }

        if (isActivated)
        {
            leverObject.GetComponent<Animator>().SetTrigger(nameLeverAnim);

            gameObjects.GetComponent<Animator>().SetTrigger(nameTrigger);
        }
        else
        {
            leverObject.GetComponent<Animator>().SetTrigger(nameLeverAnim2);

            gameObjects.GetComponent<Animator>().SetTrigger(nameTrigger2);
        }
    }
}