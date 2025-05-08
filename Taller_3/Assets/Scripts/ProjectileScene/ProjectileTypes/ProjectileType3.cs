using UnityEngine;


public class ProjectileType3 : ProjectileBase
{
    private ParticleSystem particleEffect;

    private void Awake()
    {
        particleEffect = GetComponentInChildren<ParticleSystem>(true); // busca el hijo incluso si est� inactivo
    }

    public override void HandleCollision(Collider other)
    {
        if (particleEffect != null)
        {
            // 1. Posicionar primero donde ocurri� el impacto
            particleEffect.transform.position = transform.position;

            // 2. Luego soltar el objeto (para que se mantenga visible tras reciclar el proyectil)
            particleEffect.transform.SetParent(null);

            // 3. Limpiar y reproducir
            particleEffect.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
            particleEffect.Play();

            // 4. Destruirlo despu�s
            Destroy(particleEffect.gameObject, particleEffect.main.duration + 0.1f);
        }

        // Reciclar el proyectil inmediatamente
        pool.ReturnProjectile(gameObject);
    }
}
