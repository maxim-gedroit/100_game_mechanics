using UnityEngine;

public class Teleporter : MonoBehaviour
{
    public Teleporter Other;
    
    private void OnTriggerStay(Collider other)
    {
        float zPos = transform.worldToLocalMatrix.MultiplyPoint3x4(other.transform.position).z;
        if (zPos < 0)
        {
            var item = other.GetComponent<CharacterController>();
            item.enabled = false;
            Teleport(other.transform);
            item.enabled = true;
        }
    }

    private void Teleport(Transform obj)
    {
        Vector3 localPos = transform.worldToLocalMatrix.MultiplyPoint3x4(obj.position);
        localPos = new Vector3(-localPos.x, localPos.y, -localPos.z - 2);
        obj.position = Other.transform.localToWorldMatrix.MultiplyPoint3x4(localPos);
        
        Quaternion difference = Other.transform.rotation *
                                Quaternion.Inverse(transform.rotation * Quaternion.Euler(0, 180, 0));
        obj.rotation = difference * obj.rotation;
        
    }
}