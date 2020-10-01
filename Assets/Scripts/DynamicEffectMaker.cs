using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicEffectMaker : MonoBehaviour
{
    [SerializeField]
    GameObject pikapikaPerticle;
    [SerializeField]
    GameObject huwahuwaPerticle;
    [SerializeField]
    GameObject kakukakuPerticle;
    public void OnChangeText(string text){
        if(text.Contains("ピカピカ")){
            Instantiate(pikapikaPerticle);
        }
        if(text.Contains("ふわふわ")){
            Instantiate(huwahuwaPerticle);
        }
        if(text.Contains("かくかく")){
            Instantiate(kakukakuPerticle);
        }
    }
}
