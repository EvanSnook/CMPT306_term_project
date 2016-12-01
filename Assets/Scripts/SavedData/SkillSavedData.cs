using UnityEngine;
using System.Collections;

public class SkillSavedData : MonoBehaviour {
    
    //binaryTree and GameObject versions of each tree.
    public BinaryTree QTree;
    private GameObject QTreeRootNode;
    public BinaryTree ETree;
    private GameObject ETreeRootNode;
    public BinaryTree MSTree;
    private GameObject MSTreeRootNode;
    public BinaryTree MWTree;
    private GameObject MWTreeRootNode;
    public BinaryTree RSTree;
    private GameObject RSTreeRootNode;
    public BinaryTree RWTree;
    private GameObject RWTreeRootNode;
    
    void Awake () {
        // set up tree data structure from TreeRootNodes
        QTreeRootNode = GameObject.Find("QTree");
        GameObject UiNode = QTreeRootNode.transform.GetChild(0).gameObject;
        QTree = generateTree(UiNode);
        
    }
	
    //generates a Binary tree based on the heiarchy of the skill tree nodes
    public BinaryTree generateTree(GameObject NodeGameObject)
    {
        BinaryTree Root;
        Root = (BinaryTree)ScriptableObject.CreateInstance("BinaryTree");
        Root.skillElement = (Skill)ScriptableObject.CreateInstance("Skill");
        setSkillsInfo(Root.skillElement, NodeGameObject);
        //children on the right are first in the heiarchy.
        //children on the left are next in the heiarchy.
        //only works with binary expansion or linear.
        //only looks at children with the tag "SkillTreeNode"
        foreach (Transform child in NodeGameObject.transform)
        {
            if (child.gameObject.tag == "SkillTreeNode")
            {
                if (Root.getRightChild() == null)
                {
                    Root.RightChild = generateTree(child.gameObject);
                    Root.RightChild.Parent = Root;
                }
                else if (Root.getLeftChild() == null)
                {
                    Root.LeftChild = generateTree(child.gameObject);
                    Root.LeftChild.Parent = Root;
                }
            }
        }
        return Root;
    }

    //assigns the feilds of infoOut to those of infoIn's skillTreeNode script
    public void setSkillsInfo(Skill infoOut, GameObject infoIn)
    {
        SkillTreeNode treeNode = infoIn.GetComponent<SkillTreeNode>();

        infoOut.cost = treeNode.cost;
        infoOut.bought = treeNode.bought;
        infoOut.locked = treeNode.locked;
        infoOut.skillType = treeNode.skillType;
        infoOut.Script = treeNode.skillObject;
    }
}
