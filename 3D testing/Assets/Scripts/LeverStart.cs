using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverStart : MonoBehaviour
{
    public GameObject lightObj;

    private float distantion;
    public float maxDistance;

    public Transform player;
    public Transform lever;

    public AudioSource engineOn;

    public static bool isStartButtonActive = false;

    public GameObject hintUI;

    void Start()
    {
        lightObj.GetComponent<Light>().enabled = false;
    }

    void OnMouseOver()
    {
        distantion = Vector3.Distance(player.position, lever.position);

        if ((Input.GetKeyDown(KeyCode.E)) & (distantion < maxDistance) & (LoadedStart.isStartLeverActive))
        {
            lightObj.GetComponent<Light>().enabled = true;

            isStartButtonActive = true;

            hintUI.SetActive(false);
        }
    }
}