/* 
 * Scene 1
 *  - 아무 키나 누를 씨, 2.EnterName 씬으로 넘어가는 기능.
 *  
 * Scene 2
 *  - Name_Inputfield : 이름 입력칸
 *  - Check_Duplication_Button : Name_Inputfield > Text Area > Text에 적힌 데이터 값이 서버 DB에 있는 데이터 값과 중복된
 *                               내용이 있는지 확인. 확인 될 시 Start_Button에 확인 시그널 보내기.
 *  - Start Button : 확인 시그널이 도착될 시 활성화, 3.MainTitle 씬으로 이동
 *  
 * Scene 3
 *  - Start_Button : 4.Select_GameMode 씬으로 이동
 *  - To_Tutorial_Button : 튜토리얼 맵으로 이동
 *  - Option_Button : 9.Paused_Screen(In-Game)에 있는 에셋 사용해서 옵션 팝업
 *  - Exit_Button : 프로그램 종료
 *  
 *  - PlayerName : 플레이어 이름 표기
 *  - Change_Name_Button : 2.EnterName 씬으로 이동
 *  - PlayerCharacterShowcase : 플레이어가 마지막으로 사용했던 아바타 표기 (Idle 모션)
 *  
 * Scene 4
 *  - GameMode_Selection_Background (1vs1) : 게임 모드를 1vs1로 변경 > 5.Ready_Match 씬으로 이동
 *  - GameMode_Selection_Background (2vs2) : 게임 모드를 2vs2로 변경 > 5.Ready_Match 씬으로 이동
 *  
 * Scene 5
 *  - ToCustomizeCharacter_B : Character_Items 표기
 *  - SelectMap_B : {SelectedMapList}에 선택한 맵 리스트 표기
 *  - Map_Item_Panel : 맵 클릭 시, 선택. 스와이프로 리스트 넘기기
 *  - PlayerCharacterShowcase : 플레이어가 마지막으로 사용했던 아바타 표기 (Idle 모션)
 *  - Start : 6.Matching 씬으로 이동
 * 
 * Scene 6 
 *  - Text에 변수에 맞게 넣기.
 *  
 * Scene 7
 *  - Animation ShowCase : 걷는 애니메이션 실루엣과 로딩 글자 애니메이션
 *  
 * Scene 8
 *  - Timer : 타이머 - 알잘딱하게 변수 표기
 *  - Portrait : 남은 제한 시간에 따라 초상화 스프라이트 변경
 *  - Time_L,M,R : 제한 시간. 파랑팀은 왼>중>오로 줄어들고, 붉은팀은 오>중>왼으로 줄어듬.
 *  - Text (TMP) : 쓰여진 변수 대로 재료 이미지 삽입.
 *  - Score : 각 팀 스코어
 * 
 * Scene 9
 *  - Display - Screen Resoultion : 표기된 내용 대로 해상도 조정 
 *  - Display - Screen Mode : 표기된 내용 대로 화면 모드 조정 
 * 
 *  - Graphic - Texture, Shadow : 텍스쳐와 그림자 품질 조정. 더미 데이터로 두기.
 *  
 *  - Sounds : 소리 조정
 *  
 *  - Key Binding-Button : Prefab-Key Binding 열기.
 *  
 *  - Exit : 창 닫기
 *  
 * Scene 10
 *  - Continue : 5.Ready_Match 씬으로 이동
 *  - Back To Main Menu : 3.MainTitle 씬으로 이동
 *  - Left Game : 프로그램 종료.
 * 
 * */