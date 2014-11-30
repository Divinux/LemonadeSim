using UnityEngine;
using System.Collections;

public class ClientSpawner : MonoBehaviour 
{
public GameObject vPrefab;
public int vAmount;
	void Awake () 
	{
	InvokeRepeating("Spawn", 0.1F, 0.5F);
	}
	
	void Spawn () 
	{
		if(vAmount > 0)
		{
			GameObject a = Instantiate(vPrefab, transform.position, transform.rotation) as GameObject;
			Client c = a.GetComponent<Client>();
			c.vHome = gameObject;
			vAmount--;
		}
	}
}
