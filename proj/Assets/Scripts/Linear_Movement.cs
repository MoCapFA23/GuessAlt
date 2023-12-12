using System.Collections;
using UnityEditor;
using UnityEngine;

public class Linear_Movement : MonoBehaviour
{
    private Rigidbody _rb;
    private enum Direction { Forward, Back, Left, Right };
    [SerializeField] private Direction _currDir;
    [SerializeField] private float speed;
    public float killTime;
    // Start is called before the first frame update
    public void Start()
    {
        _rb = GetComponent<Rigidbody>();

        StartCoroutine(SelfDestruct());
    }

    // Update is called once per .2 seconds
    public void FixedUpdate()
    {
        switch(_currDir)
        {
            case Direction.Forward:
                _rb.velocity = Vector3.forward*speed;
                break;
            case Direction.Back:
                _rb.velocity = Vector3.back*speed;
                break;
            case Direction.Left:
                _rb.velocity = Vector2.left*speed;
                break;
            case Direction.Right:
                _rb.velocity = Vector2.right*speed;
                break;
            default:
                break;
        }
        _rb.AddForce(Vector3.zero);
    }

    private IEnumerator SelfDestruct()
    {
        yield return new WaitForSeconds(killTime);
        Destroy(gameObject);
    }
}