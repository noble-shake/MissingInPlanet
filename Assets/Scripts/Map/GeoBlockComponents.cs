using Unity.Entities;
using Unity.Mathematics;

public struct GeoBlockTag: IComponentData { }
public struct GeoBlockColor : IComponentData
{
    float4 geoColor;
}

[System.Serializable]
public enum GeoColor
{ 
    FloorB1,
    Floor1,
    Floor2,
    Floor3,
    None,
}

[System.Serializable]
public enum GeoBlock
{ 
    Blocked,
    NonBlocked,
}

public static class GeoColorManager
{
    public static float4 GetColor(GeoColor _color)
    {
        switch (_color)
        {
            case GeoColor.FloorB1:
                return new float4 { x = 0f, y = 0f, w = 0f, z = 0f };
            case GeoColor.Floor1:
                return new float4 { x = 0f, y = 0f, w = 0f, z = 0f };
            case GeoColor.Floor2:
                return new float4 { x = 0f, y = 0f, w = 0f, z = 0f };
            case GeoColor.Floor3:
                return new float4 { x = 0f, y = 0f, w = 0f, z = 0f };
            case GeoColor.None:
            default:
                return new float4 { x = 0f, y = 0f, w = 0f, z = 0f };
        }
    }

    public static float4 BlockBlending(GeoBlock _blocked, float4 origin)
    {
        switch (_blocked)
        {
            case GeoBlock.Blocked:
                return origin * 0.5f + new float4 { x = 0.5f, y = 0f, w = 0f, z = 1f };
            case GeoBlock.NonBlocked:
            default:
                return origin;
            
        }
    }
}