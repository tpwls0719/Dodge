using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameoverText; // 게임 오버 텍스트 게임 오브젝트

    public Text timeText; // 현재 생존 시간 텍스트 UI

    public Text recordText; // 최고 기록 텍스트 UI

    private float surviveTime; // 현재 생존 시간

    private bool isGameOver; // 게임 오버 상태를 나타내는 변수
    
    void Start()
    {
        //생존 시간과 게임 오버 상태를 초기화
        surviveTime = 0;
        isGameOver = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (!isGameOver)
        {
            //생존 시간 갱신
            surviveTime += Time.deltaTime;
            //갱신한 생존 시간을 timeText UI에 표시
            timeText.text = "Time: " + (int)surviveTime;
        }
        else
        {
            //게임 오버인 상태에서 키볻 R키를 누른 경우 
            if (Input.GetKeyDown(KeyCode.R))
            {
                //SampleScene or 숫자로 표현가능 씬을 로드하여 게임을 다시 시작
                SceneManager.LoadScene("SampleScene");
                RestartGame();
            }
        }
    }

    public void RestartGame()
    {
        //SampleScene 씬을 로드
        SceneManager.LoadScene("SampleScene");
    }

    //현재 게임을 게임 오버 상태로 변경하는 메서드
    public void EndGame()
    {
        //현재 상태를 게임 오버 상태로 전환
        isGameOver = true;
        //게임 오버 텍스트 게임 오브젝트를 활성화
        gameoverText.SetActive(true);

        //BestTime 키로 저장된, 이전까지의 최고 기록 가져오기
        float bestTime = PlayerPrefs.GetFloat("BestTime");

        //이전까지의 최고 기록보다 현재 생존 시간이 더 크다면
        if (surviveTime > bestTime)
        {
            //최고 기록의 값을 현재 생존 시간의 값으로 변경
            bestTime = surviveTime;
            //변경죈 최고 기록을 BestTime 키로 저장
            PlayerPrefs.SetFloat("BestTime", bestTime);
        }

        recordText.text = "Best Time: " + (int)bestTime;

    }
}
