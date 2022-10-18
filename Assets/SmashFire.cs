using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class SmashFire : MonoBehaviour
{
    private bool Shot = false;

    private FireState _fireState = FireState.Up;
    private Light2D Fire;

    // Start is called before the first frame update
    void Awake()
    {
        Fire = gameObject.GetComponentInChildren<Light2D>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void FixedUpdate()
    {
        if (Shot)
        {
            if (_fireState == FireState.Up)
            {
                Fire.intensity = Fire.intensity + 0.05f;
            }
            else
            {
                if (Fire.intensity > 0)
                {
                    Fire.intensity = Fire.intensity - 0.3f;
                }
                else
                {
                    Fire.intensity = 0;
                }
            }
        }
        else
        {
            Fire.intensity = 0;
        }
    }

    public void smashFire()
    {
        StartCoroutine(Up());
    }

    IEnumerator Up()
    {
        Fire.intensity = 1f;
        Shot = true;
        _fireState = FireState.Up;
        yield return new WaitForSeconds(0.666f * 0.25f);
        StartCoroutine(Down());
    }

    IEnumerator Down()
    {
        _fireState = FireState.Down;
        yield return new WaitForSeconds(0.666f * 0.25f);
        Shot = false;
    }

    public enum FireState
    {
        Up,
        Down
    }
}