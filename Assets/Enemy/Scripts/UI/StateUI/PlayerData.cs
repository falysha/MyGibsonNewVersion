using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    // Ѫ��
    [Range(0,100)]
    public float HP;

    // ��ǰѪ��
    [Range(0, 100)]
    public float currentHP;

    // ����
    [Range(0, 100)]
    public float MP;

    // ���ܼ��ܵ�ǰ��ȴʱ��
    [Range(0, 3)]
    public float currentHideCD;

    // �����ٶ�
    public float blueBarRecoverSpeed;

    // ����1ʣ����ȴ
    [Range(0, 3)]
    public float skill1CD;

    // ����2ʣ����ȴ
    [Range(0, 3)]
    public float skill2CD;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }
}
