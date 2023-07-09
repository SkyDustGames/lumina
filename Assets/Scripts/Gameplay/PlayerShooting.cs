using UnityEngine;
using DG.Tweening;

public class PlayerShooting : MonoBehaviour {
    
    [SerializeField] float bulletSpeed;
    [SerializeField] Rigidbody2D bulletPrefab;
    [SerializeField] Transform firePoint;
    [SerializeField] Transform graphics, playerGraphics;
    [SerializeField] SpriteRenderer shootingPart;
    DG.Tweening.Core.TweenerCore<Color, Color, DG.Tweening.Plugins.Options.ColorOptions> core;

    private void Update() {
        transform.LookAt2D(Helpers.Mouse);
        if (transform.rotation.eulerAngles.z >= 90 && transform.rotation.eulerAngles.z <= 270) {
            graphics.localRotation = Quaternion.Euler(0, 180, 180);
            playerGraphics.localRotation = Quaternion.Euler(0, 180, 0);
        } else {
            graphics.localRotation = Quaternion.identity;
            playerGraphics.localRotation = Quaternion.identity;
        }

        if (Input.GetButtonDown("Fire1")) {
            if (core != null && !core.IsComplete())
                core.Kill();

            Helpers.Camera.Shake(.1f, .1f);
            firePoint.SpawnParticle(0, false);

            Rigidbody2D bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            bullet.AddForce(transform.right * bulletSpeed, ForceMode2D.Impulse);

            Destroy(bullet.gameObject, 5);

            shootingPart.color = Color.white;
            core = shootingPart.DOColor(new Color(0.0471698f, 0.0471698f, 0.0471698f), 1f);
        }
    }
}