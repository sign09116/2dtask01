using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    /// <summary>生命值圖片清單 </summary>
    [SerializeField] Image[] LifeImage;
    public int LifeCount ;
    /// <summary>數量文字 </summary>
    [SerializeField] Text t_Count;
    [HideInInspector]public int Count;
   
    string _LifeCount = "_LifeCount";

    #region 單例
    private void Awake()
    {
        instance = this;
    }
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        LifeCount = PlayerPrefs.GetInt("_LifeCount");
        
        Debug.Log(PlayerPrefs.GetInt("_LifeCount"));
       // PlayerPrefs.DeleteKey("LifeCount");
        if (LifeCount < 1)
        {
            LifeCount = 3;
        }
        for (int i = 0; i < LifeCount; i++)
        {
            LifeImage[i].enabled = true;
        }
    }

    // Update is called once per frame
   
    private void LateUpdate()
    {
        t_Count.text = Count.ToString();
    }
  
    public void HPDown()
    {
        LifeCount--;
        PlayerPrefs.SetInt("_LifeCount", LifeCount);
    }
    public void HpUP()
    {
        LifeCount++;
        PlayerPrefs.SetInt("_LifeCount", LifeCount);
    }
}
