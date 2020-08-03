using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateLM : MonoBehaviour
{
    [SerializeField]GameObject lMObj;
    private void Awake()
    {
        if (GameObject.FindGameObjectsWithTag("LevelM").Length > 1)
            Destroy(this.gameObject);
        else
            DontDestroyOnLoad(this.gameObject);
    }
    GameObject lm;
    private void Update()
    {
        GameObject lm = GameObject.Find("Levelmanager");
        if (lm==null)
        {
            Instantiate(lMObj, this.transform.position, Quaternion.identity);      
        }
    }
}
