using Melanchall.DryWetMidi.Interaction;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lane : MonoBehaviour
{
    public Melanchall.DryWetMidi.MusicTheory.NoteName noteRestriction;
    public GameObject NotePrefap;
    List<Note> notes = new List<Note>();
    public List<double> timeStamps = new List<double>();
    GameObject Player;
    public static string panjung;
    int SpawnIndex = 0;
    int InputIndex = 0;

    public bool GameEND;
    void Start()
    {
        GameEND = false;
        Player = MusicManager.Instance.Player;
        gameObject.transform.LookAt(Player.transform.position);
    }

    public void SetTimeStamps(Melanchall.DryWetMidi.Interaction.Note[] array)
    {
        foreach (var note in array)
        {
            if (note.NoteName == noteRestriction)
            {
                var metricTimeSpan = TimeConverter.ConvertTo<MetricTimeSpan>(note.Time, MusicManager.midiFile.GetTempoMap());
                timeStamps.Add((double)metricTimeSpan.Minutes * 60f + metricTimeSpan.Seconds + (double)metricTimeSpan.Milliseconds / 1000f);
            }
        }
    }
    public static GameObject note;

    void Update()
    {
        if (SpawnIndex < timeStamps.Count)
        {
            if (MusicManager.GetAudioSourceTime() >= timeStamps[SpawnIndex] - MusicManager.Instance.NoteTime)
            {
                note = Instantiate(NotePrefap, gameObject.transform);           
                notes.Add(note.GetComponent<Note>());
                note.GetComponent<Note>().assignedTime = (float)timeStamps[SpawnIndex];
                SpawnIndex++;
                GameEND = true;
            }
        }

        if (InputIndex < timeStamps.Count)
        {
            double timeStamp = timeStamps[InputIndex];
            double[] marginOfError = MusicManager.Instance.marginOfError;
            double audioTime = MusicManager.GetAudioSourceTime() - (MusicManager.Instance.InputDelayInMilSec / 1000.0);
            if (HItBox.inHit == true)
            {
                if (MechMove.pigock == true)
                {
                    if (Math.Abs(audioTime - timeStamp) < marginOfError[0])
                    {
                        ScoreManager.Instance.Perpect();
                        print($"Hit on {InputIndex} Perpect");
                        InputIndex++;
                        HItBox.inHit = false;
                        MechMove.pigock = false;
                        Destroy(notes[InputIndex].gameObject);
                    }
                    else if (Math.Abs(audioTime - timeStamp) < marginOfError[1])
                    {
                        ScoreManager.Instance.Great();
                        print($"Hit on {InputIndex} Great");
                        InputIndex++;
                        HItBox.inHit = false;
                        MechMove.pigock = false;
                        Destroy(notes[InputIndex].gameObject);
                    }
                    else if (Math.Abs(audioTime - timeStamp) < marginOfError[2])
                    {
                        ScoreManager.Instance.Good();
                        print($"Hit on {InputIndex}  Good");
                        InputIndex++;
                        HItBox.inHit = false;
                        MechMove.pigock = false;
                        Destroy(notes[InputIndex].gameObject);
                    }
                    else
                    {
                        print($"Hit inaccurate on {InputIndex} note with {Math.Abs(audioTime - timeStamp)} delay");
                        HItBox.inHit = false;
                        MechMove.pigock = false;
                    }
                }

                if (timeStamp + marginOfError[2] <= audioTime || Player.transform.position == note.transform.position)
                {
                    ScoreManager.Instance.Miss();
                    print($"Missed on {InputIndex} note");
                    InputIndex++;
                    HItBox.inHit = false;
                    MechMove.pigock = false;
                }
            }
        }
    }
}
