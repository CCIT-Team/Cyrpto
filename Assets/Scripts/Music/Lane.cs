using Melanchall.DryWetMidi.Interaction;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lane : MonoBehaviour
{
    public Melanchall.DryWetMidi.MusicTheory.NoteName noteRestriction;
    public KeyCode input;
    public GameObject NotePrefap;
    List<Note> notes = new List<Note>();
    public List<double> timeStamps = new List<double>();
    public GameObject Enemy;
    GameObject Player;

    int SpawnIndex = 0;
    int InputIndex = 0;

    void Start()
    {
        Player = GameObject.FindWithTag("Player");
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
    
    void Update()
    {
        if(SpawnIndex < timeStamps.Count)
        {
           if(MusicManager.GetAudioSourceTime() >= timeStamps[SpawnIndex] - MusicManager.Instance.NoteTime)
            {
                var note = Instantiate(NotePrefap, gameObject.transform);
                Instantiate(Enemy, note.transform);
                transform.LookAt(Player.transform);
                notes.Add(note.GetComponent<Note>());
                note.GetComponent<Note>().assignedTime = (float)timeStamps[SpawnIndex];  
                SpawnIndex++;
            }
        }

        if(InputIndex < timeStamps.Count)
        {
            double timeStamp = timeStamps[InputIndex];
            double marginOfError = MusicManager.Instance.marginOfError;
            double audioTime = MusicManager.GetAudioSourceTime() - (MusicManager.Instance.InputDelayInMilSec / 1000.0);

            if(Input.GetKeyDown(input))
            {
                if(Math.Abs(audioTime - timeStamp) < marginOfError)
                {
                    Hit();
                    print($"Hit on {InputIndex} note");
                    Destroy(notes[InputIndex].gameObject);
                    InputIndex++;
                }
                else
                {
                    print($"Hit inaccurate on {InputIndex} note with {Math.Abs(audioTime - timeStamp)} delay");
                }
            }
            if (col.)
            {
                if (Math.Abs(audioTime - timeStamp) < marginOfError)
                {
                    Hit();
                    print($"Hit on {InputIndex} note");
                    Destroy(notes[InputIndex].gameObject);
                    InputIndex++;
                }
                else
                {
                    print($"Hit inaccurate on {InputIndex} note with {Math.Abs(audioTime - timeStamp)} delay");
                }
            }
            if (timeStamp + marginOfError <= audioTime)
            {
                Miss();
                print($"Missed on {InputIndex} note");
                InputIndex++;
            }
        }
    }

    private void Hit()
    {
        ScoreManager.Hit();
    }

    private void Miss()
    {
        ScoreManager.Miss();
    }

     void OnCollisionEnter(Collision col)
    {
        
    }
}
