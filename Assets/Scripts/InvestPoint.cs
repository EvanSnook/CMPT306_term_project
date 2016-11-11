using UnityEngine;
using System.Collections;

public class InvestPoint : MonoBehaviour {

    SkillTree root;
    public static int SkillPoints = 1;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnMouseDown()
    {
            Debug.Log("leveled up "+ gameObject.name);
            //SendMessage("LevelUp");
    }
}
