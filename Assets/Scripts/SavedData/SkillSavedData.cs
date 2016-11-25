using UnityEngine;
using System.Collections;

public class SkillSavedData : MonoBehaviour {

    BinaryTree QTree;
    public GameObject QTreeRootNode;
	// Use this for initialization
	void Start () {
        QTree = generateTree(QTreeRootNode);
    }
	
    public BinaryTree generateTree(GameObject Item)
    {
        BinaryTree Root;
        Root = (BinaryTree)ScriptableObject.CreateInstance("BinaryTree");
        Root.UINode = Item;
        Debug.Log(Time.time + " "+Root.UINode.name);
        foreach (Transform child in Item.transform)
        {
            if (child.gameObject.tag == "SkillTreeNode")
            {
                if (Root.getRightChild() == null)
                {
                    Root.RightChild = generateTree(child.gameObject);
                }
                else if (Root.getLeftChild() == null)
                {
                    Root.LeftChild = generateTree(child.gameObject);
                }
            }
        }
        
        return Root;
    }
}
