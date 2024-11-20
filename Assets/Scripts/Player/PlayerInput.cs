using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public bool IsMoveUpKeyPress => Input.GetKey(KeyCode.Space);
    public bool IsShootKeyPress => Input.GetKeyDown(KeyCode.E);
    public bool IsPauseKeyPress => Input.GetKeyDown(KeyCode.Escape);
}
