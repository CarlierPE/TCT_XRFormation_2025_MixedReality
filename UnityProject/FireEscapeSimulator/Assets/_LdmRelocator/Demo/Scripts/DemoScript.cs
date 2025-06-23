
using UnityEngine;
namespace Ldm.Relocator
{
    public class DemoScript : MonoBehaviour
    {
        [SerializeField] TriangleBasedRelocator TriangleRelocator;
        [Header("First Test Triangle")]
        [SerializeField] Transform TestTriangle1_A;
        [SerializeField] Transform TestTriangle1_B;
        [SerializeField] Transform TestTriangle1_C;
        [Space(10)]
        [Header("Second Test Triangle")]
        [SerializeField] Transform TestTriangle2_A;
        [SerializeField] Transform TestTriangle2_B;
        [SerializeField] Transform TestTriangle2_C;
        [Space(10)]
        [Header("Anchor base relocation")]
        [SerializeField] AnchorBasedRelocator AnchorBasedRelocator;
        [SerializeField] Transform AnchorToRelocateTo;

        void Start()
        {
            TriangleRelocator.SpawnFittingRelocatable(TestTriangle1_A.position, TestTriangle1_B.position, TestTriangle1_C.position, 0.1f);
            TriangleRelocator.SpawnFittingRelocatable(TestTriangle2_A.position, TestTriangle2_B.position, TestTriangle2_C.position, 0.1f);
            AnchorBasedRelocator.Relocate(new Pose(AnchorToRelocateTo.position, AnchorToRelocateTo.rotation));
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}