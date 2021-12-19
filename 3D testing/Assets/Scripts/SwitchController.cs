using UnityEngine;

public class SwitchController : MonoBehaviour
{
    GameObject[] switches;

    private bool isAllCorrect = false;

    public float maxDistance = 4.0f;

    public Transform player;

    void Start()
    {
        switches = GameObject.FindGameObjectsWithTag("Switch");
    }

    void SwitchManage()
    {
        if ((true) & (true) & (true))
        {

        }
    }
}
