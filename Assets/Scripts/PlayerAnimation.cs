using UnityEditor.Tilemaps;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator am;
    private PlayerMovement pm;
    private SpriteRenderer sr;
    
    private void Awake(){
        am = GetComponent<Animator>();
        pm = GetComponent<PlayerMovement>();
        sr = GetComponent<SpriteRenderer>();
    }

    private void Update(){
        if (pm.moveDir.x != 0 || pm.moveDir.y != 0){
            FlipSprite();
            am.SetBool("isWalking", true);
        }else{
            am.SetBool("isWalking", false);
        }
    }

    private void FlipSprite()
    {
        if (pm.lastHorizontalMovement < 0){
            sr.flipX = true;
        }
        else{
            sr.flipX = false;
        }
    }
}
