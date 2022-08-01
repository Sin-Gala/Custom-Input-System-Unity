using System.Collections.Generic;

[System.Serializable]
public class KeySetDef
{
    public KeySetDef(KeySet keySet)
    {
        this.keySet = keySet;

        if (this.keySet == KeySet.CharacterMovement ||
            this.keySet == KeySet.CharacterMovementArrows)
            isMovement = true;
    }

    public KeySet keySet;
    public bool isMovement { get; private set; } = false;

    public List<Keys> keys = new List<Keys>();

    [System.Serializable]
    public enum KeySet
    {
        None = 0,
        CharacterMovement = 1,
        CharacterMovementArrows = 2,
        Interactions = 3,
        Menu = 4
    }
}