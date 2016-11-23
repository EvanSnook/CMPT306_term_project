using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InvestPoint : MonoBehaviour {

    SkillTree root;
    public static int SkillPoints = 1;
    public Text currentSkill;
    private string Indicator;
    // Use this for initialization
    void Start () {
        Indicator = currentSkill.text;
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnMouseDown()
    {
        
        Debug.Log("leveled up "+ gameObject.name);
        currentSkill.text = Indicator + GetComponentInChildren<Text>().text;
    }
}
