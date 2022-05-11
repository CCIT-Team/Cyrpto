using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    GameObject Player;
    double timeInstantiated;
    public float assignedTime;
    Vector3 notetransform;
    [HideInInspector]
    public double timeSinceInstantiated;
    [HideInInspector]
    public static float t;

    void Start()
    {
        notetransform = new Vector3(0,0,gameObject.transform.position.z);
        Player = MusicManager.Instance.Player;
        timeInstantiated = MusicManager.GetAudioSourceTime();
    }

   
    void Update()
    {
        timeSinceInstantiated = MusicManager.GetAudioSourceTime() - timeInstantiated;
        t = (float)(timeSinceInstantiated / (MusicManager.Instance.NoteTime * 2));
        //Debug.Log(notetransform.z-= Player.transform.position.z);

        if (t > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            transform.localPosition = Vector3.Lerp(Vector3.forward * MusicManager.Instance.NoteSpawnY, Vector3.forward * MusicManager.Instance.NoteDespawnY * Player.transform.position.z, t);
        }
    }
}
