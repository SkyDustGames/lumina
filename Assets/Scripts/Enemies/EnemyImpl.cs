using UnityEngine;

public class EnemyImpl : Enemy {

    [Header("EnemyImpl.cs")]
    [SerializeField] float radius;

    public override void Update() {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, radius);
        
        bool found = false;
        foreach (Collider2D collider in colliders) {
            if (collider.gameObject.CompareTag("Player")) {
                found = true;
                break;
            }
        }

        enemyActive = found;
        base.Update();
    }

    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}