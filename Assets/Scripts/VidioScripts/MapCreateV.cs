using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCreateV : MonoBehaviour
{
    public GameObject[] map_Part;
    public GameObject backGroundMap;
    int partCount;
    List<GameObject> ActiveMaps = new List<GameObject>();
    GameObject delete;
    int activeCount = 0;
    int ran;
    [Range(0,0.5f)]
    public float moveSpeed = 0;

    // Start is called before the first frame update
    void Start()
    {
        partCount = map_Part.Length;
        Instantiate(backGroundMap).transform.position = new Vector3(0, 0, 400);
    }

    // Update is called once per frame
    void Update()
    {
        

        ran = Random.Range(0, partCount);
        switch (activeCount)
        {
            case 0:
                ActiveMaps.Add(Instantiate(map_Part[ran]));
                ActiveMaps[0].transform.position = this.gameObject.transform.position;
                activeCount++;
                break;
            case 1:
                ActiveMaps.Add(Instantiate(map_Part[ran]));
                ActiveMaps[1].transform.position = ActiveMaps[0].transform.position + new Vector3(0, 0, 125);
                activeCount++;
                break;
            case 2:
                ActiveMaps.Add(Instantiate(map_Part[ran]));
                ActiveMaps[2].transform.position = ActiveMaps[1].transform.position + new Vector3(0, 0,125);
                activeCount++;
                break;
            case 3:
                ActiveMaps.Add(Instantiate(map_Part[ran]));
                ActiveMaps[3].transform.position = ActiveMaps[2].transform.position + new Vector3(0, 0, 125);
                activeCount++;
                break;
            case 4:
                break;
        }

        ActiveMaps[0].transform.Translate(new Vector3(0, 0, -moveSpeed * Time.deltaTime * 60));
        ActiveMaps[1].transform.Translate(new Vector3(0, 0, -moveSpeed * Time.deltaTime * 60));
        ActiveMaps[2].transform.Translate(new Vector3(0, 0, -moveSpeed * Time.deltaTime * 60));
        ActiveMaps[3].transform.Translate(new Vector3(0, 0, -moveSpeed * Time.deltaTime * 60));

        if (ActiveMaps[0].transform.position.z <= -126)
        {
            delete = ActiveMaps[0];
            ActiveMaps.Remove(ActiveMaps[0]);
            Destroy(delete);
            activeCount--;
        }
    }
}
