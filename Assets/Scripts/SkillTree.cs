using UnityEngine;
using System.Collections;

public class SkillTree : ScriptableObject {

    SkillTree LeftTree { get; set; }
    SkillTree RightTree { get; set; }
    Skill Skill { get; set; }
    int Cost { get; set; }
    bool Unlocked { get; set; } 
    bool Visible { get; set; } 

    SkillTree()
    {
        LeftTree = null;
        RightTree = null;
        Skill = null;
    }

    SkillTree(SkillTree inLeft, SkillTree inRight, Skill inData)
    {
        LeftTree = inLeft;
        RightTree = inRight;
        Skill = inData;
    }


}
