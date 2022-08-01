using UnityEngine;

[System.Serializable]
public class Keys
{
    public Keys(KeyNames keyName, KeyCode startKey)
    {
        this.keyName = keyName;
        key = startKey;
    }

    public KeyNames keyName;
    public KeyCode key;

    [System.Serializable]
    public enum KeyNames
    {
        None = 0,
        Up = 1,
        Right = 2,
        Down = 3,
        Left = 4,
        Pause = 5,
        Interaction = 6,
    }
}