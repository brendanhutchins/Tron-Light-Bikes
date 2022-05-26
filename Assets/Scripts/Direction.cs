using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CurrentDirection { Right, Left, Up, Down };

public interface Direction
{
    public CurrentDirection CurrentDirection { get; }
}
