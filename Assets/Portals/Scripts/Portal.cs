using UnityEngine;

public class Portal : MonoBehaviour
{
    public Portal Other;
    public Camera PortalView;
    public Camera Main;

    private void Start()
    {
        Other.PortalView.targetTexture = new RenderTexture(Screen.width,Screen.height,24);
        GetComponentInChildren<MeshRenderer>().sharedMaterial.mainTexture = Other.PortalView.targetTexture;
    }
    
    private void Update()
    {
        Vector3 lookerPosition = Other.transform.worldToLocalMatrix.MultiplyPoint3x4(Main.transform.position);
        lookerPosition = new Vector3(-lookerPosition.x, lookerPosition.y, -lookerPosition.z);
        PortalView.transform.localPosition = lookerPosition;

        Quaternion difference = transform.rotation * Quaternion.Inverse(Other.transform.rotation * Quaternion.Euler(0,180,0));
        PortalView.transform.rotation = difference * Main.transform.rotation;

        PortalView.nearClipPlane = lookerPosition.magnitude;
    }
}
