using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Transform _player;
    private Camera _cam;
    public Transform CamTransfrom;

    Vector3 hitPosition;
    private float _mouseX;
    private Vector3 _directionMove;

    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private float _mouseVelocity = 2f;

    private void Start()
    {
        _cam = Camera.main;
        _player = GetComponent<Transform>();
        _directionMove = _player.position;
    }
///////////////////////////////////////////////
    private void Update()
    {
        CamTransfrom.position = _player.position + new Vector3(0,19.7f,-13f);
        InputKey();        
        MousePosition();
    }

    private void FixedUpdate()
    {
        PlayerMove();
    }
///////////////////////////////////////////////

    private void PlayerMove()
    {
        _player.LookAt(hitPosition);
        _player.position += _directionMove;
    }

    private void InputKey()
    {
        _mouseX += Input.GetAxis("Mouse X") * _mouseVelocity;
        _directionMove = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical")).normalized * _moveSpeed;
    }

    private void MousePosition()
    {
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
        {
            Debug.DrawRay(CamTransfrom.position, hit.point, Color.green);
            Debug.Log(hit.point);
            hitPosition = hit.point;
        }
        
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(hitPosition, 1f);    
    }
}
