using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridObserver : MonoBehaviour
{
    private GameObject prevHover;
    private RaycastHit hit;
    private Ray ray;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        /* Detect when mouse hovers over space */
        if (Physics.Raycast(ray, out hit, 100))
        {
            Debug.Log(hit.transform.gameObject.name);
            if(hit.transform.gameObject.tag.Equals("GridSpace") && prevHover != hit.transform.gameObject)
            {
                prevHover = hit.transform.gameObject;
                prevHover.GetComponent<GridSpace>().ToggleHighlight();
            }
            else if(prevHover != null && prevHover != hit.transform.gameObject)
            {
                prevHover.GetComponent<GridSpace>().ToggleHighlight();
                prevHover = null;
            }
        }
        else if (prevHover != null)
        {
            prevHover.GetComponent<GridSpace>().ToggleHighlight();
            prevHover = null;
        }
    }
}
