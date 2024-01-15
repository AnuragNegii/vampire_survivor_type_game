using UnityEngine;

public class ChunkTrigger : MonoBehaviour {
    private MapController mc;
    [SerializeField] private GameObject targetMap;

    private void Awake(){
        mc = FindAnyObjectByType<MapController>();
    }



    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            mc.currentChunk = targetMap;
        }
    }


    private void OnTriggerExit2D(Collider2D other){
        if (other.CompareTag("Player")){
            if(mc.currentChunk == targetMap){
                mc.currentChunk = null;
            }
        }
    }
}