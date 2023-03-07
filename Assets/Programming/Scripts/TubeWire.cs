using UnityEngine;
using System.Collections;

public class TubeWire : BaseObject
{
    RaycastHit hit1;
    RaycastHit hit2;
    private BaseObject temp;
    private void Start()
    {
        StartCoroutine(Detect());
    }
    
    private IEnumerator Detect()
    {
        while (true)
        {
            if (Physics.Raycast(transform.position,  transform.TransformDirection(Vector3.down), out hit1,1f) 
                && Physics.Raycast(transform.position,  transform.TransformDirection(Vector3.up), out hit2,1f) )
            {
                OnDetectedStart(hit1);
                OnDetectedEnd(hit2);
                yield return new WaitForSeconds(1f);
            }
            else
            {
                Connect(false);
                temp?.Connect(false);
                temp = null;
                yield return new WaitForSeconds(1f);
            } 
        }
    }

    private void OnDetectedStart(RaycastHit hit)
    {
        if (hit.collider.name == "BoxEngineEntry")
        {
            Connect(true);
            return;
        }
        
        if (hit.collider.name == "BoxEngine")
        {
            var state = hit.collider.GetComponent<BaseObject>().isConnected;
            Connect(state);
            return;
        }
        
        hit.collider.GetComponent<BaseObject>().Connect(isConnected);
    }
    
    private void OnDetectedEnd(RaycastHit hit)
    {
        temp = hit.collider.GetComponent<BaseObject>();
        temp.Connect(isConnected);
    }
}