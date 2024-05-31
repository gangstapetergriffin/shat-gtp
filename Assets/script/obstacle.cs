using Unity.AI.Navigation;
using UnityEngine;
using UnityEngine.AI; // Required for accessing NavMesh components

public class ObstacleGenerator : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public float generationRadius = 10f;
    public int obstacleCount = 5;
    public NavMeshSurface navMeshSurface; // Assign this in the Inspector

    void Start()
    {
        GenerateObstacles();
        UpdateNavMesh();
    }

    void GenerateObstacles()
    {
        for (int i = 0; i < obstacleCount; i++)
        {
            Vector3 randomPoint = Random.insideUnitSphere * generationRadius;
            randomPoint += transform.position;
            randomPoint.y = 1;

            Instantiate(obstaclePrefab, randomPoint, Quaternion.identity);
        }
    }

    void UpdateNavMesh()
    {
        navMeshSurface.BuildNavMesh(); // This updates the NavMesh
    }
}
