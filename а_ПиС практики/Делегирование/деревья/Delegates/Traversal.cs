using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates.TreeTraversal
{
	public static class Traversal
	{
		public static IEnumerable<Tout> Travel<Tin, Tout>
			(Tin root,
			Func<Tin, bool> filter,
			Func<Tin, IEnumerable<Tin>> childSelector,
			Func<Tin, Tout> resultSelector)
		{
			if (filter(root)) yield return resultSelector(root);
            foreach (var result in childSelector(root).SelectMany(child => Travel(child, filter, childSelector, resultSelector)))
                yield return result;
        }

		public static IEnumerable<T> GetBinaryTreeValues<T>(BinaryTree<T> parent)
		{
			return Travel(
				parent, 
				binaryTree => binaryTree.Left == null && binaryTree.Right == null,
				binaryTree => new[] { binaryTree.Left, binaryTree.Right }.Where(way => way != null),
				binaryTree => binaryTree.Value);
		}

		public static IEnumerable<Job> GetEndJobs(Job parent)
		{
			return Travel(
				parent, 
				jobs => jobs.Subjobs.Count == 0,
				jobs => jobs.Subjobs, 
				jobs => jobs);
		}

		public static IEnumerable<Product> GetProducts(ProductCategory parent)
		{
			return Travel<ProductCategory, IEnumerable<Product>>
				(parent, 
				productCategory => productCategory.Products.Count > 0,
				productCategory => productCategory.Categories,
				productCategory => productCategory.Products)
				.SelectMany(productCategory => productCategory);
		}
	}
}