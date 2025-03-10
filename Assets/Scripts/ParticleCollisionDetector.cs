using UnityEngine;
using System.Collections.Generic;

public class ParticleCollisionDetector : MonoBehaviour
{
    public ParticleSystem part, splashEffect;
    public List<ParticleCollisionEvent> collisionEvents;

    private void Start()
    {
        part = GetComponent<ParticleSystem>();
        collisionEvents = new List<ParticleCollisionEvent>();
    }

    private void OnParticleCollision(GameObject other)
    {
        // reduce enemy's health
        if (other.GetComponent<HealthManager>()) {
            other.GetComponent<HealthManager>().Reduce(5);
        }
        
        int numCollisionEvents = part.GetCollisionEvents(other, collisionEvents);
        int i = 0;
        while (i < numCollisionEvents)
        {
            Vector3 pos = collisionEvents[i].intersection;
            Vector3 normal = collisionEvents[i].normal;
            splashEffect.transform.position = pos;
            splashEffect.transform.rotation = Quaternion.LookRotation(normal);
            i++;
        }
    }
}
