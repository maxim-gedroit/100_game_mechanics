using System;
using UnityEngine;

public class ProgrammingController : MonoBehaviour
{
    public static event  Action OnChoose;
    private Ray ray;
    private RaycastHit hit;
    
    private void Update()
    {
        ChoosePlayer();
    }

    private void ChoosePlayer()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            OnChoose?.Invoke();
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 1000))
            {
                if (hit.collider.tag == "Player")
                {
                    var item = hit.collider.GetComponent<BaseObject>();
                    item.Init();
                }
            }
        }
    }
}