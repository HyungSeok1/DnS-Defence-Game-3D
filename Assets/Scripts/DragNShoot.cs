using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DragNShoot : MonoBehaviour
{
    public float dragPower = 1f;
    public Rigidbody rb;
    
    public Vector3 minPower;
    public Vector3 maxPower;

    TrajectoryLine tl;

    Camera cam;
    [SerializeField]
    Vector3 force;
    [SerializeField]
    Vector3 startPoint;
    [SerializeField]
    Vector3 endPoint;
    Vector3 direction;
    Quaternion lookRotation = Quaternion.identity;

    private void Start()
    {
        cam = Camera.main;
        tl = GetComponent<TrajectoryLine>();
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        transform.rotation = Quaternion.Euler(0, lookRotation.eulerAngles.y, 0);
    }

    private void FixedUpdate()
    {
        if (!UI_Controller.attempting && !UI_Controller.isUpgrade){
            if (Input.GetMouseButtonDown(0))
            {
                startPoint = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, cam.transform.position.y - transform.position.y));
            }

            if (Input.GetMouseButton(0)) // 드래그 라인 생성
            {
                Vector3 currentPoint = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, cam.transform.position.y - transform.position.y));
                tl.RenderLine(startPoint, currentPoint);
            }

            if (Input.GetMouseButtonUp(0)) // 드래그 끝나면 발사
            {
                endPoint = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, cam.transform.position.y - transform.position.y));
                force = new Vector3(
                    Mathf.Clamp(startPoint.x - endPoint.x, minPower.x, maxPower.x),
                    0, // Y축은 고정
                    Mathf.Clamp(startPoint.z - endPoint.z, minPower.z, maxPower.z)
                );

                //rb.AddForce(force * power, ForceMode.Impulse);
                rb.velocity = force * dragPower;

                // 이동 방향을 바라보게 설정
                direction = rb.velocity;
                direction.y = 0; // Y축 고정
                lookRotation = Quaternion.LookRotation(direction);
                lookRotation.x = 0;
                lookRotation.z = 0;
                tl.EndLine();
                UI_Controller.attempting = true;
                UI_Controller.attempt += 1;
            }

        }

        // 속도가 일정 수치 이하로 떨어지면 정지
        if (rb.velocity.magnitude < 1f)
        {
            rb.velocity = Vector3.zero;
            UI_Controller.attempting = false;
        }

        // Ensure rotation's x and z are always 0
        transform.rotation = Quaternion.Euler(0, lookRotation.eulerAngles.y, 0);
        
    }

    private void OnCollisionEnter(Collision collision) // 벽에 부딪히면 방향을 바꿔서 속력을 줄이지 않고 계속 이동
    {
        if (collision.gameObject.tag == "Wall")
        {
            direction = rb.velocity;
            direction.y = 0; // Y축 고정
            lookRotation = Quaternion.LookRotation(direction);
            lookRotation.x = 0;
            lookRotation.z = 0;

            // Ensure rotation's x and z are always 0
            transform.rotation = Quaternion.Euler(0, lookRotation.eulerAngles.y, 0);
        }else if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("Enemy Kill");
        }
    }
}
