using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MusicOnOff : MonoBehaviour {

	public Toggle toggle;

	public void soundChange()
	{
		if (toggle.isOn) 
		{
			Debug.Log("on");
			AudioListener.pause = false;
		}
		else
		{
			Debug.Log("off");
			AudioListener.pause = true;
		}
	}
}
