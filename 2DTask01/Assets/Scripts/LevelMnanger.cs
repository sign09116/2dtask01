using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelMnanger : MonoBehaviour
{
    public static LevelMnanger instance;
    Button ReTry;
    private void Awake()
    {
        instance = this;
        

    }

    int NextID;
    private void Start()
    {
        SetUI();
    }
  


    /// <summary>按鈕呼叫離開遊戲</summary>
    public void Exit()
    {
        Application.Quit();
    }
    public CanvasGroup confirm_grp = null;
    public CanvasGroup GameOver_grp = null;
    public CanvasGroup Clear_grp = null;
    public void Showconfirm()
    {
        confirm_grp.alpha = 1f;
        confirm_grp.blocksRaycasts = true;
    }
    public void Retry()
    {
        SceneManager.LoadScene("Game");

    }
    /// <summary>重製UI</summary>

    Scene sceneId;
    Scene NextScene;

    /// <summary>設定UI</summary>
    public void SetUI()
    {
        sceneId = SceneManager.GetActiveScene();
        NextID = sceneId.buildIndex + 1;
        confirm_grp = GameObject.Find("confirm").GetComponent<CanvasGroup>();
        if (sceneId.buildIndex != 0)
        {
           
            GameOver_grp = GameObject.Find("GameOver").GetComponent<CanvasGroup>();
            Clear_grp = GameObject.Find("Clear").GetComponent<CanvasGroup>();
            ReTry = GameObject.Find("B_Retry").GetComponent<Button>();
            ReTry.onClick.AddListener(Retry);
        }

    }
    /// <summary>按鈕呼叫換場景</summary>
    public void ChangeScence()
    {

        SceneManager.LoadScene(NextID);
    }

    IEnumerator StartGameOver()
    {
        GameManager.instance.HPDown();
        yield return new WaitForSeconds(1.5f);
        LevelMnanger.instance.GameOver_grp.alpha = 1;
        LevelMnanger.instance.GameOver_grp.blocksRaycasts = true;    
    }
    IEnumerator StartGameClear()
    {
        yield return new WaitForSeconds(1.5f);
        LevelMnanger.instance.Clear_grp.alpha = 1;
        LevelMnanger.instance.Clear_grp.blocksRaycasts = true;

    }
    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }


}
