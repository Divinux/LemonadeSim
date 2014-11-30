using UnityEngine;
using System.Collections;

public class Stand : MonoBehaviour 
{
	//my own node
	public GameObject vNode;
	//first in queue
	public GameObject vFirst;
	//last in queue
	public GameObject vLast;
	//speed of selling
	public float vSellSpeed = 5F;
	
	//ui object
	public UI vUI;
	
	//client component
	private Client fc;
	void Awake () 
	{
		vUI = GetComponent<UI>();
	}

	public void GiveTarget (Client asker) 
	{
		if(vLast == null)
		{
			asker.vTarget = vNode;
			vFirst = asker.gameObject;
			vLast = asker.gameObject;
		}
		else
		{
			Client c = vLast.GetComponent<Client>();
			asker.vTarget = c.vNode;
			c.vFollower = asker.gameObject;
			vLast = asker.gameObject;

		}
	}
	
	public void Buy()
	{
		//get client compoennt
		fc = vFirst.GetComponent<Client>();
		if(vUI.vIcePer <= vUI.vIce && vUI.vSugarPer <= vUI.vSugar && vUI.vLemonsPer <= vUI.vLemons && vUI.vCups >= 1)
		{
			Invoke("BuyPause", vSellSpeed);
		}
		else
		{
			CallFollower();
		}
		
	}
	
	public void BuyPause()
	{
		Transaction();
		CallFollower();
	}
	
	
	void CallFollower()
	{
		//send client home
		fc.vTarget = fc.vHome;
		//if he had a follower, call him
		if(fc.vFollower != null)
		{
			vFirst = fc.vFollower;
			Client fw = fc.vFollower.GetComponent<Client>();
			fw.vTarget = vNode;
		}
	}
	
	void Transaction()
	{
		if(vUI.vIcePer <= vUI.vIce && vUI.vSugarPer <= vUI.vSugar && vUI.vLemonsPer <= vUI.vLemons && vUI.vCups >= 1)
		{
			//earn money
			vUI.vMoney += vUI.vPrice;
			vUI.vIce -= vUI.vIcePer;
			vUI.vSugar -= vUI.vSugarPer;
			vUI.vLemons -= vUI.vLemonsPer;
			vUI.vCups--;
		}
	}

}
