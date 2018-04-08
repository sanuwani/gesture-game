using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {


    private static AudioManager instance = null; public static AudioManager Instance { get { return instance; } }
    public AudioSource aud1;
    public AudioSource aud2;
    public AudioSource aud3;
    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }

    public void Mute() {
        aud1.mute = !aud1.mute;
        aud2.mute = !aud2.mute;
        aud3.mute = !aud3.mute;
    }
    private void OnLevelWasLoaded(int level)
    {

        if ((level == 0)|| (level == 1)|| (level == 2)|| (level == 6)|| (level == 10)) {
            
            if (!aud1.isPlaying) {
                aud2.Stop();
                aud3.Stop();
                if(aud1.mute==false)
                    aud1.Play();
            }
        }
        if ((level == 7) || (level == 8) || (level == 9))
        {
            
            if (!aud2.isPlaying)
            {
                aud1.Stop();
                aud3.Stop();
                if (aud2.mute == false)
                    aud2.Play();
            }
        }
        if ((level == 3) || (level == 4) || (level == 5))
        {
            
            if (!aud3.isPlaying)
            {
                aud1.Stop();
                aud2.Stop();
                if (aud3.mute == false)
                    aud3.Play();
            }

        }
    }
}
