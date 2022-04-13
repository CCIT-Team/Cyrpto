using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    GameObject Player;
    double timeInstantiated;
    public float assignedTime;
    Vector3 notetransform;

    void Start()
    {
        notetransform = new Vector3(0,0,gameObject.transform.position.z);
        Player = GameObject.FindWithTag("Player");
        timeInstantiated = MusicManager.GetAudioSourceTime();
    }

   
    void Update()
    {
        double timeSinceInstantiated = MusicManager.GetAudioSourceTime() - timeInstantiated;
        float t = (float)(timeSinceInstantiated / (MusicManager.Instance.NoteTime * 2));
        Debug.Log(notetransform.z-= Player.transform.position.z);

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
