using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class cinemachineCamController : MonoBehaviour,IDragHandler,IPointerDownHandler,IPointerUpHandler
{
    private Image camControlImg;
    Vector2 camInput;
    [SerializeField] CinemachineVirtualCamera camVirtualCamera;
     CinemachinePOV cinemachinePOV;
    string XInputAxis = "Mouse X", YInputAxis = "Mouse Y";
  
    private void Start()
    {
        camControlImg = GetComponent<Image>();
        cinemachinePOV=camVirtualCamera.GetCinemachineComponent<CinemachinePOV>();
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(camControlImg.rectTransform, eventData.position, eventData.pressEventCamera, out camInput))
        {
            Debug.Log(camInput);

            cinemachinePOV.m_HorizontalAxis.m_InputAxisName = XInputAxis;
            cinemachinePOV.m_VerticalAxis.m_InputAxisName = YInputAxis;
           
        
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        OnDrag(eventData);
    }

    public void OnPointerUp(PointerEventData eventData)
    {

        cinemachinePOV.m_HorizontalAxis.m_InputAxisName = null;
        cinemachinePOV.m_VerticalAxis.m_InputAxisName = null;
        cinemachinePOV.m_HorizontalAxis.m_InputAxisValue = 0;
        cinemachinePOV.m_VerticalAxis.m_InputAxisValue = 0;



    }


}
