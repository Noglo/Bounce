using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orb_Script : MonoBehaviour
{

    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.collider.CompareTag("Player")){
            other.gameObject.GetComponent<PlayerManager>().orbsOnLevel -= 1;
            Destroy(this.gameObject);
        }
    }
}
