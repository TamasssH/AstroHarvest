using System.Collections.Generic;
using UnityEngine;

public class ParticleBullet : MonoBehaviour
{
    public ParticleSystem ParticleSys;
    public float fireRate = 0.2f;
    public int damage = 20;
    public GameObject spark;

    private float nextFireTime = 0f;
    List<ParticleCollisionEvent> colEvents = new List<ParticleCollisionEvent>();

    private void Start()
    {
        ParticleSys = GetComponent<ParticleSystem>();
    }

    private void Update()
    {
        if (Input.GetMouseButton(0) && Time.time >= nextFireTime)
        {
            nextFireTime = Time.time + fireRate;
            ParticleSys.Play();
        }
    }

    public void OnParticleCollision(GameObject other)
    {
        Health health = other.GetComponent<Health>();
        if (health != null)
        {
            health.TakeDamage(damage);
        }

        // Optional spark
        // int events = ParticleSys.GetCollisionEvents(other, colEvents);
        // for (int i = 0; i < events; i++) {
        //     Instantiate(spark, colEvents[i].intersection, Quaternion.LookRotation(colEvents[i].normal));
        // }
    }
}