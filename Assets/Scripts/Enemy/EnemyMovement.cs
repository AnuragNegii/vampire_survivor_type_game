using Unity.VisualScripting;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {
    Transform player;
    public float moveSpeed;

    void Start(){
        player = FindObjectOfType<PlayerMovement>().transform;
    }

    private void Update() {
       transform.position = Vector2.MoveTowards(transform.position, player.position, moveSpeed* Time.deltaTime); // constantly move enemy towards the player
    }
}