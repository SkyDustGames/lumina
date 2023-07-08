using UnityEngine;

public class PlayerShooting : MonoBehaviour {
    
    [SerializeField] float bulletSpeed;
    [SerializeField] Rigidbody2D bulletPrefab;
    [SerializeField] Transform firePoint;

    private void Update() {
        transform.LookAt2D(Helpers.Mouse);
        if (Input.GetButtonDown("Fire1")) {
            Helpers.Camera.Shake(.1f, .1f);
            firePoint.SpawnParticle(0, false);

            Rigidbody2D bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            bullet.AddForce(transform.right * bulletSpeed, ForceMode2D.Impulse);

            Destroy(bullet.gameObject, 5);
        }
    }
}