using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    GameObject Player;
    double timeInstantiated;
    public float assignedTime;

    void Start()
    {
        Player = GameObject.FindWithTag("Player");
        timeInstantiated = MusicManager.GetAudioSourceTime();
    }

   
    void Update()
    {
        double timeSinceInstantiated = MusicManager.GetAudioSourceTime() - timeInstantiated;
        float t = (float)(timeSinceInstantiated / (MusicManager.Instance.NoteTime * 2));

        if(t > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            transform.LookAt(Player.transform);
            transform.position = Vector3.Lerp(Vector3.forward * MusicManager.Instance.NoteSpawnY, Player.transform.position, t);//Vector3.forward * MusicManager.Instance.NoteDespawnY,t);
        }
    }
}
