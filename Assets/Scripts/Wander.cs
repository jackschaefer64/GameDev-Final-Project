using UnityEngine;
using UnityEngine.AI;
public class Wander : MonoBehaviour
{
    public float wanderRadius = 10f;
    public float wanderTime = 5f;
    private NavMeshAgent agent;
    private float timer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnEnable()
    {
        agent = GetComponent<NavMeshAgent>();
        timer = wanderTime;
    }
    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= wanderTime)
        {
            Vector3 newPos = RandomNavSphere(transform.position, wanderRadius, -1);
            agent.SetDestination(newPos);
            timer = 0;
        }
    }
    public static Vector3 RandomNavSphere(Vector3 origin, float dist, int layerMask)
    {
        Vector3 randDirection = Random.insideUnitSphere * dist;
        randDirection += origin;
        NavMeshHit navHit;
        NavMesh.SamplePosition(randDirection, out navHit, dist, layerMask);
        return navHit.position;
    }
}
