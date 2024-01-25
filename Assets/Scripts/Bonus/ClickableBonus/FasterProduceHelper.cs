public static class FasterProduceHelper
{
    public static float GetPercentage(float value)
    {
       return (float)value / 100.0f;
    }
    public static float GetPercentageBonus(float value)
    {
        return 1.0f - (float)value;
    }
}