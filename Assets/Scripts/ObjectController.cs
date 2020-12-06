using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class ObjectController : MonoBehaviour
{

    public Material InactiveMaterial;// color of object when not in focus
    public Material GazedAtMaterial;// color of material when in focus
    public string ClickPayload; //Which scene to go
    public VideoPlayer videoPlayer; //Specify videoplayer to object


    private const float _minObjectDistance = 2.5f;
    private const float _maxObjectDistance = 3.5f;
    private const float _minObjectHeight = 0.5f;
    private const float _maxObjectHeight = 3.5f;

    private Renderer _myRenderer;
    private bool busy = false;

    public void Start()
    {
        _myRenderer = GetComponent<Renderer>();
        SetMaterial(false);
    }

    public void OnPointerEnter()
    {
        SetMaterial(true);
    }


    public void OnPointerExit()
    {
        SetMaterial(false);
    }


    public void OnPointerClick()
    {
        if (ClickPayload == "1")
        {
            SceneManager.LoadScene("Video 1", LoadSceneMode.Single);
        }
        else if (ClickPayload == "2")
        {
            SceneManager.LoadScene("Video 2", LoadSceneMode.Single);
        }
        else if (ClickPayload == "Pause")
        {
            if (videoPlayer.isPlaying && !busy)
            {
                busy = true;
                StartCoroutine(PauseVideo());
            }
            else
            {
                busy = true;
                StartCoroutine(PlayVideo());
            }
        }
        else if (ClickPayload == "Main Menu")
        {
            SceneManager.LoadScene("Main Menu", LoadSceneMode.Single);
        }
        else
        {
            SceneManager.LoadScene("Video 1", LoadSceneMode.Single);
        }


    }


    private void SetMaterial(bool gazedAt)
    {
        if (InactiveMaterial != null && GazedAtMaterial != null)
        {
            _myRenderer.material = gazedAt ? GazedAtMaterial : InactiveMaterial;
        }
    }

    IEnumerator PauseVideo()
    {
        videoPlayer.Pause();
        yield return new WaitForSeconds(1);
        busy = false;
    }

    IEnumerator PlayVideo()
    {
        videoPlayer.Play();
        yield return new WaitForSeconds(1);
        busy = false;
    }
}
