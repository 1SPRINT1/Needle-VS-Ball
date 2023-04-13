using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1 : MonoBehaviour
{
    public GameObject Panel;
    private PlayerMove PM;


    private void Start()
    {
        
    }
    private void Update()
    {
        if (PM.Score >= 5)
        {
            Panel.SetActive(true);
        }
    }

}
