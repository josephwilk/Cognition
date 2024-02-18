using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class FractureMover : MonoBehaviour
    {
        FracturedObject fracturedComponent;

        [Range(0.00f, 0.09f)]
        public float space = 0.0f;

        public float _space
        {
            get { return space; }
            set { space = value; }
        }

        void Start()
        {
            fracturedComponent = GetComponent<FracturedObject>();
        }

        public void ForceDecomposition()
        {
            if (!fracturedComponent)
            {
                fracturedComponent = GetComponent<FracturedObject>();
            }

            if (Mathf.Equals(space, 0.0f))
            {
                fracturedComponent.SetSingleMeshVisibility(true);
            }
            else
            {
                fracturedComponent.SetSingleMeshVisibility(false);
            }

            foreach (FracturedChunk fracturedChunk in fracturedComponent.ListFracturedChunks)
            {
                fracturedChunk.PreviewDecompositionValue = (space);
                fracturedChunk.UpdatePreviewDecompositionPosition();
            }
        }

        public void Decomposition(float amount)
        {
            space = amount;
        }

        void Update()
        {
            ForceDecomposition();
        }
    }
