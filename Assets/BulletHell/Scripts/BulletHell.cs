using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHell : MonoBehaviour
{
    private ParticleSystem _particle;
    private float TotalDuration =>_particle.duration + _particle.startLifetime;
    private int counter = 1;
    void Start()
    {
        _particle = GetComponent<ParticleSystem>();
        StartCoroutine(SwitchBullets());
    }

    private IEnumerator SwitchBullets()
    {
        while (true)
        {
            var shape = _particle.shape;
            counter++;
            _particle.Play();
            shape.arcSpeed = counter;
            yield return new WaitForSeconds(TotalDuration);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
