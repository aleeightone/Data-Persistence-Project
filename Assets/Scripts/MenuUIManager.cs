using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif


[DefaultExecutionOrder(1000)]

public class MenuUIManager : MonoBehaviour
{
    public GameObject beginMenu;
    public Text nameInput;
    public Text highScoreDisplay;
    
    // Start is called before the first frame update
    void Start()
    {
        DataManager.Instance.LoadHighScore();
        highScoreDisplay.text = DataManager.Instance.highScorePlayerName + " : " + DataManager.Instance.playerHighScore;

    }

    public void ClickStart()
    {
        beginMenu.SetActive(true);
    }

    public void StartGame()
    {
        DataManager.Instance.currentPlayerName = nameInput.text.ToString();
        
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        DataManager.Instance.SaveHighScore();
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else

        Application.Quit();
#endif
    }

}
