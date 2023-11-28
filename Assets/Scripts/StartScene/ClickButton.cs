using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickButton : MonoBehaviour
{
    private Image buttonImage;
    public Sprite newImage;

    // Start is called before the first frame update
    void Start()
    {

        buttonImage = GetComponent<Image>();

        Button button = GetComponent<Button>();
        if (button != null)
        {
            button.onClick.AddListener(ChangeImage);
        }
    }

    void ChangeImage()
    {
        // 이미지 변경
        if (newImage != null)
        {
            buttonImage.sprite = newImage;
        }
    }
}
