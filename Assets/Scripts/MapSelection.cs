using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.Events;

public class MapSelection : MonoBehaviour
{
    [Header("UI References")]
    [SerializeField] private Button[] panelButtons; // 패널 겸 버튼들
    [SerializeField] private RectTransform panelContainer; // 패널들을 포함하는 컨테이너
    [SerializeField] private RectMask2D maskArea; // 마스크 컴포넌트

    [Header("Settings")]
    public float slideDuration = 0.5f; // 슬라이드 애니메이션 지속 시간
    public float panelSpacing = 1000f; // 패널 간의 간격
    [Tooltip("선택된 패널이 정렬될 X 좌표")]
    public float alignmentPositionX = 0f; // 선택된 패널이 정렬될 X 좌표
    [Tooltip("선택된 패널이 정렬될 Y 좌표")]
    public float alignmentPositionY = 0f; // 선택된 패널이 정렬될 Y 좌표
    
    [SerializeField] private int currentIndex = 0; // 현재 활성화된 패널 인덱스
    private bool isSliding = false; // 슬라이딩 중 여부 체크
    
    // 현재 선택된 패널을 다시 클릭했을 때 실행될 이벤트
    public UnityEvent<int> onSelectedPanelClicked;

    private void Start()
    {
        currentIndex = 0;
        SetupButtons();
        InitializePanelPositions(); // 초기 패널 위치 설정
        SetupMaskArea();
    }

    private void SetupMaskArea()
    {
        if (maskArea == null)
        {
            Debug.LogWarning("RectMask2D가 할당되지 않았습니다. Inspector에서 할당해주세요.");
            return;
        }

        // 패널들이 마스크 영역을 벗어나도 계속 렌더링되도록 설정
        foreach (Button button in panelButtons)
        {
            CanvasRenderer canvasRenderer = button.GetComponent<CanvasRenderer>();
            if (canvasRenderer != null)
            {
                canvasRenderer.cullTransparentMesh = false;
            }
        }
    }

    private void InitializePanelPositions() // 위치 초기화
    {
        if (panelContainer == null)
        {
            Debug.LogWarning("Panel Container가 할당되지 않았습니다. Inspector에서 할당해주세요.");
            return;
        }

        // 모든 패널을 초기 위치에 배치
        for (int i = 0; i < panelButtons.Length; i++)
        {
            float xPos = alignmentPositionX + (i - currentIndex) * panelSpacing;
            float yPos = alignmentPositionY;
            panelButtons[i].GetComponent<RectTransform>().anchoredPosition = new Vector2(xPos, yPos);
        }
    }

    private void SetupButtons()
    {
        for (int i = 0; i < panelButtons.Length; i++)
        {
            int idx = i; // 클로저 문제 방지
            panelButtons[i].onClick.AddListener(() => HandleButtonClick(idx));
        }
    }

    private void HandleButtonClick(int index)
    {
        if (index == currentIndex)
        {
            // 현재 선택된 패널을 다시 클릭했을 때
            onSelectedPanelClicked?.Invoke(index);
        }
        else
        {
            // 다른 패널로 이동
            ShowPanel(index);
        }
    }

    public void ShowPanel(int index)
    {
        // 슬라이딩 중이면 무시
        if (isSliding) return;

        isSliding = true;

        // 선택된 패널이 alignmentPosition에 오도록 모든 패널의 위치 계산
        float offset = (currentIndex - index) * panelSpacing;
        
        foreach (Button button in panelButtons)
        {
            RectTransform rectTransform = button.GetComponent<RectTransform>();
            float currentX = rectTransform.anchoredPosition.x;
            float targetX = currentX + offset;
            
            rectTransform.DOAnchorPosX(targetX, slideDuration)
                .SetEase(Ease.OutCubic);
        }

        // 애니메이션 완료 후 처리
        DOVirtual.DelayedCall(slideDuration, () =>
        {
            currentIndex = index;
            isSliding = false;
        });
    }

    // 런타임에서 정렬 위치를 변경하는 메서드
    public void SetAlignmentPosition(float newPositionX, float newPositionY)
    {
        alignmentPositionX = newPositionX;
        alignmentPositionY = newPositionY;
        if (!isSliding)
        {
            ShowPanel(currentIndex); // 현재 선택된 패널을 새로운 정렬 위치로 이동
        }
    }
}
