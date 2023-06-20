using UnityEngine;
using TMPro;

public class FloatingPopup : MonoBehaviour
{
    public float floatSpeed = 1f;
    public float scaleSpeed = 1f;
    public float displayTime = 3f;

    private Transform mainCamera;
    private float timer;
    private int moneyGained;
    private string moneyGainedString;

    private void Start()
    {
        mainCamera = Camera.main.transform;
        timer = displayTime;

        // Set the initial rotation to face the main camera
        transform.rotation = Quaternion.LookRotation(transform.position - mainCamera.position);
    }

    public void Initialize(int money)
    {
        moneyGained = money;

        // Set the TextMeshPro text to display the moneyGained value
        TextMeshProUGUI textMeshPro = GetComponentInChildren<TextMeshProUGUI>();
        moneyGainedString = moneyGained.ToString();

        textMeshPro.text = $"+ {moneyGainedString} Bones";
        // Start the countdown timer
        timer = displayTime;
    }


    private void Update()
    {
        // Float up
        transform.Translate(Vector3.up * floatSpeed * Time.deltaTime, Space.World);

        // Scale up
        transform.localScale += Vector3.one * scaleSpeed * Time.deltaTime;

        // Countdown and destroy after display time
        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            DestroyCanvas();
        }
    }

    private void DestroyCanvas()
    {
        // Find the Canvas parent object and destroy it
        Canvas canvas = GetComponentInParent<Canvas>();
        if (canvas != null)
        {
            Destroy(canvas.gameObject);
        }
    }
}
