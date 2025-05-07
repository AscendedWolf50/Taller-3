using UnityEngine;

public class NumberLogger : MonoBehaviour
{
    void OnEnable()
    {
        ClickEventManager.OnButtonClicked += LogNumber;
    }

    void OnDisable()
    {
        ClickEventManager.OnButtonClicked -= LogNumber;
    }

    private void LogNumber(int number)
    {
        Debug.Log("N�mero actual: " + number);
    }
}
