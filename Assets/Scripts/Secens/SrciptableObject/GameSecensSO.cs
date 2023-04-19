using UnityEngine;
using UnityEngine.AddressableAssets;


public class GameSceneSO : DescriptionBaseSO
{
    public ScenesType scenesType;
    public AssetReference sceneReference;
}

public enum ScenesType
{
    StartGame,
    Manager,
    Menu,
    GamePlay,
}
