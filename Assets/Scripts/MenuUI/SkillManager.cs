using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class SkillManager : MonoBehaviour {

    public int skillPoints;
    public SkillTreeNode selectedSkill;
    public Text skillPointText;

    void Awake()
    {
        //fetching the skill points from the saved data
        skillPoints = GameObject.Find("SavedData").GetComponent<PlayerSavedData>().SkillPoints;
    }

    void FixedUpdate()
    {
        //updating the text for when points are spent
        skillPointText.text = "Skill Points: " + skillPoints;
    }

    void SkillSelected(SkillTreeNode skill)
    {
        //Apply the skill to the player
        selectedSkill = skill;
    }

	public void Purchase(){

        if (selectedSkill.isPurchaseable() && skillPoints >= selectedSkill.cost)
        {
            //Debug.Log("Purchase Skill");
            //deduct skill points
            skillPoints = skillPoints - selectedSkill.cost;
            selectedSkill.PurchaseSkill();
            //unlock the next level if there is one
            if(selectedSkill.rightChild != null){
                selectedSkill.rightChild.GetComponent<SkillTreeNode>().UnlockSkill();
            }
            if (selectedSkill.leftChild != null)
            {
                selectedSkill.leftChild.GetComponent<SkillTreeNode>().UnlockSkill();
            }
        }
    }
}
