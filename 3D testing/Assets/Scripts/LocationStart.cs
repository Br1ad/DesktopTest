using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LocationStart : MonoBehaviour
{
    public string nameDoorOpen; // Открытие двери

    public GameObject doorObject; // Объект двери

    void Start()
    {
        doorObject.GetComponent<Animator>().SetTrigger(nameDoorOpen);
    }
}