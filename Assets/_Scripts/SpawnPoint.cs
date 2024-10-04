using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class SpawnPoint : MonoBehaviour
{
    public Target OccupingTarget;
    
    public void AssignTarget(Target target)
    {
        if (OccupingTarget == null)
        {
            OccupingTarget = target;
            target.OnDeath += UnassingTarget;
        }
        
    }

    private void UnassingTarget()
    {
        OccupingTarget.OnDeath -= UnassingTarget;
        OccupingTarget = null;
    }

}
