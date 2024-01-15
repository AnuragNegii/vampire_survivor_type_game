using UnityEngine;

/// <summary>
/// Base Script for all Weapon Controllers
/// </summary>

public class WeaponController : MonoBehaviour {
    
    [Header("Weapon Stats")]
    public GameObject prefab;
    public float damage;
    public float speed;
    public float cooldownDuration;
    public int pierce;
    
    private float currentCooldown;

    protected PlayerMovement pm;

    protected virtual void Start(){
        pm = FindObjectOfType<PlayerMovement>();
        currentCooldown = cooldownDuration; // At the start set the current cooldown to be the cooldown duration
    }

    protected virtual void Update(){
        currentCooldown -= Time.deltaTime;
        if (currentCooldown <= 0f){
            Attack(); // Once cooldown becomes 0, attack
        }
    }

    protected virtual void Attack()
    {
        currentCooldown = cooldownDuration;
    }
}