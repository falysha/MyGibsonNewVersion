using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    private bool pause = false;

    private Image _image;
    // Start is called before the first frame update
    void Start()
    {
        _image = gameObject.GetComponent<Image>();
        _image.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pause)
            {
                Time.timeScale = 1;
                _image.enabled = false;
                pause = false;
            }
            else
            {
                Time.timeScale = 0;
                _image.enabled = true;
                pause = true;
            }
        }
    }
}
