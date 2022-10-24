using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class OpenTrigger : MonoBehaviour
{
    [Header("墨水文件")]
    [SerializeField] public TextAsset inkJson;//json文件

    public int dialogueobj = 0;//对话对象

    private void OnTriggerEnter2D(Collider2D collider)
    {
        DialogManager.instance.diagoueobj = dialogueobj;
        DialogManager.GetInstance().EnterDialogueMode(inkJson);
        Destroy(gameObject);
    }
}
