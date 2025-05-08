using UnityEngine;
using System.Collections;

public class ProjectileShooter : MonoBehaviour
{
    public ProjectilePoolBase[] pools; // arrastrar en el orden Tipo1, Tipo2, Tipo3
    public Transform firePoint; // punto desde donde se dispara

    private int currentType = 0;
    private bool canShoot = true;

    [SerializeField] public Collider targetCollider; // Asignalo desde el Inspector

    public void DisableTargetColliderForSeconds(float seconds)
    {
        if (targetCollider != null)
            StartCoroutine(ReenableColliderCoroutine(seconds));
    }

    private IEnumerator ReenableColliderCoroutine(float seconds)
    {
        targetCollider.enabled = false;
        yield return new WaitForSeconds(seconds);
        targetCollider.enabled = true;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1)) // Clic derecho → cambiar tipo
        {
            currentType = (currentType + 1) % pools.Length;
            Debug.Log("Tipo de proyectil actual: " + (currentType + 1));
        }

        if (Input.GetMouseButtonDown(0) && canShoot) // Clic izquierdo → disparar
        {
            GameObject proj = pools[currentType].GetProjectile();
            if (proj != null)
            {
                proj.transform.position = firePoint.position;
                proj.transform.rotation = firePoint.rotation;

                proj.GetComponent<ProjectileBase>().Initialize(pools[currentType], this);

                // ✅ APLICAR MOVIMIENTO
                Rigidbody rb = proj.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    rb.linearVelocity = firePoint.forward * 10f; // ajustá la fuerza si querés
                }
                else
                {
                    Debug.LogWarning("El proyectil no tiene Rigidbody.");
                }
            }
        }
    }

    public void LockFireForSeconds(float seconds)
    {
        StartCoroutine(LockFireCoroutine(seconds));
    }

    private System.Collections.IEnumerator LockFireCoroutine(float seconds)
    {
        canShoot = false;
        yield return new WaitForSeconds(seconds);
        canShoot = true;
    }
}
