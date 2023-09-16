namespace LiskovSubstitution_BadDesign
{
    public interface IArmorHitAlarm
    {
        bool HasArmorDroppedBelowThreshold(int currentArmorDefensePoints);

        void RaiseAlarm();
    }
}