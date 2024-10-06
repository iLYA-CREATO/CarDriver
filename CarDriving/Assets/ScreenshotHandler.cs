using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenshotHandler : MonoBehaviour
{
    private void Update()
    {
        // ���������, ������ �� ������� "S"
        if (Input.GetKeyDown(KeyCode.T))
        {
            StartCoroutine(CaptureScreenshot());
        }
    }

    private System.Collections.IEnumerator CaptureScreenshot()
    {
        // ���������� ����� �������� �����
        yield return new WaitForEndOfFrame();

        // ���������� ��� ��� ����� ���������
        string timestamp = System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss");
        string filePath = $"Screenshots/screenshot_{timestamp}.png";

        // ������� �������� ���� - Screenshots/ -> �������� ��� ����������� ������� ��� �����
        System.IO.Directory.CreateDirectory("Screenshots");

        // ������� �������� � ��������� ���
        ScreenCapture.CaptureScreenshot(filePath);
        Debug.Log($"�������� ��������: {filePath}");
    }
}
