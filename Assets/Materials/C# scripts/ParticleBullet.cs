using UnityEngine;

public class ParticleBullet : MonoBehaviour
{
    public ParticleSystem ParticleSys;
    public float fireRate = 0.2f;
    public int damage = 20;

    private float nextFireTime = 0f;

    void Start()
    {
        if (ParticleSys == null) ParticleSys = GetComponent<ParticleSystem>();
    }

    void Update()
    {
        if (Input.GetMouseButton(0) && Time.time >= nextFireTime)
        {
            nextFireTime = Time.time + fireRate;
            if (ParticleSys) ParticleSys.Play();
        }
    }

    public void OnParticleCollision(GameObject other)
    {
        Health health = other.GetComponent<Health>();
        if (health != null)
        {
            health.TakeDamage(damage);
        }
    }
}