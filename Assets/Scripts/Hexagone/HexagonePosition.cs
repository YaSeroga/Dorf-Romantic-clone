using UnityEngine;
public struct HexagonePosition
{
    public int x;
    public int z;

    /// <summary>
    /// Returns world position evaluate hexagonePosition.
    /// </summary>
    /// <value>Vector3 position</value>
    public Vector3 worldPosition
    {
        get
        {
            Vector3 position = Vector3.zero;
            position.x = x * Hexagone.Width + (0.5f * z * Hexagone.Width);
            position.z = z * Hexagone.Length * 0.75f;
            return position;
        }
    }

    public HexagonePosition(int xCoord, int ZCoord)
    {
        x = xCoord;
        z = ZCoord;
    }

    public HexagonePosition WithX(int xCoord)
    {
        return new HexagonePosition() { x = xCoord, z = this.z };
    }
    public HexagonePosition WithZ(int ZCoord)
    {
        return new HexagonePosition() { x = this.x, z = ZCoord };
    }


    public static HexagonePosition Zero = new HexagonePosition(0, 0);
    public static HexagonePosition RightUpDelta = new HexagonePosition(0, 1);
    public static HexagonePosition RightDelta = new HexagonePosition(1, 0);
    public static HexagonePosition RightDownDelta = new HexagonePosition(1, -1);
    public static HexagonePosition LeftDownDelta = new HexagonePosition(0, -1);
    public static HexagonePosition LeftDelta = new HexagonePosition(-1, 0);
    public static HexagonePosition LeftUpDelta = new HexagonePosition(-1, 1);

    public static bool operator ==(HexagonePosition obj1, HexagonePosition obj2)
    {
        return obj1.x == obj2.x && obj1.z == obj2.z;
    }
    public static bool operator !=(HexagonePosition obj1, HexagonePosition obj2)
    {
        return !(obj1 == obj2);
    }
    public static HexagonePosition operator +(HexagonePosition obj1, HexagonePosition obj2)
    {
        HexagonePosition result = HexagonePosition.Zero;

        result.x = obj1.x + obj2.x;
        result.z = obj1.z + obj2.z;

        return result;
    }

}