using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int level;
    public static GameManager instance;

    public Transform outsideWorld;
    public Transform insideWorld;

    public Player player;
    public Camera cam;

    public Holes hole;
    public Holes theOtherHole;
    [HideInInspector]
    public Vector2 theOtherHoleDefaultPos;

    public GameObject gameOverPanel;
    public GameObject nextLevelPanel;

    private void Awake()
    {
        Time.timeScale = 0.8f;
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        theOtherHoleDefaultPos = insideWorld.position;
    }

    void Start()
    {
        SetHolesActive(false);
    }

    public void SetHolesActive(bool isActive)
    {
        hole.gameObject.SetActive(isActive);
        theOtherHole.gameObject.SetActive(isActive);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            CreateHole(0);
        if (Input.GetMouseButtonDown(1))
            CreateHole(90f);
        if (Input.GetMouseButtonDown(2) || Input.GetKeyDown(KeyCode.Tab))
            SetHolesActive(false);
    }

    public void CreateHole(float angle)
    {
        SetHolesActive(false);
        SetHolesActive(true);
        Vector2 pos = cam.ScreenToWorldPoint(Input.mousePosition);
        hole.transform.position = pos;
        hole.transform.rotation = Quaternion.Euler(Vector3.forward * angle);
        theOtherHole.transform.position = pos + theOtherHoleDefaultPos;
        theOtherHole.transform.rotation = Quaternion.Euler(Vector3.forward * angle);
    }

    public void GameOver()
    {
        gameOverPanel.SetActive(true);
    }

    public void Retry()
    {
        SceneManager.LoadScene(level);  
    }

    public void GotExit()
    {
        nextLevelPanel.SetActive(true);
    }

    public void NextLevel()
    {
        Debug.Log("level " + level + " finished");
        level++;
        if (level > 2)
            level = 0;
        SceneManager.LoadScene(level);
    }

}
