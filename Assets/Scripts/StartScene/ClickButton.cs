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
    public TMP_InputField playerNameInput;// meshPro가 붙은 UI는 using TMPro;를 사용해서 앞에 TMP_를 붙여줘야한다.

    // Start is called before the first frame update
    void Start()
    {

        buttonImage = GetComponent<Image>();
        Button button = GetComponent<Button>();


        if (button != null)
        {
            button.onClick.AddListener(ChangeImage);//버튼 클릭하면 발생하는 메서드에 연결
        }


    }

    void ChangeImage()
    {
        // 이미지 변경
        if (newImage != null)
        {
            buttonImage.sprite = newImage;
        }

        if (playerNameInput != null && !string.IsNullOrEmpty(playerNameInput.text))
        {
            // 입력값을 사용하여 다음 Scene으로 이동
            string playerName = playerNameInput.text;

            // 다음 Scene으로 이동하면서 플레이어 이름을 전달
            SceneManager.LoadScene("MainScene");//현재씬 언로드 후 지정된 씬 불러오기
            PlayerPrefs.SetString("PlayerName", playerName); // 플레이어 이름 저장
            // PlayerPrefs.GetString("PlayerName"); 나중에 이 함수로 가져올 수 있음
        }
        else
        {
            //이 부분은 나중에 따로 이미지나 UI를 사용하여 다르게 구현해준다.
            Debug.Log("플레이어 이름이 비어있습니다.");
        }
    }
}
