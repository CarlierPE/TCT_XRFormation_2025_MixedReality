using UnityEngine;
using System.Collections.Generic;
public class DrawTrajetMono : MonoBehaviour
{

    public TrajetsMono _source;

    private void OnDrawGizmos()
    {
        if (_source == null) return;
        var trajectPoints =  _source._trajet.GetPoints();
        for (int i = 0; i < trajectPoints.Count - 1; i++)
        {
            var origin = trajectPoints[i].position;
            var destination = trajectPoints[i + 1].position;
            Debug.DrawLine(origin, destination);
        }
    }
}
