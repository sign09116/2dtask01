using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public bool isGround = false;
    private void OnTriggerEnter2D(Collider2D hit)
    {
        if (hit.CompareTag("Ground"))
        {
            isGround = true;
        }
    }
    private void OnTriggerExit2D(Collider2D hit)
    {
        if (hit.CompareTag("Ground"))
        {
            isGround = false;
        }
    }
}
