namespace LiskovSubstitution_GoodDesignWithTemplatePattern
{
    public interface IArmorHitAlarm
    {
        bool HasArmorDroppedBelowThreshold(int currentArmorDefensePoints);

        void RaiseAlarm();
    }
}