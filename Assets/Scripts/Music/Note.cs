using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    double timeInstantiated;
    public float assignedTime;
    [HideInInspector]
    public double timeSinceInstantiated;
    [HideInInspector]
    public static float t;

    void Start()
    {
        timeInstantiated = MusicManager.GetAudioSourceTime();
    }

   
    void Update()
    {
        timeSinceInstantiated = MusicManager.GetAudioSourceTime() - timeInstantiated;
        t = (float)(timeSinceInstantiated / (MusicManager.Instance.NoteTime * 2));

        if (t > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            if(Lim_GameManager.instance.pause.activeSelf == true)
            {
                Time.timeScale = 0;
                t = 0;
                transform.localPosition = Vector3.Lerp(Vector3.back * MusicManager.Instance.NoteSpawnZ, Vector3.back * MusicManager.Instance.NoteDespawnZ,Time.deltaTime + t);
            }
            else
            {
                Time.timeScale = 1;
                t = (float)(timeSinceInstantiated / (MusicManager.Instance.NoteTime * 2));
                transform.localPosition = Vector3.Lerp(Vector3.back * MusicManager.Instance.NoteSpawnZ, Vector3.back * MusicManager.Instance.NoteDespawnZ, t);
            }         
            //transform.position = Vector3.Lerp(Vector3.forward * MusicManager.Instance.NoteSpawnZ, Vector3.forward * MusicManager.Instance.NoteDespawnZ, t);           
        }
    }
}
