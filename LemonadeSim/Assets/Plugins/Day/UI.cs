using UnityEngine;
using System.Collections;

public class UI : MonoBehaviour 
{
public Texture2D vBar;
public Texture2D vEnd;
public GUISkin s1;
public string vMoneyShort;
	/////stock
	public float vIce = 0;
	public float vSugar = 0;
	public int vCups = 0;
	public float vLemons = 0;
	public float vMoney = 0;
	//recipe per cup amount
	public float vIcePer = 1F;
	public float vSugarPer = 1F;
	public float vLemonsPer = 1F;
	public float vPrice;
	public int vDay;
	
	//sounds
	public AudioClip vClick;
	public AudioClip vCash;
	void Awake () 
	{

	Load();
	}
	
	void OnGUI () 
	{
	GUI.skin = s1;
	GUI.DrawTexture(new Rect(10, 500, 880, 100), vBar, ScaleMode.StretchToFill, true, 0F);
	 MoneyShort();
	GUI.Label(new Rect(-80, 545, 200, 100), "<color=#171717>" + vIce + "</color>");
		 GUI.Label(new Rect(95, 545, 200, 100), "<color=#171717>" + vSugar + "</color>");
		  GUI.Label(new Rect( 460, 545, 200, 100), "<color=#171717>" + vCups + "</color>");
		   GUI.Label(new Rect(295, 545, 200, 100), "<color=#171717>" + vLemons + "</color>");
		   GUI.Label(new Rect(645, 545, 200, 100), "<color=#171717>" + vMoneyShort + "</color>");
		   
		   GUI.Label(new Rect(-82, 544, 200, 100), "<color=yellow>" + vIce + "</color>");
		 GUI.Label(new Rect(93, 544, 200, 100), "<color=yellow>" + vSugar + "</color>");
		  GUI.Label(new Rect( 458, 544, 200, 100), "<color=yellow>" + vCups + "</color>");
		   GUI.Label(new Rect(293, 544, 200, 100), "<color=yellow>" + vLemons + "</color>");
		   GUI.Label(new Rect(643, 544, 200, 100), "<color=yellow>" + vMoneyShort + "</color>");
		   
		   GUI.DrawTexture(new Rect(690, 10, 200, 100), vEnd, ScaleMode.StretchToFill, true, 0F);
		    if (GUI.Button(new Rect(690, 10, 200, 100), " ", "label"))
		 {
		 LoadMenu();
		 }
	}
	void LoadMenu()
	{
	Click();
	Save();
	PlayerPrefs.SetInt("toload",2);
	Application.LoadLevel(1);
	}
	public void Click()
	{
	 audio.clip = vClick;
	audio.Play();
	}
	public void Cash()
	{
	 audio.clip = vCash;
	audio.Play();
	}
	void Load()
	{
	vDay = PlayerPrefs.GetInt("day");
	vPrice =  PlayerPrefs.GetFloat("price");
	vIce = PlayerPrefs.GetFloat("ice");
	vSugar=PlayerPrefs.GetFloat("sugar");
	vCups=PlayerPrefs.GetInt("cups");
	vLemons=PlayerPrefs.GetFloat("lemons");
	vMoney=PlayerPrefs.GetFloat("money");
	
	vIcePer=PlayerPrefs.GetFloat("iceper");
	vSugarPer=PlayerPrefs.GetFloat("sugarper");
	vLemonsPer=PlayerPrefs.GetFloat("lemonsper");
	}
	void Save()
	{
	
	PlayerPrefs.SetInt("day", vDay+1);
	PlayerPrefs.SetFloat("ice", vIce);
	PlayerPrefs.SetFloat("sugar", vSugar);
	PlayerPrefs.SetInt("cups", vCups);
	PlayerPrefs.SetFloat("lemons", vLemons);
	PlayerPrefs.SetFloat("money", vMoney);
	
	PlayerPrefs.SetFloat("iceper", vIcePer);
	PlayerPrefs.SetFloat("sugarper", vSugarPer);
	PlayerPrefs.SetFloat("lemonsper", vLemonsPer);
	}
	void MoneyShort()
	{
		if(vMoney >= 1000000)
		{
			float z1 = vMoney/1000000;
			vMoneyShort = z1.ToString("F1") + " mio";
		}
		else if(vMoney >= 1000)
		{
			float z2 = vMoney/1000;
			vMoneyShort = z2.ToString("F1") + " k";
		}
		else
		{
			vMoneyShort = vMoney.ToString("F2") + "";
		}
	}
}
