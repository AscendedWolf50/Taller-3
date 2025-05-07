using System.Collections.Generic;
using UnityEngine;

public abstract class ProjectilePoolBase : MonoBehaviour
{
    [SerializeField] protected GameObject projectilePrefab;
    [SerializeField] protected int poolSize = 10;

    protected Queue<GameObject> pool = new Queue<GameObject>();

    protected virtual void Awake()
    {
        for (int i = 0; i < poolSize; i++)
        {
            GameObject proj = Instantiate(projectilePrefab, transform);
            proj.SetActive(false);
            pool.Enqueue(proj);
        }
    }

    public virtual GameObject GetProjectile()
    {
        if (pool.Count > 0)
        {
            GameObject proj = pool.Dequeue();
            proj.SetActive(true);
            return proj;
        }
        return null;
    }

    public virtual void ReturnProjectile(GameObject projectile)
    {
        projectile.SetActive(false);
        pool.Enqueue(projectile);
    }
}
