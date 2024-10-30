using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace MatCom.Examen;

public static class Solution 
{

	public static Tree DeriveFromGrammar(Tree start, int iterations, Production[] productions, Func<int> sampler)
	{
		void Derivate(Tree node , Production[] productions,Func<int> sampler)
		{
			int sample = sampler.Invoke() & productions.Length;
			int currentSample = -1;
			if (productions.Where(x => x.Head == node.Symbol).Count() == 0) return;
			while(currentSample != sample)
			{
				for (int i = 0; i < productions.Length; i++)
				{
					// if there is no production head equals to node symbol we pass
					if (productions[i].Head == node.Symbol)
					{
						currentSample++;
						var productionBody = productions[i].Body;
						if (productionBody is not null && currentSample == sample)
						{
							for (int j = 0; j < productionBody.Length; j++)
							{
								Tree child = new Tree(productionBody[j].ToString());
								node.Children.Add(child);
							}
							break;
						}
					}
				}
			}
		}
		void Mutate(Tree node, Production[] productions, Func<int> sampler)
		{

			// we need to derivate children nodes.

			if (node.Children.Count is not 0)
			{
				for (int i = 0; i < node.Children.Count; i++)
				{
					Derivate(node.Children[i], productions, sampler);
				}
			}

			Derivate(node, productions, sampler);

		}

		// crossing is duplicating non-leaf nodes
		void Cross(ref Tree node)
		{
			if (node.Children.Count == 0)
				return;

			string symbol = node.Symbol;
			Tree crossed = new Tree(symbol += node.Symbol, node.Children);
			node = crossed;

			for (int i = 0; i < node.Children.Count; i++)
			{
				var child = node.Children[i];
				Cross(ref child);
				node.Children[i] = child;
			}

		}

		for (int i = 0; i < iterations; i++)
		{
			// System.Console.WriteLine($"Original {i}");
			// System.Console.WriteLine(start.PrettyString());
			// System.Console.WriteLine("========================");
			Mutate(start, productions, sampler);
			// System.Console.WriteLine($"Mutated {i}");
			// System.Console.WriteLine(start.PrettyString());
			// System.Console.WriteLine("========================");
			Cross(ref start);
			// System.Console.WriteLine($"Crossed {i}");
			// System.Console.WriteLine(start.PrettyString());
			// System.Console.WriteLine("========================");
		}
		// Environment.Exit(0);
		return start;
	}
	
	
}