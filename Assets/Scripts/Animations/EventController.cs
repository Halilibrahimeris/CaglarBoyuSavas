using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventController : MonoBehaviour
{
    public GameObject HandArrow;
    public GameObject Stone;
    public void IdleStart()
    {
        HandArrow.SetActive(false);
    }
    public void TakeArrow()
    {
        HandArrow.SetActive(true);
    }
    public void ArrowLeft()
    {
        HandArrow.SetActive(false);
    }

    public void StoneActive()
    {
        Stone.SetActive(true);
    }
    public void StoneDeactive()
    {
        Stone.SetActive(false);
    }
}
