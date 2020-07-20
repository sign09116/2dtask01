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
    [SerializeField] Collider2D collider2;
    private void Start()
    {
        collider2.enabled = true;
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
            P_rig.velocity = new Vector2(MoveSpeed, P_rig.velocity.y);
        }
    }
    #region 死亡
    /// <summary>死亡 </summary>
    void Dead()
    {
        ani.SetBool("DEAD", true);
        collider2.enabled = false;
        GameManager.instance.LifeCount--;
    }
    #endregion
    private void OnCollisionEnter2D(Collision2D hit)
    {
        if (hit.collider.CompareTag("Spikes"))
        { 
            Dead();
        }
    }
    private void OnTriggerEnter2D(Collider2D eat)
    {
        if (eat.CompareTag("Cherry"))
        {
            GameManager.instance.Count++;
            Destroy(eat.gameObject);
        }
    }
}

