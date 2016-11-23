using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SkillToolTip : MonoBehaviour {

    public GameObject ToolTip;
    private SkillTreeNode thisNode;
	// Use this for initialization
	void Start () {
        thisNode = GetComponent<SkillTreeNode>();
        ToolTip.SetActive(false);
	}

    void ShowToolTip()
    {
        ToolTip.SetActive(true);
    }

    void HideToolTip()
    {
        ToolTip.SetActive(false);
    }
}
