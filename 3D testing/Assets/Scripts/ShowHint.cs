using System.Collections;
using UnityEngine;

public class ShowHint : MonoBehaviour
{
    public static float delay = 1.0f;
    public GameObject hintUI;
    
    void Start()
    {
        WaitAndDo();
    }

    IEnumerable WaitAndDo()
    {
        yield return new WaitForSeconds(delay);

        hintUI.SetActive(false);
    }
}
