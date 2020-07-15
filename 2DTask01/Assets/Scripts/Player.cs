using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{/// <summary>剛體 </summary>
    [SerializeField] Rigidbody2D P_rig;
    /// <summary>動畫控制器 </summary>
    [SerializeField] Animator ani;
    /// <summary>移動速度 </summary>
    [SerializeField, Range(0f, 100f)] float MoveSpeed = 1f;
    /// <summary>跳躍力道 </summary>
    [SerializeField, Range(0f, 100f)] float JumpPower=1f;
    /// <summary>地板偵測位置 </summary>
    [SerializeField] GameObject GroundCheck;
    [SerializeField] GroundCheck groundCheck;
    private void Start()
    {
        
    }
    private void Update()
    {   //獲取慣性
        ani.SetFloat("velocity", P_rig.velocity.y);
        ani.SetBool("isGround", groundCheck.isGround);
        //跳躍
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (groundCheck.isGround)
            {
                P_rig.AddForce(Vector2.up * JumpPower, ForceMode2D.Impulse); 
            }  
        } 
        //死亡
        if (this.transform.position.y<=-6.5f)
        {
            Dead();
        } 
    }
    private void FixedUpdate()
    {
        //移動
        if (groundCheck.isGround)
        {
            P_rig.AddForce(Vector2.right * MoveSpeed*Time.deltaTime, ForceMode2D.Impulse);
        }
    }
    #region 死亡
    /// <summary>死亡 </summary>
    void Dead()
    {
        ani.SetBool("DEAD", true);
        GameManager.instance.LifeCount--;
    }
    #endregion
   
}

