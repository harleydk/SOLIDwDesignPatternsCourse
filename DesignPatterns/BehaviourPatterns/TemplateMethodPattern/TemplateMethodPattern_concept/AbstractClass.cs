namespace TemplatePattern
{
    /// <summary>
    /// The 'AbstractClass' abstract class.
    /// </summary>
    internal abstract class AbstractClass
    {
        public abstract void PrimitiveOperation1();

        public abstract void PrimitiveOperation2();

        // The "Template method"
        public void TemplateMethod()
        {
            PrimitiveOperation();
            PrimitiveOperation1();
            PrimitiveOperation2();
        }

        private void PrimitiveOperation()
        {
            // All implementations execute this method.
        }
    }
}