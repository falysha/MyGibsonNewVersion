using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiCanavas : MonoBehaviour
{
    public GameObject uicanavas;
    public GameObject skill;
    public static UiCanavas instance;
    public void Start()
    {
    }
    void Update()
    {
        if(GameManager.instance.State != GameState.IsPlaying)
        {
            uicanavas.SetActive(false);
        }
        else
        {
            uicanavas.SetActive(true);
            if (GameManager.instance.haveskill)
            {
                skill.SetActive(true);
            }
            else
            {
                skill.SetActive(false);
            }
        }
    }
}
