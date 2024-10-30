using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace MatCom.Examen;

public class Production {
	public string Head {get; private set; }
	public char[] Body {get; private set; }

	public Production(string head, char[] body) {
		this.Head = head;
		this.Body = body;
	}
}

public class Tree {
	public string Symbol {get; private set;}
	public List<Tree> Children {get; private set;}

	public Tree(string symbol, List<Tree>? children=null) {
		this.Symbol = symbol;
		this.Children = children is null? new (): children;
	}

	public string PrettyString(int indentation=0)
	{
		string spaces = String.Concat(Enumerable.Repeat("    ", indentation));
		IEnumerable<string > children = this.Children.Select(x => x.PrettyString(indentation + 1));
		return $"{spaces}|__ {this.Symbol}" + (this.Children.Count > 0? $"\n{string.Join("\n", children)}" : "");
	}

	public override string ToString() {
		return "TREE\n" + PrettyString();
	}
}