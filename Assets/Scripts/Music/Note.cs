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
            transform.localPosition = Vector3.Lerp(Vector3.forward * MusicManager.Instance.NoteSpawnZ, Vector3.forward * MusicManager.Instance.NoteDespawnZ, t);
        }
    }
}
