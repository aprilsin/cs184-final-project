﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// lightning prefab

public class LightningSegment {
    /** adjustable parameters **/
    public Vector3 startPos;
    public Vector3 direction;
    public float width;
    public float length;
    public Material lightningMaterial;
    private Color color;
    Vector3 DefaultOrientation = Vector3.up;
    public int segmentNumber;

    public GameObject cylinderObject; // the cylinder game object in Unity that represents THIS segment

    public void createSegment() {
        direction = Vector3.Normalize(direction);
        Vector3 rotAxisV = Vector3.Normalize(direction + DefaultOrientation);

        cylinderObject = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        cylinderObject.GetComponent<MeshRenderer>().material = lightningMaterial;
        color = lightningMaterial.GetColor("_EmissionColor");

        cylinderObject.transform.position = startPos + direction * length / 2.0f;
        cylinderObject.transform.rotation = new Quaternion(rotAxisV.x, rotAxisV.y, rotAxisV.z, 0);
        cylinderObject.transform.localScale = new Vector3(0, length / 2.0f, 0);
    }

    public void setBrightness(float newBrightness) {
        Color newColor = Mathf.Min(newBrightness, 0.7f) * color;
        cylinderObject.GetComponent<MeshRenderer>().material.SetColor("_EmissionColor", newColor);
        
        cylinderObject.transform.localScale = new Vector3(newBrightness, length / 2.0f, newBrightness);
    }

    public void destroySegment() {
        Object.Destroy(cylinderObject);
    }
}

