using UnityEngine;

public class MajorisSword : MonoBehaviour {

    [SerializeField] Majoris boss;
    
    private void OnCollisionEnter2D(Collision2D other) {
        if (boss.state == 1) {
            boss.StateChange();
            boss.state++;
        }

        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;

        if (other.gameObject.CompareTag("Block"))
            other.transform.GetComponent<BreakableBlock>().Damage();
        else if (other.gameObject.CompareTag("Player"))
            other.transform.GetComponent<PlayerHealth>().Damage(4f);
    }
}