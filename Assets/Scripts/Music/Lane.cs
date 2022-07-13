using Melanchall.DryWetMidi.Interaction;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lane : MonoBehaviour
{
    public Melanchall.DryWetMidi.MusicTheory.NoteName noteRestriction;
    public GameObject noteprefab;
    GameObject note;
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
        if (MusicManager.Instance.Player != null)
        {
            gameObject.transform.LookAt(Player.transform.position);
        }
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
        //Debug.Log(SwordAttackred.isredcut);
        //Debug.Log(SwordAttackblue.isbluecut);
        //  Debug.Log(isgunhit);

        if (SpawnIndex < timeStamps.Count)
        {
            if (MusicManager.GetAudioSourceTime() >= timeStamps[SpawnIndex] - MusicManager.Instance.NoteTime)
            {
                note = Instantiate(noteprefab, gameObject.transform);
                notes.Add(note.GetComponent<Note>());
                note.GetComponent<Note>().assignedTime = (float)timeStamps[SpawnIndex];
                SpawnIndex++;
            }
        }
        double etp = Vector3.Distance(Player.transform.position, note.transform.position);//enemy to player
                                                                                          // Debug.Log("Enemy to Player Distance = " + etp + "This Lane = " + gameObject.name);
        if (InputIndex < timeStamps.Count)
        {
            double timeStamp = timeStamps[InputIndex];
            double[] marginOfError = MusicManager.Instance.marginOfError;
            double[] farmarginOfError = MusicManager.Instance.farmarginOfError;
            double audioTime = MusicManager.GetAudioSourceTime() - (MusicManager.Instance.InputDelayInMilSec / 1000.0);
            //if (note.CompareTag("RedEnemy") || note.CompareTag("BlueEnemy"))
            // {
            if (SwordAttackred.isredcut == true || SwordAttackblue.isbluecut == true)
            {
                if (0 < etp && etp < marginOfError[0])
                {
                    ScoreManager.Instance.Perpect();
                    Debug.Log("Hit on" + InputIndex + "Perpect");
                    InputIndex++;
                    Destroy(notes[InputIndex].gameObject);
                    SwordAttackred.isredcut = false;
                    SwordAttackblue.isbluecut = false;
                    HItBox.inHit = false;
                    MechMove.pigock = false;
                }
                else if (marginOfError[0] < etp && etp < marginOfError[1])
                {
                    ScoreManager.Instance.Great();
                    Debug.Log("Hit on" + InputIndex + "Great");
                    InputIndex++;
                    Destroy(notes[InputIndex].gameObject);
                    SwordAttackred.isredcut = false;
                    SwordAttackblue.isbluecut = false;
                    HItBox.inHit = false;
                    MechMove.pigock = false;
                }
                else if (marginOfError[1] < etp && etp < marginOfError[2])
                {
                    ScoreManager.Instance.Good();
                    Debug.Log("Hit on" + InputIndex + "Good");
                    InputIndex++;
                    Destroy(notes[InputIndex].gameObject);
                    SwordAttackred.isredcut = false;
                    SwordAttackblue.isbluecut = false;
                    HItBox.inHit = false;
                    MechMove.pigock = false;
                }

                if (marginOfError[2] < etp || Player.transform.position == note.transform.position)
                {
                    ScoreManager.Instance.Miss();
                    Debug.Log("Missed on" + InputIndex + "note");
                    InputIndex++;
                    SwordAttackred.isredcut = false;
                    SwordAttackblue.isbluecut = false;
                    HItBox.inHit = false;
                    MechMove.pigock = false;
                }
                //}
                //}
                //else
                //{
                if (Lim_ViveInputLeftHandManager.isgunhit == true)
                {
                    if (0 < etp && etp < farmarginOfError[0])
                    {
                        ScoreManager.Instance.Perpect();
                        Debug.Log("Hit on" + InputIndex + "Perpect");
                        InputIndex++; ;
                        Destroy(notes[InputIndex].gameObject);
                        Lim_ViveInputLeftHandManager.isgunhit = false;
                    }
                    else if (farmarginOfError[0] < etp && etp < farmarginOfError[1])
                    {
                        ScoreManager.Instance.Great();
                        Debug.Log("Hit on" + InputIndex + "Great");
                        InputIndex++;
                        Destroy(notes[InputIndex].gameObject);
                        Lim_ViveInputLeftHandManager.isgunhit = false;
                    }
                    else if (farmarginOfError[1] < etp && etp < farmarginOfError[2])
                    {
                        ScoreManager.Instance.Good();
                        Debug.Log("Hit on" + InputIndex + "Good");
                        InputIndex++;
                        Destroy(notes[InputIndex].gameObject);
                        Lim_ViveInputLeftHandManager.isgunhit = false;
                    }

                    if (farmarginOfError[2] < etp || Player.transform.position == note.transform.position)
                    {
                        ScoreManager.Instance.Miss();
                        Debug.Log("Missed on" + InputIndex + "note");
                        InputIndex++;
                        Lim_ViveInputLeftHandManager.isgunhit = false;
                    }
                }
                //}
                //}
            }
        }
    }
}
