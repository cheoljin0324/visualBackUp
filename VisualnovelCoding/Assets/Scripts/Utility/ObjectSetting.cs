using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ObjectSetting : MonoBehaviour
{
    [Header("��� ������")]
    public SpriteRenderer backGround;
    [Header("ĳ���� ������")]
    public List<SpriteRenderer> charRenderer;
    [Header("�̺�Ʈ CG ������")]
    public SpriteRenderer eventCG;
    [Header("���̾�α� �ڽ� ������")]
    public SpriteRenderer dialogueBox;
    [Header("��ȭ ���� ������")]
    public SpriteRenderer endIcon;
    [Header("�̸� �ؽ�ƮUI")]
    public Text nameText;
    [Header("��ȭ �ؽ�ƮUI")]
    public Text talkText;
    [Header("���� ��ư")]
    public Button[] selectionbtn;
    [Header("Ŀư ������(��� ȭ�� �ݾƵα� ��)")]
    public SpriteRenderer cutton;
    [Header("�̺�Ʈ CG Ŀư ������(��� ȭ�� �ݾƵα� ��)")]
    public SpriteRenderer EventCGcutton;
    [Header("ȭ����ȯ ��� �뵵")]
    public SpriteRenderer ScreenTransition;
    [Header("CG��ȯ �뵵")]
    public SpriteRenderer UseCGTransition;
    [Header("��� �� ��ư �迭 ����Ʈ")]
    public List<Button> selectionButton;
    [Header("1�� ��ȭ�� ��������Ʈ")]
    public SpriteRenderer oneDialogue;
    [Header("1�� ��ȭ�� �ؽ�Ʈ")]
    public Text onetalkText;
}
