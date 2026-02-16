using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class CursorScript : MonoBehaviour
{
    public Texture2D[] Textures;
    public Vector2 HotSpot = Vector2.zero;
    public CursorMode CursorMode = CursorMode.Auto;

    private readonly float delay = 0.1f;
    private Coroutine coroutine;

    private InputAction clickAction;

    private void Start()
    {
        SetDefaultCursor();
        clickAction = InputSystem.actions.FindAction("UI/Click");
    }

    private void Update()
    {
        if (clickAction.WasPressedThisFrame())
        {
            if (coroutine != null) StopAllCoroutines();
            coroutine = StartCoroutine(PerformClickAnimation());
        }
    }

    private IEnumerator PerformClickAnimation()
    {
        for (int i = 0; i < Textures.Length; i++)
        {
            Cursor.SetCursor(Textures[i], HotSpot, CursorMode);
            yield return new WaitForSeconds(delay);
        }

        SetDefaultCursor();
    }

    private void SetDefaultCursor()
    {
        Cursor.SetCursor(Textures[0], HotSpot, CursorMode);
    }
}
