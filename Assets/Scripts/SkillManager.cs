using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class SkillManager : MonoBehaviour {

    public int skillPoints;
    public SkillTreeNode selectedSkill;

    void SkillSelected(SkillTreeNode skill)
    {
        selectedSkill = skill;
    }
	public void Purchase(){
        
        if (selectedSkill.isPurchaseable() && skillPoints >= selectedSkill.cost)
        {
            Debug.Log("Purchase Skill");
            skillPoints = skillPoints - selectedSkill.cost;
            selectedSkill.PurchaseSkill();
            if(selectedSkill.rightChild != null){
                selectedSkill.rightChild.GetComponent<SkillTreeNode>().UnlockSkill();
            }
            if (selectedSkill.leftChild != null)
            {
                selectedSkill.leftChild.GetComponent<SkillTreeNode>().UnlockSkill();
            }
            

        }
        else
        {
            Debug.Log("Cannot Purchase Skill");
        }
    }
}
