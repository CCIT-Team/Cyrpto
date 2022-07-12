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
    public Text clock;
    int audiotime;
    public Text audiotimetext;
    int fre;
    public Text fretext;
    public Text Geta;
    float time = 0;
    public GameObject Player;

    public float NoteDespawnZ {
        get {
            //return NoteTapZ - (NoteSpawnZ - NoteTapZ);
            return Player.transform.position.z - 10;
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
        time += Time.deltaTime;
        ComboText.text = "" + ScoreManager.Instance.comboScore;
        PanjungText.text = "" + ScoreManager.Instance.scorestring;
        clock.text = "" + time;
        audiotime = audioSource.timeSamples;
        fre = audioSource.clip.frequency;
        audiotimetext.text = "" + audiotime;
        fretext.text = "" + fre;
        Geta.text = "" + GetAudioSourceTime();
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
}
