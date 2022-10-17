using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    // 血量
    [Range(0,100)]
    public float HP;

    // 当前血量
    [Range(0, 100)]
    public float currentHP;

    // 蓝量
    [Range(0, 100)]
    public float MP;

    // 闪避技能当前冷却时间
    [Range(0, 3)]
    public float currentHideCD;

    // 回蓝速度
    public float blueBarRecoverSpeed;

    // 技能1剩余冷却
    [Range(0, 3)]
    public float skill1CD;

    // 技能2剩余冷却
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
