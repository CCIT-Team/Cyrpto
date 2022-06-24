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
    public float SongDelayInSec;
    public int InputDelayInMilSec;
    public double[] marginOfError;
    public string FileLocation;
    public float NoteTime;
    public float NoteSpawnZ;
    public float NoteTapZ;
    public Text ComboText;
    public Text PanjungText;
    public GameObject Player;

    public float NoteDespawnZ
    {
        get
        {
            return NoteTapZ - (NoteSpawnZ - NoteTapZ);
        }
    }
    public static MidiFile midiFile;

    void Start()
    {
        Instance = this;
        ReadFromFile();
    }

    
    void Update()
    {
       NoteTapZ = Player.transform.position.z;
       //NoteSpawnZ = Lane.Lanetransform.position.z;
      // NoteTime =  NoteSpawnZ - NoteTapZ;
        
        ComboText.text = "" + ScoreManager.Instance.comboScore;
        PanjungText.text = "" + ScoreManager.Instance.scorestring;
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
    }
    public static double GetAudioSourceTime()
    {
        return (double)Instance.audioSource.timeSamples / Instance.audioSource.clip.frequency;
    }
}
