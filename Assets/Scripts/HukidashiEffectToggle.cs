using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HukidashiEffectToggle : MonoBehaviour
{
    public static bool enable = true;
    [SerializeField]
    Image me;
    public void fai()
    {
        enable = !enable;
        if(enable)
            me.color = Color.white;
        else if(!enable)
            me.color = Color.gray;
    }
}
