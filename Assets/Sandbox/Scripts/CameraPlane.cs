using UnityEngine;
using System.Collections;


public static class CameraPlane
{

	public static Vector3 ViewportToWorldPlanePoint (Camera theCamera, float zDepth, Vector2 viewportCord)
	{
		Vector2 angles = ViewportPointToAngle (theCamera, viewportCord);
		float xOffset = Mathf.Tan (angles.x) * zDepth;
		float yOffset = Mathf.Tan (angles.y) * zDepth;
		Vector3 cameraPlanePosition = new Vector3 (xOffset, yOffset, zDepth);
		cameraPlanePosition = theCamera.transform.TransformPoint (cameraPlanePosition);
		return cameraPlanePosition;
	}
	
	public static Vector3 ScreenToWorldPlanePoint (Camera camera, float zDepth, Vector3 screenCoord)
	{
		var point = Camera.main.ScreenToViewportPoint (screenCoord);
		return ViewportToWorldPlanePoint (camera, zDepth, point);
	}
	

	public static Vector2 ViewportPointToAngle (Camera cam, Vector2 ViewportCord)
	{
		float adjustedAngle = AngleProportion(cam.fieldOfView/2, cam.aspect) * 2;
		float xProportion = ((ViewportCord.x - .5f)/.5f);
		float yProportion = ((ViewportCord.y - .5f)/.5f);
		float xAngle = AngleProportion(adjustedAngle/2, xProportion) * Mathf.Deg2Rad;
		float yAngle = AngleProportion(cam.fieldOfView/2, yProportion) * Mathf.Deg2Rad;
		return new UnityEngine.Vector2 (xAngle, yAngle);
	}
	

	public static float CameraToPointDepth (Camera cam, Vector3 point)
	{
		Vector3 localPosition = cam.transform.InverseTransformPoint (point);
		return localPosition.z;
	}
	
	public static float AngleProportion (float angle, float proportion)
	{
		float oppisite = Mathf.Tan (angle * Mathf.Deg2Rad);
		float oppisiteProportion = oppisite * proportion;
		return Mathf.Atan (oppisiteProportion) * Mathf.Rad2Deg;
	}
}