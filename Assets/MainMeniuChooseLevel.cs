using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MainMeniuChooseLevel : MonoBehaviour {

    public GameObject mainMeniu;
    public GameObject chooseLevel;

	public void back ()
    {
        mainMeniu.SetActive(true);
        chooseLevel.SetActive(false);
    }
    public void start ()
    {
        mainMeniu.SetActive(false);
        chooseLevel.SetActive(true);
    }
}
