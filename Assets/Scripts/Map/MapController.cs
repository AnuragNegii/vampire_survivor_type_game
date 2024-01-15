using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour {

    private PlayerMovement playerMovement;
    private Vector3 noTerrainPosition;

    [SerializeField] private float checkerRadius;
    [SerializeField] private List<GameObject> terrainChunks;
    [SerializeField] private LayerMask terrainMask;
    [SerializeField] private GameObject player;
    
    public GameObject currentChunk;
    
    [Header("Optimization")]//Header Optimization
    [SerializeField]private List<GameObject> spawnedChunks;
    [SerializeField] private float maxOpDist; //Must be greater than the length and width of the tilemap
    [SerializeField] private float optimizerCooldownDuration;
    private float optimizerCooldown;
    private float opDist;
    private GameObject latestChunk;


    private void Awake(){
        playerMovement = FindObjectOfType<PlayerMovement>();
    }

    private void Update() {
        ChunkChecker();
        ChunkOptimizer();
    }

    private void ChunkChecker(){

        if(!currentChunk){
            return;
        }

        if(playerMovement.moveDir.x > 0 && playerMovement.moveDir.y == 0)// Right
        {
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("Right").position, checkerRadius, terrainMask))
            {
                noTerrainPosition = currentChunk.transform.Find("Right").position;
                SpawnChunk();
            }
        }
        else if(playerMovement.moveDir.x < 0 && playerMovement.moveDir.y == 0)// left
        {
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("left").position, checkerRadius, terrainMask))
            {
                noTerrainPosition = currentChunk.transform.Find("left").position;
                SpawnChunk();
            }
        }
        else if(playerMovement.moveDir.x == 0 && playerMovement.moveDir.y > 0)// up
        {
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("Up").position, checkerRadius, terrainMask))
            {
                noTerrainPosition = currentChunk.transform.Find("Up").position;
                SpawnChunk();
            }
        }
        else if(playerMovement.moveDir.x == 0 && playerMovement.moveDir.y < 0)// down
        {
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("Down").position, checkerRadius, terrainMask))
            {
                noTerrainPosition = currentChunk.transform.Find("Down").position;
                SpawnChunk();
            }
        }
        else if(playerMovement.moveDir.x > 0 && playerMovement.moveDir.y > 0)// Right up
        {
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("Right up").position, checkerRadius, terrainMask))
            {
                noTerrainPosition = currentChunk.transform.Find("Right up").position;
                SpawnChunk();
            }
        }
        else if(playerMovement.moveDir.x < 0 && playerMovement.moveDir.y > 0) //left up
        {
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("left up").position, checkerRadius, terrainMask))
            {
                noTerrainPosition = currentChunk.transform.Find("left up").position;
                SpawnChunk();
            }
        }
        else if(playerMovement.moveDir.x > 0 && playerMovement.moveDir.y < 0)// right down
        {
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("Right down").position, checkerRadius, terrainMask))
            {
                noTerrainPosition = currentChunk.transform.Find("Right down").position;
                SpawnChunk();
            }
        }
        else if(playerMovement.moveDir.x < 0 && playerMovement.moveDir.y < 0)// left down
        {
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("left down").position, checkerRadius, terrainMask))
            {
                noTerrainPosition = currentChunk.transform.Find("left down").position;
                SpawnChunk();
            }
        }
    }

    private void SpawnChunk()
    {
        int randNo = Random.Range(0, terrainChunks.Count);
        latestChunk = Instantiate(terrainChunks[randNo], noTerrainPosition, Quaternion.identity);
        spawnedChunks.Add(latestChunk);
    }

    private void ChunkOptimizer(){
        optimizerCooldown -= Time.deltaTime;

        if (optimizerCooldown <= 0f){
            optimizerCooldown = optimizerCooldownDuration;
        }
        else{
            return;
        }
        foreach (GameObject chunk in spawnedChunks){
            opDist = Vector3.Distance(player.transform.position, chunk.transform.position);
            if (opDist > maxOpDist){
                chunk.SetActive(false);
            }
            else{
                chunk.SetActive(true);
            }
        }
    }


    
}