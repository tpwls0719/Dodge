using UnityEditor.Build.Content;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRigidbody;
    public float speed = 8f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //수평과 수직 축 입력 값을 감지하여 저장
        float xInput = Input.GetAxis("Horizontal");
        //Debug.Log("xInput: " + xInput);

        float zInput = Input.GetAxis("Vertical");
        //Debug.Log("zInput: " + zInput);

        //실제 이동 속도를 입력 값과 이동 속력을 통해 결정
        float xspeed = xInput * speed;
        float zspeed = zInput * speed;

        //Vector3 속도를 (xspeed, 0f, zspeed)로 설정
        Vector3 newVelocity = new Vector3(xspeed, 0f, zspeed);
        //리지드바디의 속도에 newVelocity를 적용
        playerRigidbody.linearVelocity = newVelocity;

    }

    public void Die()
    {
        //자신의 게임 오브젝트를 비활성화
        gameObject.SetActive(false);
        GameManager gameManager = FindFirstObjectByType<GameManager>();
        //가져온 GameManager 오브젝트의 EndGame 메서드를 실행
        gameManager.EndGame();
    }
}
