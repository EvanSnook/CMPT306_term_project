using UnityEngine;
using System.Collections;

public class Skill : ScriptableObject {

    public int cost;    
    public bool locked;
    public bool bought;
    public SkillTreeNode.SkillType skillType = SkillTreeNode.SkillType.Q;
    public Object Script;
    
    public void LockSkill()
    {
        this.locked = true;
        this.bought = false;
    }

    //purchases the skill
    public void PurchaseSkill()
    {
        this.locked = false;
        this.bought = true;
    }

    //unlocks the skill so you can see the tool tip and purchase the skill.
    public void UnlockSkill()
    {
        this.locked = false;
        this.bought = false;
    }

}
