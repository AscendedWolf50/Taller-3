using UnityEngine;

public class SphereFactory : IFactory
{
    private GameObject prefab;

    public SphereFactory(GameObject prefab)
    {
        this.prefab = prefab;
    }

    public GameObject Create()
    {
        return GameObject.Instantiate(prefab);
    }
}
