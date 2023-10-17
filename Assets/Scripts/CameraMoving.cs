using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMoving : MonoBehaviour
{
	public float speed;

	private float x, y;

	public float ShakeAmount;
	float ShakeTime;
	Vector3 initialPosition;


	public float sensitivity = 2.0f;
	public float maxYAngle = 80.0f;

	private Vector2 currentRotation;

	public void VibrateForTime(float time)
	{
		ShakeTime = time;
	}

	void Start()
	{
		transform.GetComponent<Transform>();

		x = transform.rotation.eulerAngles.y;
		y = transform.rotation.eulerAngles.x;

		initialPosition = transform.position;
	}

	void Update()
    {
		// 마우스 입력을 사용하여 카메라 회전 처리
		float mouseX = Input.GetAxis("Mouse X");
		float mouseY = -Input.GetAxis("Mouse Y");

		currentRotation.x += mouseX * sensitivity;
		currentRotation.y += mouseY * sensitivity;
		currentRotation.y = Mathf.Clamp(currentRotation.y, -maxYAngle, maxYAngle);

		transform.localRotation = Quaternion.Euler(currentRotation.y, currentRotation.x, 0);

		if (ShakeTime > 0)
		{
			transform.position = Random.insideUnitSphere * ShakeAmount + initialPosition;
			ShakeTime -= Time.deltaTime;
		}
		else
		{
			ShakeTime = 0.0f;
			transform.position = initialPosition;
		}
    }

}
