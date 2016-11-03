using UnityEngine;
using System.Collections;

public class Skill : ScriptableObject {

    string Name { get; set; }
    string Desciptoin { get; set; }

    Skill(string inName, string inDescription)
    {
        Name = inName;
        Desciptoin = inDescription;
    }
}
