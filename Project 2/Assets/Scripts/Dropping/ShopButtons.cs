using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopButtons : MonoBehaviour
{

    public Button[] shopButton;
    public Text friend_amt, garb_amt, org_amt, gov_amt, cult_amt;
    public Text friend_cost, garb_cost, org_cost, gov_cost, cult_cost;

    public Image org_img, gov_img, cult_img;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        showText();
        if(Gamemanager.manager.trash >= Gamemanager.manager.friendcost)
        {
            shopButton[0].interactable = true;
        }
        else
        {
            shopButton[0].interactable = false;
        }
        if (Gamemanager.manager.trash >= Gamemanager.manager.garbagemancost)
        {
            shopButton[1].interactable = true;
        }
        else
        {
            shopButton[1].interactable = false;
        }

        if (Gamemanager.manager.trash >= Gamemanager.manager.orgcost)
        {
            shopButton[2].interactable = true;
        }
        else
        {
            shopButton[2].interactable = false;
        }

        if(Gamemanager.manager.org_bw == 1)
        {
            org_img.color = Color.white;
        }
        else
        {
            org_img.color = Color.black;
        }

        if (Gamemanager.manager.trash >= Gamemanager.manager.govcost)
        {
            shopButton[3].interactable = true;
        }
        else
        {
            shopButton[3].interactable = false;
        }

        if (Gamemanager.manager.gov_bw == 1)
        {
            gov_img.color = Color.white;
        }
        else
        {
            gov_img.color = Color.black;
        }

        if (Gamemanager.manager.trash >= Gamemanager.manager.cultcost)
        {
            shopButton[4].interactable = true;
        }
        else
        {
            shopButton[4].interactable = false;
        }

        if (Gamemanager.manager.cult_bw == 1)
        {
            cult_img.color = Color.white;
        }
        else
        {
            cult_img.color = Color.black;
        }
    }

    public void increaseTrashPerSec(float val)
    {
        Gamemanager.manager.trashpersec += val;
    }

    public void GetFriend()
    {
        if (Gamemanager.manager.trash >= Gamemanager.manager.friendcost)
        {
            Gamemanager.manager.trash -= Gamemanager.manager.friendcost;
            increaseTrashPerSec(0.5f);
            Gamemanager.manager.friendcost += Gamemanager.manager.friendcost / 4;
            Gamemanager.manager.friend++;
        }
    }

    public void GetWorker()
    {
        if (Gamemanager.manager.trash >= Gamemanager.manager.garbagemancost)
        {
            Gamemanager.manager.trash -= Gamemanager.manager.garbagemancost;
            increaseTrashPerSec(1f);
            Gamemanager.manager.garbagemancost += Gamemanager.manager.garbagemancost / 4;
            Gamemanager.manager.garbageman++;
        }
    }

    public void GetOrg()
    {
        if (Gamemanager.manager.trash >= Gamemanager.manager.orgcost)
        {
            Gamemanager.manager.trash -= Gamemanager.manager.orgcost;
            increaseTrashPerSec(2f);
            Gamemanager.manager.orgcost += Gamemanager.manager.orgcost / 4;
            Gamemanager.manager.organization++;
        }
    }

    public void GetGov()
    {
        if (Gamemanager.manager.trash >= Gamemanager.manager.govcost)
        {
            Gamemanager.manager.trash -= Gamemanager.manager.govcost;
            increaseTrashPerSec(5f);
            Gamemanager.manager.govcost += Gamemanager.manager.govcost / 4;
            Gamemanager.manager.government++;
        }
    }

    public void GetCult()
    {
        if (Gamemanager.manager.trash >= Gamemanager.manager.cultcost)
        {
            Gamemanager.manager.trash -= Gamemanager.manager.cultcost;
            increaseTrashPerSec(10f);
            Gamemanager.manager.cultcost += Gamemanager.manager.cultcost / 4;
            Gamemanager.manager.cult++;  
        }
    }

    public void increaseTrashGet()
    {
        if (Gamemanager.manager.trash >= Gamemanager.manager.getTrashCost)
        {
            Gamemanager.manager.trash -= Gamemanager.manager.getTrashCost;
            Gamemanager.manager.getTrash += 1;
            Gamemanager.manager.getTrashCost += Gamemanager.manager.getTrashCost / 6;
        }


    }

    public void showText()
    {
        friend_amt.text = "Has: " + Gamemanager.manager.friend;
        garb_amt.text = "Has: " + Gamemanager.manager.garbageman;
        org_amt.text = "Has: " + Gamemanager.manager.organization;
        gov_amt.text = "Has: " + Gamemanager.manager.government;
        cult_amt.text = "Has: " + Gamemanager.manager.cult;
        friend_cost.text = "get friend to help pick up trash " + "Costs: " + Gamemanager.manager.friendcost.ToString("F2");
        garb_cost.text = "hire a professional garbage man to help pick up trash " + "Costs: " + Gamemanager.manager.garbagemancost.ToString("F2");
        if(Gamemanager.manager.org_bw == 1)
        {
            org_cost.text = "convince an organization to organize effort to clean up trash" + "Costs: " + Gamemanager.manager.orgcost.ToString("F2");
        }
        else
        {
            org_cost.text = "??? " + "Costs: " + Gamemanager.manager.orgcost.ToString("F2");
        }

        if (Gamemanager.manager.gov_bw == 1)
        {
            gov_cost.text = "get friend to help pick up trash " + "Costs: " + Gamemanager.manager.govcost.ToString("F2");
        }
        else
        {
            gov_cost.text = "??? " + "Costs: " + Gamemanager.manager.govcost.ToString("F2");
        }

        if (Gamemanager.manager.cult_bw == 1)
        {
            cult_cost.text = "get friend to help pick up trash " + "Costs: " + Gamemanager.manager.cultcost.ToString("F2");
        }
        else
        {
            cult_cost.text = "??? " + "Costs: " + Gamemanager.manager.cultcost.ToString("F2");
        }
        
        
    }
}
