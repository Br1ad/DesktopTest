using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    GameObject door;
    void Start()
    {
        door = GameObject.Find("Door");
    }
    void OnTriggerEnter(Collider other) 
    { 
        
    }
}
