using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Melanchall.DryWetMidi.Core;
using Melanchall.DryWetMidi.Interaction;
using System.IO;
using UnityEngine.Networking;
using UnityEngine.UI;

public class MusicManager : MonoBehaviour
{
    public static MusicManager Instance;
    public AudioSource audioSource;
    public Lane[] lanes;
    public GameObject[] laness;
    public float SongDelayInSec;
    public int InputDelayInMilSec;
    public double[] marginOfError;
    public double[] farmarginOfError;
    public string FileLocation;
    public float NoteTime;
    public float NoteSpawnZ;
    public float NoteTapZ;
    public GameObject Player;
    public int noteCount;
    public float NoteDespawnZ {
        get {
            //return NoteTapZ - (NoteSpawnZ - NoteTapZ);
            return Player.transform.position.z - 50;
        }
    }
    public static MidiFile midiFile;

    void Awake()
    {
        Instance = this;
        for (int i = 0; i >= 7; i++)
        {
            laness[i].SetActive(true);
        }
    }

    void Start()
    {
        NoteSpawnZ = Lane.lanetransform.position.z;
        ReadFromFile();
    }


    void Update()
    {
        NoteTapZ = Player.transform.position.z;
        resultEND();
    }

    void ReadFromFile()
    {
        midiFile = MidiFile.Read(Application.streamingAssetsPath + "/" + FileLocation);
        GetDataFromMidi();
    }
    void GetDataFromMidi()
    {
        var notes = midiFile.GetNotes();
        var array = new Melanchall.DryWetMidi.Interaction.Note[notes.Count];
        notes.CopyTo(array, 0);

        foreach (var lane in lanes) lane.SetTimeStamps(array);

        Invoke(nameof(StartSong), SongDelayInSec);
    }
    public void StartSong()
    {
        audioSource.Play();
        GetAudioSourceTime();
    }
    public static double GetAudioSourceTime()
    {
        return (double)Instance.audioSource.timeSamples / Instance.audioSource.clip.frequency;
    }

    public void resultEND()
    {
        if (ScoreManager.instance.resultwindow.activeSelf == true && ScoreManager.instance.missCount == 10)
        {
            for (int i = 0; i < 6; i++)
            {
                laness[i].SetActive(false);
            }
        }

    }
    public void Pause_Stop()
    {
        if(Lim_GameManager.instance.pause.activeSelf == true && audioSource.isPlaying == true)
        {
            audioSource.Pause();
        }
        else { audioSource.UnPause(); }
    }
}
