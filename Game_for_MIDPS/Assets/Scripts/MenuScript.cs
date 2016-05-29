using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour {

    public GameObject levelChenger;
    public GameObject exitPanel;

    void Update()
    {
        if(levelChenger.activeSelf == true && Input.GetKeyDown(KeyCode.Escape))
        {
            levelChenger.SetActive(false);
        }
        else if (exitPanel.activeSelf ==false && Input.GetKeyDown(KeyCode.Escape))
        {
            exitPanel.SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            exitPanel.SetActive(false);
        }
    }


	public void OnClickStart()
    {
        levelChenger.SetActive(true);
    }

    public void OnClickExit()
    {
        Application.Quit();
    }

    public void levelButtons(int level)
    {
        SceneManager.LoadScene(level);
    }
}
