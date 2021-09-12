using UnityEngine;
public struct HexagonPosition
{
    public int X;
    public int Z;

    /// <summary>
    /// Returns world position evaluate hexagonePosition.
    /// </summary>
    /// <value>Vector3 position</value>
    public Vector3 WorldPosition
    {
        get
        {
            Vector3 position = Vector3.zero;
            position.x = X * Hexagon.Width + (0.5f * Z * Hexagon.Width);
            position.z = Z * Hexagon.Length * 0.75f;
            return position;
        }
    }

    public HexagonPosition(int xCoord, int zCoord)
    {
        X = xCoord;
        Z = zCoord;
    }

    public HexagonPosition WithX(int xCoord)
    {
        return new HexagonPosition() { X = xCoord, Z = this.Z };
    }
    public HexagonPosition WithZ(int zCoord)
    {
        return new HexagonPosition() { X = this.X, Z = zCoord };
    }


    public static HexagonPosition Zero = new HexagonPosition(0, 0);
    public static HexagonPosition RightUpDelta = new HexagonPosition(0, 1);
    public static HexagonPosition RightDelta = new HexagonPosition(1, 0);
    public static HexagonPosition RightDownDelta = new HexagonPosition(1, -1);
    public static HexagonPosition LeftDownDelta = new HexagonPosition(0, -1);
    public static HexagonPosition LeftDelta = new HexagonPosition(-1, 0);
    public static HexagonPosition LeftUpDelta = new HexagonPosition(-1, 1);

    public static bool operator ==(HexagonPosition obj1, HexagonPosition obj2)
    {
        return obj1.X == obj2.X && obj1.Z == obj2.Z;
    }
    public static bool operator !=(HexagonPosition obj1, HexagonPosition obj2)
    {
        return !(obj1 == obj2);
    }
    public static HexagonPosition operator +(HexagonPosition obj1, HexagonPosition obj2)
    {
        HexagonPosition result = HexagonPosition.Zero;

        result.X = obj1.X + obj2.X;
        result.Z = obj1.Z + obj2.Z;

        return result;
    }

}