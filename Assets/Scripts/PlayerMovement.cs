using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 moveDir;

    [SerializeField] private float moveSpeed;

    private void Awake(){
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate() {
        MoveInput();
        Move();
    }

    private void MoveInput(){
        float moveDirX = Input.GetAxis("Horizontal");
        float moveDirY = Input.GetAxis("Vertical");

        moveDir = new Vector2(moveDirX, moveDirY).normalized;
    }

    private void Move(){
        rb.velocity = new Vector2(moveDir.x * moveSpeed, moveDir.y * moveSpeed);
    }

}
