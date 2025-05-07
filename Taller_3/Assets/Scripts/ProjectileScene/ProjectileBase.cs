using UnityEngine;

public abstract class ProjectileBase : MonoBehaviour
{
    protected ProjectilePoolBase pool;
    protected ProjectileShooter shooter;

    public void Initialize(ProjectilePoolBase pool, ProjectileShooter shooter)
    {
        this.pool = pool;
        this.shooter = shooter;
    }

    public abstract void HandleCollision(Collider other);

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Target"))
        {
            HandleCollision(other);
        }
    }
}
