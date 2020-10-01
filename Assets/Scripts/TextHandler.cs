using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextHandler : MonoBehaviour
{

    string CheckText = "null";

    [SerializeField]
    private string text;
    [SerializeField]
    DynamicEffectMaker dynamicEffectMaker;
    [SerializeField]
    TextManager textManager;
    private void Start()
    {
        //OnChangeText(text);
    }

    public void OnChangeText(string text)
    {
        dynamicEffectMaker.OnChangeText(text);
        textManager.OnChangeText(text);
    }

    //textが変更されたときOnChangeTextを呼ぶ
    void Update()
    {
        if( CheckText != text )
        {
            OnChangeText(text);
        }
        CheckText = text;
    }
}
