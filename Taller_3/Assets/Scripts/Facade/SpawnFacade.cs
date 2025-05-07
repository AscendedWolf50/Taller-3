using System.Collections.Generic;
using UnityEngine;

public class SpawnFacade
{
    private Dictionary<string, IFactory> factories = new Dictionary<string, IFactory>();
    private string currentType = "Cube";

    public void RegisterFactory(string type, IFactory factory)
    {
        factories[type] = factory;
    }

    public void SetCurrentType(string type)
    {
        currentType = type;
    }

    public GameObject Spawn()
    {
        if (factories.ContainsKey(currentType))
        {
            return factories[currentType].Create();
        }
        Debug.LogWarning("No factory found for type: " + currentType);
        return null;
    }
}
