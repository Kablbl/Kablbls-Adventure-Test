using UnityEngine;

public class MangoSpawner : MonoBehaviour
{
    public GameObject mangoPrefab;  // Mango prefab to spawn
    public float spawnRadius = 10f;  // Radius around the player where mangos can appear
    public float spawnInterval = 5f;  // Time interval in seconds between spawns

    private float timer;  // Tracks time to next spawn

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            SpawnMango();
            timer = 0;  // Reset timer
        }
    }

    void SpawnMango()
    {
        Vector3 spawnPos = Random.insideUnitSphere * spawnRadius;  // Generate random position within sphere
        spawnPos.y = 0;  // Adjust y position if necessary, depending on your game's ground level
        spawnPos += transform.position;  // Make it relative to the player position
        Instantiate(mangoPrefab, spawnPos, Quaternion.identity);  // Instantiate the mango at the random position
    }
}