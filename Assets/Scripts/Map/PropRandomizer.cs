using System.Collections.Generic;
using UnityEngine;

public class PropRandomizer : MonoBehaviour {
    [SerializeField] private List<GameObject> props;
    [SerializeField] private List<Transform> propsLocation;

    private void Start(){
        propRand();
    }

    private void propRand(){
        foreach (Transform prop in propsLocation){
            int randNo = Random.Range(0, props.Count);
            GameObject propLocation = Instantiate(props[randNo], prop.position, Quaternion.identity);
            propLocation.transform.parent = prop;
        }
    }
}