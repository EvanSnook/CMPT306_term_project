using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SkillTreeNode : MonoBehaviour {

    public GameObject parent;
    public GameObject rightChild;
    public GameObject leftChild;
    public GameObject skillsManager;
    public Text currentSkillText;
    public Text equipedSkillText;
    public int cost;
    public bool locked;
    public bool bought;
    private string selectedText = "Selected Ability: ";
    private string equipedText;
    // Use this for initialization

    void Awake()
    {
        cost = 1;
        equipedText = equipedSkillText.text;

        //setting up the tree based on unity hiearchy. right trees come first and left trees second.
        if (gameObject.transform.parent.gameObject.tag == "SkillTreeNode")
        {
            parent = gameObject.transform.parent.gameObject;
            LockSkill();
        }
        else
        {
            UnlockSkill();
        }
        foreach(Transform child in transform)
        {
            if (child.gameObject.tag == "SkillTreeNode")
            {
                if (rightChild == null)
                {
                    rightChild = child.gameObject;
                }
                else if (leftChild == null)
                {
                    leftChild = child.gameObject;
                }
            }
        }
        
    }

    void OnMouseDown()
    {
        //select the skill
        if (!this.locked)
        {
            skillsManager.SendMessage("SkillSelected", this);
            currentSkillText.text = selectedText + GetComponentInChildren<Text>().text;
            if (this.bought)
            {
                equipedSkillText.text = equipedText + GetComponentInChildren<Text>().text;
            }
        }
    }

    void OnMouseEnter()
    {
        //Show popup description.
        if (!this.locked)
        {
            gameObject.SendMessage("ShowToolTip");
        }
    }

    void OnMouseExit()
    {
        //Hide popup description.
        gameObject.SendMessage("HideToolTip");
    }

    public bool isPurchaseable()
    {
        return (!this.locked && !this.bought);
    }

    public void LockSkill()
    {
        this.locked = true;
        this.bought = false;
        gameObject.GetComponent<Image>().color = new Color(0f, 0f, 0f);
    }

    public void PurchaseSkill()
    {
        this.locked = false;
        this.bought = true;
        equipedSkillText.text = equipedText + GetComponentInChildren<Text>().text;
        gameObject.GetComponent<Image>().color = new Color(1f, 1f, 1f);
    }

    public void UnlockSkill()
    {
        this.locked = false;
        this.bought = false;
        gameObject.GetComponent<Image>().color = new Color(0.5f, 0.5f, 0.5f);
    }
}
