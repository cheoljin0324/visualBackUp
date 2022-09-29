using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ObjectSetting : MonoBehaviour
{
    [Header("배경 렌더러")]
    public SpriteRenderer backGround;
    [Header("캐릭터 렌더러")]
    public List<SpriteRenderer> charRenderer;
    [Header("이벤트 CG 렌더러")]
    public SpriteRenderer eventCG;
    [Header("다이얼로그 박스 렌더러")]
    public SpriteRenderer dialogueBox;
    [Header("대화 종료 아이콘")]
    public SpriteRenderer endIcon;
    [Header("이름 텍스트UI")]
    public Text nameText;
    [Header("대화 텍스트UI")]
    public Text talkText;
    [Header("선택 버튼")]
    public Button[] selectionbtn;
    [Header("커튼 렌더러(잠시 화면 닫아두기 용)")]
    public SpriteRenderer cutton;
    [Header("이벤트 CG 커튼 렌더러(잠시 화면 닫아두기 용)")]
    public SpriteRenderer EventCGcutton;
    [Header("화면전환 사용 용도")]
    public SpriteRenderer ScreenTransition;
    [Header("CG전환 용도")]
    public SpriteRenderer UseCGTransition;
    [Header("사용 할 버튼 배열 리스트")]
    public List<Button> selectionButton;
    [Header("1인 대화용 스프라이트")]
    public SpriteRenderer oneDialogue;
    [Header("1인 대화용 텍스트")]
    public Text onetalkText;
}
