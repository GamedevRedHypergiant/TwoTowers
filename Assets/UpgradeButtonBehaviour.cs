using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UpgradeButtonBehaviour : MonoBehaviour
{

    public Button upgradeButton;
    public GameObject attributePanel;
    public Text soldierName;
    public Text soldierInfoDamage;
    public Text soldierInfoElse;

    // Use this for initialization
    void Start()
    {
    
    }
    
    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectWithTag("GoodCastle").GetComponent<CastleController>().gold
            >= GameObject.FindGameObjectWithTag("GoodCastle").GetComponent<CastleController>().upgrade_cost)
        {
            upgradeButton.interactable = true;
        } else
        {
            upgradeButton.interactable = false;
        }
    }

    public void onMouseEnter()
    {
        string temp;
        if (upgradeButton.interactable == true)
        {
            soldierName.color = Color.green;
            soldierInfoDamage.color = Color.green;
            soldierInfoElse.color = Color.green;
        } else
        {
            soldierName.color = Color.red;
            soldierInfoDamage.color = Color.red;
            soldierInfoElse.color = Color.red;
        }
        
        
        soldierName.text = "Tower";
        temp = "Upgrade Cost: " + GameObject.FindGameObjectWithTag("GoodCastle").GetComponent<CastleController>().start_upgrade_cost.ToString();
        temp += "\nMax Mage: " + (GameObject.FindGameObjectWithTag("GoodCastle").GetComponent<CastleController>().max_mages
                                  + GameObject.FindGameObjectWithTag("GoodCastle").GetComponent<CastleController>().upgrade_mages).ToString();
        temp += "\nMax Warrior: " + (GameObject.FindGameObjectWithTag("GoodCastle").GetComponent<CastleController>().max_warriors
                                  + GameObject.FindGameObjectWithTag("GoodCastle").GetComponent<CastleController>().upgrade_warriors).ToString();
        temp += "\nMax Troll: " + (GameObject.FindGameObjectWithTag("GoodCastle").GetComponent<CastleController>().max_trolls
                                  + GameObject.FindGameObjectWithTag("GoodCastle").GetComponent<CastleController>().upgrade_trolls).ToString();
        soldierInfoDamage.text = temp;
        temp = "Life now: " + GameObject.FindGameObjectWithTag("GoodCastle").GetComponent<CastleController>().Hitpoints.ToString();
        temp += "\nAfter Upgrade: " + (GameObject.FindGameObjectWithTag("GoodCastle").GetComponent<CastleController>().Hitpoints
                                    + GameObject.FindGameObjectWithTag("GoodCastle").GetComponent<CastleController>().upgrade_health);
        soldierInfoElse.text = temp;
  
        attributePanel.SetActive(true);
    }
    
    public void onMouseExit()
    {
        attributePanel.SetActive(false);
    }
}
