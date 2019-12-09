
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class btnSprint : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{

    PlayerController pc;
    bool isSprint;

    public UnityEvent hold;
    public void OnPointerDown(PointerEventData eventData)
    {
        isSprint = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
       isSprint = false;
    }

    // Start is called before the first frame update
    void Awake()
    {
        pc = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isSprint)
        {
            pc.Sprint();

            if (hold != null) hold.Invoke();
        }
    }
}
