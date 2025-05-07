using UnityEngine;

public class ProjectileType1 : ProjectileBase
{
    public override void HandleCollision(Collider other)
    {
        Debug.Log("Impacto del proyectil tipo 1");
        pool.ReturnProjectile(gameObject);
    }
}
