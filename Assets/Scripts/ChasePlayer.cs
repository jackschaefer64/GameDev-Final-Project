using UnityEngine;
using UnityEngine.AI;
public class ChasePlayer : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Transform playerTransform;
    private NavMeshAgent agent;
    float detectionRange = 10;
    private Vector3 startPos;
    private Light myLight;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        Light myLight = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        float distanceFromPlayer = Vector3.Distance(transform.position, playerTransform.position);
        float chaseDistance = Vector3.Distance(transform.position, startPos);
        if(distanceFromPlayer <= 10.0f)
        {
            GetComponent<Wander>().enabled = false;
            //myLight.color = Color.red;
            myLight.color -= (Color.red / 2.0f) * Time.deltaTime;
            agent.SetDestination(playerTransform.position);
        }
        else
        {
            //myLight.color = Color.white;
            GetComponent<Wander>().enabled = true;
        }
        
    }
}
