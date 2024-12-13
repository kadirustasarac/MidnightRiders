using System;
using System.Collections;
using UnityEngine;

public class CursorChanger : MonoBehaviour
{
    public Texture2D normalCursor;
    public Texture2D shootCursor;
    public Texture2D normal2Cursor;
    [SerializeField] float cursorTime = 0.5f;
    [SerializeField] private float hitTime = 0.5f;

    private bool isStanding = true;
    private bool isHit = false;

    // Varsayılan imleç boyutu ve hotspot (imleç merkezi noktası)
    public Vector2 hotspot = Vector2.zero;
    public CursorMode cursorMode = CursorMode.Auto;

    // Özel imleci ayarla
    private IEnumerator SetCustomCursor()
    {
        while (isStanding)
        {
            Cursor.SetCursor(normalCursor, hotspot, cursorMode);
            yield return new WaitForSeconds(cursorTime);
            Cursor.SetCursor(normal2Cursor, hotspot, cursorMode);
            yield return new WaitForSeconds(cursorTime);
        }
    }

    // Varsayılan imlece dön
    public void ResetCursor()
    {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }

    public void Shoot()
    {
        if (isHit == false)
        {
            StartCoroutine(ShootCursor());
        }
    }

    IEnumerator ShootCursor()
    {
        isHit = true;
        isStanding = false;
        Cursor.SetCursor(shootCursor, hotspot, cursorMode);
        yield return new WaitForSeconds(hitTime);
        isStanding = true;
        isHit = false;
        StartCoroutine(SetCustomCursor());
    }

    private void Start()
    {
        StartCoroutine(SetCustomCursor());
    }
}
