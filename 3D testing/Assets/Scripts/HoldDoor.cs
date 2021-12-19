using UnityEngine;

public class HoldDoor : MonoBehaviour
{
    public float stopwatch;

    public Transform player;
    public Transform door;

    public int maxDistantion = 4;
    private float distantion;

    private bool isHolded = false;

    void OnMouseOver()
    {
        if ((distantion < maxDistantion) & (Input.GetKey(KeyCode.E)))
        {
            stopwatch += Time.deltaTime;

            if (stopwatch >= 3.0f)
            {
                isHolded = true;
            }
        }
        else if (Input.GetKeyUp(KeyCode.E))
        {
            stopwatch = 0f;
        }
    }

    void OnMouseExit()
    {
        stopwatch = 0f;
    }

    void Update()
    {
        distantion = Vector3.Distance(player.position, door.position);

        if (isHolded)
        {
            this.gameObject.GetComponent<Renderer>().material.color = Color.green;
        }
        else
        {
            this.gameObject.GetComponent<Renderer>().material.color = Color.gray;
        }
    }
}