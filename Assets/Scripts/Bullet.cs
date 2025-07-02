using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 8f;
    private Rigidbody bulletRigidbody;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        bulletRigidbody = GetComponent<Rigidbody>();

        bulletRigidbody.linearVelocity = transform.forward * speed;
        
        Destroy(gameObject, 3f); // Destroy the bullet after 2 seconds
        
    }

    // 트리거 충돌시 자동으로 메소드 실행
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("충돌한 게임 오브젝트: " + other.name);
        //충돌한 상대방 게임 오브젝트가 Player 태그를 가진 경우
        if (other.tag == "Player")
        {
            //상대방 게임 오브젝트에서 PlayerController 컴포넌트를 가져옴
            PlayerController playerController = other.GetComponent<PlayerController>();
            if (playerController != null)
            {
                //메소드 실행
                playerController.Die();
            }
        }
    }

    void Update()
    {
        
    }
}
