using System;
using UnityEngine;

public class ClickEventManager : MonoBehaviour
{
    public static event Action<int> OnButtonClicked;
    private int currentNumber = 1;

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Click izquierdo
        {
            OnButtonClicked?.Invoke(currentNumber);
            currentNumber = (currentNumber % 4) + 1;
        }
    }
}
