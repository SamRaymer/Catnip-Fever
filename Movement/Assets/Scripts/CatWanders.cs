using UnityEngine;
using System.Collections;
using UnityEngine.AI;
 
public class CatWanders : MonoBehaviour {
 
    public float wanderRadius;
    public float wanderTimer;
 
    private Transform target;
    private UnityEngine.AI.NavMeshAgent agent;
    private float timer;
 
    // Use this for initialization
    void OnEnable () {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent> ();
        timer = wanderTimer;
    }
 
    // Update is called once per frame
    void Update () {
        timer += Time.deltaTime;
 
        if (timer >= wanderTimer) {
            // HOW
            // Vector3 newPos = RandomNavSphere(transform.position, wanderRadius, -1);
            // agent.SetDestination(newPos);
            // agent.SetDestination(new Vector3(Random.Range(1,5), Random.Range(1,5), 0));
            timer = 0;
        }
    }
 
    public static Vector3 RandomNavSphere(Vector3 origin, float dist, int layermask) {
        Vector3 randDirection = Random.insideUnitSphere * dist;
 
        randDirection += origin;
 
        UnityEngine.AI.NavMeshHit navHit;
 
        UnityEngine.AI.NavMesh.SamplePosition (randDirection, out navHit, dist, layermask);
 
        return navHit.position;
    }
}