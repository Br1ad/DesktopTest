using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonActive : MonoBehaviour
{
    [SerializeField] private Animator myDoor = null;

    [SerializeField] private bool openTrigger = false;
    [SerializeField] private bool closeTrigger = false;

    [SerializeField] private string openDoor = "openDoor";
    [SerializeField] private string closeDoor = "closeDoor";

    public Object crate;
    public Object door;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Crate"))
        {
            if (!openTrigger)
            {
                myDoor.Play(openDoor);
                gameObject.SetActive(false);
            }
        }
    }  
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Crate"))
        {
            myDoor.Play(closeDoor);
        }
    }
}