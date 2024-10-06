using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenshotHandler : MonoBehaviour
{
    private void Update()
    {
        // Проверяем, нажата ли клавиша "S"
        if (Input.GetKeyDown(KeyCode.T))
        {
            StartCoroutine(CaptureScreenshot());
        }
    }

    private System.Collections.IEnumerator CaptureScreenshot()
    {
        // Дожидаемся конца текущего кадра
        yield return new WaitForEndOfFrame();

        // Генерируем имя для файла скриншота
        string timestamp = System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss");
        string filePath = $"Screenshots/screenshot_{timestamp}.png";

        // Создаем серийный путь - Screenshots/ -> возможно вам потребуется создать эту папку
        System.IO.Directory.CreateDirectory("Screenshots");

        // Снимаем скриншот и сохраняем его
        ScreenCapture.CaptureScreenshot(filePath);
        Debug.Log($"Скриншот сохранен: {filePath}");
    }
}
