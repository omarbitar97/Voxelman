using Unity.Entities;
using UnityEngine;

public class VoxelizerAuthoring : MonoBehaviour
{
    [SerializeField] float _voxelSize = 0.05f;
    [SerializeField] float _voxelLife = 0.3f;
    [SerializeField] float _colorFrequency = 0.5f;
    [SerializeField] float _colorSpeed = 0.5f;
    [SerializeField] float _gravity = 0.2f;
    [SerializeField] GameObject _prefab; // Add a field for the prefab

    class Baker : Baker<VoxelizerAuthoring>
    {
        public override void Bake(VoxelizerAuthoring src)
        {
            var data = new Voxelizer()
            {
                VoxelSize = src._voxelSize,
                VoxelLife = src._voxelLife,
                ColorFrequency = src._colorFrequency,
                ColorSpeed = src._colorSpeed,
                Gravity = src._gravity,
                Prefab = GetEntity(src._prefab, TransformUsageFlags.Dynamic) // Bake the prefab
            };
            AddComponent(GetEntity(TransformUsageFlags.None), data);
        }
    }
}

public struct Voxelizer : IComponentData
{
    public float VoxelSize;
    public float VoxelLife;
    public float ColorFrequency;
    public float ColorSpeed;
    public float Gravity;
    public Entity Prefab; // Add this field

}
