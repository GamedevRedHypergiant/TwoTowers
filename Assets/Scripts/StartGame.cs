using UnityEngine;
using System.Collections;

public class StartGame : MonoBehaviour {



	public void startLevel(int sceneIndex)
	{
		Application.LoadLevel(sceneIndex);
	}
}
