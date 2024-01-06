using UnityEngine;

public class CameraMovement : MonoBehaviour {
    private Transform player;
    [SerializeField] private Vector3 offset;

    private void Awake(){
        player = GameObject.Find("Player").GetComponent<Transform>();
    }
    
    private void LateUpdate() {
        transform.position = player.position + offset;
    }
}