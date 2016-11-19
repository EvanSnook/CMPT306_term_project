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
            if(selectedSkill.RightChild != null){
                selectedSkill.RightChild.GetComponent<SkillTreeNode>().UnlockSkill();
            }
            if (selectedSkill.LeftChild != null)
            {
                selectedSkill.LeftChild.GetComponent<SkillTreeNode>().UnlockSkill();
            }
            

        }
        else
        {
            Debug.Log("Cannot Purchase Skill");
        }
    }
}
