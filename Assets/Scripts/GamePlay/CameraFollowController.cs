using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowController : MonoBehaviour
{
    public Transform target; // Tham chiếu đến Transform của game object mục tiêu
    public float rotationSpeed = 5f;
    public float distanceFromTarget = 5f;

    private Vector3 lastMousePosition;
    private bool isDragging = false;

    private void Update()
    {
        // Kiểm tra xem người chơi có bắt đầu kéo trên màn hình không
        if (Input.GetMouseButtonDown(0) && Input.mousePosition.x > Screen.width / 2f)
        {
            isDragging = true;
            lastMousePosition = Input.mousePosition;
        }

        // Kiểm tra xem người chơi có kết thúc kéo trên màn hình không
        if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
        }

        // Nếu đang kéo trên màn hình, thực hiện xoay camera
        if (isDragging)
        {
            // Lấy vị trí hiện tại của chuột
            Vector3 currentMousePosition = Input.mousePosition;

            // Tính toán sự thay đổi vị trí chuột so với lần trước
            float deltaX = currentMousePosition.x - lastMousePosition.x;

            // Áp dụng xoay camera dựa trên sự thay đổi vị trí chuột
            RotateCamera(deltaX);

            // Lưu lại vị trí chuột hiện tại để sử dụng cho lần tiếp theo
            lastMousePosition = currentMousePosition;
        }

        // Di chuyển camera gần game object mục tiêu
        MoveCameraToTarget();
    }

    private void RotateCamera(float deltaX)
    {
        // Xoay camera theo hướng ngang (quanh trục Y)
        transform.RotateAround(target.position, Vector3.up, deltaX * rotationSpeed);
    }

    private void MoveCameraToTarget()
    {
        // Tính toán vị trí mới của camera dựa vào khoảng cách từ game object mục tiêu
        Vector3 desiredPosition = target.position - transform.forward * distanceFromTarget;

        // Di chuyển camera đến vị trí mới
        transform.position = desiredPosition;
    }
}
