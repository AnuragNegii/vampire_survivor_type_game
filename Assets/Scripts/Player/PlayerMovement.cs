using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;


    [SerializeField] private float moveSpeed;

    [HideInInspector]
    public float lastHorizontalMovement;
    [HideInInspector]
    public float lastVerticalMovement;
    [HideInInspector]
    public Vector2 moveDir;
    [HideInInspector]
    public Vector2 lastMovedVector;

    private void Awake(){
        rb = GetComponent<Rigidbody2D>();
        lastMovedVector = new Vector2(1f, 0f); // if we dont do this and game starts up and the player doesn't move, the projectile weapon won't have any momentum and will not move
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
            lastMovedVector = new Vector2(lastHorizontalMovement, 0f);// last moved x
        }
        if (moveDir.y != 0){
            lastVerticalMovement = moveDir.y;
            lastMovedVector = new Vector2(0f, lastVerticalMovement); // last moved y
        }

        if (moveDir.x != 0 && moveDir.y != 0){
            lastMovedVector = new Vector2(lastHorizontalMovement, lastVerticalMovement); /// whike Moving
        }
    }

    private void Move(){
        rb.velocity = new Vector2(moveDir.x * moveSpeed, moveDir.y * moveSpeed);
    }

}
