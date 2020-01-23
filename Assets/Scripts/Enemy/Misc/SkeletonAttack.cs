using UnityEngine;

public class SkeletonAttack : MonoBehaviour {

    public float strong = 2;

    private void OnTriggerEnter2D (Collider2D other) {
        if (other.CompareTag ("Player")) {
            other.GetComponent<PlayerHealth> ().RemoveHealth (strong);
        }
    }
}