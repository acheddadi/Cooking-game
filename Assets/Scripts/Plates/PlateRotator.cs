using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateRotator : MonoBehaviour
{
    [SerializeField] private Transform targetPosition;
    [SerializeField] private Vector3 rotateAboutLocalPoint;
    [SerializeField] private RotationAxis rotateAboutAxis = RotationAxis.X;
    [SerializeField] private float rotationRadius = 2.0f, rotationSpeed = 3.0f;

    private enum RotationAxis { X, Y, Z };
    private Vector3 rotationAxis, rotateAboutPoint;

    // Start is called before the first frame update
    void Start()
    {
        targetPosition.position = rotateAboutPoint = transform.TransformPoint(rotateAboutLocalPoint);
        switch (rotateAboutAxis)
        {
            case RotationAxis.X:
                rotationAxis = Vector3.right;
                targetPosition.position += Vector3.up * rotationRadius;
                break;
            case RotationAxis.Y:
                rotationAxis = Vector3.up;
                targetPosition.position += Vector3.forward * rotationRadius;
                break;
            case RotationAxis.Z:
                rotationAxis = Vector3.forward;
                targetPosition.position += Vector3.right * rotationRadius;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        targetPosition.RotateAround(rotateAboutPoint, rotationAxis, rotationSpeed * Time.deltaTime);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(targetPosition.position, 0.25f);
    }

    public Vector3 GetTargetPosition()
    {
        return targetPosition.position;
    }
}
