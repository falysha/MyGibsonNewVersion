using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class OpenTrigger : MonoBehaviour
{
    [Header("īˮ�ļ�")]
    [SerializeField] public TextAsset inkJson;//json�ļ�

    public int dialogueobj = 0;//�Ի�����

    private void OnTriggerEnter2D(Collider2D collider)
    {
        DialogManager.instance.diagoueobj = dialogueobj;
        DialogManager.GetInstance().EnterDialogueMode(inkJson);
        Destroy(gameObject);
    }
}
