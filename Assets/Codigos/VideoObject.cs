using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoObject : MonoBehaviour
{
    public VideoClip videoClip;  // Il video MP4 che desideri riprodurre
    public RawImage rawImage;  // Il componente RawImage per visualizzare il video
    public VideoPlayer videoPlayer;  // Componente VideoPlayer

    private void Start()
    {
        videoPlayer.playOnAwake = false;
        videoPlayer.clip = videoClip;
        videoPlayer.isLooping = false;
        videoPlayer.renderMode = VideoRenderMode.APIOnly;
        videoPlayer.targetTexture = new RenderTexture((int)rawImage.rectTransform.rect.width, (int)rawImage.rectTransform.rect.height, 0);
        rawImage.texture = videoPlayer.targetTexture;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            videoPlayer.Play();
            rawImage.enabled = true;
        }
    }
}