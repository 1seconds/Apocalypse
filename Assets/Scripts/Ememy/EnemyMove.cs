using UnityEngine;
using System.Collections;

public class EnemyMove : MonoBehaviour
{
    void OnTriggerEnter(Collider other) {
        if (other.gameObject.name == "Player") {
            Destroy(gameObject);
            print("GameOver");
        }
    }
}
