namespace CompositePattern_concept
{
    /// <summary>
    /// The composite pattern describes a group of objects that is treated the same way as a single instance
    /// of the same type of object. The intent of a composite is to "compose" objects into tree structures to represent
    /// part-whole hierarchies. Implementing the composite pattern lets clients treat individual objects and compositions uniformly.
    /// </summary>
    internal class Program
    {
        private static void Main()
        {
            // Create a tree structure
            Composite root = new();
            root.Add(new Leaf("Leaf A"));
            root.Add(new Leaf("Leaf B"));

            Composite comp = new();
            comp.Add(new Leaf("Leaf XA"));
            comp.Add(new Leaf("Leaf XB"));

            root.Add(comp);
            root.Add(new Leaf("Leaf C"));

            // Add and remove a leaf
            Leaf leaf = new("Leaf D");
            root.Add(leaf);
            root.Remove(leaf);

            // Recursively display tree
            root.Display(1);
        }
    }
}