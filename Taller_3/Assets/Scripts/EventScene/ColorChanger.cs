using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    private Renderer rend;

    void Start()
    {
        rend = GetComponent<Renderer>();
        ClickEventManager.OnButtonClicked += ChangeColor;
    }

    void OnDestroy()
    {
        ClickEventManager.OnButtonClicked -= ChangeColor;
    }

    private void ChangeColor(int number)
    {
        Color color = Color.white;
        switch (number)
        {
            case 1: color = Color.red; break;
            case 2: color = Color.green; break;
            case 3: color = Color.blue; break;
            case 4: color = Color.yellow; break;
        }
        rend.material.color = color;
    }
}
