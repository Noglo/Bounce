using UnityEngine;

public class OrbScript : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other) {
        if (other.collider.CompareTag("Player")){
            other.gameObject.GetComponent<PlayerManager>().OrbsOnLevel -= 1;
            Destroy(this.gameObject);
        }
    }
}
