using UnityEngine;

public class LastMinuteAdjustementSpaceMono : MonoBehaviour
{
    public Transform m_whatToMove;
    public Transform m_playerHead;

    public Vector2 m_moveHorizontalJoystick; // x = left-right, y = forward-back
    public Vector2 m_moveVerticalAndRotate;  // x = rotation, y = up-down

    public float m_moveSpeed = 1f;
    public float m_rotationSpeed = 90f;
    public float m_deathZone = 0.1f;

    public void SetJoystickDownUpRotate(Vector2 joystick)
    {
        m_moveVerticalAndRotate = joystick;
    }

    public void SetJoystickHorizontal(Vector2 joystick)
    {
        m_moveHorizontalJoystick = joystick;
    }

    void Update()
    {
        // Apply dead zone to joystick inputs
        Vector2 horizontalInput = ApplyDeadZone(m_moveHorizontalJoystick, m_deathZone);
        Vector2 verticalAndRotateInput = ApplyDeadZone(m_moveVerticalAndRotate, m_deathZone);

        float upDown = verticalAndRotateInput.y;     // Vertical movement (Y axis)
        float rotate = verticalAndRotateInput.x;     // Y-axis rotation input
        float leftRight = horizontalInput.x;         // Horizontal movement (X axis)
        float forwardBack = horizontalInput.y;       // Forward/back movement (Z axis)

        // Calculate flat forward and right directions based on the head orientation
        Vector3 flatForward = m_playerHead.forward;
        flatForward.y = 0f;
        flatForward.Normalize();

        Vector3 flatRight = m_playerHead.right;
        flatRight.y = 0f;
        flatRight.Normalize();

        // Combine movement directions
        Vector3 moveDirection = (flatForward * forwardBack + flatRight * leftRight) * m_moveSpeed * Time.deltaTime;
        moveDirection += Vector3.up * upDown * m_moveSpeed * Time.deltaTime;

        // Apply movement
        m_whatToMove.Translate(moveDirection, Space.World);

        // Apply rotation around player's Y-axis
        if (Mathf.Abs(rotate) > 0f)
        {
            Quaternion rotationFrom = Quaternion.identity;
            Quaternion rotationTo = Quaternion.Euler(0, rotate * m_rotationSpeed * Time.deltaTime, 0);
            RotateTargetAroundPointByCreatingEmpyPoint(m_whatToMove, m_playerHead.position, rotationFrom, rotationTo);
        }
    }

    private Vector2 ApplyDeadZone(Vector2 input, float deadZone)
    {
        return new Vector2(
            Mathf.Abs(input.x) < deadZone ? 0f : input.x,
            Mathf.Abs(input.y) < deadZone ? 0f : input.y
        );
    }

    public static void RotateTargetAroundPointByCreatingEmpyPoint(Transform whatToMove, Vector3 pivot, Quaternion rotationFrom, Quaternion rotationTo)
    {
        // TEMPORARY HACK: rotates an object around a point using a temporary parent
        Quaternion toRotate = rotationTo * Quaternion.Inverse(rotationFrom);

        GameObject mirrorObject = new GameObject();
        mirrorObject.transform.position = whatToMove.position;
        mirrorObject.transform.rotation = whatToMove.rotation;
        GameObject temp = new GameObject("TempPivot");
        Transform pivotTransform = temp.transform;
        pivotTransform.position = pivot;
        mirrorObject.transform.parent = pivotTransform;
        pivotTransform.rotation *= toRotate;

        whatToMove.position = mirrorObject.transform.position;
        whatToMove.rotation = mirrorObject.transform.rotation;

        if (Application.isPlaying)
        {
            Destroy(temp);
            Destroy(mirrorObject);
        }
        else { 
            DestroyImmediate(temp);
            DestroyImmediate(mirrorObject);
        }
    }
}
