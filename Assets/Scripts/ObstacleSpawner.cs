using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [Header("Prefab dan Pengaturan Spawn")]
    public GameObject obstaclePrefab;
    public float spawnInterval = 2f;
    public float spawnY = -2.5f;
    public float spawnOffsetX = 10f;
    public int spawnCount = 1;
    public float horizontalSpacing = 1.5f;

    private void Start()
    {
        if (obstaclePrefab == null)
        {
            Debug.LogError("Prefab obstacle belum diatur di Inspector.");
            enabled = false;
            return;
        }

        InvokeRepeating(nameof(SpawnObstacles), 1f, spawnInterval);
    }

    void SpawnObstacles()
    {
        if (obstaclePrefab == null)
        {
            Debug.LogWarning("Prefab obstacle telah dihancurkan atau null!");
            return;
        }

        float startX = Camera.main.transform.position.x + spawnOffsetX;

        for (int i = 0; i < spawnCount; i++)
        {
            float x = startX + i * horizontalSpacing;
            Vector3 spawnPos = new Vector3(x, spawnY, 0f);

            GameObject newObstacle = Instantiate(obstaclePrefab, spawnPos, Quaternion.identity);

            Destroy(newObstacle, 10f); 
        }
    }
}
