using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    Transform player;
    NavMeshAgent nav;

    void Awake()
    {
        // Find the player GameObject by tag
        player = GameObject.FindGameObjectWithTag("Player")?.transform;
        nav = GetComponent<NavMeshAgent>();

        if (player == null)
        {
            Debug.LogError("Player not found! Make sure you have a GameObject tagged as 'Player'.");
        }
    }

    void Update()
    {
        if (player != null)
        {
            // Set destination to player position
            nav.SetDestination(player.position);
            // Look at the player
            transform.LookAt(player);
        }

        // Visualize the path
        if (nav.hasPath)
        {
            NavMeshPath path = nav.path;
            for (int i = 0; i < path.corners.Length - 1; i++)
            {
                Debug.DrawLine(path.corners[i], path.corners[i + 1], Color.red);
            }
        }
    }
}
