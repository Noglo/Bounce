using UnityEngine;

public class EnemyScript : MonoBehaviour
{

    public enum Direction {Vertical, Horizontal} // Направление движения.

    public Direction moveDirection = Direction.Vertical;

    [SerializeField] private float rotSpeed = 200f;
    [SerializeField] private float dist = 1f;

    [SerializeField] private float speed = 1f;

    private Vector3 pos_1;
    private Vector3 pos_2;

    private void Start()
    {
        if  (moveDirection == Direction.Vertical){
            pos_1 = transform.position + Vector3.up * dist;
            pos_2 = transform.position + Vector3.down * dist;
        }
        else{
            pos_1 = transform.position + Vector3.right * dist;
            pos_2 = transform.position + Vector3.left * dist;
        }
    }

    private void Update()
    {
        transform.Rotate(Vector3.forward * rotSpeed * Time.deltaTime);
        transform.position = Vector3.Lerp (pos_1, pos_2, Mathf.PingPong(Time.time * speed, 1.0f)); //Непрерывно перемещаеи между 2ух точек.
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.collider.CompareTag("Player")){
            other.gameObject.GetComponent<PlayerManager>().Death();
        }
    }
}
