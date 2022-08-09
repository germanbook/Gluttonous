using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GladiatorStats : MonoBehaviour
{

    /// <summary>
	/// For galadiator moving in Ludus
	/// </summary>

    private bool isClicked;

    public float speed = 5f;

    private Vector2 gladiatorInitialPosition;

    public Transform destinationPosition;

    private static GameObject clickedObject;

    // Start is called before the first frame update
    void Start()
    {
        isClicked = false;
        gladiatorInitialPosition = this.gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (isClicked)
        {
            if (clickedObject.name == this.gameObject.name)
            {
                float step = speed * Time.deltaTime;
                this.transform.position = Vector2.MoveTowards(this.transform.position, destinationPosition.transform.position, step);

            }
            else
            {
                float step = speed * Time.deltaTime;
                this.transform.position = Vector2.MoveTowards(this.transform.position, gladiatorInitialPosition, step);
                this.gameObject.GetComponent<StatsPanel>().statsPanelDisplayed = true;
                this.gameObject.GetComponent<StatsPanel>().OnMouseDown();
            }

            
        }
        //if (Input.GetMouseButtonDown(0))
        //{
        //    CastRay();
        //}

    }

    private void OnMouseDown()
    {
        isClicked = true;
        clickedObject = this.gameObject;
        this.gameObject.GetComponent<StatsPanel>().statsPanelDisplayed = false;

    }

    //void CastRay()
    //{
    //    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    //    RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity);
    //    if (hit.collider != null)
    //    {
    //        Debug.Log(hit.collider.gameObject.name);
    //        clickedObject = hit.collider.gameObject;
    //    }


    //}
}
