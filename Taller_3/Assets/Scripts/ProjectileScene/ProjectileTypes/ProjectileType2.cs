using UnityEngine;
using System.Collections;

public class ProjectileType2 : ProjectileBase
{
    public override void HandleCollision(Collider other)
    {
        shooter.LockFireForSeconds(1f);
        shooter.DisableTargetColliderForSeconds(1f); // se encarga de desactivar y reactivar
        pool.ReturnProjectile(gameObject);
    }

    private IEnumerator DisableTargetTemporarily(Collider targetCollider)
    {
        targetCollider.enabled = false;
        yield return new WaitForSeconds(0.5f);
        targetCollider.enabled = true;
    }
}
