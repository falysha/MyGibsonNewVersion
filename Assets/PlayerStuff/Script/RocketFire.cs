using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class RocketFire : MonoBehaviour
{
    private bool Shot = false;

    private FireState _fireState = FireState.Up;
    private Light2D[] Fire;

    // Start is called before the first frame update
    void Awake()
    {
        Fire = gameObject.GetComponentsInChildren<Light2D>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void FixedUpdate()
    {
        if (Shot)
        {
            if (_fireState==FireState.Up)
            {
                Fire[0].intensity = Fire[0].intensity + 0.1f;
            }
            else if(_fireState==FireState.Hold)
            {
                Fire[1].intensity = Fire[0].intensity;
            }
            else
            {
                if (Fire[0].intensity>0)
                {
                    Fire[0].intensity=Fire[0].intensity-0.3f;
                    Fire[1].intensity = Fire[0].intensity;
                }
            }
        }
        else
        {
            Fire[1].intensity = Fire[0].intensity = 0;
        }
    }

    public void rocketFire()
    {
        StartCoroutine(Up());
    }

    IEnumerator Up()
    {
        Shot = true;
        _fireState = FireState.Up;
        yield return new WaitForSeconds(0.71428f * 0.666f);
        StartCoroutine(Hold());
    }

    IEnumerator Hold()
    {
        _fireState = FireState.Hold;
        yield return new WaitForSeconds(0.71428f * 0.166f);
        StartCoroutine(Down());
    }

    IEnumerator Down()
    {
        _fireState = FireState.Down;
        yield return new WaitForSeconds(0.71428f * 0.166f);
        Shot = false;
    }
    public enum FireState
    {
        Up,
        Hold,
        Down
    }
}
