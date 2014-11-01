using UnityEngine;
using System.Collections;

public class GoldGUI : MonoBehaviour {

	Transform pilis;
	// Use this for initialization
	void Start () {
	
	}

	// Update is called once per frame
	void Update () {
		pilis = GameObject.FindGameObjectWithTag ("GoodCastle").transform;
		float gold = pilis.GetComponent<CastleController> ().gold;
		string format = System.String.Format("{0} Gold",gold);
		guiText.text = format;
	}
}
