using UnityEngine;

public class KnifeController : WeaponController {

    protected override void Start()
    {
        base.Start();
    }

    protected override void Attack()
    {
        base.Attack();
        GameObject spawnedKnife = Instantiate(prefab);
        spawnedKnife.transform.position = transform.position; //Assign the position to be the same as this object which is parented to the player
        spawnedKnife.GetComponent<KnifeBehaviour>().DirectionChecker(pm.lastMovedVector); // reference and set the direction
    }
}