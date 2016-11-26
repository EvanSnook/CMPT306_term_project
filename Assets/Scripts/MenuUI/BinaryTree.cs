using UnityEngine;
using System.Collections;

public class BinaryTree : ScriptableObject {

    public BinaryTree Parent;
    public BinaryTree RightChild;
    public BinaryTree LeftChild;
    
    public Skill skillElement;
    
    public BinaryTree(BinaryTree inParent, Skill inElement)
    {
        Parent = inParent;
        skillElement = inElement;
    }

    public BinaryTree getParent()
    {
        return Parent;
    }

    public BinaryTree getRightChild()
    {
        return RightChild;
    }

    public BinaryTree getLeftChild()
    {
        return LeftChild;
    }

    public Skill getSkillTreeNode()
    {
        return skillElement;
    }

    //this function finds a BinaryTree object with a skill script named skillName it returns null if none can be found.
    public BinaryTree findSkillElement(string skillName)
    {
        BinaryTree returnTree;
        if (skillElement.Script.name == skillName)
        {
            return this;
        }
        else if(RightChild != null)
        {
            if(LeftChild != null)
            {
                returnTree = LeftChild.findSkillElement(skillName);
                if (returnTree != null)
                {
                    return returnTree;
                }
            }
            
             returnTree = RightChild.findSkillElement(skillName);
            if (returnTree != null)
            {
                return returnTree;
            }
        }
        return null;
    }
    
}
