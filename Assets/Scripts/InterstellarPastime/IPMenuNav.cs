using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IPMenuNav : MonoBehaviour
{
    private GameObject toHide;
    [SerializeField] private GameObject toShow;

    private void Start()
    {
        toHide = this.gameObject.transform.parent.gameObject;
    }

    public void MoveToScreen()
    {
        toHide.SetActive(false);
        toShow.SetActive(true);
    }
}
