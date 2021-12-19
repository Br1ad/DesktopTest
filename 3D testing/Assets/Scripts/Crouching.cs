using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crouching : MonoBehaviour
{
    private CharacterController controller;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftControl))
        {
            controller.height = 1.4f;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.name = )
        {

        }
    }
}
