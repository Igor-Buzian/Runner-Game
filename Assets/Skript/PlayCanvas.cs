using UnityEngine;

public class PlayCanvas : MonoBehaviour
{
    private void Start()
    {
        Cursor.visible = true;
    }
    [Header("Canvas")]
    [SerializeField] private Canvas Scorecanvas;
    [SerializeField] private Canvas Healthcanvas;
    [SerializeField] private Canvas Endcanvas;
    [SerializeField] private Canvas Pausecanvas;
    [Header("Camera")]
    [SerializeField] private Camera MapCamera;
    [Header("Audio")]
    [SerializeField] private AudioSource audio;
    [Header("Player")]
    [SerializeField] private GameObject Player;
    
    public void PlayButton()
    {
        Cursor.visible = false;
        transform.gameObject.SetActive(false);
        MapCamera.gameObject.SetActive(false);
        audio.gameObject.SetActive(true);
        Player.SetActive(true);
        Scorecanvas.gameObject.SetActive(true);
        Pausecanvas.gameObject.SetActive(true);
        Healthcanvas.gameObject.SetActive(true);
        Endcanvas.gameObject.SetActive(true);
    }
    
}
