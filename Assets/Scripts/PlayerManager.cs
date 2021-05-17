using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayerManager : MonoBehaviour
{
    public static int playerHP = 100;
    public TextMeshProUGUI playerHPText;
    public GameObject bloodOverlay;

    public static bool isGameOver;
    void Start()
    {
        isGameOver = false;
        playerHP = 100;
    }

    // Update is called once per frame
    void Update()
    {
        playerHPText.text = "+" + playerHP;
        if (isGameOver)
        {
            SceneManager.LoadScene("Level");
        }
    }

    public IEnumerator TakeDamage(int damageAmount)
    {
        bloodOverlay.SetActive(true);
        playerHP -= damageAmount;
        if (playerHP <= 0)
            isGameOver = true;

        yield return new WaitForSeconds(1);
        bloodOverlay.SetActive(false);

    }
}
