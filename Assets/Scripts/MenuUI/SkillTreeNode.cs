using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SkillTreeNode : MonoBehaviour {
    public enum SkillType { Q, E, RW, RS, MW, MS };
    //tree nodes
    //public GameObject parent;
    //public GameObject rightChild;
    //public GameObject leftChild;
    //manages the skills and skill points
    public GameObject skillsManager;
    //number of skill points requied to buy
    public int cost;
    public GameObject skillObject;
    public SkillType skillType;
    //Status of the node
    public bool locked;// true: unable to see. false: can see name and description.
    public bool bought;// true: completely unlocked and equipable. false: able to purchase, unable to equip.
    
    private string selectedText = "Selected Ability: ";
    private string equipedText;
    // Use this for initialization

    void Start()
    {
        LoadSavedData();
    }

    void Update()
    {
        LoadSavedData();
    }

    void OnMouseDown()
    {
        //select the skill
        if (!this.locked)
        {
            skillsManager.SendMessage("SkillSelected", this);
            //select the skill
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

    //locks the skill turns the node dark and disables tool tip.
    public void LockSkill()
    {
        this.locked = true;
        this.bought = false;
        gameObject.GetComponent<Image>().color = new Color(0f, 0f, 0f);
    }

    //purchases the skill turns the skill white.
    public void PurchaseSkill()
    {
        this.locked = false;
        this.bought = true;
        gameObject.GetComponent<Image>().color = new Color(1f, 1f, 1f);
    }

    //unlocks the skill so you can see the tool tip and purchase the skill.
    public void UnlockSkill()
    {
        this.locked = false;
        this.bought = false;
        gameObject.GetComponent<Image>().color = new Color(0.5f, 0.5f, 0.5f);
    }

    public void LoadSavedData()
    {
        GameObject SavedData = GameObject.Find("SavedData");
        BinaryTree QTree = SavedData.GetComponent<SkillSavedData>().QTree;
        BinaryTree ETree = SavedData.GetComponent<SkillSavedData>().ETree;
        BinaryTree MSTree = SavedData.GetComponent<SkillSavedData>().MSTree;
        BinaryTree MWTree = SavedData.GetComponent<SkillSavedData>().MWTree;
        BinaryTree RSTree = SavedData.GetComponent<SkillSavedData>().RSTree;
        BinaryTree RWTree = SavedData.GetComponent<SkillSavedData>().RWTree;
        BinaryTree foundTree;
        switch (skillType)
        {
            case (SkillType.Q):
                {
                    //search the tree for matching script
                    foundTree = QTree.findSkillElement(skillObject.name);
                    break;
                }
            case (SkillType.E):
                {
                    //search the tree for matching script
                    foundTree = ETree.findSkillElement(skillObject.name);
                    break;
                }
            case (SkillType.MS):
                {
                    //search the tree for matching script
                    foundTree = MSTree.findSkillElement(skillObject.name);
                    break;
                }
            case (SkillType.MW):
                {
                    //search the tree for matching script
                    foundTree = MWTree.findSkillElement(skillObject.name);
                    break;
                }
            case (SkillType.RS):
                {
                    //search the tree for matching script
                    foundTree = RSTree.findSkillElement(skillObject.name);
                    break;
                }
            case (SkillType.RW):
                {
                    //search the tree for matching script
                    foundTree = RWTree.findSkillElement(skillObject.name);
                    break;
                }
            default:
                {
                    foundTree = null;
                    break;
                }
        }
        if (foundTree != null)
        {
            this.locked = foundTree.skillElement.locked;
            this.bought = foundTree.skillElement.bought;
            this.cost = foundTree.skillElement.cost;
        }
        if (locked)
        {
            LockSkill();
        }
        else if (bought)
        {
            PurchaseSkill();
        }
        else
        {
            UnlockSkill();
        }
    }
}
