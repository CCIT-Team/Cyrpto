using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Compass : MonoBehaviour
{
    public RawImage compassImage;
    public Transform player;
    //public Text compassDirectionText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        compassImage.uvRect = new Rect(player.localEulerAngles.y / 360, 0, 1, 1);

        Vector3 forward = player.transform.forward;

        forward.y = 0;

        float headingAngle = Quaternion.LookRotation(forward).eulerAngles.y;
        headingAngle = 5 * (Mathf.RoundToInt(headingAngle / 5.0f));

        int displayangle;
        displayangle = Mathf.RoundToInt(headingAngle);

        //switch (displayangle)
        //{
        //    case 0:
        //        compassDirectionText.text = "N";
        //        break;
        //    case 360:
        //        compassDirectionText.text = "N";
        //        break;
        //    case 45:
        //        compassDirectionText.text = "NE";
        //        break;
        //    case 90:
        //        compassDirectionText.text = "E";
        //        break;
        //    case 130:
        //        compassDirectionText.text = "SE";
        //        break;
        //    case 180:
        //        compassDirectionText.text = "S";
        //        break;
        //    case 225:
        //        compassDirectionText.text = "SW";
        //        break;
        //    case 270:
        //        compassDirectionText.text = "W";
        //        break;
        //    default:
        //        compassDirectionText.text = headingAngle.ToString();
        //        break;

        //}

    }
}
