using DG.Tweening;
using UnityEngine;

public class BaseObject : MonoBehaviour
{
    private bool isEnabled;
    private bool isMove;
    public bool isConnected;

    RaycastHit hit;

    private enum MoveState
    {
        None,
        Move
    }

    private MoveState _state;

    private void Awake()
    {
        ProgrammingController.OnChoose += () =>
        {
            isEnabled = false;
        };
    }

    public virtual void Connect(bool state)
    {
        isConnected = state;
    }

    private void Update()
    {
        if(_state != MoveState.None || !isEnabled)
            return;
        
        if (Input.GetKey(KeyCode.A))
            MoveLeft();
        
        if (Input.GetKey(KeyCode.W))
            MoveForward();
        
        if (Input.GetKey(KeyCode.S))
            MoveBack();
        
        if (Input.GetKey(KeyCode.D))
            MoveRight();
        
        if (Input.GetKey(KeyCode.R))
            Rotate();
    }
    
    public virtual void Init()
    {
        isEnabled = true;
    }

    private void Move()
    {
        _state = MoveState.Move; 
        Connect(false);
    }

    private void MoveLeft()
    {
        Move();
        transform.DOMoveX(transform.position.x - 1, 0.2f).OnComplete(() =>
        {
            _state = MoveState.None;
        });
    }
    
    private void MoveRight()
    {
        Move();
        transform.DOMoveX(transform.position.x + 1, 0.2f).OnComplete(() =>
        {
            _state = MoveState.None;
        });
    }
    
    private void MoveForward()
    {
        Move();
        transform.DOMoveZ(transform.position.z + 1, 0.2f).OnComplete(() =>
        {
            _state = MoveState.None;
        });
    }
    
    private void MoveBack()
    {
        Move();
        transform.DOMoveZ(transform.position.z - 1, 0.2f).OnComplete(() =>
        {
            _state = MoveState.None;
        });
    }

    private void Rotate()
    {
        Move();
        transform.DORotate(new Vector3(transform.eulerAngles.x,transform.eulerAngles.y + 90f,transform.eulerAngles.z), 0.2f).OnComplete(() =>
        {
            _state = MoveState.None;
        });
    }
}
