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
    GameObject Player;
    public static string panjung;
    int SpawnIndex = 0;
    int InputIndex = 0;

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
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
        if(SpawnIndex < timeStamps.Count)
        {
           if(MusicManager.GetAudioSourceTime() >= timeStamps[SpawnIndex] - MusicManager.Instance.NoteTime)
            {
                //Instantiate(Enemy, gameObject.transform);
                //Enemy.transform.DetachChildren();
                //note = Instantiate(NotePrefap, gameObject.transform);
                note = Instantiate(NotePrefap, gameObject.transform);
                //Instantiate(Enemy, note.transform);
                //Enemy.transform.DetachChildren();
                //Instantiate(Enemy, note.transform);
                //Enemy.transform.parent = null;
                transform.LookAt(Player.transform);
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
                    Perpect();
                    print($"Hit on {InputIndex} note");
                    Destroy(notes[InputIndex].gameObject);
                    InputIndex++;
                }
                if (Math.Abs(audioTime - timeStamp) < marginOfError[1])
                {
                    Great();
                    print($"Hit on {InputIndex} note");
                    Destroy(notes[InputIndex].gameObject);
                    InputIndex++;
                }
                if (Math.Abs(audioTime - timeStamp) < marginOfError[2])
                {
                    Good();
                    print($"Hit on {InputIndex} note");
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
                Miss();
                print($"Missed on {InputIndex} note");
                InputIndex++;
            }
        }
    }

    private void Perpect()
    {
        panjung = "Perpect!";
    }
    private void Great()
    {
        panjung = "Great!";
    }
    private void Good()
    {
        panjung = "Good!";
    }

    private void Miss()
    {
        ScoreManager.Miss();
    }
}
