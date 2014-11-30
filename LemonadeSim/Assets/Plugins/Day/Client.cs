using UnityEngine;
using System.Collections;

public class Client : MonoBehaviour 
{
public float vSpeed = 2.0F;
//the stand
public GameObject vStand;
public Stand vStandS;
//my start position
public GameObject vHome;
//my target
public GameObject vTarget;
//my node
public GameObject vNode;
//my follower 
public GameObject vFollower;
//did i get queue position yet
public bool vQueued = false;
public bool vBought = false;

public GameObject vLookSmoother;

public Animation anim;

	void Awake () 
	{
		vStand = GameObject.FindWithTag("stand");
		vStandS = vStand.GetComponent<Stand>();
		vTarget = vStandS.vNode;
		//vStandS.GiveTarget(this);
	}
	
	void FixedUpdate () 
	{
		if(vTarget != null)
		{
			Move();
			if(Vector3.Distance(vStandS.vNode.transform.position, transform.position) <= 10 && vQueued == false)
			{
				vStandS.GiveTarget(this);
				vQueued = true;
			}
		}
		

	}
	
	void Move()
	{
		if(vQueued == true)
		{
		MoveTo(vTarget);
		}
		else
		{
		MoveTo(vStandS.vNode);
		}
	}
	
	void MoveTo(GameObject vT)
	{
		if(Vector3.Distance(vT.transform.position, transform.position) >= 1F)
		{
			vLookSmoother.transform.LookAt(vT.transform);
			float rf = Mathf.Lerp(transform.eulerAngles.y,vLookSmoother.transform.eulerAngles.y, Time.time);
			transform.eulerAngles =new Vector3(transform.eulerAngles.x, rf, transform.eulerAngles.z);
			transform.eulerAngles = new Vector3(0,transform.eulerAngles.y,0);
			transform.Translate(Vector3.forward * Time.deltaTime * vSpeed, Space.Self);
			anim.CrossFade("walk");
			
		}
		else
		{
		vLookSmoother.transform.LookAt(vStandS.transform);
		float rs = Mathf.Lerp(transform.eulerAngles.y,vLookSmoother.transform.eulerAngles.y, Time.time/50);
			transform.eulerAngles =new Vector3(transform.eulerAngles.x, rs, transform.eulerAngles.z);
		//transform.localEulerAngles =Vector3.Slerp(transform.localEulerAngles, vLookSmoother.transform.localEulerAngles, Time.time);
		anim.CrossFade("Idle");
			transform.eulerAngles = new Vector3(0,transform.eulerAngles.y,0);
			if(vBought == false)
			{
			TryBuy();
			}
		}
	}
	
	void TryBuy()
	{
		if(vStandS.vFirst == gameObject && Vector3.Distance(vStandS.vNode.transform.position, transform.position) <= 1.2F && vBought == false)
		{
			vStandS.Buy();
			vBought = true;
		}
	}
	
	
}
