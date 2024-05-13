using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Transforms
{
    public string name;
    public Transform Point1, Point2, Point3;
    public Vector3 Xrotation;
}

public class Splines : MonoBehaviour
{
    public float Interpolite;
    public List<Transforms> classTransform;
    
    private CameraMovement movement;
    private void Start()
    {
        movement = GetComponent<CameraMovement>();
    }
    private void Update()
    {
        if (movement.splineGoForward)
        {
            Interpolite = (Interpolite + Time.deltaTime);
            if(Interpolite >= 1)
                Interpolite = 1;
            for (int i = 0; i < classTransform.Count; i++)
            {
                Movement(classTransform[i].Point1, classTransform[i].Point2, classTransform[i].Point3);
            }
            Rotation(0,90);
        }
        if (movement.splineGoBack)
        {
            Interpolite = (Interpolite - Time.deltaTime);
            if(Interpolite <= 0)
                Interpolite = 0;
            for (int i = 0; i < classTransform.Count; i++)
            {
                Movement(classTransform[i].Point1, classTransform[i].Point2, classTransform[i].Point3);
            }
            Rotation(0,90);
        }

    }

    public void Movement(Transform a, Transform b, Transform c)
    {
        c.position = Vector3.Lerp(a.position, b.position, Interpolite);
    }
    public void Rotation(float startRotationx, float endRotationx)
    {
        float xRotation = Mathf.Lerp(0, 90, Interpolite);
        Camera.main.transform.rotation = Quaternion.Euler(xRotation, -90, 0);
    }
}
