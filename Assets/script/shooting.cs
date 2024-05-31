using UnityEngine;
using System.Collections; // Include this for IEnumerator

public class Shooter : MonoBehaviour
{
    public LineRenderer tracer; // Assign a LineRenderer component in the Inspector
    public Transform gunBarrel; // Assign the gun barrel's end Transform in the Inspector
    public float tracerSpeed = 500f; // Speed at which the tracer travels
    public string targetTag = "Enemy"; // Tag of the GameObjects to destroy
    public float tracerLifeTime = 0.1f; // Lifetime of the tracer

    void Update()
    {
        // Check if the left mouse button is clicked
        if (Input.GetButtonDown("Fire1"))
        {
            StartCoroutine(Shoot());
        }
    }

    IEnumerator Shoot()
    {
        Vector3 startPosition = gunBarrel.position;
        Vector3 endPosition = gunBarrel.position + gunBarrel.forward * 100f;
        RaycastHit hit;

        if (Physics.Raycast(gunBarrel.position, gunBarrel.forward, out hit, 100f))
        {
            endPosition = hit.point;

            // Destroy the hit GameObject if it has the correct tag
            if (hit.collider.CompareTag(targetTag))
            {
                Destroy(hit.collider.gameObject);
            }
        }

        // Prepare the tracer for animation
        tracer.SetPosition(0, startPosition);
        tracer.SetPosition(1, startPosition);
        tracer.startWidth = 0.1f;
        tracer.endWidth = 0.1f;
        tracer.enabled = true;

        // Animate the tracer moving to the target
        float distance = Vector3.Distance(startPosition, endPosition);
        float startTime = Time.time;

        while (Time.time - startTime < tracerLifeTime)
        {
            float t = (Time.time - startTime) * tracerSpeed / distance;
            Vector3 currentEndPosition = Vector3.Lerp(startPosition, endPosition, t);
            tracer.SetPosition(0, Vector3.Lerp(startPosition, currentEndPosition, t / 2)); // This makes the back of the tracer travel
            tracer.SetPosition(1, currentEndPosition);

            // Simulate motion blur by fading the tracer over time
            tracer.startWidth = Mathf.Lerp(0.1f, 0.02f, t);
            tracer.endWidth = 0.02f;
            yield return null;
        }

        // Turn off the line renderer
        tracer.enabled = false;
    }
}
