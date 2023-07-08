using UnityEngine;

public class ParticleManager : MonoBehaviour {

    [SerializeField] ParticleSystem[] particles;
    public static ParticleManager instance;

    private void Awake() {
        instance = this;
    }

    public void SpawnParticle(Transform transform, int particleIndex, bool setColor) {
        ParticleSystem particle = Instantiate(particles[particleIndex], transform.position, transform.rotation);

        ParticleSystem.MainModule main = particle.main;
        if (setColor)
            main.startColor = transform.GetComponent<SpriteRenderer>().color;

        Destroy(particle.gameObject, particle.main.startLifetime.constantMax);
    }
}