using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    /// <summary>生命值圖片清單 </summary>
    [SerializeField] List<Image> LifeImage = new List<Image>();
    public int LifeCount = 3;
    /// <summary>數量文字 </summary>
    [SerializeField] Text t_Count;
    [HideInInspector]public int Count;
    #region 單例
    private void Awake()
    {
        instance = this;
    }
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.DeleteKey("LifeCount");
        if (PlayerPrefs.GetInt("LifeCount") == 0)
        {
           PlayerPrefs.SetInt("LifeCount", 3);
        }
        else
        {
            LifeCount = PlayerPrefs.GetInt("LifeCount");
        }
        for (int i = 0; i < LifeCount; i++)
        {
            LifeImage[i].enabled = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
       
    }
    private void LateUpdate()
    {
        t_Count.text = Count.ToString();
    }
}
