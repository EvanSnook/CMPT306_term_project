using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
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
    private GameObject Player;

    void Awake(){
        Player = GameObject.Find("Character");
        if (SceneManager.GetActiveScene().name == "Spawn_room")
        {
            SavedData = GameObject.Find("SavedData");
            skillPoints = SavedData.GetComponent<PlayerSavedData>().SkillPoints;
            if (SavedData.GetComponent<PlayerSavedData>().QSkill != null)
            {
                equipedQText.text = Qstring + SavedData.GetComponent<PlayerSavedData>().QSkill.name;
            }
            //equipedEText.text = Estring + SavedData.GetComponent<PlayerSavedData>().ESkill.name;
            //equipedMWText.text = MWstring + SavedData.GetComponent<PlayerSavedData>().MWSkill.name;
            //equipedMSText.text = MSstring + SavedData.GetComponent<PlayerSavedData>().MSSkill.name;
            //equipedRWText.text = RWstring + SavedData.GetComponent<PlayerSavedData>().RWSkill.name;
            //equipedRSText.text = RSstring + SavedData.GetComponent<PlayerSavedData>().RSSkill.name;
        }
        
        
    }
    void FixedUpdate(){
        //updating the text for when points are spent
        if (SceneManager.GetActiveScene().name == "Spawn_room")
        {
            skillPointText.text = "Skill Points: " + SavedData.GetComponent<PlayerSavedData>().SkillPoints;
        }
    }

    //this is called when we click on a skill node
    void SkillSelected(SkillTreeNode skill){
        //Apply the skill to the player
        selectedSkill = skill;
        selectedSkillText.text = "Selected Ability:\n" +selectedSkill.GetComponentInChildren<Text>().text;
        if (selectedSkill.bought){
            findAndReplaceSkill();
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
            foundTree = findAndReplaceSkill();
            if (foundTree != null){
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

    public BinaryTree findAndReplaceSkill()
    {
        BinaryTree TreeNode = null;
        //decide what tree to look in based on skill type of the selected skill
        switch (selectedSkill.skillType)
        {
            case (SkillTreeNode.SkillType.Q):
                {
                    //find the Binary tree node with the selected skill in it
                    TreeNode = SavedData.GetComponent<SkillSavedData>().QTree.findSkillElement(selectedSkill.skillObject.name);
                    //remove old skill
                    if (SavedData.GetComponent<PlayerSavedData>().QSkill != null)
                    {
                        Destroy(Player.transform.FindChild(SavedData.GetComponent<PlayerSavedData>().QSkill.name + "(Clone)").gameObject);
                    }
                    //update all texts needed
                    equipedQText.text = Qstring + selectedSkill.GetComponentInChildren<Text>().text;
                    //save data
                    SavedData.GetComponent<PlayerSavedData>().QSkill = selectedSkill.skillObject;
                    break;
                }
            case (SkillTreeNode.SkillType.E):
                {
                    //TODO add the same case as Q just for all the other cases.
                    break;
                }
            case (SkillTreeNode.SkillType.MS):
                {
                    break;
                }
            case (SkillTreeNode.SkillType.MW):
                {
                    break;
                }
            case (SkillTreeNode.SkillType.RS):
                {
                    break;
                }
            case (SkillTreeNode.SkillType.RW):
                {
                    break;
                }
            default:
                {
                    break;
                }
        }
        SavedData.SendMessage("ApplySkillsToPlayer", Player);
        return TreeNode;
    }
    
}
