using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour
{

    private SceneManagerCustom sceneManagerCustom;
    private GameObject logo;
    private GameObject menu;
    private GameObject credits;
    private GameObject difficultScreen;

    void Start()
    {
        SoundManager.instance.Play(SoundID.MENU, false, 0.2F, 0);
        sceneManagerCustom = GetComponent<SceneManagerCustom>();
        logo = GameObject.Find("CastleHuntAnim");
        menu = GameObject.Find("Canvas");
        credits = GameObject.Find("Canvas-Credits");
        difficultScreen = GameObject.Find("Canvas-SelectDifficult");
        credits.GetComponent<Canvas>().enabled = false;
        difficultScreen.GetComponent<Canvas>().enabled = false;
    }

    public void StartGame(int difficult)
    {
        GameManager.instance.difficult = difficult;
        sceneManagerCustom.StartGame();
    }

    public void LoadCredits()
    {
        logo.GetComponent<SpriteRenderer>().enabled = false;
        menu.GetComponent<Canvas>().enabled = false;
        credits.GetComponent<Canvas>().enabled = true;
        difficultScreen.GetComponent<Canvas>().enabled = false;
    }

    public void LoadStartMenu()
    {
        logo.GetComponent<SpriteRenderer>().enabled = true;
        menu.GetComponent<Canvas>().enabled = true;
        credits.GetComponent<Canvas>().enabled = false;
        difficultScreen.GetComponent<Canvas>().enabled = false;
    }

    public void LoadDifficultScreen()
    {
        logo.GetComponent<SpriteRenderer>().enabled = true;
        menu.GetComponent<Canvas>().enabled = false;
        credits.GetComponent<Canvas>().enabled = false;
        difficultScreen.GetComponent<Canvas>().enabled = true;
    }

    public void Exit() {
        Application.Quit();
    }
}