[System.Flags]
public enum Biome : short
{
    None = 0,
    Everything = short.MaxValue,
    Town = 1 << 1, // 1
    Forest = 1 << 2, // 2
    Field = 1 << 3, // 4
    Water = 1 << 4, // 8
    Rails = 1 << 5, // 16


}