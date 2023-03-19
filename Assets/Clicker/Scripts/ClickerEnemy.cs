using DG.Tweening;
using UnityEngine;
using UnityEngine.AI;
[RequireComponent(typeof(NavMeshAgent))]

public class ClickerEnemy : MonoBehaviour
{
     Transform _target;

    private NavMeshAgent agent;
    private bool isInited;
    
    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.enabled = false;
    }

    public void Init(Transform tr)
    {
        agent.enabled = true;
        _target = tr;
        isInited = true;
    }

    void Update()
    {
        if (!isInited)
            return;
        
        ChasePlayer();
    }
    
    private void ChasePlayer()
    {
        agent.SetDestination(_target.position);
    }

    private void OnCollisionEnter(Collision collision)
    {
        transform.DOScale(0, 0.3f).OnComplete(() =>
        {
            Destroy(gameObject);
        });
        
    }
}