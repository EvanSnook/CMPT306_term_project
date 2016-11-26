using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class SkillManager : MonoBehaviour {

    private int skillPoints;
    public SkillTreeNode selectedSkill;
    public Text skillPointText;
    public Text selectedSkillText;
    public Text equipedQText;
    public Text equipedEText;
    public Text equipedMWText;
    public Text equipedMSText;
    public Text equipedRWText;
    public Text equipedRSText;
    public string Qstring = "Defensive Ability:\n";
    public string Estring = "Offensive Ability:\n";
    public string MWstring = "Melee Down:\n";
    public string MSstring = "Melee Up:\n";
    public string RWstring = "Ranged Up:\n";
    public string RSstring = "Ranged Down:\n";
    private GameObject SavedData;


    void Awake(){
        SavedData = GameObject.Find("SavedData");
        skillPoints = SavedData.GetComponent<PlayerSavedData>().SkillPoints;
        //equipedQText.text = Qstring + SavedData.GetComponent<PlayerSavedData>().QSkill.name;
        //equipedEText.text = Estring + SavedData.GetComponent<PlayerSavedData>().ESkill.name;
        //equipedMWText.text = MWstring + SavedData.GetComponent<PlayerSavedData>().MWSkill.name;
        //equipedMSText.text = MSstring + SavedData.GetComponent<PlayerSavedData>().MSSkill.name;
        //equipedRWText.text = RWstring + SavedData.GetComponent<PlayerSavedData>().RWSkill.name;
        //equipedRSText.text = RSstring + SavedData.GetComponent<PlayerSavedData>().RSSkill.name;
    }
    void FixedUpdate(){
        //updating the text for when points are spent
        skillPointText.text = "Skill Points: " + SavedData.GetComponent<PlayerSavedData>().SkillPoints;
    }

    void SkillSelected(SkillTreeNode skill){
        //Apply the skill to the player
        selectedSkill = skill;
        selectedSkillText.text = "Selected Ability:\n" +selectedSkill.GetComponentInChildren<Text>().text;
        if (selectedSkill.bought){
            //find what text to update based on skill type
            switch (selectedSkill.skillType)
            {
                case (SkillTreeNode.SkillType.Q):
                    {
                        equipedQText.text = Qstring + selectedSkill.GetComponentInChildren<Text>().text;
                        SavedData.GetComponent<PlayerSavedData>().QSkill = selectedSkill.skillScript;
                        break;
                    }
                case (SkillTreeNode.SkillType.E):
                    {
                        //equip the skill
                        equipedQText.text = Estring + selectedSkill.GetComponentInChildren<Text>().text;
                        SavedData.GetComponent<PlayerSavedData>().ESkill = selectedSkill.skillScript;
                        break;
                    }
                case (SkillTreeNode.SkillType.MS):
                    {
                        //equip the skill
                        equipedQText.text = MSstring + selectedSkill.GetComponentInChildren<Text>().text;
                        SavedData.GetComponent<PlayerSavedData>().MSSkill = selectedSkill.skillScript;
                        break;
                    }
                case (SkillTreeNode.SkillType.MW):
                    {
                        //equip the skill
                        equipedQText.text = MWstring + selectedSkill.GetComponentInChildren<Text>().text;
                        SavedData.GetComponent<PlayerSavedData>().MWSkill = selectedSkill.skillScript;
                        break;
                    }
                case (SkillTreeNode.SkillType.RS):
                    {
                        //equip the skill
                        equipedQText.text = RSstring + selectedSkill.GetComponentInChildren<Text>().text;
                        SavedData.GetComponent<PlayerSavedData>().RSSkill = selectedSkill.skillScript;
                        break;
                    }
                case (SkillTreeNode.SkillType.RW):
                    {
                        //equip the skill
                        equipedRWText.text = RWstring + selectedSkill.GetComponentInChildren<Text>().text;
                        SavedData.GetComponent<PlayerSavedData>().RWSkill = selectedSkill.skillScript;
                        break;
                    }
            }
        }
    }

    //the purchase button was pressed
    public void Purchase(){
        //get the save data
        GameObject SavedData = GameObject.Find("SavedData");
        skillPoints = SavedData.GetComponent<PlayerSavedData>().SkillPoints;
        BinaryTree foundTree = null;
        //make sure that you are able to purchase the skill
        if (selectedSkill != null && selectedSkill.isPurchaseable() && skillPoints >= selectedSkill.cost){

            //deduct skill points
            SavedData.GetComponent<PlayerSavedData>().SkillPoints = skillPoints - selectedSkill.cost;
            selectedSkill.PurchaseSkill();

            //decide what tree to look in based on skill type of the selected skill
            switch (selectedSkill.skillType){
                case (SkillTreeNode.SkillType.Q):{
                        //look for the Skill object
                        foundTree = SavedData.GetComponent<SkillSavedData>().QTree.findSkillElement(selectedSkill.skillScript.name);
                        //equip the skill
                        equipedQText.text = Qstring + selectedSkill.GetComponentInChildren<Text>().text;
                        break;
                    }
                case (SkillTreeNode.SkillType.E):{
                        //look for the Skill object
                        foundTree = SavedData.GetComponent<SkillSavedData>().ETree.findSkillElement(selectedSkill.skillScript.name);
                        //equip the skill
                        equipedQText.text = Estring + selectedSkill.GetComponentInChildren<Text>().text;
                        break;
                    }
                case (SkillTreeNode.SkillType.MS):{
                        //look for the Skill object
                        foundTree = SavedData.GetComponent<SkillSavedData>().MSTree.findSkillElement(selectedSkill.skillScript.name);
                        //equip the skill
                        equipedQText.text = MSstring + selectedSkill.GetComponentInChildren<Text>().text;
                        break;
                    }
                case (SkillTreeNode.SkillType.MW):{
                        //look for the Skill object
                        foundTree = SavedData.GetComponent<SkillSavedData>().MWTree.findSkillElement(selectedSkill.skillScript.name);
                        //equip the skill
                        equipedQText.text = MWstring + selectedSkill.GetComponentInChildren<Text>().text;
                        break;
                    }
                case (SkillTreeNode.SkillType.RS):{
                        //look for the Skill object
                        foundTree = SavedData.GetComponent<SkillSavedData>().RSTree.findSkillElement(selectedSkill.skillScript.name);
                        //equip the skill
                        equipedQText.text = RSstring + selectedSkill.GetComponentInChildren<Text>().text;
                        break;
                    }
                case (SkillTreeNode.SkillType.RW):{
                        //look for the Skill object
                        foundTree = SavedData.GetComponent<SkillSavedData>().RWTree.findSkillElement(selectedSkill.skillScript.name);
                        //equip the skill
                        equipedRWText.text = RSstring + selectedSkill.GetComponentInChildren<Text>().text;
                        break;
                    }
                default:{
                        foundTree = null;
                        break;
                    }
            }
            if(foundTree != null){
                //purchase the Skill
                foundTree.skillElement.PurchaseSkill();
                //unlock its children
                if (foundTree.RightChild != null){
                    foundTree.RightChild.skillElement.UnlockSkill();
                }
                if(foundTree.LeftChild != null){
                    foundTree.LeftChild.skillElement.UnlockSkill();
                }
            }
        }
    }
}
