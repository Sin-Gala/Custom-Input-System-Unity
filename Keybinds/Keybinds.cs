using System.Collections.Generic;
using UnityEngine;

public static class Keybinds
{
    public static List<KeySetDef> keysDef = new List<KeySetDef>();

    /// <summary>
    /// Only call this when resetting the saved keys
    /// </summary>
    public static void SetBaseKeySets()
    {
        // Set base movement keys depending on the keyboard type (ZQSD or WASD)
        KeySetDef temp = new KeySetDef(KeySetDef.KeySet.CharacterMovement);
        switch (Application.systemLanguage.ToString())
        {
            case Language.Languages.French:
                temp.keys.Add(new Keys(Keys.KeyNames.Up, KeyCode.Z));
                temp.keys.Add(new Keys(Keys.KeyNames.Left, KeyCode.Q));
                break;
            default:
                temp.keys.Add(new Keys(Keys.KeyNames.Up, KeyCode.W));
                temp.keys.Add(new Keys(Keys.KeyNames.Left, KeyCode.A));
                break;
        }

        // Set base key sets
        keysDef = new List<KeySetDef>()
        {
            // Character Movement Key Sets
            new KeySetDef(KeySetDef.KeySet.CharacterMovement)
            {
                keys = new List<Keys>()
                {
                    temp.keys[0],
                    temp.keys[1],
                    new Keys(Keys.KeyNames.Down, KeyCode.S),
                    new Keys(Keys.KeyNames.Right, KeyCode.D)
                }
            },
            new KeySetDef(KeySetDef.KeySet.CharacterMovementArrows)
            {
                keys = new List<Keys>()
                {
                    new Keys(Keys.KeyNames.Up, KeyCode.UpArrow),
                    new Keys(Keys.KeyNames.Left, KeyCode.LeftArrow),
                    new Keys(Keys.KeyNames.Down, KeyCode.DownArrow),
                    new Keys(Keys.KeyNames.Right, KeyCode.RightArrow)
                }
            },
            // Base Interactions Key Sets
            new KeySetDef(KeySetDef.KeySet.Interactions)
            {
                keys = new List<Keys>()
                {
                    new Keys(Keys.KeyNames.Interaction, KeyCode.I)
                }
            },
            // Menu Key Sets
            new KeySetDef(KeySetDef.KeySet.Menu)
            {
                keys = new List<Keys>()
                {
                    new Keys(Keys.KeyNames.Pause, KeyCode.Escape)
                }
            }
        };
    }

    // Used when rebinding the keys at run-time
    public static void UpdadeKey(KeySetDef.KeySet keySet, Keys.KeyNames keyName, KeyCode newKey)
    {
        int keySetIndex = GetKeySetDefIndex(keySet);
        int keyIndex = GetKeyIndex(keySet, keyName);

        keysDef[keySetIndex].keys[keyIndex].key = newKey;
    }

    #region CHECK KEYS
    /// <summary>
    /// Is a key currently being pressed/hold down
    /// </summary>
    public static bool IsAKeyPressed(Keys.KeyNames keyName, bool isMovement)
    {
        foreach (KeySetDef keySetDef in keysDef)
        {
            if (keySetDef.isMovement != isMovement) continue;

            foreach (Keys keys in keySetDef.keys)
            {
                if (keys.keyName != keyName) continue;
                if (!Input.GetKey(keys.key)) continue;

                return true;
            }
        }

        return false;
    }

    /// <summary>
    /// Is a key currently being pressed/hold down in a specific keyset
    /// </summary>
    public static bool IsAKeyPressed(Keys.KeyNames keyName, KeySetDef.KeySet keySet)
    {
        foreach (KeySetDef keySetDef in keysDef)
        {
            if (keySetDef.keySet != keySet) continue;

            foreach (Keys keys in keySetDef.keys)
            {
                if (keys.keyName != keyName) continue;
                if (!Input.GetKey(keys.key)) continue;

                return true;
            }
        }

        return false;
    }

    /// <summary>
    /// Is a key released this frame
    /// </summary>
    public static bool IsAKeyReleased(Keys.KeyNames keyName, bool isMovement)
    {
        foreach (KeySetDef keySetDef in keysDef)
        {
            if (keySetDef.isMovement != isMovement) continue;

            foreach (Keys keys in keySetDef.keys)
            {
                if (keys.keyName != keyName) continue;
                if (!Input.GetKeyUp(keys.key)) continue;

                return true;
            }
        }

        return false;
    }

    /// <summary>
    /// Is a key released this frame in a specific keyset
    /// </summary>
    public static bool IsAKeyReleased(Keys.KeyNames keyName, KeySetDef.KeySet keySet)
    {
        foreach (KeySetDef keySetDef in keysDef)
        {
            if (keySetDef.keySet != keySet) continue;

            foreach (Keys keys in keySetDef.keys)
            {
                if (keys.keyName != keyName) continue;
                if (!Input.GetKeyUp(keys.key)) continue;

                return true;
            }
        }

        return false;
    }

    /// <summary>
    /// Is a key down for the first time this frame (not hold)
    /// </summary>
    public static bool IsAKeyDown(Keys.KeyNames keyName, bool isMovement)
    {
        foreach (KeySetDef keySetDef in keysDef)
        {
            if (keySetDef.isMovement != isMovement) continue;

            foreach (Keys keys in keySetDef.keys)
            {
                if (keys.keyName != keyName) continue;
                if (!Input.GetKeyDown(keys.key)) continue;

                return true;
            }
        }

        return false;
    }

    /// <summary>
    /// Is a key down for the first time this frame (not hold) in a specific keyset
    /// </summary>
    public static bool IsAKeyDown(Keys.KeyNames keyName, KeySetDef.KeySet keySet)
    {
        foreach (KeySetDef keySetDef in keysDef)
        {
            if (keySetDef.keySet != keySet) continue;

            foreach (Keys keys in keySetDef.keys)
            {
                if (keys.keyName != keyName) continue;
                if (!Input.GetKeyDown(keys.key)) continue;

                return true;
            }
        }

        return false;
    }
    #endregion

    #region GET / SET
    public static int GetKeySetDefIndex(KeySetDef.KeySet keySet)
    {
        if (keysDef.Count == 0)
            SetBaseKeySets();

        for (int i = 0; i < keysDef.Count; i++)
        {
            if (keysDef[i].keySet != keySet) continue;

            return i;
        }

        return 0;
    }

    public static int GetKeyIndex(KeySetDef.KeySet keySet, Keys.KeyNames keyName)
    {
        int keySetIndex = GetKeySetDefIndex(keySet);

        for (int i = 0; i < keysDef[keySetIndex].keys.Count; i++)
        {
            if (keysDef[keySetIndex].keys[i].keyName != keyName) continue;

            return i;
        }

        return 0;
    }

    public static KeyCode GetKeyCode(KeySetDef.KeySet keySet, Keys.KeyNames keyName)
    {
        int keySetIndex = GetKeySetDefIndex(keySet);

        foreach (Keys key in keysDef[keySetIndex].keys)
        {
            if (key.keyName != keyName) continue;

            return key.key;
        }

        return KeyCode.None;
    }
    #endregion
}
