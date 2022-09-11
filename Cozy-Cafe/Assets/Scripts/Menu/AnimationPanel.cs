using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationPanel : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Animate_Panel()
    {
        GetComponent<Animation>().Play("Settings Open");
    }
    public void Close_Panel()
    {
        GetComponent<Animation>().Play("Settings Close");
    }

    public void Animate_Transition()
    {
        GetComponent<Animation>().Play("Black_animation");
    }

    
}
