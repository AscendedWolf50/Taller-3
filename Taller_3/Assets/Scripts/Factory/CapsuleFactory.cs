using UnityEngine;

public class CapsuleFactory : IFactory
{
    private GameObject prefab;

    public CapsuleFactory(GameObject prefab)
    {
        this.prefab = prefab;
    }

    public GameObject Create()
    {
        return GameObject.Instantiate(prefab);
    }
}
