using System.Collections.Generic;

using UnityEngine;

[System.Serializable]   
public class Trajets 
{
  [SerializeField]  private string _nomTrajet;
  [SerializeField]  private List<Transform> _trajets = new List<Transform>();

    public List<Transform> GetPoints() {
        return _trajets;
    }

}
