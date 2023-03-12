using TMPro;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BikePlayer : MonoBehaviour
{
    public static BikePlayer Instance;
    private Rigidbody _rigidbody;
    private float force = 80f;
    [SerializeField] private Transform W1;
    [SerializeField] private Transform W2;
    [SerializeField] private Transform bullet;
    private float _timer;
    public int CountHp;
    [SerializeField] private TMP_Text _text;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        Instance = this;
    }

    public void SetLabel(int i)
    {
        _text.text = i.ToString();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            _timer += Time.deltaTime;
            if (_timer >= 0.1f)
            {
                var obj = Instantiate(bullet, W1.position,Quaternion.Euler(90,0,0));
                var rb = obj.GetComponent<Rigidbody>();
                rb.AddForce(W1.forward * 800f);
            
                var obj1 = Instantiate(bullet, W2.position,Quaternion.Euler(90,0,0));
                var rb1 = obj1.GetComponent<Rigidbody>();
                rb1.AddForce(W2.forward * 800f);
                _timer = 0;
            }
        }
    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W))
        {
            _rigidbody.AddForce(transform.forward * force);
        }
        if (Input.GetKey(KeyCode.S))
        {
            _rigidbody.AddForce(transform.forward * -force/2);
        }
        if (Input.GetKey(KeyCode.A))
        {
            _rigidbody.AddTorque(transform.up * (force/2 * -1));
        }
        if (Input.GetKey(KeyCode.D))
        {
            _rigidbody.AddTorque(transform.up * (force/2 * 1));
        }
    }
}
