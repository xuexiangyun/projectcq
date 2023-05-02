using Newtonsoft.Json;
using System;
using System.Collections;
using System.IO;
using System.Threading.Tasks;
using UnityEngine;


public static class SaveProfileTool{
    static readonly string profileFolder = Application.persistentDataPath+"Profile";
    public static SaveProfile<T> LoadProfile<T>(string profilekey) where T: GameProfileData
    {
        string _loadpath = $"{profileFolder}/{profilekey}";
        if (!File.Exists(_loadpath)){
        Debug.Log($"{profilekey} is not exists");
        }

        var _jsonContext = File.ReadAllText(_loadpath);
        return JsonConvert.DeserializeObject<SaveProfile<T>>(_jsonContext);
    }

    public static async void LoadProfileAsync<T>(string profilekey, Action<SaveProfile<T>> callback) where T : GameProfileData
    {
        string _loadpath = $"{profileFolder}/{profilekey}";
        if (!File.Exists(_loadpath))
        {
            Debug.Log($"{profilekey} is not exists");
        }

        var _jsonContext = await File.ReadAllTextAsync(_loadpath);
        var _jObj = JsonConvert.DeserializeObject<SaveProfile<T>>(_jsonContext);
        callback.Invoke(_jObj);
    }

    public static void SaveProfile<T>(SaveProfile<T> profile) where T:GameProfileData
    {
        string _loadpath = $"{profileFolder}/{profile.profileKey}";
        var _jsonstr = JsonConvert.SerializeObject(profile, Formatting.Indented,
           new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore});

        if (!Directory.Exists(profileFolder))
            Directory.CreateDirectory(profileFolder);
        if (File.Exists(_loadpath))
            File.Delete(_loadpath);
      
        File.WriteAllText(_loadpath, _jsonstr);
    }

    public static async Task SaveProfileAsync<T>(SaveProfile<T> profile, Action callback) where T : GameProfileData
    {
        
        string _loadpath = $"{profileFolder}/{profile.profileKey}";
        var _jsonstr = JsonConvert.SerializeObject(profile, Formatting.Indented,
           new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });

        if (!Directory.Exists(profileFolder))
            Directory.CreateDirectory(profileFolder);
        if (File.Exists(_loadpath))
            File.Delete(_loadpath);

         await File.WriteAllTextAsync(_loadpath, _jsonstr);
         callback.Invoke();
    }
 }
