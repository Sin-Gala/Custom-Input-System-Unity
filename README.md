# Custom Input System for Unity
This custom input system is easy to configure, save, and update at run-time.

Last Unity version tested: 2021.3.6f1

## How to use
1. Set the KeyNames you wish to be using in the Keys file
2. Set the KeySet you wish to be using in the KeySetDef file
3. Initialize the KeySetDef list in Keybinds like this:

     - The KeySet to use
     
       - The Keys that it is made off (using the KeyNames you set earlier + the Unity KeyCode corresponding)
4. Call the inputs where you want to (ex: Player file)

### Files
- Keys.cs : Used to check inputs. Formed of a KeyName and a Unity KeyCode
- KeySetDef.cs : Used to organize the different input maps of your project. Formed of a KeySet and a list of Keys
- Keybinds.cs : Used to manage all the KeySetDef you set for your project
- Player.cs : Test script for a basic top-down player movement using this input system

### Important functions (in Keybinds)
- SetBaseKeySets() : Used to set the base KeySet you wish to use. Also used in a save system when you reset a save
- UpdadeKey(KeySetDef.KeySet, Keys.KeyNames, KeyCode) : Used to update a current key data. Used for example when rebinding keys at run-time
- IsAKeyPressed(Keys.KeyNames, bool) : Check in all the corresponding KeySetDef if a certain key is pressed/hold (correpond to Unity GetKey())
- IsAKeyReleased(Keys.KeyNames, bool) : Check in all the corresponding KeySetDef if a certain key is released (correpond to Unity GetKeyUp())
- IsAKeyDown(Keys.KeyNames, bool) : Check in all the corresponding KeySetDef if a certain key is pressed (correpond to Unity GetKeyDown())