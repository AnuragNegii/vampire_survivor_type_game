using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    [HideInInspector]
    public Vector2 moveDir;

    [SerializeField] private float moveSpeed;

    [HideInInspector]
    public float lastHorizontalMovement;
    [HideInInspector]
    public float lastVerticalMovement;

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
        if (moveDir.x != 0){
            lastHorizontalMovement = moveDir.x;
        }
        if (moveDir.y != 0){
            lastVerticalMovement = moveDir.y;
        }
    }

    private void Move(){
        rb.velocity = new Vector2(moveDir.x * moveSpeed, moveDir.y * moveSpeed);
    }

}
