using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractableUI : MonoBehaviour
{
    // Start is called before the first frame update

    private BoxCollider boxCollider;
    private RectTransform rectTransform;

    public GameObject chapters;
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();

        boxCollider = gameObject.AddComponent<BoxCollider>();

        boxCollider.size = rectTransform.sizeDelta;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Blue_Sword")
        {
            chapters.SetActive(true);

            //Destroy(gameObject);
        }

    }
}
