using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class ShotGunFire : MonoBehaviour
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
            if (_fireState == FireState.Up)
            {
                Fire[0].intensity = Fire[0].intensity + 0.2333f;
            }
            else
            {
                Fire[1].intensity = 0.1f;
            }
        }
        else
        {
            Fire[0].intensity=Fire[1].intensity = 0;
        }
    }

    public void shotGunFire()
    {
        StartCoroutine(Up());
    }

    IEnumerator Up()
    {
        Fire[0].intensity = 0.8f;
        Shot = true;
        _fireState = FireState.Up;
        yield return new WaitForSeconds(0.06f);
        StartCoroutine(Down());
    }

    IEnumerator Down()
    {
        _fireState = FireState.Hold;
        yield return new WaitForSeconds(0.06f);
        Shot = false;
    }

    public enum FireState
    {
        Up,
        Hold
    }
}
