using UnityEngine;

public class CameraFolow : MonoBehaviour
{
    public Transform player;
    public float moveSmoothTime = 1f;
    public float heightSmoothTime = 1f;
    public float rotationSmoothTime = 0.1f;
    public float followBehindDst = 5f;
    public float lookThisFarInFront = 5f;
    public float height = 12f;
    Vector3 lastPlayerPos;
    Vector3 moveCurrentVelocity;
    float heightCurrentVelocity;

    void Start () {
        lastPlayerPos = player.transform.position;
    }
	
    void FixedUpdate () {

        if (player != null)
        {
            lastPlayerPos = player.transform.position;
        }


        Vector3 moveSmoothed = Vector3.SmoothDamp(transform.position, lastPlayerPos - Vector3.back * -followBehindDst, ref moveCurrentVelocity, moveSmoothTime);

        float heightSmoothed = Mathf.SmoothDamp(transform.position.y, height, ref heightCurrentVelocity, heightSmoothTime);

        transform.position = new Vector3(moveSmoothed.x, heightSmoothed, moveSmoothed.z);

        Vector3 toTarget = (lastPlayerPos + Vector3.back * lookThisFarInFront) - transform.position;
        Quaternion targetRotation = Quaternion.LookRotation(toTarget);

        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSmoothTime);
    }
}
