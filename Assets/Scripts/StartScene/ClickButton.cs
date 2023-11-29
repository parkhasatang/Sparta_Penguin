using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class ClickButton : MonoBehaviour
{
    private Image buttonImage;
    public Sprite newImage;
    public TMP_InputField playerNameInput;// meshPro�� ���� UI�� using TMPro;�� ����ؼ� �տ� TMP_�� �ٿ�����Ѵ�.

    // Start is called before the first frame update
    void Start()
    {

        buttonImage = GetComponent<Image>();
        Button button = GetComponent<Button>();


        if (button != null)
        {
            button.onClick.AddListener(ChangeImage);//��ư Ŭ���ϸ� �߻��ϴ� �޼��忡 ����
        }


    }

    void ChangeImage()
    {
        // �̹��� ����
        if (newImage != null)
        {
            buttonImage.sprite = newImage;
        }

        if (playerNameInput != null && !string.IsNullOrEmpty(playerNameInput.text))
        {
            // �Է°��� ����Ͽ� ���� Scene���� �̵�
            string playerName = playerNameInput.text;

            // ���� Scene���� �̵��ϸ鼭 �÷��̾� �̸��� ����
            SceneManager.LoadScene("MainScene");//����� ��ε� �� ������ �� �ҷ�����
            PlayerPrefs.SetString("PlayerName", playerName); // �÷��̾� �̸� ����
            // PlayerPrefs.GetString("PlayerName"); ���߿� �� �Լ��� ������ �� ����
        }
        else
        {
            //�� �κ��� ���߿� ���� �̹����� UI�� ����Ͽ� �ٸ��� �������ش�.
            Debug.Log("�÷��̾� �̸��� ����ֽ��ϴ�.");
        }
    }
}
