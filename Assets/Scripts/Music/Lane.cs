using Melanchall.DryWetMidi.Interaction;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lane : MonoBehaviour
{
    public static Transform Lanetransform;
    public Melanchall.DryWetMidi.MusicTheory.NoteName noteRestriction;
    public KeyCode input;
    public GameObject NotePrefap;
    List<Note> notes = new List<Note>();
    public List<double> timeStamps = new List<double>();
    GameObject Player;
    public static string panjung;
    int SpawnIndex = 0;
    int InputIndex = 0;

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        Lanetransform = gameObject.transform;
    }

    public void SetTimeStamps(Melanchall.DryWetMidi.Interaction.Note[] array)
    {
        foreach (var note in array)
        {
            if(note.NoteName == noteRestriction)
            {
                var metricTimeSpan =  TimeConverter.ConvertTo<MetricTimeSpan>(note.Time, MusicManager.midiFile.GetTempoMap());
                timeStamps.Add((double)metricTimeSpan.Minutes * 60f + metricTimeSpan.Seconds + (double)metricTimeSpan.Milliseconds / 1000f);
            }
        }
    }
    public static GameObject note;

    void Update()
    {
        if (SpawnIndex < timeStamps.Count)
        {
           if(MusicManager.GetAudioSourceTime() >= timeStamps[SpawnIndex] - MusicManager.Instance.NoteTime)
            {
                note = Instantiate(NotePrefap, gameObject.transform);
                notes.Add(note.GetComponent<Note>());
                note.GetComponent<Note>().assignedTime = (float)timeStamps[SpawnIndex];  
                SpawnIndex++;
            }
        }

        if(InputIndex < timeStamps.Count)
        {
            double timeStamp = timeStamps[InputIndex];
            double[] marginOfError = MusicManager.Instance.marginOfError;
            double audioTime = MusicManager.GetAudioSourceTime() - (MusicManager.Instance.InputDelayInMilSec / 1000.0);

            if(AttackPlayer.a == true)
            {
                if(Math.Abs(audioTime - timeStamp) < marginOfError[0])
                {
                    ScoreManager.Instance.Perpect();
                    ScoreManager.Instance.Hit();
                    print($"Hit on {InputIndex} Perpect");
                    Destroy(notes[InputIndex].gameObject);
                    InputIndex++;
                }
                if (Math.Abs(audioTime - timeStamp) < marginOfError[1])
                {
                    ScoreManager.Instance.Great();
                    ScoreManager.Instance.Hit();
                    print($"Hit on {InputIndex} Great");
                    Destroy(notes[InputIndex].gameObject);
                    InputIndex++;
                }
                if (Math.Abs(audioTime - timeStamp) < marginOfError[2])
                {
                    ScoreManager.Instance.Good();
                    ScoreManager.Instance.Hit();
                    print($"Hit on {InputIndex}  Good");
                    Destroy(notes[InputIndex].gameObject);
                    InputIndex++;
                }
                else
                {
                    print($"Hit inaccurate on {InputIndex} note with {Math.Abs(audioTime - timeStamp)} delay");
                    AttackPlayer.a = false;
                }
            }
            
            if (timeStamp + marginOfError[2] <= audioTime)
            {
                ScoreManager.Instance.Miss();
                print($"Missed on {InputIndex} note");
                InputIndex++;
            }
        }
    }

}
