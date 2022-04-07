using System.Collections.Generic;

namespace Delegates.TreeTraversal
{
    public class ProductCategory
    {
        public List<Product> Products = new List<Product>();
        public List<ProductCategory> Categories = new List<ProductCategory>();
    }

    public class Product
    {
        public string Name;
    }

    public class Job
    {
        public string Name;
        public List<Job> Subjobs = new List<Job>();
    }

    public class BinaryTree<T>
    {
        public BinaryTree<T> Left;
        public BinaryTree<T> Right;
        public T Value;
    }
}
