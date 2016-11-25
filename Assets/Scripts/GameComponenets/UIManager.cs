using UnityEngine;
using System.Collections;

public class UIManager : MonoBehaviour
{

    public GameObject mainCamera;
    public Canvas SkillsCanvas;
    public Canvas MainMenuCanvas;

    void Awake()
    {
        MainMenu();
    }
    public void ShowSkills()
    {
        //zoom out camera
        mainCamera.GetComponent<Camera>().orthographicSize = 10;
        //move camera upwards
        mainCamera.GetComponent<Transform>().position = new Vector3(0, 6, -10);
        //turn on the skills UI main menu off
        MainMenuCanvas.enabled = false;
        SkillsCanvas.enabled = true;
    }

    public void MainMenu()
    {
        //zoom out camera
        mainCamera.GetComponent<Camera>().orthographicSize = 6;
        //move camera upwards
        mainCamera.GetComponent<Transform>().position = new Vector3(0, 1, -10);
        //turn off the skills UI main menu on
        SkillsCanvas.enabled = false;
        MainMenuCanvas.enabled = true;
    }

    public void Exit()
    {
        Application.Quit();
    }
}
