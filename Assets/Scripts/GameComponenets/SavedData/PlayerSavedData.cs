﻿using UnityEngine;
using System.Collections;

public class PlayerSavedData : MonoBehaviour
{

    public int SkillPoints; // This is the number of skill points that the player currently has.

    public int NumberOfDeaths; // This is the number of times that the player has died.

    public int RangedDamageDone; // This is the damage done to the boss by the player's ranged attack.
    public int MeleeDamageDone; // This is the damage done to the boss by the player's melee attack.

    //currently equipped skills
    public GameObject QSkill;
    public GameObject ESkill;
    public GameObject RWSkill;
    public GameObject RSSkill;
    public GameObject MWSkill;
    public GameObject MSSkill;

    void Start()
    {
        NumberOfDeaths = 0;
        RangedDamageDone = 0;
        MeleeDamageDone = 0;
    }

    //takes in the object to add the skills to.
    public void ApplySkillsToPlayer(GameObject Player)
    {
        GameObject newskill;
        if (QSkill != null)
        {
            newskill = Instantiate(QSkill);
            newskill.transform.SetParent(Player.transform, false);
            try
            {
                Player.BroadcastMessage("SetNumOfOrbs", gameObject.GetComponent<SkillSavedData>().QTree.findSkillElement(QSkill.name).skillElement.numberOfInvests);
            }
            catch { }
        }
        //TODO add cases for all the other skills keys
    }

    public void RemoveSkillsFromPlayer(GameObject Player)
    {
        //remove the children from player
        int count = Player.transform.childCount;
        for (int i = 0; i < count; i++)
        {
            QSkill = null;
            Destroy(Player.transform.GetChild(i).gameObject);
        }


    }

    // This is called to add a specific number of points when sent message.
    public void AddSkillPoints(int NumberOfPoints)
    {
        SkillPoints += NumberOfPoints;
    }

    public void SubtractSkillPoints(int NumberOfPoints)
    {
        SkillPoints -= NumberOfPoints;
    }

    // This is called when the player dies and increments the number of deaths for the player.
    public void PlayerDied()
    {
        NumberOfDeaths++;
    }


    // This is called when the game goes to the main menu and resets all the saved data for a new game.
    public void ResetPlayerSavedData()
    {
        RemoveSkillsFromPlayer(GameObject.Find("Character"));
        RangedDamageDone = 0; // This resets the amount of ranged damage done to 0.
        MeleeDamageDone = 0; // This resets teh amount of melee damage done to 0.
        NumberOfDeaths = 0; // This resets the number of deaths to 0.
        SkillPoints = 0; // This resets the number of skill points to 0.
    }

    // This increases the Total Damage Done by the Player's Ranged Attack.
    public void PlayerRangedDMG(int DMGDone)
    {
        RangedDamageDone += DMGDone;
    }

    // This increases the Total Damage Done by the Player's Melee Attack.
    public void PlayerMeleeDMG(int DMGDone)
    {
        MeleeDamageDone += DMGDone;
    }

    // This is the total Damage done by the Player to the boss.
    public int TotalDamageDoneToBoss()
    {
        return RangedDamageDone + MeleeDamageDone;
    }

}
