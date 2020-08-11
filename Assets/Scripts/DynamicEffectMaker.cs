using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicEffectMaker : MonoBehaviour
{
    [SerializeField]
    GameObject pikapikaPerticle;
    public void OnChangeText(string text){
        if(text.Contains("ピカピカ")){
            Instantiate(pikapikaPerticle);
        }
        if(text.Contains("ふわふわ")){
            
        }
        if(text.Contains("かくかく")){
            
        }
    }
}
