
using UnityEngine;

public class Car : MonoBehaviour
{
    //資料
    //品牌.CC 重量 顏色 速度 天窗
    /// <summary>品牌 </summary>
    [SerializeField] string brand;
    /// <summary>CC數 </summary>
    [SerializeField] int CC;
    /// <summary>重量 </summary>
    [SerializeField] float weight;
    /// <summary>顏色 </summary>
    [SerializeField] Color color;
    /// <summary>速度 </summary>
    [SerializeField] float speed;
    /// <summary>是否有天窗 </summary>
    [SerializeField] bool window;
}
