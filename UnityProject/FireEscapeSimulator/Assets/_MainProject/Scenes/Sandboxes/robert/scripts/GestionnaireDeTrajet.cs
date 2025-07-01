using UnityEngine;
using System.Collections.Generic;
using JetBrains.Annotations;
public class GestionnaireDeTrajet : MonoBehaviour
{
    [SerializeField] private List<Trajets> _trajets = new List<Trajets>();
    [SerializeField] private Color couleurGizmo = Color.green;
    private void OnDrawGizmos()
    {
        //Gizmos.color = couleurGizmo;
        //foreach (Trajets trajets in _trajets)
        //{
        //    if (trajets.points == null || trajets.points.Count < 2) return;
        //    for (int i = 0; i < trajets.points.Count - 1; i++)
        //    {
        //        if (trajets.points[i] != null && trajets.points[i + 1] != null)
        //        {
        //            Gizmos.DrawLine(trajets.points[i].position, trajets.points[i + 1].position);
        //            Gizmos.DrawSphere(trajets.points[i].position, 0.1f);
        //        }
        //        Gizmos.DrawSphere(trajets.points[trajets.points.Count - 1].posoition, 0.1f);
        //    }
           
        //}
     }
    public List<Trajets> trajets => _trajets;
}
