using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class WebCamera : MonoBehaviour
{
    bool HasCamera { get; set; }
    string CameraName { get; set; }
    WebCamTexture WebTexture { get; set; }
    Material WebMat { get; set; }

    public Image Target;

    IEnumerator Start()
    {
        HasCamera = false;

        // Auth
        if (Application.platform == RuntimePlatform.OSXWebPlayer
          || Application.platform == RuntimePlatform.WindowsWebPlayer)
        {
            yield return Application.RequestUserAuthorization(UserAuthorization.WebCam);
            if (!Application.HasUserAuthorization(UserAuthorization.WebCam))
            {
                Debug.LogError("RequestUserAuthorization");
                yield break;
            }
        }

        // get camera
        var devices = WebCamTexture.devices;

        if (devices.Length == 0)
        {
            Debug.LogError("No devices found.");
            yield break;
        }

        HasCamera = true;
        CameraName = devices[0].name;

        // set texture
        WebTexture = new WebCamTexture(CameraName);
        WebTexture.Play();

        WebMat = new Material(Shader.Find("Custom/WebCamera"));
    }

    void Update()
    {
        Shader.SetGlobalTexture("_WebTexture", WebTexture);
    }

    void OnRenderImage(RenderTexture sourceTexture, RenderTexture destTexture)
    {
        Graphics.Blit(sourceTexture, destTexture, WebMat);
    }
}
