using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Interface for usable weapons, bombs etc.
public interface IUsable
{
    void OnUse();

    void OffUse();
}
