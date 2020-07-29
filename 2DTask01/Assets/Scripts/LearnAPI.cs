using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LearnAPI : MonoBehaviour
{
    //認識API靜態(static) 關鍵字成員
    //Random.value 隨機零到1的值
    public void Start()
    {//取得靜態屬性
        print(Random.value);
        print(Mathf.PI);
    }
    private void Update()
    {
        print("遊戲時間" + Time.time);
    }
}
