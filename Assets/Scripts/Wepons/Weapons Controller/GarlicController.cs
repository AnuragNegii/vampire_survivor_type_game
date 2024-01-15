using UnityEngine;

public class GarlicController : WeaponController {
    protected override void Start()
    {
        base.Start();
    }

    protected override void Attack()
    {
        base.Attack();
        GameObject spawnedGarlic = Instantiate(prefab);
        spawnedGarlic.transform.position = transform.position; /// ASsign the position to be the same as the object which is parented to the player
        spawnedGarlic.transform.parent = transform; // So that it spawns below this object
    }
}