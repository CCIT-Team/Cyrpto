using Melanchall.DryWetMidi.Interaction;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lane : MonoBehaviour
{
    public Melanchall.DryWetMidi.MusicTheory.NoteName noteRestriction;
    public GameObject note;
    public static Transform lanetransform;
    List<Note> notes = new List<Note>();
    public List<double> timeStamps = new List<double>();
    GameObject Player;
    public static string panjung;
    int SpawnIndex = 0;
    int InputIndex = 0;

    void Start()
    {
        Player = MusicManager.Instance.Player;
        gameObject.transform.LookAt(Player.transform.position);
        lanetransform = transform;
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

    void Update()
    {
        if (SpawnIndex < timeStamps.Count)
        {
            if (MusicManager.GetAudioSourceTime() >= timeStamps[SpawnIndex] - MusicManager.Instance.NoteTime)
            {
                note = Instantiate(note, transform);
                notes.Add(note.GetComponent<Note>());
                note.GetComponent<Note>().assignedTime = (float)timeStamps[SpawnIndex];
                SpawnIndex++;
            }
        }
        double etp = Vector3.Distance(Player.transform.position, note.transform.position);//enemy to player
        Debug.Log("Enemy to Player Distance = " + etp + "This Lane = " + gameObject.name);
        if (InputIndex < timeStamps.Count)
        {
            double timeStamp = timeStamps[InputIndex];
            double[] marginOfError = MusicManager.Instance.marginOfError;
            double audioTime = MusicManager.GetAudioSourceTime() - (MusicManager.Instance.InputDelayInMilSec / 1000.0);
            if (HItBox.inHit == true && MechMove.pigock == true)
            {
                if (0 < etp && etp < marginOfError[0])
                {
                    ScoreManager.Instance.Perpect();
                    Debug.Log("Hit on" + InputIndex + "Perpect");
                    InputIndex++;
                    HItBox.inHit = false;
                    MechMove.pigock = false;
                    Destroy(notes[InputIndex].gameObject);
                }
                else if (marginOfError[0] < etp && etp < marginOfError[1])
                {
                    ScoreManager.Instance.Great();
                    Debug.Log("Hit on" + InputIndex + "Great");
                    InputIndex++;
                    HItBox.inHit = false;
                    MechMove.pigock = false;
                    Destroy(notes[InputIndex].gameObject);
                }
                else if (marginOfError[1] < etp && etp < marginOfError[2])
                {
                    ScoreManager.Instance.Good();
                    Debug.Log("Hit on" + InputIndex + "Good");
                    InputIndex++;
                    HItBox.inHit = false;
                    MechMove.pigock = false;
                    Destroy(notes[InputIndex].gameObject);
                }

                if (marginOfError[2] < etp || Player.transform.position == note.transform.position)
                {
                    ScoreManager.Instance.Miss();
                    Debug.Log("Missed on" + InputIndex + "note");
                    InputIndex++;
                    HItBox.inHit = false;
                    MechMove.pigock = false;
                }
                //if (HItBox.inHit == true)
                //{
                //    if (MechMove.pigock == true)
                //    {
                //        if (Math.Abs(audioTime - timeStamp) < marginOfError[0])
                //        {
                //            ScoreManager.Instance.Perpect();
                //            print($"Hit on {InputIndex} Perpect");
                //            InputIndex++;
                //            HItBox.inHit = false;
                //            MechMove.pigock = false;
                //            Destroy(notes[InputIndex].gameObject);
                //        }
                //        else if (Math.Abs(audioTime - timeStamp) < marginOfError[1])
                //        {
                //            ScoreManager.Instance.Great();
                //            print($"Hit on {InputIndex} Great");
                //            InputIndex++;
                //            HItBox.inHit = false;
                //            MechMove.pigock = false;
                //            Destroy(notes[InputIndex].gameObject);
                //        }
                //        else if (Math.Abs(audioTime - timeStamp) < marginOfError[2])
                //        {
                //            ScoreManager.Instance.Good();
                //            print($"Hit on {InputIndex}  Good");
                //            InputIndex++;
                //            HItBox.inHit = false;
                //            MechMove.pigock = false;
                //            Destroy(notes[InputIndex].gameObject);
                //        }
                //        else
                //        {
                //            print($"Hit inaccurate on {InputIndex} note with {Math.Abs(audioTime - timeStamp)} delay");
                //            HItBox.inHit = false;
                //            MechMove.pigock = false;
                //        }
                //    }

                //    if (timeStamp + marginOfError[2] <= audioTime || Player.transform.position == note.transform.position)
                //    {
                //        ScoreManager.Instance.Miss();
                //        print($"Missed on {InputIndex} note");
                //        InputIndex++;
                //        HItBox.inHit = false;
                //        MechMove.pigock = false;
                //    }
            }
        }
    }
}
