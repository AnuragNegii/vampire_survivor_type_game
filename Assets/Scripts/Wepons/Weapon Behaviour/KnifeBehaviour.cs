using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

public class KnifeBehaviour : ProjectileWeaponBehaviour {
    private KnifeController kc;

    protected override void Start(){
        base.Start();
        kc = FindObjectOfType<KnifeController>();
    }

    private void Update()   {
        transform.position += direction * Time.deltaTime * kc.speed; //set the  movement of the knife
    }
}