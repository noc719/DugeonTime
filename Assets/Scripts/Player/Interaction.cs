using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class Interaction : MonoBehaviour
{
    [Header("RayOption")]
    public float checkRate = 0.05f;  //갱신 시간
    private float lastCheckTime;
    public float interactionDistance; //감지 범위
    public LayerMask interactLayer; //감지할 대상 레이어

    private GameObject curInteractObject; //감지대상 정보를 저장할 변수
    private IInteractable curIInteractable;// 대상의 인터페이스 구현 정보를 가져올 변수

    [Header("Text")]
    public TextMeshProUGUI namePrompt; //아이템 이름 프롬프트 텍스트
    public TextMeshProUGUI descriptionPrompt; //아이템 설명 프롬프트 텍스트
    private Camera cam;  //레이가 나갈 카메라

    private void Start()
    {
        cam = Camera.main;
    }

    private void Update()
    {
        if(Time.time - lastCheckTime > checkRate) //갱신 시간 제약
        {
            lastCheckTime = Time.time;

            Ray ray = cam.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));
            //화면 정가운데
            if(Physics.Raycast(ray, out RaycastHit hit, interactionDistance, interactLayer)) //해당하는 레이어의 대상을 감지하였다면
            {
                if(hit.collider.gameObject != curInteractObject) //이미 감지했던 대상과 일치하지 않다면
                {
                    curInteractObject = hit.collider.gameObject;
                    curIInteractable = hit.collider.GetComponent<IInteractable>();
                    PrompTextUpdate();
                }
            }
            else //아니라면 받아왔던 정보를 초기화
            {
                curInteractObject = null;
                curIInteractable = null;
                namePrompt.gameObject.SetActive(false);
                descriptionPrompt.gameObject.SetActive(false);
            }
        }
    }

    private void PrompTextUpdate() //대상에서 가져온 인터페이스의 함수 호출
    {
        namePrompt.gameObject.SetActive(true);
        descriptionPrompt.gameObject.SetActive(true);
        namePrompt.text = curIInteractable.GetPromptNameText();
        descriptionPrompt.text = curIInteractable.GetPromptDescriptionText();
    }

    public void OnInteraction(InputAction.CallbackContext context)
    {
        if(context.phase == InputActionPhase.Started && curIInteractable != null)
        {
            curIInteractable.OnInteract();
            curInteractObject = null;
            curIInteractable = null;
            namePrompt.gameObject.SetActive(false);
            descriptionPrompt.gameObject.SetActive(false);
        }
    }
}