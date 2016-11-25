using UnityEngine;
using System.Collections;

public class BinaryTree : ScriptableObject {

    public BinaryTree Parent;
    public BinaryTree RightChild;
    public BinaryTree LeftChild;
    
    public GameObject UINode;
    
    public BinaryTree(BinaryTree inParent, GameObject inElement)
    {
        Parent = inParent;
        UINode = inElement;
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

    public GameObject getSkillTreeNode()
    {
        return UINode;
    }

    
}
