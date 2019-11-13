using UnityEngine;

// path of editor menu from we can create the instance of this scriptable objects
[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/MyScriptableObject", order = 1)]
public class MyScriptable : ScriptableObject
{
    public string Name;
    public float Value;
}