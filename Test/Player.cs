using UnityEngine;

public class Player : MonoBehaviour
{
    private void Update() => GetMovementInput();

    private void GetMovementInput()
    {
        if (Keybinds.IsAKeyPressed(Keys.KeyNames.Up, true))
            Movement(new Vector2(0, 1));
        if (Keybinds.IsAKeyPressed(Keys.KeyNames.Right, true))
            Movement(new Vector2(1, 0));
        if (Keybinds.IsAKeyPressed(Keys.KeyNames.Down, true))
            Movement(new Vector2(0, -1));
        if (Keybinds.IsAKeyPressed(Keys.KeyNames.Left, true))
            Movement(new Vector2(-1, 0));
    }

    private void Movement(Vector2 dir)
    {
        transform.position =
            Vector2.MoveTowards(
                transform.position,
                new Vector2(
                    transform.position.x + dir.x,
                    transform.position.y + dir.y),
                GetCharacterDatas().speedMovement * Time.deltaTime);
    }
}
