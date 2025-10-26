using UnityEngine;
public class GameManager : MonoBehaviour
{
    public Transform player;

    void Update()
    {
        // Move the player with arrow keys (for testing)
        float moveX = Input.GetAxis("Horizontal") * Time.deltaTime * 5;
        float moveY = Input.GetAxis("Vertical") * Time.deltaTime * 5;
        player.Translate(new Vector3(moveX, moveY, 0));

        // Press S to save the player’s position
        if (Input.GetKeyDown(KeyCode.S))
        {
            SaveGame();
        }

        // Press L to load the player’s position
        if (Input.GetKeyDown(KeyCode.L))
        {
            LoadGame();
        }
    }

    void SaveGame()
    {
        PlayerData data = new PlayerData();
        data.x = player.position.x;
        data.y = player.position.y;

        SaveSystem.Save(data);
    }

    void LoadGame()
    {
        PlayerData data = SaveSystem.Load();
        if (data != null)
        {
            player.position = new Vector3(data.x, data.y, 0);
        }
    }
}
