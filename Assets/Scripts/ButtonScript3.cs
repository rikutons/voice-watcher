using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ButtonScript3 : MonoBehaviour
{
    public static bool Enable2 = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void fai()
    {
        if (Enable2 == true)
            Enable2 = false;
        else if (Enable2 == false)
            Enable2 = true;
        print(Enable2);
    }
}
