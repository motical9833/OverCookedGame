using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class CaptureScreenToSpriteScript : MonoBehaviour
{
    Camera cameraToCapture;
    int width = 1920;
    int height = 1080;

    public Texture2D capturedTexture;

    public Sprite CaptureScreen()
    {
        cameraToCapture = Camera.main;

        // RenderTexture ����
        RenderTexture renderTexture = new RenderTexture(width, height, 24);
        cameraToCapture.targetTexture = renderTexture;

        // RenderTexture�� Camera�� �����ϰ� ȭ���� ������
        RenderTexture.active = renderTexture;
        cameraToCapture.Render();

        // RenderTexture�� Texture2D�� ��ȯ
        capturedTexture = new Texture2D(width, height, TextureFormat.RGB24, false);
        capturedTexture.ReadPixels(new Rect(0, 0, width, height), 0, 0);
        capturedTexture.Apply();

        Sprite sprite = Texture2DToSprite(capturedTexture);

        cameraToCapture.targetTexture = null;
        RenderTexture.active = null;
        Destroy(renderTexture);

        return sprite;
    }

    public void CleanUpCapturedTexture()
    {
        if (capturedTexture != null)
        {
            Destroy(capturedTexture);
            capturedTexture = null;
            Debug.Log("capturedTexture Destroy");
        }
    }

    public void Start()
    {
        Sprite test = CaptureScreen();
    }

    public void Capture()
    {
        cameraToCapture = Camera.main;

        // 1. RenderTexture ����
        RenderTexture renderTexture = new RenderTexture(width, height, 24);
        cameraToCapture.targetTexture = renderTexture;

        // 2. RenderTexture�� Camera�� �����ϰ� ȭ���� ������
        RenderTexture.active = renderTexture;
        cameraToCapture.Render();

        // 3. RenderTexture�� Texture2D�� ��ȯ
        Texture2D texture = new Texture2D(width, height, TextureFormat.RGB24, false);
        texture.ReadPixels(new Rect(0, 0, width, height), 0, 0);
        texture.Apply();

        // 4. �̹��� ���Ϸ� ����
        byte[] bytes = texture.EncodeToPNG();
        File.WriteAllBytes(Path.Combine(Application.persistentDataPath, "ScreenShot.png"), bytes);

        // Clean up
        cameraToCapture.targetTexture = null;
        RenderTexture.active = null;
        Destroy(renderTexture);
        Destroy(texture);

        Debug.Log("Screenshot saved to: " + Path.Combine(Application.persistentDataPath, "ScreenShot.png"));
    }

    //Texture2D�� Sprite�� ��ȯ
    private Sprite Texture2DToSprite(Texture2D texture)
    {
        Rect rect = new Rect(0, 0, texture.width, texture.height);
        Vector2 pivot = new Vector2(0.5f, 0.5f);
        return Sprite.Create(texture, rect, pivot);
    }
}
