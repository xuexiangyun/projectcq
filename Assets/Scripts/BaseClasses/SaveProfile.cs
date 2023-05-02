using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SerializeField]
public sealed class SaveProfile<T> where T: GameProfileData
{
    public string profileKey;
    public T data;
    public SaveProfile() { }
    public SaveProfile(string key,T _data)
    {
        profileKey = key;
        data = _data;
    }
}


public abstract record GameProfileData { }