using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inputlogtext_newScript : MonoBehaviour
{
    GameObject logtextobj;
    Text logtext;

    // Start is called before the first frame update
    void Start()
    {

    }

    void OnEnable()
    {
        logtextobj = this.gameObject;
        logtext = logtextobj.GetComponent<Text>();
        //�n�߂ă��O���J�����Ƃ����������Ȃ�����C������K�v����
        foreach (string log in GameManager.instance.logtext)
        {
            logtext.text += log;
        }
    }
    // Update is called once per frame
    void Update()
    { 

    }
}
