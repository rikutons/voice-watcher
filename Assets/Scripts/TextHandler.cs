using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextHandler : MonoBehaviour
{
    [SerializeField]
    private string text;
    [SerializeField]
    DynamicEffectMaker dynamicEffectMaker;
    private void Start()
    {
        OnChangeText(text);
    }

    public void OnChangeText(string text)
    {
        dynamicEffectMaker.OnChangeText(text);
    }
}
