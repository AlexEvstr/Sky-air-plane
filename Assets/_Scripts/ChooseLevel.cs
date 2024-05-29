using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChooseLevel : MonoBehaviour
{
    private Button button;
    private Image image;
    private int level;

    private void Start()
    {
        button = GetComponent<Button>();
        image = GetComponent<Image>();

        if (button == null || image == null || !int.TryParse(gameObject.name, out level))
        {
            return;
        }

        int bestLevel = PlayerPrefs.GetInt("BestLevel", 1);
        if (bestLevel < level)
        {
            button.enabled = false;
            image.color = new Color(0.5f, 0.5f, 0.5f);
        }
        else
        {
            button.enabled = true;
            image.color = new Color(1f, 1f, 1f);
        }
    }

    public void PickThisLevel()
    {
        if (int.TryParse(gameObject.name, out level))
        {
            PlayerPrefs.SetInt("Level", level);
            SceneManager.LoadScene("GameplayScene");
        }
    }
}
