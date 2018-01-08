using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneManagerCustom : MonoBehaviour
{

    public void ChangeToNextScene()
    {
        int level = GameManager.instance.level++;
        if (level == 0) SceneManager.LoadScene(SCENES.Level_1.ToString());
        if (level == 1) SceneManager.LoadScene(SCENES.Level_2.ToString());
        if (level == 2) ChangeToStartMenuScene();
    }

    public void StartGame()
    {
        GameManager.instance.level = 0;
        SceneManager.LoadScene(SCENES.Level_0.ToString());
    }

    public void ChangeToStartMenuScene()
    {
        SceneManager.LoadScene(SCENES.StartMenu.ToString());
    }
}

public enum SCENES {
    StartMenu,
    Level_0,
    Level_1,
    Level_2
}
