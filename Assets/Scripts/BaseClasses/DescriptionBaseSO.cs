using UnityEditor;
using UnityEngine;

/// <summary>
///  基本的SO
/// </summary>
public class DescriptionBaseSO : ScriptableObject
{
    [SerializeField, HideInInspector] private string _guid;
    public string Guid => _guid;

#if UNITY_EDITOR
    void OnValidate()
    {
        var path = AssetDatabase.GetAssetPath(this);
        _guid = AssetDatabase.AssetPathToGUID(path);
    }
#endif

    [TextArea] public string description;
}
