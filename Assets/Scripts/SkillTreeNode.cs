using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SkillTreeNode : MonoBehaviour {

    public GameObject LeftChild;
    public GameObject RightChild;
    public GameObject Parent;

    public Text currentSkillText;
    private string skillSlot;
    public bool locked;
    public bool bought;
    public int cost;
    public GameObject SkillsManager;

	// Use this for initialization
	void Start () {
        skillSlot = currentSkillText.text;
        if(Parent == null ){
            UnlockSkill();
        }else{
            LockSkill();
        }
        
	}

    void OnMouseDown()
    {
        //selct the skill
        Debug.Log("Selected " + gameObject.name);
        SkillsManager.SendMessage("SkillSelected", this);
        currentSkillText.text = skillSlot + GetComponentInChildren<Text>().text;
  
    }

    void OnMouseEnter()
    {
        //Show popup description.
        gameObject.SendMessage("ShowToolTip");
    }

    void OnMouseExit()
    {
        //Hide popup description.
        gameObject.SendMessage("HideToolTip");
    }

    public bool isPurchaseable()
    {
        return !this.locked && !this.bought;
    }

    public void LockSkill()
    {
        Debug.Log("Locking " + gameObject.name);
        this.locked = true;
        this.bought = false;
        gameObject.GetComponent<Image>().color = new Color(0f, 0f, 0f);
    }

    public void PurchaseSkill()
    {
        Debug.Log("Purchasing " + gameObject.name);
        this.locked = false;
        this.bought = true;
        gameObject.GetComponent<Image>().color = new Color(255f, 255f, 255f);
    }

    public void UnlockSkill()
    {
        Debug.Log("Unlocking " + gameObject.name);
        this.locked = false;
        this.bought = false;
        gameObject.GetComponent<Image>().color = new Color(1f, 0f, 0f);
    }
}
