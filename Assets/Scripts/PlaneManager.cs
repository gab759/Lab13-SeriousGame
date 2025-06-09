using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class PlaneManager : MonoBehaviour
{
    [SerializeField] private ARPlaneManager arPlaneManager;
    [SerializeField] private GameObject model3DPrefab;

    private List<ARPlane> planes = new List<ARPlane>();
    private GameObject model3DPlaced;

    private void OnEnable()
    {
        arPlaneManager.planesChanged += PlanesFound;
    }

    private void OnDisable()
    {
        arPlaneManager.planesChanged -= PlanesFound;
    }

    private void PlanesFound(ARPlanesChangedEventArgs planeData)
    {
        if (planeData.added != null && planeData.added.Count > 0)
        {
            planes.AddRange(planeData.added);
        }

        foreach (var plane in planes)
        {
            if (plane.extents.x * plane.extents.y > 0.4f && model3DPlaced == null)
            {
                model3DPlaced = Instantiate(model3DPrefab);

                // Apuntar hacia la normal del plano
                model3DPlaced.transform.forward = plane.normal;

                // Luego ajustar rotación X a -90 sin perder la rotación en Y y Z
                Vector3 currentEuler = model3DPlaced.transform.eulerAngles;
                model3DPlaced.transform.rotation = Quaternion.Euler(0f, -180f, 0f);

                float yOffset = model3DPlaced.transform.localScale.y / 2;
                model3DPlaced.transform.position = new Vector3(
                    plane.center.x,
                    plane.center.y + yOffset,
                    plane.center.z
                );

                StopPlaneDetection();
            }
        }
    }

    public void StopPlaneDetection()
    {
        arPlaneManager.requestedDetectionMode = PlaneDetectionMode.None;

        foreach (var plane in planes)
        {
            plane.gameObject.SetActive(false);
        }
    }
}
