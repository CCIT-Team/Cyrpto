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
    public float NoteSpawnY;
    public float NoteTapY;
    public Text ComboText;
    public Text PanjungText;
    public GameObject Player;

    public float NoteDespawnY
    {
        get
        {
            return NoteTapY - (NoteSpawnY - NoteTapY);
        }
    }
    public static MidiFile midiFile;

    void Start()
    {
        //text.GetComponent<Text>();
        audioSource.Play();
        Instance = this;
        ReadFromFile();
    }

    
    void Update()
    {
        ComboText.text = "" + SwordAttack.Combo;
        PanjungText.text = "" + Lane.panjung;
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
