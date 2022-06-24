using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class FadeFun : MonoBehaviour
{
    private float _fadeDuration = 2f;
    // Start is called before the first frame update
    void Start()
    {
        FadeinBlack();
        Invoke("FadeoutBlack", _fadeDuration);
    }

    private void FadeinBlack()
    {
        //set start color
        SteamVR_Fade.View(Color.clear, 0f);
        //set and start fade to
        SteamVR_Fade.View(Color.black, _fadeDuration);
    }
    private void FadeoutBlack()
    {
        //set start color
        SteamVR_Fade.View(Color.black, 0f);
        //set and start fade to
        SteamVR_Fade.View(Color.clear, _fadeDuration);
    }
}
