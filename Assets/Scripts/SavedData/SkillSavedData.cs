using UnityEngine;
using System.Collections;

public class SkillSavedData : MonoBehaviour {
    
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
	
    public BinaryTree generateTree(GameObject NodeGameObject)
    {
        
        BinaryTree Root;
        Root = (BinaryTree)ScriptableObject.CreateInstance("BinaryTree");
        Root.skillElement = (Skill)ScriptableObject.CreateInstance("Skill");
        setSkillsInfo(Root.skillElement, NodeGameObject);
        
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
