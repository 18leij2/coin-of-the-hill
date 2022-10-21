using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(LineRenderer))]
public class TrajectoryLine : MonoBehaviour
{
    public LineRenderer line;

    private void Awake()
    {
        line = GetComponent<LineRenderer>();

    }

    public void renderLine(Vector3 startPoint, Vector3 endPoint)
    {
        line.positionCount = 2;
        Vector3[] points = new Vector3[2];
        points[0] = startPoint;
        points[1] = endPoint;

        line.SetPositions(points);
    }

    public void endLine()
    {
        line.positionCount = 0;
    }
}
