using UnityEngine;
using System.Collections;

public class ProjectileType3 : ProjectileBase
{
    private ParticleSystem particleEffect;

    private void Awake()
    {
        particleEffect = GetComponentInChildren<ParticleSystem>();
    }

    public override void HandleCollision(Collider other)
    {
        StartCoroutine(PlayEffectAndReturn());
    }

    private IEnumerator PlayEffectAndReturn()
    {
        if (particleEffect != null)
        {
            particleEffect.Play();
            yield return new WaitForSeconds(particleEffect.main.duration);
        }

        pool.ReturnProjectile(gameObject);
    }
}
