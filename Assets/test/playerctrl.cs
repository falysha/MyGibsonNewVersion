using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerctrl : MonoBehaviour
{
    public float m_speed = 5f;
    private Rigidbody2D m_body;
    private float m_input_h;
    // Start is called before the first frame update
    void Start()
    {
        m_body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (DialogManager.GetInstance().DialogueIsPlaying)
        {
            return;
        }
        m_input_h = Input.GetAxisRaw("Horizontal");
        Move(m_input_h);
    }

    private void Move(float h)
    {
        Vector2 v = m_body.velocity;
        v.x = h * m_speed;
        m_body.velocity = v;
    }

    private void FixedUpdate()
    {

    }
}
