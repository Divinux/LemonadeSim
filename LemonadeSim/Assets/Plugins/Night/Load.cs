using UnityEngine;
using System.Collections;

public class Load : MonoBehaviour 
{
public Texture2D vBg;
public GUISkin s1;

private int tl;
private int d;

	void Awake () 
	{
	tl = PlayerPrefs.GetInt("toload");
	d = PlayerPrefs.GetInt("day");
	}
	void OnGUI()
	{
			GUI.skin = s1;
			
			GUI.Label(new Rect(240, 200, 300, 100), "<color=#171717>" + "DAY " + d + "</color>");
		   GUI.Label(new Rect(238, 199, 300, 100), "<color=yellow>" + "DAY " + d + "</color>");
			
		   GUI.Label(new Rect(300, 300, 300, 100), "<color=#171717>" + "LOADING..." + "</color>");
		   GUI.Label(new Rect(298, 299, 300, 100), "<color=yellow>" + "LOADING..." + "</color>");
		   fLoad();
	}
	void fLoad()
	{
	
	if(tl != 0)
	{
	Application.LoadLevel(tl);
	}
	else
	{
	Application.LoadLevel(3);
	}
	}
}
