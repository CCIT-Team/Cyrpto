using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractableUI : MonoBehaviour
{
    // Start is called before the first frame update

    private BoxCollider boxCollider;
    private RectTransform rectTransform;

    public GameObject UI;
    public GameObject UI1;
    public GameObject UI2;
    public static readonly WaitForSeconds waitForSeconds = new WaitForSeconds(2.0f);

    public void Start()
    {

        //rectTransform = GetComponent<RectTransform>();

        //boxCollider = gameObject.AddComponent<BoxCollider>();

        //boxCollider.size = rectTransform.sizeDelta;
        //StartCoroutine(active());
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Blue_Sword")
        {
            
            UI.SetActive(true);
            UI1.SetActive(true);
            UI2.SetActive(true);
        }

    }

    IEnumerator active()
    {
        yield return waitForSeconds;
        UI.SetActive(true);
    }
}
