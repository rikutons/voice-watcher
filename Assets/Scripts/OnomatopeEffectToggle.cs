using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnomatopeEffectToggle : MonoBehaviour
{
    public static bool enable = true;
    [SerializeField]
    Image me;
    public static int click = 0;

    //getter
    public static int getclick()
    {
        return click;
    }

    public void fai()
    {
        enable = !enable;

        if(enable)
        {
            me.color = Color.white;
            click = 1;
        }
        else if(!enable)
        {
            me.color = Color.gray;
            click = 0;
        }
    }

}
