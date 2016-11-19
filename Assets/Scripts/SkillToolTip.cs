using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SkillToolTip : MonoBehaviour {

    public GameObject ToolTip;

	// Use this for initialization
	void Start () {
        ToolTip.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void ShowToolTip()
    {
        Debug.Log("Show " + gameObject.name);
        ToolTip.SetActive(true);
    }

    void HideToolTip()
    {
        Debug.Log("Hide " + gameObject.name);
        ToolTip.SetActive(false);
    }
}
