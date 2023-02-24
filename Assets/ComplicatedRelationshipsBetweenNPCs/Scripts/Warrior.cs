using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

[RequireComponent(typeof(NavMeshAgent))]
public class Warrior : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private Transform _leftArm;
    [SerializeField] private Transform _rightArm;
    
    private NavMeshAgent agent;
    public LayerMask whatIsGround;
    public LayerMask whatIsTarget;
    public float sightRange;
    
    public Vector3 walkPoint;
    private bool walkPointSet;
    private float walkPointRange = 10f;
    

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }


    void Update()
    {
        var state = Physics.CheckSphere(transform.position, sightRange, whatIsTarget);
        if (!state) 
            Patroling();
        else
            ChasePlayer();
    }
    
    private void Patroling()
    {
        if (!walkPointSet) 
            SearchWalkPoint();

        if (walkPointSet)
            agent.SetDestination(walkPoint);

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        if (distanceToWalkPoint.magnitude < 1f)
            walkPointSet = false;
    }
    private void ChasePlayer()
    {
        RotateArms();
        agent.SetDestination(_target.position);
    }
   
    
    private void DestroyEnemy()
    {
        Destroy(gameObject);
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }
    private void SearchWalkPoint()
    {
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);
        
        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);
        
        Debug.DrawRay(walkPoint,-transform.up, Color.blue);
        
        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
            walkPointSet = true;
        
    }

    private void RotateArms()
    {
        _leftArm.Rotate(Vector3.right * 5f);
        _rightArm.Rotate(Vector3.right* 5f);
    }
}