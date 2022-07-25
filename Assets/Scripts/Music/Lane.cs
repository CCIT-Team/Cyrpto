using Melanchall.DryWetMidi.Interaction;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region 존나 만지지마
/*public class Lane : MonoBehaviour
{
    public Melanchall.DryWetMidi.MusicTheory.NoteName noteRestriction;
    public GameObject noteprefab;
    GameObject note;
    public static Transform lanetransform;
    List<Note> notes = new List<Note>();
    public List<double> timeStamps = new List<double>();
    GameObject Player;
    public static string panjung;
    public bool inhit;
    int SpawnIndex = 0;
    int InputIndex = 0;
    bool notedie;
    bool check = false;
    double ETP;
    double[] marginOfError;
    double[] farmarginOfError;

    void Start()
    {
        Player = MusicManager.Instance.Player;
        if (MusicManager.Instance.Player != null)
        {
            gameObject.transform.LookAt(Player.transform.position);
        }
        lanetransform = transform;
        marginOfError = MusicManager.Instance.marginOfError;
        farmarginOfError = MusicManager.Instance.farmarginOfError;
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
        Debug.Log(notedie);
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
        inhit = note.GetComponent<HItBox>().isHit;
        notedie = note.GetComponent<MechMove>().isdie;
        double etp = Vector3.Distance(Player.transform.position, note.transform.position);//enemy to player
        ETP = etp;
        //Debug.Log("Enemy to Player Distance = " + etp + "This Lane = " + gameObject.name);
        // if (InputIndex < timeStamps.Count)
        //  {
        double timeStamp = timeStamps[InputIndex];
        double[] marginOfError = MusicManager.Instance.marginOfError;
        double[] farmarginOfError = MusicManager.Instance.farmarginOfError;
        double audioTime = MusicManager.GetAudioSourceTime() - (MusicManager.Instance.InputDelayInMilSec / 1000.0);
        if (note.CompareTag("RedEnemy") || note.CompareTag("BlueEnemy")) { CloseJudgment(); }
        if (note.CompareTag("farEnemy")) { FarJudgment(); }
        #region 원래 코드
        //if (marginOfError[2] > etp && note.CompareTag("RedEnemy")|| marginOfError[2] > etp && note.CompareTag("BlueEnemy"))
        //{
        //    if (inhit)
        //    {
        //        //Debug.Log("된다");
        //        //Debug.Log(etp + "  " + gameObject.name);
        //        notedie = true;
        //        if (0 < etp && etp < marginOfError[0] && notedie == true)
        //        {
        //            ScoreManager.Instance.Perpect();
        //            notedie = false;
        //            //Debug.Log(notedie + "나 죽었는감? Per" + gameObject.name);
        //            //Debug.Log("Hit on" + InputIndex + "Perpect");
        //            InputIndex++;
        //            //Destroy(notes[InputIndex].gameObject);
        //            notedie = false;
        //            SwordAttackred.isredcut = false;
        //            SwordAttackblue.isbluecut = false;
        //            HItBox.inHit = false;
        //            MechMove.pigock = false;
        //            notedie = false;
        //        }
        //        else if (marginOfError[0] < etp && etp < marginOfError[1] && notedie == true)
        //        {
        //            ScoreManager.Instance.Great();
        //            notedie = false;
        //            //Debug.Log(notedie + "나 죽었는감?" + gameObject.name);
        //            //Debug.Log("Hit on" + InputIndex + "Great");
        //            InputIndex++;
        //            //Destroy(notes[InputIndex].gameObject);
        //            notedie = false;
        //            SwordAttackred.isredcut = false;
        //            SwordAttackblue.isbluecut = false;
        //            HItBox.inHit = false;
        //            MechMove.pigock = false;
        //        }
        //        else if (marginOfError[1] < etp && etp < marginOfError[2] && notedie == true)
        //        {
        //            ScoreManager.Instance.Good();
        //            notedie = false;
        //            //Debug.Log(notedie + "나 죽었는감?" + gameObject.name);
        //            //Debug.Log("Hit on" + InputIndex + "Good");
        //            InputIndex++;
        //            //Destroy(notes[InputIndex].gameObject);
        //            notedie = false;
        //            SwordAttackred.isredcut = false;
        //            SwordAttackblue.isbluecut = false;
        //            HItBox.inHit = false;
        //            MechMove.pigock = false;
        //        }
        //        else if (marginOfError[0] > etp && notedie == true || marginOfError[3] < etp && notedie == true)
        //        {
        //            ScoreManager.Instance.Miss();
        //            notedie = false;
        //            //Debug.Log(notedie + "나 죽었는감?" + gameObject.name);
        //            //Debug.Log("Missed on" + InputIndex + "note");
        //            InputIndex++;
        //            notedie = false;
        //            SwordAttackred.isredcut = false;
        //            SwordAttackblue.isbluecut = false;
        //            HItBox.inHit = false;
        //            MechMove.pigock = false;
        //        }
        //    }
        //    if (etp < marginOfError[0] && notedie == false)
        //    {
        //        ScoreManager.Instance.Miss();
        //        Debug.Log("Missed on" + InputIndex + "note");
        //        InputIndex++;
        //        notedie = false;
        //        SwordAttackred.isredcut = false;
        //        SwordAttackblue.isbluecut = false;
        //        HItBox.inHit = false;
        //        MechMove.pigock = false;
        //    }

        //}
        //if (farmarginOfError[2] > etp && note.CompareTag("farEnemy"))
        //{

        //    if (Lim_ViveInputLeftHandManager.isgunhit == true)
        //    {
        //        notedie = true;
        //        if (0 < etp && etp < farmarginOfError[0] && notedie == true)
        //        {
        //            ScoreManager.Instance.Perpect();
        //            notedie = false;
        //            //Debug.Log("Hit on" + InputIndex + "Perpect");
        //            InputIndex++; ;
        //            //Destroy(notes[InputIndex].gameObject);
        //            notedie = false;
        //            Lim_ViveInputLeftHandManager.isgunhit = false;
        //        }
        //        else if (farmarginOfError[0] < etp && etp < farmarginOfError[1] && notedie == true)
        //        {
        //            ScoreManager.Instance.Great();
        //            notedie = false;
        //            //Debug.Log("Hit on" + InputIndex + "Great");
        //            InputIndex++;
        //            //Destroy(notes[InputIndex].gameObject);
        //            notedie = false;
        //            Lim_ViveInputLeftHandManager.isgunhit = false;
        //        }
        //        else if (farmarginOfError[1] < etp && etp < farmarginOfError[2] && notedie == true)
        //        {
        //            ScoreManager.Instance.Good();
        //            notedie = false;
        //           // Debug.Log("Hit on" + InputIndex + "Good");
        //            InputIndex++;
        //            //Destroy(notes[InputIndex].gameObject);
        //            notedie = false;
        //            Lim_ViveInputLeftHandManager.isgunhit = false;
        //        }

        //        if (farmarginOfError[0] > etp && notedie == true || farmarginOfError[3] < etp && notedie == true)
        //        {
        //            ScoreManager.Instance.Miss();
        //            notedie = false;
        //           // Debug.Log("Missed on" + InputIndex + "note");
        //            InputIndex++;
        //            notedie = false;
        //            Lim_ViveInputLeftHandManager.isgunhit = false;
        //        }
        //    }
        //    else if (etp < farmarginOfError[0] && notedie == false)
        //    {
        //        ScoreManager.Instance.Miss();
        //        notedie = false;
        //       // Debug.Log("Missed on" + InputIndex + "note");
        //        InputIndex++;
        //        notedie = false;
        //        Lim_ViveInputLeftHandManager.isgunhit = false;
        //    }
        //}
        #endregion
        //}
    }
    void CloseJudgment()
    {
        if (marginOfError[2] > ETP & inhit)
        {
            notedie = true;
            if (0 < ETP & ETP < marginOfError[0] & notedie == true)
            {
                check = true;
                if (check == true) { ScoreManager.Instance.Perpect(); check = false; }
                // ScoreManager.Instance.Perpect();
                notedie = false;
                HItBox.inHit = false;
                //Debug.Log("Hit on" + InputIndex + "Perpect");
                InputIndex++;
                HItBox.inHit = false;
                MechMove.pigock = false;
                notedie = false;
            }
            else if (marginOfError[0] < ETP & ETP < marginOfError[1] & notedie == true)
            {
                check = true;
                if (check == true) { ScoreManager.Instance.Great(); check = false; }
                //ScoreManager.Instance.Great();
                notedie = false;
                HItBox.inHit = false;
                //Debug.Log("Hit on" + InputIndex + "Great");
                InputIndex++;
                notedie = false;
                HItBox.inHit = false;
                MechMove.pigock = false;
            }
            else if (marginOfError[1] < ETP & ETP < marginOfError[2] & notedie == true)
            {
                check = true;
                if (check == true) { ScoreManager.Instance.Good(); check = false; }
                //ScoreManager.Instance.Good();
                notedie = false;
                HItBox.inHit = false;
                //Debug.Log("Hit on" + InputIndex + "Good");
                InputIndex++;
                notedie = false;
                HItBox.inHit = false;
                MechMove.pigock = false;
            }
            else if (marginOfError[0] > ETP & notedie == true || marginOfError[4] > ETP & marginOfError[3] < ETP & notedie == true)
            {
                check = true;
                if (check == true) { ScoreManager.Instance.Miss(); check = false; }
                // ScoreManager.Instance.Miss();
                notedie = false;
                HItBox.inHit = false;
                //Debug.Log("Missed on" + InputIndex + "note");
                InputIndex++;
                notedie = false;
                HItBox.inHit = false;
                MechMove.pigock = false;
            }
        }
        if (ETP < marginOfError[0] & notedie == false )
        {
            check = true;
            if (check == true) { ScoreManager.Instance.Miss(); check = false; }
            //ScoreManager.Instance.Miss();
            Debug.Log("Missed on" + InputIndex + "note");
            InputIndex++;
            notedie = false;
            HItBox.inHit = false;
            MechMove.pigock = false;
        }
    }

    void FarJudgment()
    {
        if (farmarginOfError[2] > ETP & Lim_ViveInputLeftHandManager.isgunhit == true)
        {
            notedie = true;
            if (0 < ETP && ETP < farmarginOfError[0] & notedie == true)
            {
                check = true;
                if (check == true) { ScoreManager.Instance.Perpect(); check = false; }
                // ScoreManager.Instance.Perpect();
                notedie = false;
                //Debug.Log("Hit on" + InputIndex + "Perpect");
                InputIndex++; ;
                //Destroy(notes[InputIndex].gameObject);
                notedie = false;
                Lim_ViveInputLeftHandManager.isgunhit = false;
            }
            else if (farmarginOfError[0] < ETP & ETP < farmarginOfError[1] & notedie == true)
            {
                check = true;
                if (check == true) { ScoreManager.Instance.Great(); check = false; }
                //ScoreManager.Instance.Great();
                notedie = false;
                //Debug.Log("Hit on" + InputIndex + "Great");
                InputIndex++;
                //Destroy(notes[InputIndex].gameObject);
                notedie = false;
                Lim_ViveInputLeftHandManager.isgunhit = false;
            }
            else if (farmarginOfError[1] < ETP & ETP < farmarginOfError[2] & notedie == true)
            {
                check = true;
                if (check == true) { ScoreManager.Instance.Good(); check = false; }
                //ScoreManager.Instance.Good();
                notedie = false;
                // Debug.Log("Hit on" + InputIndex + "Good");
                InputIndex++;
                //Destroy(notes[InputIndex].gameObject);
                notedie = false;
                Lim_ViveInputLeftHandManager.isgunhit = false;
            }

            if (farmarginOfError[0] > ETP & notedie == true || farmarginOfError[4] > ETP & farmarginOfError[3] < ETP & notedie == true)
            {
                check = true;
                if (check == true) { ScoreManager.Instance.Miss(); check = false; }
                //ScoreManager.Instance.Miss();
                notedie = false;
                // Debug.Log("Missed on" + InputIndex + "note");
                InputIndex++;
                notedie = false;
                Lim_ViveInputLeftHandManager.isgunhit = false;
            }
        }
        else if (ETP < farmarginOfError[0] && notedie == false)
        {
            check = true;
            if (check == true) { ScoreManager.Instance.Miss(); check = false; }
            //ScoreManager.Instance.Miss();
            notedie = false;
            // Debug.Log("Missed on" + InputIndex + "note");
            InputIndex++;
            notedie = false;
            Lim_ViveInputLeftHandManager.isgunhit = false;
        }
    }
}*/
#endregion 만지지마

#region 존나게 만져
public class Lane : MonoBehaviour
{
    public Melanchall.DryWetMidi.MusicTheory.NoteName noteRestriction;
    public GameObject noteprefab;
    GameObject note;
    public static Transform lanetransform;
    List<Note> notes = new List<Note>();
    public List<double> timeStamps = new List<double>();
    GameObject Player;
    int SpawnIndex = 0;
    int InputIndex = 0;

    double[] marginOfError;
    double[] farmarginOfError;

    void Start()
    {
        Player = MusicManager.Instance.Player;
        if (MusicManager.Instance.Player != null)
        {
            gameObject.transform.LookAt(Player.transform.position);
        }
        lanetransform = transform;
        marginOfError = MusicManager.Instance.marginOfError;
        farmarginOfError = MusicManager.Instance.farmarginOfError;
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
                note = Instantiate(noteprefab, gameObject.transform);
                notes.Add(note.GetComponent<Note>());
                note.GetComponent<Note>().assignedTime = (float)timeStamps[SpawnIndex];
                SpawnIndex++;
            }
        }

        if (InputIndex < timeStamps.Count)
        {
            double timeStamp = timeStamps[InputIndex];
            double[] marginOfError = MusicManager.Instance.marginOfError;
            double[] farmarginOfError = MusicManager.Instance.farmarginOfError;
            double audioTime = MusicManager.GetAudioSourceTime() - (MusicManager.Instance.InputDelayInMilSec / 1000.0);
            if (Lim_GameManager.instance.pause.activeSelf == true)
            {
                audioTime = 0;
            }
            else
            {
                audioTime = MusicManager.GetAudioSourceTime() - (MusicManager.Instance.InputDelayInMilSec / 1000.0);
            }
        }
    }
}
#endregion
