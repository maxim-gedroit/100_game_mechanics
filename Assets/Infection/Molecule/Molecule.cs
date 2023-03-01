using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

[RequireComponent(typeof(NavMeshAgent))]
public class Molecule : MonoBehaviour
{
    [SerializeField] private Material _defaultMaterial;
    [SerializeField] private Material _infectionMaterial;
    
    private NavMeshAgent agent;
    
    public LayerMask whatIsGround;
    public LayerMask whatIsMolecule;
    
    public float sightRange;
    
    public Vector3 walkPoint;
    private bool walkPointSet;
    private float walkPointRange = 10f;
    private Renderer _renderer;
    
    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        _renderer = GetComponent<Renderer>();
        _renderer.material = _defaultMaterial;
    }

    private void Start()
    {
        if (gameObject.tag == "2")
        {
            gameObject.layer = 0;
        }
    }

    private void Update()
    {
        Infection();
        Patroling();
    }

    private void Infection()
    {
        if (gameObject.tag != "2")
        {
            return;
        }

        Collider[] overlappedColliders = Physics.OverlapSphere(transform.position, sightRange, whatIsMolecule);
        for (int i = 0; i < overlappedColliders.Length; i++)
        {
            var item = overlappedColliders[i].gameObject;
            if (item.tag == "1")
            {
                item.GetComponent<Molecule>().SetInfection();
            }
        }
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

    public void SetInfection()
    {
        _renderer.material = _infectionMaterial;
        gameObject.tag = "2";
        gameObject.layer = 0;
        agent.speed = 20;
        agent.acceleration = 16;
        Destroy(gameObject,10f);
    }
}