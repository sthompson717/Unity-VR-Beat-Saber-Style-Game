using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliceCubes : MonoBehaviour
{
    public static void Slice(Transform cube, Vector3 bladePosition, Vector3 contactPointNormal)
    {
        // inspired by https://www.youtube.com/watch?v=QzKfbbqB-1g

        Vector3 cubeVerticalPosition = new Vector3(bladePosition.x, cube.position.y, cube.position.z);
        Vector3 cubeHorizontalPosition = new Vector3(cube.position.x, bladePosition.y, cube.position.z);
        Vector3 cubeScale = cube.localScale;
        Vector3 topmostPoint = cube.position + Vector3.up * cubeScale.x / 2;
        Vector3 bottommostPoint = cube.position - Vector3.up * cubeScale.x / 2;
        Vector3 leftmostPoint = cube.position - Vector3.right * cubeScale.x / 2;
        Vector3 rightmostPoint = cube.position + Vector3.right * cubeScale.x / 2;
        Material cubeMaterial = cube.GetComponent<MeshRenderer>().material;

        GameObject leftSlice = GameObject.CreatePrimitive(PrimitiveType.Cube);
        GameObject rightSlice = GameObject.CreatePrimitive(PrimitiveType.Cube);
        Destroy(leftSlice.GetComponent<BoxCollider>());
        Destroy(rightSlice.GetComponent<BoxCollider>());

        
        if (Vector3.Dot(cube.up, contactPointNormal) > 0 || Vector3.Dot(-cube.up, contactPointNormal) > 0)
        {
            leftSlice.transform.position = (leftmostPoint + cubeVerticalPosition) / 2;
            rightSlice.transform.position = (rightmostPoint + cubeVerticalPosition) / 2;
            float leftSliceWidth = Vector3.Distance(cubeVerticalPosition, leftmostPoint);
            float rightSliceWidth = Vector3.Distance(cubeVerticalPosition, rightmostPoint);
            leftSlice.transform.localScale = new Vector3(leftSliceWidth, cubeScale.y, cubeScale.z);
            rightSlice.transform.localScale = new Vector3(rightSliceWidth, cubeScale.y, cubeScale.z); 
        } else
        {
            leftSlice.transform.position = (topmostPoint + cubeHorizontalPosition) / 2;
            rightSlice.transform.position = (bottommostPoint + cubeHorizontalPosition) / 2;
            float leftSliceHeight = Vector3.Distance(cubeHorizontalPosition, topmostPoint);
            float rightSliceHeight = Vector3.Distance(cubeHorizontalPosition, bottommostPoint);
            leftSlice.transform.localScale = new Vector3(cubeScale.x, leftSliceHeight, cubeScale.z);
            rightSlice.transform.localScale = new Vector3(cubeScale.x, rightSliceHeight, cubeScale.z);
        }

        leftSlice.AddComponent<Rigidbody>();
        rightSlice.AddComponent<Rigidbody>();
        leftSlice.GetComponent<Rigidbody>().useGravity = true;
        rightSlice.GetComponent<Rigidbody>().useGravity = true;
        rightSlice.GetComponent<Rigidbody>().AddForce(Vector3.down * 25f);
        leftSlice.GetComponent<MeshRenderer>().material = cubeMaterial;
        rightSlice.GetComponent<MeshRenderer>().material = cubeMaterial;

        Destroy(cube.gameObject);
        Destroy(leftSlice, 0.25f);
        Destroy(rightSlice, 0.25f);
    }
}
