using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KJH_Test_Enemy : MonoBehaviour
{
    Note note;
    GameObject Player;
    public Enemy_Type ET;

    void Start()
    {
        note = GetComponent<Note>();
        Player = MusicManager.Instance.Player;
    }

    void Update()
    {
        Switch();
    }

    void Switch()
    {
        switch (ET)
        {
            case Enemy_Type.a:
                 
                break;
            case Enemy_Type.b:
                transform.Translate(new Vector3(Player.transform.position.z * 5 * Time.deltaTime, 0,0 ));
                break;
        }
    }
}

public enum Enemy_Type
{
    a,
    b,
    c,
    d,
};
