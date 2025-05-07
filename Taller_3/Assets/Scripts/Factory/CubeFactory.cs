using UnityEngine;

public class CubeFactory : IFactory
{
    private GameObject prefab;

    public CubeFactory(GameObject prefab)
    {
        this.prefab = prefab;
    }

    public GameObject Create()
    {
        return GameObject.Instantiate(prefab);
    }
}
