using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class AiUpdater : MonoBehaviour
{
    private void Start()
    {
        InvokeRepeating("ScanMap", 3f, 1f);
    }
    // Update is called once per frame
    void ScanMap()
    {
        AstarPath.active.Scan();
    }
}
