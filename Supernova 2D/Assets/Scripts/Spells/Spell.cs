using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public interface Spell
{
    [CanBeNull] GameObject gameObject { get; set; }
    void Cast();
}
