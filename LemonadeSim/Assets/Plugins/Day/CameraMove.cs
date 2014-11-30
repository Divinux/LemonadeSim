using UnityEngine;
using System.Collections;

public class CameraMove : MonoBehaviour 
{

public Transform vP1;
public Transform vP2;

private Vector3 velocity = Vector3.zero;
	void Awake () 
	{
	
	}
	
	void FixedUpdate() 
	{
	 transform.position = Vector3.SmoothDamp(transform.position, vP2.position, ref velocity, 2.0F);
	 if(Vector3.Distance(transform.position,vP2.position)<= 1)
	 {
	 Destroy(this);
	 }
	}
}
