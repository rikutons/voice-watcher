using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript2 : MonoBehaviour
{
    public static bool Enable = true;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    public void fai()
    {
        if (Enable == true)
            Enable = false;
        else if (Enable == false)
            Enable = true;
        print(Enable);
    }

}
