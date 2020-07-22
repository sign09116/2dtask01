
using UnityEngine;

public class Spikes : MonoBehaviour
{/// <summary>掉落物件的RIG </summary>
    [SerializeField] Rigidbody2D[] d_obj_rig;

    private void OnTriggerEnter2D(Collider2D hit)
    {
        if (hit.CompareTag("Player"))
        {
            for (int i = 0; i < d_obj_rig.Length; i++)
            {
                d_obj_rig[i].gravityScale = 1;
            }  
        }
    }
}
