using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventController : MonoBehaviour
{
    public GameObject HandArrow;
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
}
